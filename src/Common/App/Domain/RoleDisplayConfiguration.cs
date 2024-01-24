using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class RoleDisplayConfiguration : DomainObject
    {
        private readonly Role role;
        private readonly SectionKey sectionKey;
        private PageKey primaryPageKey;
        private PageKey secondaryPageKey;

        public RoleDisplayConfiguration(
            long? id,
            Role role,
            SectionKey sectionKey,
            PageKey primaryPageKey,
            PageKey secondaryPageKey)
        {
            this.id = id;
            this.role = role;
            this.sectionKey = sectionKey;
            this.primaryPageKey = primaryPageKey;
            this.secondaryPageKey = secondaryPageKey;
        }

        public Role Role
        {
            get { return role; }
        }

        public SectionKey SectionKey
        {
            get { return sectionKey; }
        }

        public PageKey PrimaryPageKey
        {
            get { return primaryPageKey; }
            set { primaryPageKey = value; }
        }

        public PageKey SecondaryPageKey
        {
            get { return secondaryPageKey; }
            set { secondaryPageKey = value; }
        }

        // for grid binding
        public string RoleName
        {
            get { return role.Name; }
        }

        // for grid binding
        public string SectionName
        {
            get { return sectionKey.Name; }
        }
    }
}