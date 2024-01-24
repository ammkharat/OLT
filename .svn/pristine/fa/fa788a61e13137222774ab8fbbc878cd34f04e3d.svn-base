using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Client.Services
{
    public class TimeServiceCache : ITimeService
    {
        private readonly ITimeService targetTimeService;
        private readonly ExpiringCache<OltTimeZoneInfo, TimeSpanWrapper> timeZoneDeltaCache;

        public TimeServiceCache(ITimeService iTimeService, TimeSpan timeout)
        {
            targetTimeService = iTimeService;
            timeZoneDeltaCache = new ExpiringCache<OltTimeZoneInfo, TimeSpanWrapper>(timeout, new OltTimeZoneInfoComparer());
        }

        public DateTime GetTime(OltTimeZoneInfo clientTimeZone)
        {
            return LocalTime.Add(GetDelta(clientTimeZone));
        }

        public Date GetDate(OltTimeZoneInfo clientTimeZone)
        {
            return new Date(LocalTime.Add(GetDelta(clientTimeZone)));
        }

        public OltTimeZoneInfo GetTimeZoneInfo(string timeZoneName)
        {
            return targetTimeService.GetTimeZoneInfo(timeZoneName);
        }

        private TimeSpan GetDelta(OltTimeZoneInfo oltTimeZoneInfo)
        {
            TimeSpanWrapper timeSpanWrapper = timeZoneDeltaCache.Get(oltTimeZoneInfo);

            if (timeSpanWrapper != null) return timeSpanWrapper.TimeSpan;

            DateTime timeInTargetTimeZone = targetTimeService.GetTime(oltTimeZoneInfo);
            TimeSpan timeSpan = timeInTargetTimeZone.Subtract(LocalTime);
            timeZoneDeltaCache.Add(oltTimeZoneInfo, new TimeSpanWrapper(timeSpan));
            return timeSpan;
        }

        private static DateTime LocalTime
        {
            get { return DateTime.Now.GetNetworkPortable(); }
        }
    }

    internal class OltTimeZoneInfoComparer : EqualityComparer<OltTimeZoneInfo>
    {
        public override bool Equals(OltTimeZoneInfo x, OltTimeZoneInfo y)
        {
            return x.Equals(y);
        }

        public override int GetHashCode(OltTimeZoneInfo obj)
        {
            return obj.GetHashCode();
        }
    }

    // Wrap the TimeSpan which is a struct into a class.  By doing so, we can represent a NULL value which
    //   indicates that no TimeSpan value was found in the Cache.  We cannot rely on a TimeSpan of 00:00:00
    //   to indicate absence from the cache as it is possible that the client and server are exactly in sync.
    internal class TimeSpanWrapper
    {
        private readonly TimeSpan timeSpan;

        public TimeSpanWrapper(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        public TimeSpan TimeSpan
        {
            get { return timeSpan; }
        }
    }

}
