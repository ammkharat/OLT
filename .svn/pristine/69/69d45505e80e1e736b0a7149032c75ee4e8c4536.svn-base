using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPlantDao : IDao
    {
        [CachedQueryBySiteId]
        List<Plant> QueryBySiteId(long siteId);

        [CachedQueryById]
        Plant QueryById(long id);
    }
}