using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMontrealGroupDao : IDao
    {
        [CachedQueryById]
        WorkPermitMontrealGroup QueryById(long id);
        [CachedQueryAll]
        List<WorkPermitMontrealGroup> QueryAll();
        [CachedInsertOrUpdate(false, true)]
        void Insert(WorkPermitMontrealGroup group);
        [CachedInsertOrUpdate(false, true)]
        void Update(WorkPermitMontrealGroup workPermitGroup);
        [CachedRemove(false, true)]
        void Remove(WorkPermitMontrealGroup groupToDelete);
    }
}
