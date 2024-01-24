using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class SingleScheduleCalculator : IScheduleCalculator
    {
        private readonly DateTime endDateTime;
        private readonly DateTime startDateTime;
        private readonly OltTimeZoneInfo timeZoneInfo;

        public SingleScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime, DateTime endDateTime)
        {
            this.timeZoneInfo = timeZoneInfo;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }

        public DateTime GetNextInvokeDateTime()
        {
            var currentDateTime =
                OltTimeZoneInfo.ConvertTime(Clock.Now, Clock.TimeZone, timeZoneInfo);

            if (currentDateTime > endDateTime)
            {
                return Constants.PAST_END_TIME;
            }

            var currentCalculatedNextInvokeDateTime = startDateTime;
            if (currentCalculatedNextInvokeDateTime < currentDateTime)
            {
                currentCalculatedNextInvokeDateTime = currentDateTime;
            }

            return currentCalculatedNextInvokeDateTime;
        }
    }
}