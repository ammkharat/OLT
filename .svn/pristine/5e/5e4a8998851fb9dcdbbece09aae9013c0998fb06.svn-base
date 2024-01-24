using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public abstract class RecurringMonthlySchedule : RecurringSchedule
    {
        protected readonly List<Month> monthsToInclude;

        protected RecurringMonthlySchedule(long? id, Date startDate, Date endDate, Time startTime, Time endTime,
            List<Month> monthsToInclude, DateTime? lastInvokedDateTime,
            Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            this.monthsToInclude = monthsToInclude;
        }

        public List<Month> MonthsToInclude
        {
            get { return monthsToInclude; }
        }

        public bool ContainsMonth(Month month)
        {
            return monthsToInclude.Contains(month);
        }

        protected abstract DayOfMonth GetActualDay(Month month, int year);


        protected DateTime GetFirstEverDateTime()
        {
            var firstMonth = Month.GetFirstMonthIn(monthsToInclude);
            var actualDayOfMonth = GetActualDay(firstMonth, StartDate.Year);

            //Set it as the first possible time that it can be scheduled            
            var firstDateTime =
                new DateTime(StartDate.Year, firstMonth.Value, actualDayOfMonth.Value, StartTime.Hour, StartTime.Minute,
                    0);
            return firstDateTime;
        }


        public override DateTime GetPreviousOccurrence(DateTime someDateTime)
        {
            return someDateTime.AddMonths(-Frequency);
        }
    }
}