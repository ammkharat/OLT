using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionDao dao;

        public RolePermissionService()
        {
            dao = DaoRegistry.GetDao<IRolePermissionDao>();
        }

        public List<RolePermission> QueryByRoleId(long id)
        {
            return dao.QueryByRoleId(id);
        }

        public void Insert(RolePermission rolePermission)
        {
            dao.Insert(rolePermission);
        }

        public void Delete(RolePermission rolePermission)
        {
            dao.Delete(rolePermission);
        }
    }
}
