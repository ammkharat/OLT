using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class BusinessCategoryFLOCAssociation : DomainObject
    {
        private readonly BusinessCategory businessCategory;
        private readonly FunctionalLocation functionalLocation;

        private User lastModifiedBy;
        private DateTime lastModifiedDate;

        public BusinessCategoryFLOCAssociation(
            FunctionalLocation functionalLocation,
            BusinessCategory businessCategory,
            User lastModifiedBy,
            DateTime lastModifiedDate)
        {
            this.functionalLocation = functionalLocation;
            this.businessCategory = businessCategory;
            this.lastModifiedBy = lastModifiedBy;
            this.lastModifiedDate = lastModifiedDate;
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
        }

        public string FunctionalLocationName
        {
            get { return functionalLocation != null ? functionalLocation.FullHierarchy : null; }
        }

        public BusinessCategory BusinessCategory
        {
            get { return businessCategory; }
        }

        public string BusinessCategoryName
        {
            get { return businessCategory != null ? businessCategory.Name : null; }
        }

        public User LastModifiedBy
        {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { lastModifiedDate = value; }
        }
    }
}