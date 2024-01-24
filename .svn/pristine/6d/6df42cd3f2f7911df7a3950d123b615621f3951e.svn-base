using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormEdmontonGN24DTO : FormEdmontonDTO
    {
        public FormEdmontonGN24DTO(long id, List<string> functionalLocations, EdmontonFormType formType,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime lastModifiedDateTime, DateTime validFrom,
            DateTime validTo,
            bool isForPSVRemovalOrInstallaion, FormStatus formStatus, DateTime? approvedDateTime,
            DateTime? closedDateTime, List<string> remainingApprovals)
            : base(
                id, functionalLocations, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime,
                lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            LastModifiedDateTime = lastModifiedDateTime;
            IsForPSVRemovalOrInstallation = isForPSVRemovalOrInstallaion;
        }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { private set; get; }

        public bool IsForPSVRemovalOrInstallation { private set; get; }

        [IncludeInSearch]
        public string PSVResponseText
        {
            get { return IsForPSVRemovalOrInstallation ? StringResources.Yes : StringResources.No; }
        }
    }
}