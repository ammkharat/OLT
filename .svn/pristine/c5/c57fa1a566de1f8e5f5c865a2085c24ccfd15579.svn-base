using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITimeService
    {
        [OperationContract]
        DateTime GetTime(OltTimeZoneInfo clientTimeZone);

        [OperationContract]
        Date GetDate(OltTimeZoneInfo clientTimeZone);

        [OperationContract]
        OltTimeZoneInfo GetTimeZoneInfo(string timeZoneName);
    }
}