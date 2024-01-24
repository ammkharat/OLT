using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IVisibilityGroupDao : IDao
    {
        [CachedQueryBySiteId]
        List<VisibilityGroup> QueryAll(long siteId);
        [CachedInsertOrUpdate(true, false)]
        VisibilityGroup Insert(VisibilityGroup visibilityGroup);
        [CachedRemove(true, false)]
        void Remove(VisibilityGroup visibilityGroup);
        [CachedInsertOrUpdate(true, false)]
        void Update(VisibilityGroup visibilityGroup);
        
        bool IsAssociatedToWorkAssignments(VisibilityGroup visibilityGroup, VisibilityType visibilityType);
    }
}