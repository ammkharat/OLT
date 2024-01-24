using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringMonthlyDayOfMonthScheduleCalculator : AbstractRecurringMonthlyScheduleCalculator
    {
        private readonly DayOfMonth dayOfMonth;

        public RecurringMonthlyDayOfMonthScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, List<Month> monthsToInclude, DayOfMonth dayOfMonth)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime, monthsToInclude)
        {
            this.dayOfMonth = dayOfMonth;
        }


        // Gets the day of the month.  Used for things like, day of month being set to 30th, but the month is February
        protected override DayOfMonth GetActualDay(Month month, int year)
        {
            return dayOfMonth.GetActualDay(month, year);
        }
    }
}