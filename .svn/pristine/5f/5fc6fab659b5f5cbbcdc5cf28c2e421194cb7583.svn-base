using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRolePermissionService
    {
        [OperationContract]
        List<RolePermission> QueryByRoleId(long id);

        [OperationContract]
        void Insert(RolePermission rolePermission);

        [OperationContract]
        void Delete(RolePermission rolePermission);
    }
}