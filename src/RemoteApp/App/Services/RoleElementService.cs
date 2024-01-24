using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RoleElementService : IRoleElementService
    {
        private readonly IRoleElementDao dao;

        public RoleElementService()
        {
            dao = DaoRegistry.GetDao<IRoleElementDao>();
        }

        public List<RoleElement> QueryTemplateForRole(Role role)
        {
            return dao.QueryTemplate(role, false);
        }

        public List<RoleElement> QueryTemplateForRoleIncludeFunctionalArea(Role role)
        {
            return dao.QueryTemplate(role, true);
        }

        public List<RoleElement> QueryAll()
        {
            return dao.QueryAll();
        }

        public Dictionary<RoleElement, bool> IsSiteUsingRoleElement(Site site, List<RoleElement> roleElements)
        {
            Dictionary<RoleElement, bool> results = new Dictionary<RoleElement, bool>();

            foreach (RoleElement roleElement in roleElements)
            {
                bool isSiteUsingRoleElement = dao.IsSiteUsingRoleElement(site, roleElement);
                results.Add(roleElement, isSiteUsingRoleElement);
            }

            return results;
        }
    }
}