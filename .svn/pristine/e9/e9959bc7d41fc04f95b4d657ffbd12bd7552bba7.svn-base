using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitEdmontonGroupDao : IDao
    {
        [CachedQueryById]
        WorkPermitEdmontonGroup QueryById(long id);
        [CachedQueryAll]
        List<WorkPermitEdmontonGroup> QueryAll();
        [CachedInsertOrUpdate(false, true)]
        WorkPermitEdmontonGroup Insert(WorkPermitEdmontonGroup group);
    }
}
