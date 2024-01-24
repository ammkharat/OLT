using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - consider just caching these for 15 minutes.  How often do they change? Could remove the Delete All and Insert New and have proper update, insert, delete so that we can cache lists 
    // safely.
    public interface IRoleDisplayConfigurationDao : IDao
    {
        List<RoleDisplayConfiguration> QueryBySiteAndRole(Site site, Role role);
        List<RoleDisplayConfiguration> QueryBySite(Site site);
        void DeleteAllAndInsertNew(Site site, IList<RoleDisplayConfiguration> configurations);
    }
}
