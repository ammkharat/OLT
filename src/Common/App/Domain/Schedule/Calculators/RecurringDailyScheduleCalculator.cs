using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringDailyScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly int frequency;
        private readonly bool everyShift;
        private readonly List<ShiftPattern> shifts;
        
        public RecurringDailyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime, int frequency)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime)
        {
            if (frequency < 1)
                throw new ArgumentOutOfRangeException(StringResources.RecurringScheduleFrequencyMustBeGreaterThanZero);

            this.frequency = frequency;
        }

        //RITM0265710 mangesh
        public RecurringDailyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
           DateTime endDateTime,
           DateTime? lastInvokedDateTime, int frequency, bool everyShift, List<ShiftPattern> shifts)
            : base(timeZoneInfo, startDateTime, endDateTime, lastInvokedDateTime)
        {
            if (frequency < 1)
                throw new ArgumentOutOfRangeException(StringResources.RecurringScheduleFrequencyMustBeGreaterThanZero);

            this.frequency = frequency;
            this.everyShift = everyShift;
            this.shifts = shifts;
        }
        
        protected override DateTime CalculateNextInvokeDateTime(DateTime currentCalculatedNextInvokeDateTime)
        {
            //RITM0265710 mangesh
            if (everyShift)
            {
                if (shifts.Count > 0)
                {
                    var shiftLength = shifts[0].ShiftLength.Hours;
                    return currentCalculatedNextInvokeDateTime.AddHours(shiftLength);
                }
            }
            return currentCalculatedNextInvokeDateTime.AddDays(frequency);
        }
    }
}