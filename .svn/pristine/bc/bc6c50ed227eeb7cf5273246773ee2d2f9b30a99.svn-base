using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RecurringMonthlyDayOfWeekSchedule : RecurringMonthlySchedule
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly WeekOfMonth weekOfMonth;

        public RecurringMonthlyDayOfWeekSchedule(Date startDate, Date endDate, Time fromTime, Time toTime,
            WeekOfMonth weekOfMonth,
            DayOfWeek dayOfWeek, List<Month> monthsToInclude, Site site)
            : base(null, startDate, endDate, fromTime, toTime, monthsToInclude, null, site)
        {
            this.weekOfMonth = weekOfMonth;
            this.dayOfWeek = dayOfWeek;
        }

        public RecurringMonthlyDayOfWeekSchedule(long id, Date startDate, Date endDate, Time fromTime, Time toTime,
            WeekOfMonth weekOfMonth,
            DayOfWeek dayOfWeek, List<Month> monthsToInclude,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, fromTime, toTime, monthsToInclude, lastInvokedDateTime, site)
        {
            this.weekOfMonth = weekOfMonth;
            this.dayOfWeek = dayOfWeek;
        }

        public override bool HasEndTime
        {
            get { return false; }
        }

        public WeekOfMonth WeekOfMonth
        {
            get { return weekOfMonth; }
        }

        public override int Frequency
        {
            get { return 1; }
        }

        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeek; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.MonthlyDayOfWeek; }
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
                        String.Format(
                            StringResources.RecurringMonthlyDayOfWeekSchedule_SimpleDescription_NoEndDate_Frequency_Once,
                            WeekOfMonth, DayOfWeek, StartTime);
                }
                return ToString();
            }
        }

        public override string RecurrencePatternString
        {
            get
            {
                return string.Format(StringResources.RecurringMonthlyDayOfWeekSchedule_RecurrencePatternString,
                    dayOfWeek.Name, weekOfMonth.Name,
                    MonthsToInclude.BuildMonthStringFromMonthList());
            }
        }

        public override string BatchingKey
        {
            get
            {
                return EndDate != null
                    ? string.Format("{0} at {1}, {2} Day of week {3} in months {4} ending {5}", Type.Name, StartTime,
                        DayOfWeek, WeekOfMonth,
                        monthsToInclude.BuildMonthStringFromMonthList(), EndDate)
                    : string.Format("{0} at {1}, {2} Day of week {3} in months {4} with no End Date", Type.Name,
                        StartTime, DayOfWeek, WeekOfMonth,
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




        protected override DayOfMonth GetActualDay(Month month, int year)
        {
            return month.GetByDayOfWeekWeekOfMonth(weekOfMonth, dayOfWeek, year);
        }

        public override string ToString(bool includeEndTime)
        {
            if (includeEndTime)
                return string.Format(
                    StringResources.RecurringMonthlyDayOfWeekSchedule_ToString_IncludeEndTime,
                    dayOfWeek.Name,
                    weekOfMonth.Name,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime, monthsToInclude.BuildMonthStringFromMonthList());

            return string.Format(StringResources.RecurringMonthlyDayOfWeekSchedule_ToString_NoIncludeEndTime,
                dayOfWeek.Name,
                weekOfMonth.Name, Date.ToDateString(StartDate),
                Date.ToDateString(EndDate), StartTime, monthsToInclude.BuildMonthStringFromMonthList());
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return new RecurringMonthlyDayOfWeekScheduleCalculator(Site.TimeZone, StartDateTime, EndDateTime,
                lastInvokedDateTime, monthsToInclude, DayOfWeek,
                WeekOfMonth).GetNextInvokeDateTime();
        }
    }
}