using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        List<Role> QueryRolesBySite(Site site);

        [OperationContract]
        List<Role> QueryAllAvailableInSiteWithAnyRoleElement(Site site, List<RoleElement> roleElements);

        [OperationContract]
        Role GetReadOnlyRole(Site site);

        [OperationContract]
        void UpdateWorkAssignmentNotSelectedWarning(IList<Role> roles);



        //RITM-RITM0164850   Mukesh  Jan 12, 2018
        [OperationContract]
         void UpdateRole(Site site, Role role);

        [OperationContract]
        void InsertRole(Site site, Role role);

        [OperationContract]
        void RemoveRole(Site site, Role role);
        


    }
}