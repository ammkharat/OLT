using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICraftOrTradeDao : IDao
    {
        [CachedQueryById]
        CraftOrTrade QueryById(long id);
        
        // #3003 - why do we need this?
        CraftOrTrade QueryByIdAndNotDeleted(long id);
        
        CraftOrTrade QueryByWorkCentreCodeAndSiteId(string workCentreCode, long siteId);
        CraftOrTrade QueryByWorkCentreNameAndSiteId(string workCentreName, long siteId);
        CraftOrTrade QueryByWorkCentreAndNameAndSiteId(string workCentreCode, string name, long siteId);
        
        [CachedQueryBySiteId]
        List<CraftOrTrade> QueryBySiteId(long siteId);
        [CachedQueryBySiteId]
        List<CraftOrTrade> QueryBySiteIdNoCache(long siteId);
        
        [CachedInsertOrUpdate(true, false)]
        CraftOrTrade Insert(CraftOrTrade craftOrTrade);

        [CachedInsertOrUpdate(true, false)]
        void Update(CraftOrTrade craftOrTrade);
        
        [CachedInsertOrUpdate(true, false)]
        void Remove(CraftOrTrade craftOrTrade);

        [CachedQueryBySiteId]
        List<CraftOrTrade> QueryBySiteIdNoCacheRoadAccessOnPermit(long siteId);

        [CachedInsertOrUpdate(true, false)]
        CraftOrTrade InsertRoadAccessOnPermit(CraftOrTrade craftOrTrade);

        [CachedInsertOrUpdate(true, false)]
        void UpdateRoadAccessOnPermit(CraftOrTrade craftOrTrade);

        [CachedInsertOrUpdate(true, false)]
        void RemoveRoadAccessOnPermit(CraftOrTrade craftOrTrade);

        CraftOrTrade QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(string workCentreCode, string name, long siteId);

        [CachedQueryBySiteId]
        List<CraftOrTrade> QueryBySiteIdRoadAccessOnPermit(long siteId);
        
    }
}