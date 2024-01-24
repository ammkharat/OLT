using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITimeDao : IDao
    {
        DateTime GetTime(OltTimeZoneInfo clientTimeZone);
        Date GetDate(OltTimeZoneInfo clientTimeZone);
        OltTimeZoneInfo GetOltTimeZoneInfo(string timeZoneName);
    }
}