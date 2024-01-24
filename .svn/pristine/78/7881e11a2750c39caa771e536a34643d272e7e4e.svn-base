using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IRoleDao : IDao
    {
        [CachedQueryById]
        Role QueryById(long id);
        
        [CachedQueryBySiteId]
        List<Role> QueryBySiteId(long siteId);
        
        [CachedQuery("RoleByADKey")]
        Role QueryByActiveDirectoryKey(Site site, string roleKey);
        
        List<Role> QueryAllAvailableInSiteWithAnyRoleElement(long siteId, List<RoleElement> roleElements);
        
        Role QueryDefaultReadOnlyRole(Site site);
        
        void UpdateWorkAssignmentNotSelectedWarning(Role role);

        //RITM-RITM0164850   Mukesh Jan 12, 2018
        void InsertRole(Role role);
        void UpdateRole(Role role);
        void Removerole(Role role);
    }
}