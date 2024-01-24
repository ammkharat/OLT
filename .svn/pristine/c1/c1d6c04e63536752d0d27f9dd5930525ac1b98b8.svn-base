using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    public class ContinuousScheduleCalculator : IScheduleCalculator
    {
        private readonly DateTime endDateTime;
        private readonly DateTime startDateTime;
        private readonly OltTimeZoneInfo timeZoneInfo;

        public ContinuousScheduleCalculator(OltTimeZoneInfo timeZoneInfo, DateTime startDateTime, DateTime endDateTime)
        {
            this.timeZoneInfo = timeZoneInfo;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }

        public DateTime GetNextInvokeDateTime()
        {
            var currentDateTime =
                OltTimeZoneInfo.ConvertTime(Clock.Now, Clock.TimeZone, timeZoneInfo);

            var currentCalculatedNextInvokeDateTime = currentDateTime > endDateTime
                ? Constants.PAST_END_TIME
                : startDateTime;

            return currentCalculatedNextInvokeDateTime;
        }
    }
}