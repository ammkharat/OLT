using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRoleElementTemplateService
    {
        [OperationContract]
        void DeleteRoleElementTemplate(Site site, string roleName, string roleElementName);

        [OperationContract]
        void InsertRoleElementTemplate(Site site, string roleName, string roleElementName);
    }
}