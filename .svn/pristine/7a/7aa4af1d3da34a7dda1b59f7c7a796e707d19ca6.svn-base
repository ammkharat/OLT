using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public abstract class AbstractRecurringMonthlyScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly List<Month> monthsToInclude;

        protected AbstractRecurringMonthlyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, List<Month> monthsToInclude)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime)
        {
            this.monthsToInclude = monthsToInclude;
        }

        protected override DateTime CalculateNextInvokeDateTime(DateTime currentCalculatedNextInvokeDateTime)
        {
            var lastCalculatedNextInvokeMonth = Month.GetByMonth(currentCalculatedNextInvokeDateTime.Month);
            Month nextMonth;
            var year = currentCalculatedNextInvokeDateTime.Year;
            if (lastCalculatedNextInvokeMonth.IsLastMonthIn(monthsToInclude))
            {
                year++;
                nextMonth = Month.GetFirstMonthIn(monthsToInclude);
            }
            else
            {
                nextMonth = lastCalculatedNextInvokeMonth.GetNextMonthIn(monthsToInclude);
            }

            var actualDayOfMonth = GetActualDay(nextMonth, year);
            currentCalculatedNextInvokeDateTime =
                new DateTime(year, nextMonth.Value, actualDayOfMonth.Value, startDateTime.Hour,
                    startDateTime.Minute, startDateTime.Second);

            return currentCalculatedNextInvokeDateTime;
        }

        protected override DateTime CalculateFirstEverDateTime()
        {
            var firstMonth = Month.GetFirstMonthIn(monthsToInclude);
            var actualDayOfMonth = GetActualDay(firstMonth, startDateTime.Year);

            //Set it as the first possible time that it can be scheduled            
            var firstDateTime =
                new DateTime(startDateTime.Year, firstMonth.Value, actualDayOfMonth.Value, startDateTime.Hour,
                    startDateTime.Minute, 0);
            return firstDateTime;
        }

        protected abstract DayOfMonth GetActualDay(Month month, int year);
    }
}