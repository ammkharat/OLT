using System;
using System.Configuration;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class BatchingScheduler : IBatchingScheduler
    {
        private const int NumberOfMinutesToPause = 5;
        private static readonly object lockObject = new Object();

        private static readonly ILog logger = GenericLogManager.GetLogger<BatchingScheduler>();
        private readonly ScheduleBatchCollection batchCollection;

        // stop watch to count down to the next event
        private readonly IStopWatch eventTimer;

        // timer used to wait to restart the scheduler after a catastrophic event (e.g. DB down)
        private readonly IStopWatch restartEventTimer;

        private readonly OltTimeZoneInfo schedulerTimeZone;
        private IBatchHandler batchHandler;

        private bool holdStopWatch;
        private InitialLoadCountdownState initialLoadCountdownState = new InitialLoadCountdownState(-1, null);

        // Holds the Schedule Batches and is sorted by NextInvokeDateTime via the Schedule Comparer.  
        // The schedule comparer takes into consideration the timezone info when sorting.

        public BatchingScheduler(IStopWatch eventTimer, IStopWatch restartEventTimer, OltTimeZoneInfo schedulerTimeZone)
        {
            this.eventTimer = eventTimer;
            this.restartEventTimer = restartEventTimer;

            this.schedulerTimeZone = schedulerTimeZone;

            batchCollection = new ScheduleBatchCollection(schedulerTimeZone);
            Clock.TimeZone = schedulerTimeZone;
        }

        public BatchingScheduler()
        {
            eventTimer = new StopWatch(BlastOffHandler);
            restartEventTimer = new StopWatch(RefreshStopWatchHandler);

            schedulerTimeZone =
                SchedulerServiceRegistry.Instance.GetService<ITimeService>().GetTimeZoneInfo(
                    ConfigurationManager.AppSettings["ServerTimeZone"]);

            batchCollection = new ScheduleBatchCollection(schedulerTimeZone);
            Clock.TimeZone = schedulerTimeZone;
        }

        public bool IsEmpty
        {
            get { return batchCollection.IsEmpty; }
        }

        public IBatchHandler BatchHandler
        {
            set { batchHandler = value; }
        }

        public void AddSchedule(ISchedule schedule)
        {
            lock (lockObject)
            {
                // No need to Add the Schedule if it's not Valid. 
                // This will keep from those that are no longer valid even attempting to be added to the list.
                if (!schedule.IsNextScheduledTimeValid)
                {
                    logger.WarnFormat(
                        "Schedule Id {0} should not fire. {1} LastInvokeDate: {2} {3} Schedule.ToString(): {4}.",
                        schedule.Id, Environment.NewLine, schedule.LastInvokedDateTime, Environment.NewLine,
                        schedule.ToString(true));

                    return;
                }

                ScheduleBatch batchScheduleAddedInto;
                if (batchCollection.IsEmpty)
                {
                    logger.DebugFormat("Nothing in Scheduler.  This is the first schedule to be added.");
                    batchScheduleAddedInto = batchCollection.AddSchedule(schedule);
                    LogAddToBatch(schedule, batchScheduleAddedInto);
                    SetNextEventTime();
                }
                else if (batchCollection.HasExistingBatchForSchedule(schedule))
                {
                    logger.Debug(
                        "Already an existing Batch for this Schedule.  Adding the Schedule to the existing batch.");
                    batchScheduleAddedInto = batchCollection.AddSchedule(schedule);
                    LogAddToBatch(schedule, batchScheduleAddedInto);
                }
                else
                {
                    logger.Debug("Creating a new Batch for this schedule.");
                    // Add this schedule which creates a new batch.
                    batchScheduleAddedInto = batchCollection.AddSchedule(schedule);
                    LogAddToBatch(schedule, batchScheduleAddedInto);
                    // check to see if the Next Invoke Date Time needs to be adjusted because this new batch takes priority.
                    if (HasEarlierNextInvokeDateTimeThanCurrentlyScheduledBatch(batchScheduleAddedInto))
                    {
                        logger.Debug("Schedule resulted in a batch that should go to the top!");
                        eventTimer.Stop();
                        SetNextEventTime();
                    }
                }
            }
        }

        public void RemoveSchedule(ISchedule schedule)
        {
            lock (lockObject)
            {
                var isOnlyScheduleInFirstBatch = !batchCollection.IsEmpty &&
                                                 batchCollection.IsOnlyScheduleInFirstBatch(schedule);
                if (isOnlyScheduleInFirstBatch)
                {
                    logger.Debug(
                        "Schedule to be removed is the only item in the First Batch. stopping timer and resorting will occur.");

                    // Stop it immediately.  Don't let it accidently fire before we removed it.
                    eventTimer.Stop();

                    // This will also remove the first batch if this schedule was the only one in it.
                    batchCollection.RemoveSchedule(schedule);

                    // Reset the Timer Only need to reset the Timer if the item we removed was at the top of the list
                    SetNextEventTime();
                }
                else
                {
                    batchCollection.RemoveSchedule(schedule);
                }
                logger.DebugFormat("Removed schedule {0} from the Scheduler.", schedule.IdValue);
            }
        }

        public void InitialLoadComplete()
        {
            DumpBatches();
            holdStopWatch = false;
            if (initialLoadCountdownState.CountdownInMilliseconds >= 0)
            {
                eventTimer.CountDown(
                    initialLoadCountdownState.CountdownInMilliseconds,
                    initialLoadCountdownState.IntendedNextInvokeDateTime);
            }
        }

        public void StartInitialLoad()
        {
            holdStopWatch = true;
        }

        public void StopScheduler()
        {
            restartEventTimer.Stop();
            eventTimer.Stop();
        }

        public void BlastOffHandler(DateTime? intendedScheduleExecutionTime)
        {
            if (batchCollection.IsEmpty) return;

            var topScheduleBatch = batchCollection.First;

            logger.DebugFormat("{0}, setting Last Invoked Date to {1} (scheduler time)", topScheduleBatch,
                intendedScheduleExecutionTime);
            var activeSchedules = topScheduleBatch.SetLastInvokedDateTime(intendedScheduleExecutionTime);

            if (!activeSchedules.IsEmpty())
            {
                batchHandler.OnBatchTrigger(topScheduleBatch.BatchingKey, activeSchedules);
            }

            if (topScheduleBatch.IsNextScheduledTimeValid)
            {
                SetNextEventTime();
            }
            else
            {
                eventTimer.Stop();
                batchCollection.RemoveFirst();
                SetNextEventTime();
            }
        }

        private void LogAddToBatch(ISchedule schedule, ScheduleBatch batch)
        {
            logger.DebugFormat("Schedule {0} added to {1}", schedule.IdValue, batch.VerboseToString());
        }

        private void SetNextEventTime()
        {
            lock (lockObject)
            {
                if (batchCollection.IsEmpty)
                    return;

                try
                {
                    eventTimer.Stop();

                    if (logger.IsDebugEnabled)
                        logger.Debug("Starting Sorting of Items in Scheduler...");

                    batchCollection.Sort();

                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("Finished Sorting of Items in Scheduler.");
                        logger.DebugFormat("The next batch set to fire at: {0}",
                            batchCollection.NextInvokeDateTime.ToLongDateAndTimeString());
                    }

                    var rightNow = Clock.Now;
                    var intendedExecutionTime = batchCollection.NextInvokeDateTime;

                    var ts = intendedExecutionTime.Subtract(rightNow);

                    if (ts < TimeSpan.Zero)
                        ts = TimeSpan.Zero; // cannot be negative !

                    var localCountdownMilliseconds = (long) ts.TotalMilliseconds;

                    initialLoadCountdownState =
                        new InitialLoadCountdownState(localCountdownMilliseconds, intendedExecutionTime);

                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat(
                            "SetNextEventTime - countdown timespan: {0}, intendedExecutionTime: {1}, rightNow: {2}, rightNow + timespan: {3}",
                            ts, intendedExecutionTime, rightNow, rightNow.Add(ts));
                    }

                    if (!holdStopWatch)
                    {
                        eventTimer.CountDown(localCountdownMilliseconds, intendedExecutionTime);
                            // invoke after the timespan
                    }
                }
                catch (Exception e)
                {
                    if (IsDatabaseConnectionError(e))
                    {
                        logger.ErrorFormat(
                            "Connection to Database failed while attempting to set NextEventTime. Pausing for {0} minutes." +
                            Environment.NewLine +
                            "Message: {1}" + Environment.NewLine + "StackTrace: {2}", NumberOfMinutesToPause, e.Message,
                            e.StackTrace);

                        eventTimer.Stop();
                        restartEventTimer.Stop();
                        // Hold the scheduler, and attempt to fire things in 5 more minutes.
                        restartEventTimer.CountDown((long) NumberOfMinutesToPause.Minutes().TotalMilliseconds,
                            Clock.Now.AddMinutes(NumberOfMinutesToPause));
                    }
                    else
                        throw;
                }
            }
        }

        private void DumpBatches()
        {
            logger.Debug(batchCollection.ToString());
        }

        private void RefreshStopWatchHandler(DateTime? intendedExecutionTime)
        {
            SetNextEventTime();
        }

        private bool HasEarlierNextInvokeDateTimeThanCurrentlyScheduledBatch(ScheduleBatch scheduleBatch)
        {
            logger.DebugFormat(
                "Starting check for new schedule NextInvokeDateTime:{0} being earlier than other schedules.",
                scheduleBatch.NextInvokeDateTime.ToLongDateAndTimeString());


            var shouldBeFirst = batchCollection.ShouldBeFirst(scheduleBatch);

            if (shouldBeFirst)
            {
                logger.DebugFormat("Finished check. Earlier than existing schedule NextInvokeDateTime:<{0}>",
                    batchCollection.First.NextInvokeDateTime.ToLongDateAndTimeString());
            }
            else
            {
                logger.Debug("Finished check. Not earlier than other schedules.");
            }

            return shouldBeFirst;
        }

        private static bool IsDatabaseConnectionError(Exception exception)
        {
            return exception.ToString().Contains("System.Data.SqlClient.SqlException");
        }
    }
}