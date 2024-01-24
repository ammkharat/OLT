using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TimeZoneFixture
    {
        public static OltTimeZoneInfo GetSarniaTimeZone()
        {
            return new OltTimeZoneInfo("Eastern Standard Time");
        }

        public static OltTimeZoneInfo GetMountainTimeZone()
        {
            return new OltTimeZoneInfo("Mountain Standard Time");
        }

    }
}
