using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RecurringWeeklySchedule : RecurringSchedule
    {
        private readonly List<DayOfWeek> daysOfWeek;
        private readonly int frequency;

        public RecurringWeeklySchedule(Date startDate, Date endDate, Time startTime, Time endTime,
            List<DayOfWeek> daysOfWeek, int frequency, Site site)
            : this(null, startDate, endDate, startTime, endTime, daysOfWeek, frequency, null, site)
        {
        }

        public RecurringWeeklySchedule(long? id, Date startDate, Date endDate, Time startTime, Time endTime,
            List<DayOfWeek> daysOfWeek, int frequency,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            if (daysOfWeek.Count == 0)
            {
                throw new ArgumentException("Must pick at least one day of the week.", "daysOfWeek");
            }

            this.daysOfWeek = daysOfWeek;
            this.frequency = frequency;
        }

        public override bool HasEndTime
        {
            get { return false; }
        }

        public override int Frequency
        {
            get { return frequency; }
        }

        public List<DayOfWeek> DaysOfWeek
        {
            get { return daysOfWeek; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.Weekly; }
        }

        public override string SimpleDescription
        {
            get
            {
                if (EndDate == null &&
                    Equals(StartTime, EndTime) &&
                    Frequency == 1 &&
                    DaysOfWeek.Count == 1)
                {
                    return
                        string.Format(
                            StringResources.RecurringWeeklySchedule_SimpleDescrition_NoEndDate_Frequency_Once,
                            DaysOfWeek[0], StartTime);
                }
                return ToString();
            }
        }

        public override string RecurrencePatternString
        {
            get
            {
                return string.Format(StringResources.RecurringWeeklySchedule_RecurrencePatternString, frequency,
                    daysOfWeek.BuildCommaSeparatedList(day => day.Name));
            }
        }

        public override string BatchingKey
        {
            get
            {
                return EndDate != null
                    ? string.Format("{0} at {1} on {2} with Frequency {3} ending {4}", Type.Name, StartTime,
                        daysOfWeek.BuildCommaSeparatedList(day => day.Name), Frequency, EndDate)
                    : string.Format("{0} at {1} on {2} with Frequency {3} and No End Date", Type.Name, StartTime,
                        daysOfWeek.BuildCommaSeparatedList(day => day.Name), Frequency);
            }
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            var scheduledOccurences = new List<Range<DateTime>>();
            var actionItemStartDateTimeToTest = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day,
                StartTime.Hour,
                StartTime.Minute, 0).AddDays(-1);

            while (actionItemStartDateTimeToTest <= EndDateTime)
            {
                actionItemStartDateTimeToTest = GetNextInvokeDateTime(actionItemStartDateTimeToTest);
                var actionItemOccurence = new Range<DateTime>(actionItemStartDateTimeToTest,
                    new DateTime(actionItemStartDateTimeToTest.Year, actionItemStartDateTimeToTest.Month,
                        actionItemStartDateTimeToTest.Day, EndTime.Hour, EndTime.Minute, 0));
                if (DateRangeUtilities.OccurenceIsInWindow(actionItemOccurence, window))
                {
                    scheduledOccurences.Add(actionItemOccurence);
                }
                if (actionItemStartDateTimeToTest > window.UpperBound) break;
            }
            return scheduledOccurences;
        }




        public bool Contains(DayOfWeek dayOfWeek)
        {
            return daysOfWeek.Contains(dayOfWeek);
        }

        public override string ToString(bool includeEndTime)
        {
            return includeEndTime
                ? string.Format(
                    StringResources.RecurringWeeklySchedule_ToString_IncludeEndTime,
                    frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime, daysOfWeek.BuildCommaSeparatedList(day => day.Name))
                : string.Format(StringResources.RecurringWeeklySchedule_ToString_NotIncludeEndTime,
                    frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate), StartTime, daysOfWeek.BuildCommaSeparatedList(day => day.Name));
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        public override DateTime GetPreviousOccurrence(DateTime someDateTime)
        {
            return someDateTime.AddWeeks(-frequency);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return
                new RecurringWeeklyScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
                    frequency, daysOfWeek).GetNextInvokeDateTime();
        }
    }
}