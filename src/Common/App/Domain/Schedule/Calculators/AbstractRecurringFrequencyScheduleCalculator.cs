using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public abstract class AbstractRecurringFrequencyScheduleCalculator : IScheduleCalculator
    {
        private readonly OltTimeZoneInfo timeZoneInfo;
        protected DateTime endDateTime;
        private DateTime? lastInvokedDateTime;
        protected DateTime startDateTime;

        protected AbstractRecurringFrequencyScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime,
            DateTime endDateTime,
            DateTime? lastInvokedDateTime)
        {
            this.timeZoneInfo = timeZoneInfo;
            this.lastInvokedDateTime = lastInvokedDateTime;
            this.endDateTime = endDateTime;
            this.startDateTime = startDateTime;
        }

        public DateTime GetNextInvokeDateTime()
        {
            return FindNextValidInvokeDateTime();
        }

        private DateTime FindNextValidInvokeDateTime()
        {
            var currentDateTime =
                OltTimeZoneInfo.ConvertTime(Clock.Now, Clock.TimeZone, timeZoneInfo);

            if (currentDateTime > endDateTime)
                return Constants.PAST_END_TIME;

            //Subtracting 1 second from the current datetime allows the schedule to check if Now is 
            //the next scheduled time
            var scheduleLastInvokedDateTime = lastInvokedDateTime.GetValueOrDefault(currentDateTime.AddSeconds(-1));

            var currentCalculatedNextInvokeDateTime = CalculateFirstEverDateTime();

            while (currentCalculatedNextInvokeDateTime <= scheduleLastInvokedDateTime)
            {
                currentCalculatedNextInvokeDateTime =
                    CalculateNextInvokeDateTime(currentCalculatedNextInvokeDateTime);
            }

            if (currentCalculatedNextInvokeDateTime > endDateTime)
            {
                currentCalculatedNextInvokeDateTime = Constants.PAST_END_TIME;
            }

            return currentCalculatedNextInvokeDateTime;
        }

        protected abstract DateTime CalculateNextInvokeDateTime(DateTime currentCalculatedNextInvokeDateTime);

        protected virtual DateTime CalculateFirstEverDateTime()
        {
            return startDateTime;
        }
    }
}