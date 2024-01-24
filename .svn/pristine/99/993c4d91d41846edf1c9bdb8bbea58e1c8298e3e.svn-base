using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IBusinessCategoryDao : IDao
    {
        [CachedInsertOrUpdate(true, false)]
        BusinessCategory Insert(BusinessCategory businessCategory);

        [CachedQueryById]
        BusinessCategory QueryById(long id);

        [CachedRemove(true, false)]
        void Remove(BusinessCategory businessCategory);
        
        [CachedInsertOrUpdate(true, false)]
        void Update(BusinessCategory businessCategory);

        [CachedQueryBySiteId]
        List<BusinessCategory> QueryAllBySite(long siteId);

        BusinessCategory GetDefaultSAPWorkOrderCategory(long siteId); // equip / mech
        BusinessCategory GetDefaultSAPNotificationCategory(long siteId); // Environmental / Safety
    }
}