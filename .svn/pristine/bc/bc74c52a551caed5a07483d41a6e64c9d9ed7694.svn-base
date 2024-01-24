using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IGasTestElementInfoDao : IDao
    {
        [CachedQueryById]
        GasTestElementInfo QueryById(long id);
        [CachedInsertOrUpdate(true, false)]
        GasTestElementInfo Insert(GasTestElementInfo gasTestElement);
        [CachedQueryBySiteId]
        List<GasTestElementInfo> QueryStandardInfosBySiteId(long siteId);
        [CachedInsertOrUpdate(true, false)]
        void Update(GasTestElementInfo infoToBeUpdated);
        [CachedRemove(true, false)]
        void Remove(GasTestElementInfo elementInfo);
    }
}