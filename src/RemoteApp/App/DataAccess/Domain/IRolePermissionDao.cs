using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - caching for 15 minutes wouldn't be the end of the world.  Adding ability to clear a named cache would make caching totally safe.
    public interface IRolePermissionDao : IDao
    {
        List<RolePermission> QueryByRoleId(long id);
        void Delete(RolePermission rolePermission);
        void Insert(RolePermission rolePermission);
    }
}