using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRoleDisplayConfigurationService
    {
        [OperationContract]
        List<RoleDisplayConfiguration> QueryBySiteAndRole(Site site, Role role);

        [OperationContract]
        List<RoleDisplayConfiguration> QueryBySite(Site site);

        [OperationContract]
        void DeleteAllAndInsertNew(Site site, IList<RoleDisplayConfiguration> configurations);
    }
}