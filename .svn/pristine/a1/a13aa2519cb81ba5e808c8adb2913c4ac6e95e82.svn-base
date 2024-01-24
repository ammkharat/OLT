using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class TimeZoneConvertedSchedule
    {
        private static readonly IComparer<TimeZoneConvertedSchedule> sortComparer =
            new TimeZoneConvertedScheduleComparer();

        private readonly ILog logger = GenericLogManager.GetLogger<TimeZoneConvertedSchedule>();

        private readonly ISchedule schedule;
        private readonly OltTimeZoneInfo schedulerTimeZone;

        private bool dirty;
        // Stores nextInvokeDateTime in the timezone of the Scheduler
        private DateTime? nextInvokeDateTime;

        public TimeZoneConvertedSchedule(ISchedule schedule, OltTimeZoneInfo schedulerTimeZone)
        {
            this.schedule = schedule;
            this.schedulerTimeZone = schedulerTimeZone;
        }

        public ISchedule Schedule
        {
            get { return schedule; }
        }

        public long IdValue
        {
            get { return schedule.Id.Value; }
        }

        public long? Id
        {
            get { return schedule.Id; }
        }

        public DateTime NextInvokeDateTime
        {
            get
            {
                if (NextInvokeDateTimeIsStale())
                {
                    if (logger.IsDebugEnabled)
                        logger.Debug("NextInvokeDateTimeIsStale. Recalculating NextInvokeDateTime");

                    nextInvokeDateTime =
                        OltTimeZoneInfo.ConvertTime(schedule.NextInvokeDateTime, schedule.Site.TimeZone,
                            schedulerTimeZone);
                    dirty = false;
                }
                return nextInvokeDateTime.Value;
            }
        }

        public DateTime? LastInvokedDateTime
        {
            get { return schedule.LastInvokedDateTime; }
            set
            {
                dirty = true;
                schedule.LastInvokedDateTime = value;
            }
        }

        public bool IsNextScheduledTimeValid
        {
            get { return schedule.IsNextScheduledTimeValid; }
        }

        public static IComparer<TimeZoneConvertedSchedule> SortComparer
        {
            get { return sortComparer; }
        }

        private bool NextInvokeDateTimeIsStale()
        {
            return !nextInvokeDateTime.HasValue || dirty;
        }

        public void SetLastInvokedDateTime(DateTime? intendedScheduleExecutionTime)
        {
            var rightNow = Clock.Now;

            if (intendedScheduleExecutionTime != null && rightNow < intendedScheduleExecutionTime)
            {
                // This is here because occasionally, for reasons probably related to the windows time server, the event is 
                // firing slightly early and causing duplicate definition evaluations.

                logger.DebugFormat(
                    "A scheduled event was triggered before the intended time. Time: {0}, Intended Execution Time: {1}, Schedule: {2}",
                    rightNow, intendedScheduleExecutionTime, schedule);

                LastInvokedDateTime =
                    OltTimeZoneInfo.ConvertTime(intendedScheduleExecutionTime.Value, schedulerTimeZone,            
                        schedule.Site.TimeZone);

            }
            else
            {
                // Persisting the schedule's last invoked date time should take place when the trigger event happens in
                // the appropriate scheduling service.
                LastInvokedDateTime =
                    OltTimeZoneInfo.ConvertTime(rightNow, schedulerTimeZone, schedule.Site.TimeZone);
            }

            logger.InfoFormat("Event triggered for schedule {0}. Setting LastInvokedDateTime as {1}",
                schedule.Id, LastInvokedDateTime);
        }

        private sealed class TimeZoneConvertedScheduleComparer : IComparer<TimeZoneConvertedSchedule>
        {
            public int Compare(TimeZoneConvertedSchedule x, TimeZoneConvertedSchedule y)
            {
                if (x == null || y == null)
                    throw new ApplicationException("Either x or y is null when it should not be.");

                return x.Id == y.Id ? 0 : DateTime.Compare(x.NextInvokeDateTime, y.NextInvokeDateTime);
            }
        }
    }
}