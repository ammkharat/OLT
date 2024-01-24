using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class BusinessCategory : ModifiableDomainObject, ICacheBySiteId
    {
        public BusinessCategory(
            string name,
            string shortName,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime,
            long siteId) : base(lastModifiedBy, lastModifiedDateTime)
        {
            Name = name;
            ShortName = shortName;

            CreatedDateTime = createdDateTime;
            SiteId = siteId;
        }

        public BusinessCategory(
            string name,
            string shortName,
            bool isDefaultSAPWorkOrderCategory,
            bool isDefaultSAPNotificationCategory,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime,
            long siteId) : this(name, shortName, lastModifiedBy, lastModifiedDateTime, createdDateTime, siteId)
        {
            IsDefaultSAPWorkOrderCategory = isDefaultSAPWorkOrderCategory;
            IsDefaultSAPNotificationCategory = isDefaultSAPNotificationCategory;
        }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public DateTime CreatedDateTime { get; private set; }

        public bool IsDefaultSAPWorkOrderCategory { get; set; }

        public bool IsDefaultSAPNotificationCategory { get; set; }

        public bool Deleted { get; set; }

        public long SiteId { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public static int CompareByName(BusinessCategory categoryX, BusinessCategory categoryY)
        {
            return string.Compare(categoryX.Name, categoryY.Name, StringComparison.CurrentCulture);
        }
    }
}