namespace Com.Suncor.Olt.Common.Domain
{
    public class RoleElementTemplateValue
    {
        private readonly Role role;
        private readonly RoleElement roleElement;

        public RoleElementTemplateValue(Role role, RoleElement roleElement)
        {
            this.role = role;
            this.roleElement = roleElement;
        }

        public Role Role
        {
            get { return role; }
        }

        public RoleElement RoleElement
        {
            get { return roleElement; }
        }

        public bool Equals(RoleElementTemplateValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.role, role) && Equals(other.roleElement, roleElement);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RoleElementTemplateValue)) return false;
            return Equals((RoleElementTemplateValue) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((role != null ? role.GetHashCode() : 0)*397) ^
                       (roleElement != null ? roleElement.GetHashCode() : 0);
            }
        }
    }
}