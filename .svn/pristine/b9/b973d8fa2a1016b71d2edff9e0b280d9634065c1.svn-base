using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitLubesGroupDao : IDao
    {
        [CachedQueryAll]
        List<WorkPermitLubesGroup> QueryAll();
        [CachedQueryById]
        WorkPermitLubesGroup QueryById(long id);
    }
}
