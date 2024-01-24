using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISpecialWorkDao : IDao
    {
        [CachedQueryBySiteId]
        List<SpecialWork> QueryBySite(long siteId);
        
        [CachedInsertOrUpdate(true, false)]
        SpecialWork Insert(SpecialWork contractor);
        
        [CachedRemove(true, false)]
        void Remove(SpecialWork contractor);
        
        [CachedInsertOrUpdate(true, false)]
        void Update(SpecialWork contractor);
    }
}
