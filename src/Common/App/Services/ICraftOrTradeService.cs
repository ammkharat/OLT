using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ICraftOrTradeService
    {
        [OperationContract]
        CraftOrTrade QueryById(long craftOrTradeId);

        [OperationContract]
        CraftOrTrade QueryByWorkCenterOrName(string workCentreCode, string workCentreFullName, long siteId);

        [OperationContract]
        CraftOrTrade QueryByWorkCentreAndNameAndSiteId(string workCentre, string name, long siteId);

        [OperationContract]
        CraftOrTrade Insert(CraftOrTrade craftOrTrade);

        [OperationContract]
        List<CraftOrTrade> QueryBySite(Site site);

        [OperationContract]
        List<CraftOrTrade> QueryBySiteNoCache(Site site);

        [OperationContract]
        void Update(CraftOrTrade craftOrTrade);

        [OperationContract]
        void Remove(CraftOrTrade craftOrTrade);

        [OperationContract]
        List<CraftOrTrade> QueryBySiteIdRoadAccessOnPermit(Site site);

        [OperationContract]
        List<CraftOrTrade> QueryBySiteNoCacheRoadAccessOnPermit(Site site);

        [OperationContract]
        CraftOrTrade InsertRoadAccesOnPermit(CraftOrTrade craftOrTrade);

        [OperationContract]
        void UpdateRoadAccesOnPermit(CraftOrTrade craftOrTrade);

        [OperationContract]
        void RemoveRoadAccesOnPermit(CraftOrTrade craftOrTrade);

        [OperationContract]
        CraftOrTrade QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(string workCentre, string name, long siteId);

    }
}