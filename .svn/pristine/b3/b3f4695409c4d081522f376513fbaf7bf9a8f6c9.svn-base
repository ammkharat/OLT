using System;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringMinuteScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly int frequency;

        public RecurringMinuteScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
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
            return RollForwardInvokeTimeIfNotInRange(currentCalculatedNextInvokeDateTime.AddMinutes(frequency));
        }

        private DateTime RollForwardInvokeTimeIfNotInRange(DateTime currentCalculatedNextInvokeDateTime)
        {
            // if next invoke time is not within the time range, then set it to next start time
            if (!IsInvokeTimeInTimeRange(currentCalculatedNextInvokeDateTime))
            {
                var timeOfNextInvokeDateTime = new Time(currentCalculatedNextInvokeDateTime.TimeOfDay);
                var startTime = new Time(startDateTime);
                if (timeOfNextInvokeDateTime < startTime)
                    return
                        currentCalculatedNextInvokeDateTime.AddMinutes(startTime.TotalMinutes -
                                                                       timeOfNextInvokeDateTime.TotalMinutes);
                return
                    currentCalculatedNextInvokeDateTime.AddMinutes((24*60) - timeOfNextInvokeDateTime.TotalMinutes +
                                                                   startTime.TotalMinutes);
            }

            return currentCalculatedNextInvokeDateTime;
        }

        private bool IsInvokeTimeInTimeRange(DateTime currentCalculatedNextInvokeDateTime)
        {
            var timeOfNextInvokeDateTime = new Time(currentCalculatedNextInvokeDateTime.TimeOfDay);
            return timeOfNextInvokeDateTime.InRange(new Time(startDateTime), new Time(endDateTime));
        }
    }
}