using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class ScheduleComparer : IComparer<ISchedule>
    {
        #region IComparer<ISchedule> Members

        public int Compare(ISchedule x, ISchedule y)
        {
            var xNextInvokeDateTime = x.NextInvokeDateTime;
            var yNextInvokeDateTime = y.NextInvokeDateTime;

            var xDateTime = xNextInvokeDateTime == DateTime.MaxValue
                ? xNextInvokeDateTime
                : OltTimeZoneInfo.ConvertTimeToUtc(xNextInvokeDateTime, x.Site.TimeZone);
            var yDateTime = yNextInvokeDateTime == DateTime.MaxValue
                ? yNextInvokeDateTime
                : OltTimeZoneInfo.ConvertTimeToUtc(yNextInvokeDateTime, y.Site.TimeZone);

            return DateTime.Compare(xDateTime, yDateTime);
        }

        #endregion
    }

    public class ScheduleNextInvokeComparer : IComparer<TimeZoneConvertedSchedule>
    {
        public int Compare(TimeZoneConvertedSchedule x, TimeZoneConvertedSchedule y)
        {
            if (x == null || y == null)
                throw new ApplicationException("Either x or y is null when it should not be.");

            return x.Id == y.Id ? 0 : DateTime.Compare(x.NextInvokeDateTime, y.NextInvokeDateTime);
        }
    }
}