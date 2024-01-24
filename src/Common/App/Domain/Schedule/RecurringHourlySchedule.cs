using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    /// <summary>
    ///     A schedule that runs every few hours defined by the frequency
    /// </summary>
    [Serializable]
    public class RecurringHourlySchedule : RecurringSchedule
    {
        private readonly int frequency;

        public RecurringHourlySchedule(Date startDate, Date endDate, Time startTime, Time endTime, int frequency,
            Site site)
            : base(null, startDate, endDate, startTime, endTime, null, site)
        {
            this.frequency = frequency;
        }

        public RecurringHourlySchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            int frequency,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            this.frequency = frequency;
        }

        /// <summary>
        ///     The frequency (in hours) that this schedule is invoked
        /// </summary>
        public override int Frequency
        {
            get { return frequency; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.Hourly; }
        }

        public override string SimpleDescription
        {
            get { return ToString(); }
        }

        public override string RecurrencePatternString
        {
            get { return string.Format(StringResources.RecurringHourlySchedule_RecurrencePatternString, frequency); }
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        public override DateTime GetPreviousOccurrence(DateTime someDateTime)
        {
            return someDateTime.AddHours(-frequency);
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            throw new NotImplementedException(); 
        }

        public override string ToString(bool includeEndTime)
        {
            if (includeEndTime)
            {
                return string.Format(StringResources.RecurringHourlySchedule_ToString_IncludeEndTime, frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime);
            }
            return string.Format(StringResources.RecurringHourlySchedule_ToString_NotIncludeEndTime, frequency,
                Date.ToDateString(StartDate),
                Date.ToDateString(EndDate),
                StartTime);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return
                new RecurringHourlyScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
                    frequency).GetNextInvokeDateTime();
        }
    }
}