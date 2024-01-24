using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitFortHillsGroupDao : IDao
    {
        [CachedQueryById]
        WorkPermitFortHillsGroup QueryById(long id);
        [CachedQueryAll]
        List<WorkPermitFortHillsGroup> QueryAll();
        [CachedInsertOrUpdate(false, true)]
        WorkPermitFortHillsGroup Insert(WorkPermitFortHillsGroup group);
    }
}
