using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client
{
    /// <summary>
    /// Stores the List of RoleElements that a User has access to based of Site and Role when logging into OLT.
    /// </summary>
    public class UserRoleElements
    {
        private readonly Role role;

        public UserRoleElements(Role role, IEnumerable<RoleElement> roleElements)
        {
            this.roleElements = new Set<RoleElement>(roleElements);
            this.role = role;
        }

        private readonly Set<RoleElement> roleElements = new Set<RoleElement>();

        public Role Role
        {
            get { return role; }
        }

        /// <summary>
        /// Checks if the role of this user has the roleElement in question
        /// </summary>
        /// <param name="roleElement">the roleElement in question</param>
        /// <returns>true if the user has the roleElement, false otherwise</returns>
        public bool AuthorizedTo(RoleElement roleElement)
        {
            return HasRoleElement(roleElement);
        }

        /// <summary>
        /// Tests if this user is not authorized to perform the given role element.
        /// </summary>
        public bool NotAuthorizedTo(RoleElement roleElement)
        {
            return !AuthorizedTo(roleElement);
        }

        public bool HasRoleElement(RoleElement roleElement)
        {
            return roleElement != null && roleElements.ExistsById(roleElement);
        }

        public void AddRoleElement(RoleElement roleElement)
        {
            ValidateRoleElement(roleElement);

            roleElements.Add(roleElement);
        }

        private void ValidateRoleElement(RoleElement roleElement)
        {
            if (HasRoleElement(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS) &&
                roleElement.Equals(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING))
                throw new ApplicationException(
                    "Updating permit with no Restriction and with Restriction roleElements cannot coexists together");

            if (HasRoleElement(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING) &&
                roleElement.Equals(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS))
                throw new ApplicationException(
                    "Updating permit with no Restriction and with Restriction roleElements cannot coexists together");

            if (HasRoleElement(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS) &&
                roleElement.Equals(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION))
                throw new ApplicationException(
                    "Clone permit roleElement must be added before adding clone All permit sections roleElement");

            if (HasRoleElement(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION) &&
                roleElement.Equals(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS))
                throw new ApplicationException(
                    "Clone permit roleElement must be added before adding clone All permit sections roleElement");
        }
    }
}