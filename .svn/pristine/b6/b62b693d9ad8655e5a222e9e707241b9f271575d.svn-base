using System;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RoundTheClockSchedule : RecurringMinuteSchedule
    {
        public RoundTheClockSchedule(Date startDate, Date endDate, Time startTime, Time endTime, int frequency,
            Site site)
            : base(startDate, endDate, startTime, endTime, frequency, site)
        {
        }

        public RoundTheClockSchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            int frequency, DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, frequency, lastInvokedDateTime, site)

        {
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.RoundTheClock; }
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return
                new RoundTheClockScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
                    frequency).GetNextInvokeDateTime();
        }
    }
}