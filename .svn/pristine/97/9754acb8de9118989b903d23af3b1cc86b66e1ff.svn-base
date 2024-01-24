using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRoleElementService
    {
        [OperationContract]
        List<RoleElement> QueryTemplateForRole(Role role);

        [OperationContract]
        List<RoleElement> QueryTemplateForRoleIncludeFunctionalArea(Role role);

        [OperationContract]
        List<RoleElement> QueryAll();

        [OperationContract]
        Dictionary<RoleElement, bool> IsSiteUsingRoleElement(Site site, List<RoleElement> roleElements);
    }
}