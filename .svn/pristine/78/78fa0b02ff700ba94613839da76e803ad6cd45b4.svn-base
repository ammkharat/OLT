using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
  [Serializable]
    public  class FormEdmontonGN75BDTOforPriorityScreen : FormEdmontonDTO
    {
        public FormEdmontonGN75BDTOforPriorityScreen(long id, string functionalLocationName, EdmontonFormType formType,
            long? associatedGN75FormNumber,string location, long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime lastModifiedDateTime, DateTime fromDateTime,
            DateTime toDateTime,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals)
            : base(
                id, new List<string> {functionalLocationName}, formType, createdByUserId, createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId, fromDateTime, toDateTime, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals,location)
        {
            FunctionalLocationName = functionalLocationName;
            AssociatedFormGN75BFormNumber = associatedGN75FormNumber;
            LastModifiedDateTime = lastModifiedDateTime;
            Location = location;////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
        }

        public string FunctionalLocationName { private set; get; }
        public string Location { private set; get; } ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { private set; get; }

        [IncludeInSearch]
        public long? AssociatedFormGN75BFormNumber { private set; get; }

        [IncludeInSearch]
        public DateTime FromDateTime
        {
            get { return ValidFrom; }
        }

        [IncludeInSearch]
        public DateTime ToDateTime
        {
            get { return ValidTo; }
        }
    }
}
