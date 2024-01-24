using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringMonthlyDayOfWeekScheduleCalculator : AbstractRecurringMonthlyScheduleCalculator
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly WeekOfMonth weekOfMonth;

        public RecurringMonthlyDayOfWeekScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, List<Month> monthsToInclude, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime, monthsToInclude)
        {
            this.weekOfMonth = weekOfMonth;
            this.dayOfWeek = dayOfWeek;
        }

        protected override DayOfMonth GetActualDay(Month month, int year)
        {
            return month.GetByDayOfWeekWeekOfMonth(weekOfMonth, dayOfWeek, year);
        }
    }
}