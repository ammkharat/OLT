using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RecurringMinuteSchedule : RecurringSchedule
    {
        protected readonly int frequency;

        public RecurringMinuteSchedule(Date startDate, Date endDate, Time startTime, Time endTime, int frequency,
            Site site)
            : base(null, startDate, endDate, startTime, endTime, null, site)
        {
            this.frequency = frequency;
        }

        public RecurringMinuteSchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            int frequency, DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            this.frequency = frequency;
        }

        public override int Frequency
        {
            get { return frequency; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.ByMinute; }
        }

        public override string SimpleDescription
        {
            get { return ToString(); }
        }

        public override string RecurrencePatternString
        {
            get { return string.Format(StringResources.RecurringMinuteSchedule_RecurrancePatternString, frequency); }
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return
                new RecurringMinuteScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
                    frequency).GetNextInvokeDateTime();
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            throw new NotImplementedException();  
        }

        public override string ToString(bool includeEndTime)
        {
            return includeEndTime
                ? string.Format(StringResources.RecurringMinuteSchedule_ToString_IncludeEndTime, frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime)
                : string.Format(StringResources.RecurringMinuteSchedule_ToString_NotIncludeEndTime, frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate), StartTime);
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        public override DateTime GetPreviousOccurrence(DateTime someDateTime)
        {
            return someDateTime.AddMinutes(-frequency);
        }
    }
}