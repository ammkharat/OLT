using System;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    public class ShiftSchedulingService : ISchedulingService, IScheduleHandler
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ShiftSchedulingService>();

        private readonly IActionItemService actionItemService;
        private readonly INonBatchingScheduler nonBatchingScheduler;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ITimeService timeService;

        private bool stopServiceRequested;

        public ShiftSchedulingService()
            : this(new NonBatchingScheduler(),
                SchedulerServiceRegistry.Instance.GetService<IActionItemService>(),
                SchedulerServiceRegistry.Instance.GetService<IShiftPatternService>(),
                SchedulerServiceRegistry.Instance.GetService<ITimeService>())
        {
        }

        public ShiftSchedulingService(INonBatchingScheduler nonBatchingScheduler, IActionItemService actionItemService,
            IShiftPatternService shiftPatternService, ITimeService timeService)
        {
            nonBatchingScheduler.ScheduleHandler = this;
            this.nonBatchingScheduler = nonBatchingScheduler;

            this.actionItemService = actionItemService;
            this.shiftPatternService = shiftPatternService;
            this.timeService = timeService;
        }

        public void OnScheduleTrigger(ISchedule schedule, DateTime? intendedScheduleExecutionTime)
        {
            try
            {
                if (stopServiceRequested)
                {
                    logger.Debug(String.Format("Stop {0} requested.", ScheduleName));
                    return;
                }

                var siteDateTime = timeService.GetTime(schedule.Site.TimeZone);
                logger.Debug(string.Format("Firing clean up pass shift end for site {0} at {1}.", schedule.Site.Name,
                    siteDateTime));
                actionItemService.UpdateAllResponseNotRequiredActionItemsToCompleteWhenShiftEndHasPassed(schedule.Site);
            }
            catch (Exception e)
            {
                logger.Error("An error occured when shift clean up was triggered at " + Clock.Now, e);
            }
        }

        public void LoadScheduler()
        {
            var shifts = shiftPatternService.QueryAll();

            nonBatchingScheduler.StartInitialLoad();

            foreach (var shift in shifts)
            {
                var currentDate = timeService.GetDate(shift.Site.TimeZone);

                ISchedule schedule =
                    new RecurringDailySchedule(shift.IdValue, currentDate, null, shift.EndTime, shift.EndTime.Add(1), 1,
                        null, shift.Site);

                nonBatchingScheduler.AddSchedule(schedule);
            }
            nonBatchingScheduler.InitialLoadComplete();

            logger.Debug("<START> Schedule information for Action Item End Of Shift Clean Up");
            nonBatchingScheduler.DumpScheduleListToLog();
            logger.Debug("<END> Schedule information for Action Item End Of Shift Clean Up");
        }

        public string ScheduleName
        {
            get { return "Shift Scheduler"; }
        }

        public void StopService()
        {
            stopServiceRequested = true;
            nonBatchingScheduler.StopScheduler();
        }
    }
}