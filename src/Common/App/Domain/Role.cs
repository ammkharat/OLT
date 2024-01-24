using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Role : DomainObject, ICacheBySiteId
    {
        public Role(long? id, string name, string activeDirectoryKey,
            bool isAdministratorRole, bool isReadOnlyRole, bool isDefaultReadOnlyRoleForSite,
            bool isWorkPermitNonOperationsRole,
            bool warnIfWorkAssignmentNotSelected, string alias, long siteId)
        {
            this.id = id;
            Name = name;
            ActiveDirectoryKey = activeDirectoryKey;

            IsAdministratorRole = isAdministratorRole;
            IsReadOnlyRole = isReadOnlyRole;
            IsDefaultReadOnlyRoleForSite = isDefaultReadOnlyRoleForSite;
            IsWorkPermitNonOperationsRole = isWorkPermitNonOperationsRole;

            WarnIfWorkAssignmentNotSelected = warnIfWorkAssignmentNotSelected;
            Alias = alias;
            SiteId = siteId;
        }

        public string Name { get; private set; }

        public string ActiveDirectoryKey { get; private set; }

        public bool IsAdministratorRole { get; private set; }

        public bool IsReadOnlyRole { get; private set; }

        public bool IsDefaultReadOnlyRoleForSite { get; private set; }

        public bool IsWorkPermitNonOperationsRole { get; private set; }

        public bool WarnIfWorkAssignmentNotSelected { get; set; }

        public string Alias { get; private set; }
        public long SiteId { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object objectToBeCompared)
        {
            var roleToCompare = objectToBeCompared as Role;

            if (roleToCompare != null)
            {
                return id == roleToCompare.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ id.GetHashCode();
            }
        }

        public static int CompareByName(Role x, Role y)
        {
            var xName = x != null ? x.Name : null;
            var yName = y != null ? y.Name : null;

            return string.Compare(xName, yName, StringComparison.CurrentCulture);
        }
    }
}