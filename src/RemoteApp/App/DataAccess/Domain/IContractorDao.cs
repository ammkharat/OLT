using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IContractorDao : IDao
    {
        [CachedQueryBySiteId]
        List<Contractor> QueryBySite(long siteId);
        
        [CachedInsertOrUpdate(true, false)]
        Contractor Insert(Contractor contractor);
        
        [CachedRemove(true, false)]
        void Remove(Contractor contractor);
        
        [CachedInsertOrUpdate(true, false)]
        void Update(Contractor contractor);
    }
}
