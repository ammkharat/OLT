using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringWeeklyScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly List<DayOfWeek> daysOfWeek;
        private readonly int frequency;

        public RecurringWeeklyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, int frequency,
            List<DayOfWeek> daysOfWeek)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime)
        {
            this.frequency = frequency;
            this.daysOfWeek = daysOfWeek;
        }

        protected override DateTime CalculateNextInvokeDateTime(DateTime currentCalculatedNextInvokeDateTime)
        {
            var lastInvokeDayOfWeek = DayOfWeek.ConvertFromSystem(currentCalculatedNextInvokeDateTime.DayOfWeek);
            if (lastInvokeDayOfWeek.IsLastDayOfWeekIn(daysOfWeek) && frequency > 1)
            {
                currentCalculatedNextInvokeDateTime =
                    currentCalculatedNextInvokeDateTime.AddDays(7*(frequency - 1));
            }

            currentCalculatedNextInvokeDateTime = currentCalculatedNextInvokeDateTime.AddDays(1);
            currentCalculatedNextInvokeDateTime = RollDayForwardToASelectedDay(currentCalculatedNextInvokeDateTime);

            return currentCalculatedNextInvokeDateTime;
        }

        protected override DateTime CalculateFirstEverDateTime()
        {
            return RollDayForwardToASelectedDay(base.CalculateFirstEverDateTime());
        }

        private DateTime RollDayForwardToASelectedDay(DateTime dateTimeToRollForward)
        {
            var result = dateTimeToRollForward;

            var dayOfWeek = DayOfWeek.ConvertFromSystem(dateTimeToRollForward.DayOfWeek);

            if (!daysOfWeek.Contains(dayOfWeek))
            {
                var closest = dayOfWeek.GetClosestForwardDayOfWeekIn(daysOfWeek);
                result = dateTimeToRollForward.AddDays(closest - dayOfWeek);
            }

            return result;
        }
    }
}