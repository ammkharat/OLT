using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMudsGroupDao : IDao
    {
        [CachedQueryById]
        WorkPermitMudsGroup QueryById(long id);
        [CachedQueryAll]
        List<WorkPermitMudsGroup> QueryAll();
        [CachedInsertOrUpdate(false, true)]
        void Insert(WorkPermitMudsGroup group);
        [CachedInsertOrUpdate(false, true)]
        void Update(WorkPermitMudsGroup workPermitGroup);
        [CachedRemove(false, true)]
        void Remove(WorkPermitMudsGroup groupToDelete);
    }
}
