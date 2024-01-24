using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TimeService : ITimeService
    {
        private readonly ITimeDao timeDao;

        public TimeService(ITimeDao timeDao)
        {
            this.timeDao = timeDao;
        }
        
        public TimeService(): this(DaoRegistry.GetDao<ITimeDao>())
        {
        }

        public Date GetDate(OltTimeZoneInfo clientTimeZone)
        {
            return timeDao.GetDate(clientTimeZone);
        }

        public DateTime GetTime(OltTimeZoneInfo clientTimeZone)
        {
            return timeDao.GetTime(clientTimeZone).GetNetworkPortable();
        }

        public OltTimeZoneInfo GetTimeZoneInfo(string timeZoneName)
        {
            return timeDao.GetOltTimeZoneInfo(timeZoneName);
        }
    }
}