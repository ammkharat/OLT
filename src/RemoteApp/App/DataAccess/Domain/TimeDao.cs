using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TimeDao : AbstractManagedDao, ITimeDao
    {
        private readonly OltTimeZoneInfo serviceTimeZone;
        
        public TimeDao(string timeZoneOfService)
        {
            serviceTimeZone = GetOltTimeZoneInfo(timeZoneOfService);
        }

        public Date GetDate(OltTimeZoneInfo clientTimeZone)
        {
            return new Date(GetTime(clientTimeZone));
        }

        public DateTime GetTime(OltTimeZoneInfo clientTimeZone)
        {            
            return OltTimeZoneInfo.ConvertTime(DateTime.Now.GetNetworkPortable(), serviceTimeZone, clientTimeZone);
        }

        public OltTimeZoneInfo GetOltTimeZoneInfo(string timeZoneName)
        {
            return new OltTimeZoneInfo(timeZoneName);
        }
    }
}