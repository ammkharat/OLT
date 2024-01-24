using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RoleDisplayConfigurationService : IRoleDisplayConfigurationService
    {
        private readonly IRoleDisplayConfigurationDao dao;

        public RoleDisplayConfigurationService()
        {
            dao = DaoRegistry.GetDao<IRoleDisplayConfigurationDao>();
        }

        public List<RoleDisplayConfiguration> QueryBySiteAndRole(Site site, Role role)
        {
            return dao.QueryBySiteAndRole(site, role);
        }

        public List<RoleDisplayConfiguration> QueryBySite(Site site)
        {
            return dao.QueryBySite(site);
        }

        public void DeleteAllAndInsertNew(Site site, IList<RoleDisplayConfiguration> configurations)
        {
            dao.DeleteAllAndInsertNew(site, configurations);
        }
    }
}
