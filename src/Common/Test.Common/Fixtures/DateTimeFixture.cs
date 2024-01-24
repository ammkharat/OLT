using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class DateTimeFixture
    {
        public static DateTime DateTimeNow
        {
            get { return DateTime.Now.GetNetworkPortable(); }
        }

        public static Date DateNow
        {
            get { return DateTime.Now.GetNetworkPortable().ToDate(); }
        }
    }
}