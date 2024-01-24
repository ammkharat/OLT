using System;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     RolePermission Domain Object
    /// </summary>
    [Serializable]
    public class RolePermission
    {
        public RolePermission(long roleId, long roleElementId, long createdByRoleId)
        {
            RoleId = roleId;
            RoleElementId = roleElementId;
            CreatedByRoleId = createdByRoleId;
        }

        public long RoleId { get; private set; }
        public long RoleElementId { get; private set; }
        public long CreatedByRoleId { get; private set; }
    }
}