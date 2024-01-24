using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IAreaLabelDao : IDao
    {
        [CachedQueryBySiteId]
        List<AreaLabel> QueryBySiteId(long siteId);
        
        [CachedInsertOrUpdate(true, false)]
        AreaLabel Insert(AreaLabel areaLabel);

        [CachedQueryById]
        AreaLabel QueryById(long id);

        [CachedInsertOrUpdate(true, false)]
        void Update(AreaLabel areaLabel);

        [CachedRemove(true, false)]
        void Remove(AreaLabel areaLabel);

        AreaLabel QueryBySiteIdAndPlannerGroup(long siteId, string plannerGroup);
    }
}
