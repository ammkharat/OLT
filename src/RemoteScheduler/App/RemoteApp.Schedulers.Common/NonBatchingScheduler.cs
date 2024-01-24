using System;
using System.Collections.Generic;
using System.Configuration;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    // This is the main class which will maintain the list of Schedules
    // and also manage them, like rescheduling, deleting schedules etc.
    public class NonBatchingScheduler : INonBatchingScheduler
    {
        private const int NumberOfMinutesToPause = 5;
        private static readonly object lockObject = new Object();

        private static readonly ILog logger = GenericLogManager.GetLogger<NonBatchingScheduler>();

        // next event which needs to be kicked off,
        // this is set when a new Schedule is added or after invoking a Schedule

        // stop watch to count down to the next event
        private readonly IStopWatch blastoffStopWatch;

        // timer used to wait to restart the scheduler after a catastrophic event (e.g. DB down)
        private readonly IStopWatch restartStopWatch;

        private readonly OltTimeZoneInfo schedulerTimeZone;

        private readonly List<TimeZoneConvertedSchedule> upcomingScheduleList =
            new List<TimeZoneConvertedSchedule>();

        private bool holdStopWatch;
        private InitialLoadCountdownState initialLoadCountdownState = new InitialLoadCountdownState(-1, null);
        private TimeZoneConvertedSchedule nextSchedule;

        private IScheduleHandler scheduleHandler;

        public NonBatchingScheduler()
        {
            blastoffStopWatch = new StopWatch(BlastOffHandler);
            restartStopWatch = new StopWatch(RefreshStopWatchHandler);

            schedulerTimeZone =
                SchedulerServiceRegistry.Instance.GetService<ITimeService>().GetTimeZoneInfo(
                    ConfigurationManager.AppSettings["ServerTimeZone"]);

            Clock.TimeZone = schedulerTimeZone;
        }

        public NonBatchingScheduler(IStopWatch blastoffStopWatch, IStopWatch restartStopWatch,
            OltTimeZoneInfo schedulerTimeZone)
        {
            this.blastoffStopWatch = blastoffStopWatch;
            this.restartStopWatch = restartStopWatch;

            this.schedulerTimeZone = schedulerTimeZone;

            Clock.TimeZone = schedulerTimeZone;
        }

        /// <summary>
        ///     Get the number of schedules in the list
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get { return upcomingScheduleList.Count; }
        }

        public IScheduleHandler ScheduleHandler
        {
            set { scheduleHandler = value; }
        }

        public List<TimeZoneConvertedSchedule> Schedules
        {
            get { return upcomingScheduleList; }
        }


        public void StartInitialLoad()
        {
            holdStopWatch = true;
        }

        public void StopScheduler()
        {
            restartStopWatch.Stop();
            blastoffStopWatch.Stop();
        }

        public void InitialLoadComplete()
        {
            holdStopWatch = false;
            if (initialLoadCountdownState.CountdownInMilliseconds >= 0)
            {
                blastoffStopWatch.CountDown(initialLoadCountdownState.CountdownInMilliseconds,
                    initialLoadCountdownState.IntendedNextInvokeDateTime);
            }
        }

        /// <summary>
        ///     Adds a schedule to the list of schedules
        /// </summary>
        /// <param name="schedule"></param>
        public void AddSchedule(ISchedule schedule)
        {
            lock (lockObject)
            {
                // No need to Add the Schedule if it's not Valid. 
                // This will keep from those that are no longer valid even attempting to be added to the list.

                // Why not call this method before calling the method we are in?
                // Reason being is that we have to add and remove events/listensers as a result of this condition.
                if (!schedule.IsNextScheduledTimeValid)
                {
                    logger.WarnFormat(
                        "Schedule Id {0} should not fire. " + Environment.NewLine + " LastInvokeDate: {1} " +
                        Environment.NewLine + " Schedule.ToString(): {2}.",
                        schedule.Id, schedule.LastInvokedDateTime, schedule.ToString());

                    return;
                }

                var convertedSchedule =
                    new TimeZoneConvertedSchedule(schedule, schedulerTimeZone);

                var nextInvokeDateTime = convertedSchedule.NextInvokeDateTime;

                // Using this instead of a Contains check because it is a cleaner comparison rather than comparing entire Schedule objects.
                if (
                    upcomingScheduleList.Exists(
                        scheduleAlreadyInList => scheduleAlreadyInList.Id == convertedSchedule.Id))
                {
                    throw new InvalidOperationException(
                        string.Format("Schedule Id {0} already exists in scheduler", schedule.Id));
                }

                logger.InfoFormat(
                    "Adding schedule id:<{0}> description:<{1}> NextInvokeDateTime server:<{2}> local:<{3}> to list.",
                    schedule.Id, schedule, nextInvokeDateTime, schedule.NextInvokeDateTime);

                var shouldAdjustNextEventTime =
                    HasEarlierNextInvokeDateTimeThanOtherUpcomingSchedules(nextInvokeDateTime);

                // adjust the next event time if schedule is added at the top of the list
                if (shouldAdjustNextEventTime)
                {
                    // purposely duplicating code because we need to stop the stopwatch before adding this item, otherwise we end up with threading issues. 
                    // See Mingle #998
                    blastoffStopWatch.Stop();
                    upcomingScheduleList.Add(convertedSchedule);
                    SetNextEventTime();
                }
                else
                {
                    upcomingScheduleList.Add(convertedSchedule);
                }
            }
        }

        /// <summary>
        ///     Remove schedule by id
        /// </summary>
        /// <param name="scheduleId"></param>
        public void RemoveSchedule(ISchedule scheduleToRemove)
        {
            var scheduleId = scheduleToRemove.IdValue;
            lock (lockObject)
            {
                var scheduleIndex =
                    upcomingScheduleList.FindIndex(schedule => schedule.IdValue == scheduleId);

                if (scheduleIndex != -1)
                {
                    if (scheduleIndex == 0)
                    {
                        // Stop it immediately.  Don't let it accidently fire before we removed it.
                        blastoffStopWatch.Stop();
                    }

                    upcomingScheduleList.RemoveAt(scheduleIndex);

                    if (scheduleIndex == 0)
                    {
                        // Only need to reset the Timer if the item we removed was at the top of the list
                        SetNextEventTime();
                    }
                }
            }
        }

        // The reason for this method is to allow the removal of schedules but not run the 'SetNextEventTime' method for each one. This
        // is to avoid causing the blastoff timer to go off on a schedule that is about to be removed.
        public void RemoveMatchingSchedules(Predicate<TimeZoneConvertedSchedule> predicate)
        {
            lock (lockObject)
            {
                var schedules = upcomingScheduleList.FindAll(predicate);

                var needToResetNextEventTime = false;

                foreach (var schedule in schedules)
                {
                    var scheduleIndex = upcomingScheduleList.FindIndex(s => s.IdValue == schedule.Id);

                    if (scheduleIndex == -1)
                    {
                        continue;
                    }
                    if (scheduleIndex == 0)
                    {
                        needToResetNextEventTime = true;
                    }
                    // Get the internal ISchedule and remove All listeners to it.
                    try
                    {
                        upcomingScheduleList.RemoveAt(scheduleIndex);
                    }
                    catch (Exception e)
                    {
                        logger.Error("There was an error removing a schedule from the upcoming schedule list", e);
                    }
                }

                if (needToResetNextEventTime)
                    SetNextEventTime();
            }
        }


        public void DumpScheduleListToLog()
        {
            var readList =
                new List<ISchedule>(
                    Array.ConvertAll(upcomingScheduleList.ToArray(),
                        ConvertToLocal));

            foreach (var schedule in readList)
            {
                logger.Debug(schedule.ToString());
            }
        }

        public OltTimeZoneInfo GetSchedulerTimeZone()
        {
            var serverTimeZoneAsString = ConfigurationManager.AppSettings["ServerTimeZone"];

            if (string.IsNullOrEmpty(serverTimeZoneAsString))
            {
                throw new TimeZoneConversionException("Could not find a configuration setting for ServerTimeZone");
            }
            return
                OltTimeZoneInfo.FindSystemTimeZoneById(serverTimeZoneAsString);
        }

        public void BlastOffHandler(DateTime? intendedScheduleExecutionTime)
        {
            if (nextSchedule != null)
            {
                nextSchedule.SetLastInvokedDateTime(intendedScheduleExecutionTime);
                scheduleHandler.OnScheduleTrigger(nextSchedule.Schedule, intendedScheduleExecutionTime);

                if (nextSchedule.IsNextScheduledTimeValid)
                {
                    SetNextEventTime();
                }
                else
                {
                    RemoveSchedule(nextSchedule.Schedule);
                }
            }
        }

        private static int CompareNextInvokeDateTime(TimeZoneConvertedSchedule x, TimeZoneConvertedSchedule y)
        {
            if (x == null || y == null)
                throw new ApplicationException("Either x or y is null when it should not be.");

            return x.Id == y.Id ? 0 : DateTime.Compare(x.NextInvokeDateTime, y.NextInvokeDateTime);
        }

        private void RefreshStopWatchHandler(DateTime? intendedExecutionTime)
        {
            SetNextEventTime();
        }

        public TimeSpan TimeUntilExecution(DateTime rightNow, DateTime intendedExecutionTime)
        {
            return intendedExecutionTime.Subtract(rightNow);
        }

        /// <summary>
        ///     This method is used to set the time when the timer should wake up to invoke the next schedule
        /// </summary>
        public void SetNextEventTime()
        {
            lock (lockObject)
            {
                try
                {
                    blastoffStopWatch.Stop();

                    if (upcomingScheduleList.Count != 0)
                    {
                        if (logger.IsDebugEnabled)
                            logger.Debug("Starting Sorting of Items in Scheduler...");
                        upcomingScheduleList.Sort(CompareNextInvokeDateTime);
                        nextSchedule = upcomingScheduleList[0];

                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("Finished Sorting of Items in Scheduler.");
                            logger.DebugFormat("The next schedule is: {0}", nextSchedule.Id);
                        }

                        var rightNow = Clock.Now;
                        var intendedExecutionTime = nextSchedule.NextInvokeDateTime;

                        var ts = TimeUntilExecution(rightNow, intendedExecutionTime);

                        if (ts < TimeSpan.Zero)
                            ts = TimeSpan.Zero; // cannot be negative !

                        var localCountdownMilliseconds = (long) ts.TotalMilliseconds;

                        initialLoadCountdownState =
                            new InitialLoadCountdownState(localCountdownMilliseconds, intendedExecutionTime);

                        if (logger.IsDebugEnabled)
                        {
                            logger.Debug("SetNextEventTime - countdown timespan: " + ts);
                            logger.Debug("SetNextEventTime - intendedExecutionTime: " + intendedExecutionTime);
                            logger.Debug("SetNextEventTime - rightNow: " + rightNow);
                            logger.Debug("SetNextEventTime - rightNow + timespan: " + rightNow.Add(ts));
                        }

                        if (!holdStopWatch)
                        {
                            blastoffStopWatch.CountDown(localCountdownMilliseconds, intendedExecutionTime);
                                // invoke after the timespan
                        }
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

                        blastoffStopWatch.Stop();
                        restartStopWatch.Stop();
                        // Hold the scheduler, and attempt to fire things in 5 more minutes.
                        restartStopWatch.CountDown((long) NumberOfMinutesToPause.Minutes().TotalMilliseconds,
                            Clock.Now.AddMinutes(NumberOfMinutesToPause));
                    }
                    else
                        throw;
                }
            }
        }

        private static bool IsDatabaseConnectionError(Exception exception)
        {
            return exception.ToString().Contains("System.Data.SqlClient.SqlException");
        }

        private bool HasEarlierNextInvokeDateTimeThanOtherUpcomingSchedules(DateTime nextInvokeDateTime)
        {
            logger.DebugFormat(
                "Starting check for new schedule NextInvokeDateTime:{0} being earlier than other schedules.",
                nextInvokeDateTime.ToLongDateAndTimeString());

            if (upcomingScheduleList.Count == 0)
            {
                logger.Debug("Finished check. No other schedules.");
                return true;
            }
            if (nextInvokeDateTime < upcomingScheduleList[0].NextInvokeDateTime)
            {
                logger.DebugFormat("Finished check. Earlier than existing schedule NextInvokeDateTime:<{0}>",
                    upcomingScheduleList[0].NextInvokeDateTime.ToLongDateAndTimeString());
                return true;
            }

            logger.Debug("Finished check. Not earlier than other schedules.");
            return false;
        }

        private static ISchedule ConvertToLocal(TimeZoneConvertedSchedule convertedSchedule)
        {
            return convertedSchedule.Schedule;
        }
    }
}