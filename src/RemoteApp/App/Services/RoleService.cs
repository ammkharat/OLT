using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RoleService : IRoleService
    {
        private readonly IRoleDao roleDao;

        public RoleService()
        {
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        public List<Role> QueryRolesBySite(Site site)
        {            
            return roleDao.QueryBySiteId(site.IdValue);
        }
             
        public List<Role> QueryAllAvailableInSiteWithAnyRoleElement(Site site, List<RoleElement> roleElements)
        {
            return roleDao.QueryAllAvailableInSiteWithAnyRoleElement(site.IdValue, roleElements);
        }

        public Role GetReadOnlyRole(Site site)
        {
            return roleDao.QueryDefaultReadOnlyRole(site);           
        }

        public void UpdateWorkAssignmentNotSelectedWarning(IList<Role> roles)
        {
            foreach (Role role in roles)
            {
                roleDao.UpdateWorkAssignmentNotSelectedWarning(role);
            }
        }



        //RITM-RITM0164850   Mukesh Mukesh Jan 12, 2018
        public void InsertRole(Site site, Role role)
        {
            roleDao.InsertRole(role);
        }
        public void UpdateRole(Site site, Role role)
        {
            roleDao.UpdateRole(role);
        }

        public void RemoveRole(Site site, Role role)
        {

            roleDao.Removerole(role);

        }



    }
}