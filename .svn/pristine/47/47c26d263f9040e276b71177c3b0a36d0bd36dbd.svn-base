using System;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    // TODO:  Move to extension method of ISchedule?
    public class ScheduleHelper
    {
        // TODO: (Troy/Eric) Potential Refactoring is to make this a method in ISchedule and implement if statement in Abstract Recurring Schedule
        // and else inside the SingleSchedule and Continuous Schedule.
        public static DateTime GetScheduleInstanceStartDateTime(ISchedule schedule, DateTime currentDateTimeAtSite,
            int preShiftPaddingInMinutes)
        {
            if (schedule.IsRecurring)
            {
                var startTime = schedule.StartTime;
                var endTime = schedule.EndTime;
                var today = new Date(currentDateTimeAtSite);
                var nowTime = new Time(currentDateTimeAtSite);

                if (!schedule.CrossesDayBoundary && nowTime > endTime)
                {
                    today = today.AddDays(1);
                }
                else if (schedule.CrossesDayBoundary && nowTime.AddMinutes(preShiftPaddingInMinutes) < endTime)
                {
                    today = today.SubtractDays(1);
                }
                return today.CreateDateTime(startTime);
            }
            return schedule.StartDateTime;
        }

        // TODO: (Troy/Eric) Potential Refactoring is to make this a method in ISchedule and implement if statement in Abstract Recurring Schedule,
        // elseif inside the Continuous Schedule, and else inside SingleSchedule.
        public static DateTime GetScheduleInstanceEndDateTime(ISchedule schedule, DateTime currentDateTimeAtSite,
            int preShiftPaddingInMinutes)
        {
            // TODO:  This is not subtracting correctly to account for DST switch over.
            if (schedule.IsRecurring || ScheduleType.Single.Equals(schedule.Type))
            {
                var span = schedule.EndTime - schedule.StartTime;
                if (span.TotalSeconds < 0)
                {
                    var timeSpan = new TimeSpan(24, 0, 0);
                    span = span + timeSpan;
                }
                var startTime = GetScheduleInstanceStartDateTime(schedule, currentDateTimeAtSite,
                    preShiftPaddingInMinutes);
                return startTime.Add(span);
            }
            return ScheduleType.Continuous == schedule.Type
                ? schedule.EndDateTime
                : schedule.StartDate.CreateDateTime(schedule.EndTime);
        }
    }
}