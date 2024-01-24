using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     Container for time zone information because of the following
    ///     bug:
    ///     http://connect.microsoft.com/VisualStudio/feedback/details/516441/timezoneinfo-does-not-properly-implement-equality
    /// </summary>
    [Serializable]
    public class OltTimeZoneInfo
    {
        private readonly TimeZoneInfo inner;

        private OltTimeZoneInfo(TimeZoneInfo inner)
        {
            this.inner = inner;
        }

        public OltTimeZoneInfo(string timeZoneId)
        {
            inner = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        public string Id
        {
            get { return inner.Id; }
        }

        public static OltTimeZoneInfo Local
        {
            get { return new OltTimeZoneInfo(TimeZoneInfo.Local); }
        }

        public static DateTime ConvertTime(DateTime dateTime, OltTimeZoneInfo sourceTimeZone,
            OltTimeZoneInfo destinationTimeZone)
        {
            if (dateTime == DateTime.MaxValue)
                return DateTime.MaxValue;

            var sourceTimeZoneOffset = sourceTimeZone.GetOffset(dateTime);
            var dateTimeOffset = new DateTimeOffset(dateTime, sourceTimeZoneOffset);
            var convertedDateTime = TimeZoneInfo.ConvertTime(dateTimeOffset, destinationTimeZone.inner);

            return convertedDateTime.DateTime.GetNetworkPortable();
        }

        public override string ToString()
        {
            return inner.DisplayName;
        }

        public override bool Equals(object obj)
        {
            if (!GetType().Equals(obj.GetType()))
                return false;

            var other = (OltTimeZoneInfo) obj;

            return (inner.Id.Equals(other.inner.Id));
        }

        public override int GetHashCode()
        {
            return inner.GetHashCode();
        }

        private TimeSpan GetOffset(DateTime dateTime)
        {
            return inner.GetUtcOffset(dateTime);
        }

        public static OltTimeZoneInfo FindSystemTimeZoneById(string timeZoneId)
        {
            return new OltTimeZoneInfo(TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
        }

        public static DateTime ConvertTimeToUtc(DateTime dateTime, OltTimeZoneInfo sourceTimeZone)
        {
            var dateTimeAsUnspecified = new DateTime(dateTime.Ticks, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeToUtc(dateTimeAsUnspecified, sourceTimeZone.inner);
        }
    }
}