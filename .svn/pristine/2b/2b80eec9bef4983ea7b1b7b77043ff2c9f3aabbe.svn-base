using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RecurringMonthlyDayOfMonthSchedule : RecurringMonthlySchedule
    {
        private readonly DayOfMonth dayOfMonth;

        public RecurringMonthlyDayOfMonthSchedule(Date startDate, Date endDate, Time fromTime, Time toTime,
            DayOfMonth dayOfMonth,
            List<Month> monthsToInclude, Site site) :
                base(
                null, startDate, endDate, fromTime, toTime, monthsToInclude, null,
                site)
        {
            this.dayOfMonth = dayOfMonth;
        }

        public RecurringMonthlyDayOfMonthSchedule(long id, Date startDate, Date endDate, Time fromTime, Time toTime,
            DayOfMonth dayOfMonth, List<Month> monthsToInclude,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, fromTime, toTime, monthsToInclude, lastInvokedDateTime, site)
        {
            this.dayOfMonth = dayOfMonth;
        }

        public override bool HasEndTime
        {
            get { return false; }
        }

        public DayOfMonth DayOfMonth
        {
            get { return dayOfMonth; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.MonthlyDayOfMonth; }
        }

        public override string SimpleDescription
        {
            get
            {
                if (EndDate == null &&
                    Equals(StartTime, EndTime) &&
                    Frequency == 1 &&
                    monthsToInclude.TrueForAll(obj => Month.All.Exists(month => Equals(month, obj))))
                {
                    return
                        string.Format(
                            StringResources.
                                RecurringMonthlyDayOfMonthSchedule_SimpleDescription_NoEndDate_Frequency_Once,
                            DayOfMonth.NthName, StartTime);
                }
                return ToString();
            }
        }

        public override string RecurrencePatternString
        {
            get
            {
                return string.Format(StringResources.RecurringMonthlyDayOfMonthSchedule_RecurrencePatternString,
                    dayOfMonth.Value,
                    monthsToInclude.BuildMonthStringFromMonthList());
            }
        }

        public override string BatchingKey
        {
            get
            {
                return EndDate != null
                    ? string.Format("{0} at {1}, {2} Day of Months {3} ending {4}", Type.Name, StartTime, dayOfMonth,
                        monthsToInclude.BuildMonthStringFromMonthList(), EndDate)
                    : string.Format("{0} at {1}, {2} Day of Months {3} with no End Date", Type.Name, StartTime,
                        dayOfMonth,
                        monthsToInclude.BuildMonthStringFromMonthList());
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




        public override int Frequency
        {
            get { return 1; }
        }

        protected override DayOfMonth GetActualDay(Month month, int year)
        {
            return dayOfMonth.GetActualDay(month, year);
        }

        public override string ToString(bool includeEndTime)
        {
            if (includeEndTime)
                return string.Format(StringResources.RecurringMonthlyDayOfMonthSchedule_ToString_IncludeEndTime,
                    dayOfMonth.NthName,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime,
                    monthsToInclude.BuildMonthStringFromMonthList());
            return string.Format(StringResources.RecurringMonthlyDayOfMonthSchedule_ToString_NotIncludeEndTime,
                dayOfMonth.NthName,
                Date.ToDateString(StartDate),
                Date.ToDateString(EndDate), StartTime, monthsToInclude.BuildMonthStringFromMonthList());
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return new RecurringMonthlyDayOfMonthScheduleCalculator(site.TimeZone, StartDateTime,
                EndDateTime, lastInvokedDateTime, monthsToInclude, dayOfMonth).GetNextInvokeDateTime();
        }
    }
}