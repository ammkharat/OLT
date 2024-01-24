using System;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class RecurringHourlyScheduleCalculator : AbstractRecurringFrequencyScheduleCalculator
    {
        private readonly int frequency;

        public RecurringHourlyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
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
            var calculatedNextInvokeDateTime = currentCalculatedNextInvokeDateTime.AddHours(frequency);
            return RollForwardInvokeTimeIfNotInRange(calculatedNextInvokeDateTime);
        }

        protected bool IsInvokeTimeInTimeRange(DateTime calculatedNextInvokeDateTime)
        {
            var timeOfNextInvokeDateTime = new Time(calculatedNextInvokeDateTime);
            var startTime = new Time(startDateTime);
            var endTime = new Time(endDateTime);
            return timeOfNextInvokeDateTime.InRange(startTime, endTime);
        }

        private DateTime RollForwardInvokeTimeIfNotInRange(DateTime calculatedNextInvokeDateTime)
        {
            var startTime = new Time(startDateTime);

            // if next invoke time is not within the time range, then set it to next start time
            if (!IsInvokeTimeInTimeRange(calculatedNextInvokeDateTime))
            {
                var timeOfNextInvokeDateTime = new Time(calculatedNextInvokeDateTime.TimeOfDay);

                if (timeOfNextInvokeDateTime < startTime)
                    calculatedNextInvokeDateTime =
                        calculatedNextInvokeDateTime.AddMinutes(startTime.TotalMinutes -
                                                                timeOfNextInvokeDateTime.TotalMinutes);
                else
                    calculatedNextInvokeDateTime =
                        calculatedNextInvokeDateTime.AddMinutes((24*60) - timeOfNextInvokeDateTime.TotalMinutes +
                                                                startTime.TotalMinutes);
            }

            return calculatedNextInvokeDateTime;
        }
    }
}