using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftPatternDao : IDao
    {
        List<ShiftPattern> QueryAll();

        [CachedQueryById]
        ShiftPattern QueryById(long id);
        
        [CachedInsertOrUpdate(true, false)]
        ShiftPattern Insert(ShiftPattern shift);
        
        [CachedQueryBySiteId]
        List<ShiftPattern> QueryBySiteId(long siteId);
    }
}