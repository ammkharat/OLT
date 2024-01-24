using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Domain
{
    public class RolePermissionDisplayAdapter
    {
        private readonly Role role;
        private readonly RoleElement roleElement;
        private readonly Role createdByRole;

        public RolePermissionDisplayAdapter(Role role, RoleElement roleElement, Role createdByRole)
        {
            this.role = role;
            this.roleElement = roleElement;
            this.createdByRole = createdByRole;
        }

        public string RoleName
        {
            get { return role.Name; }
        }

        public string RoleElementName
        {
            get { return roleElement.Name; }
        }

        public string CreatedByRoleName
        {
            get { return createdByRole.Name; }
        }

        public RolePermission CreateRolePermission()
        {
            return new RolePermission(role.IdValue, roleElement.IdValue, createdByRole.IdValue);
        }

        public bool Equals(RolePermissionDisplayAdapter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.role, role) && Equals(other.roleElement, roleElement) && Equals(other.createdByRole, createdByRole);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RolePermissionDisplayAdapter)) return false;
            return Equals((RolePermissionDisplayAdapter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (role != null ? role.GetHashCode() : 0);
                result = (result*397) ^ (roleElement != null ? roleElement.GetHashCode() : 0);
                result = (result*397) ^ (createdByRole != null ? createdByRole.GetHashCode() : 0);
                return result;
            }
        }
    }
}
