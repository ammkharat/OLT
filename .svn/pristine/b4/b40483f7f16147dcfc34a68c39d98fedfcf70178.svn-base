using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDropdownValueDao : IDao
    {
        [CachedQueryBySiteId]
        List<DropdownValue> QueryAll(long siteId);
        [CachedInsertOrUpdate(true, false)]
        void Insert(DropdownValue value);
        [CachedInsertOrUpdate(true, false)]
        void Update(DropdownValue value);
        [CachedRemove(true, false)]
        void Remove(DropdownValue value);

        List<DropdownValue> QueryByKey(long siteId, string key);
    }
}