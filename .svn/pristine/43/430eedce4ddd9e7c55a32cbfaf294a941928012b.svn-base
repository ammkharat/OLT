using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IRoleElementDao : IDao
    {
        [CachedQueryList("RoleElementsFor")]
        List<RoleElement> QueryTemplate(Role role, bool includeFunctionalArea);

        List<RoleElement> QueryAll();

        bool IsSiteUsingRoleElement(Site site, RoleElement roleElement);
    }
}