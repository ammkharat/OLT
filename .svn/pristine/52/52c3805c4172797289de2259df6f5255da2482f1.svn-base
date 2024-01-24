using System;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RoundTheClockScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly int frequency;

        public RoundTheClockScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, int frequency)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime)
        {
            if (frequency < 1)
                throw new ArgumentOutOfRangeException(StringResources.RecurringScheduleFrequencyMustBeGreaterThanZero);

            this.frequency = frequency;
        }

        protected override DateTime CalculateNextInvokeDateTime(DateTime currentCalculatedNextInvokeDateTime)
        {
            return currentCalculatedNextInvokeDateTime.AddMinutes(frequency);
        }
    }
}