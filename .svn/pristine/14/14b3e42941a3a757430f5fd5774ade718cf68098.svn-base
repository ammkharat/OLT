using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IShiftHandoverEmailConfigurationDao : IDao
    {
        [CachedQueryBySiteId]
        List<ShiftHandoverEmailConfiguration> QueryBySiteId(long siteId);

        [CachedInsertOrUpdate(true, false)]
        void Insert(ShiftHandoverEmailConfiguration shiftHandoverEmailConfiguration);

        [CachedInsertOrUpdate(true, false)]
        void Update(ShiftHandoverEmailConfiguration configuration);

        [CachedRemove(true, false)]
        void Delete(ShiftHandoverEmailConfiguration emailConfigurationId);

        [CachedQueryById]
        ShiftHandoverEmailConfiguration QueryById(long configurationId);
    }
}
