using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ProcedureDeviationDTO : FormEdmontonDTO
    {
        public ProcedureDeviationDTO(long id,
            ProcedureDeviationType type,
            bool permanentRevisionRequired,
            bool revertedBackToOriginal,
            List<string> functionalLocations,
            long createdByUserId,
            string createdByFullName,
            string createdByFullNameWithUserName,
            DateTime createdDateTime,
            long lastModifiedByUserId,
            DateTime startDateTime,
            DateTime endDateTime,
            FormStatus formStatus,
            string lastModifiedBy,
            DateTime lastModifiedDateTime,
            int numberOfExtensions,
            string operatingProcedureNumber,
            string operatingProcedureTitle,
            OperatingProcedureLevel operatingProcedureLevel,
            string description,
            string causeDeterminationCategory,
            string cancelledBy,
            DateTime? cancelledDateTime,
            string cancelledReason)
            : base(
                id,
                functionalLocations,
                EdmontonFormType.ProcedureDeviation,
                createdByUserId,
                createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId,
                startDateTime,
                endDateTime,
                formStatus,
                null,
                null,
                null)
        {
            Type = type;
            PermanentRevisionRequired = permanentRevisionRequired;
            RevertedBackToOriginal = revertedBackToOriginal;
            CreatedByFullName = createdByFullName;
            LastModifiedBy = lastModifiedBy;
            LastModified = lastModifiedDateTime;
            NumberOfExtensions = numberOfExtensions;
            OperatingProcedureNumber = operatingProcedureNumber;
            OperatingProcedureTitle = operatingProcedureTitle;
            OperatingProcedureLevel = operatingProcedureLevel;
            Description = description;
            CauseDeterminationCategory = causeDeterminationCategory;
            CancelledBy = cancelledBy;
            CancelledDateTime = cancelledDateTime;
            CancelledReason = cancelledReason;
        }

        [IncludeInSearch]
        public string CreatedByFullName { get; set; }

        [IncludeInSearch]
        public string LastModifiedBy { get; set; }

        [IncludeInSearch]
        public DateTime LastModified { get; set; }

        [IncludeInSearch]
        public int NumberOfExtensions { get; set; }

        [IncludeInSearch]
        public ProcedureDeviationType Type { get; set; }

        [IncludeInSearch]
        public bool PermanentRevisionRequired { get; set; }

        [IncludeInSearch]
        public bool RevertedBackToOriginal { get; set; }

        [IncludeInSearch]
        public string OperatingProcedureNumber { get; set; }

        [IncludeInSearch]
        public string OperatingProcedureTitle { get; set; }

        [IncludeInSearch]
        public OperatingProcedureLevel OperatingProcedureLevel { get; set; }

        [IncludeInSearch]
        public string Description { get; set; }

        [IncludeInSearch]
        public string CauseDeterminationCategory { get; set; }

        [IncludeInSearch]
        public string CancelledBy { get; set; }

        [IncludeInSearch]
        public DateTime? CancelledDateTime { get; set; }

        [IncludeInSearch]
        public string CancelledReason { get; set; }

        public FormStatus GetStatusForDisplay()
        {
            var now = Clock.Now;

            if (IsExtensionReview(now)) return FormStatus.ExtensionReview;

            if (IsExpired(now)) return FormStatus.Expired;

            return Status;
        }

        public bool IsExtensionReview(DateTime now)
        {
            return (Status == FormStatus.Approved) &&
                   (now >= ValidTo.AddDays(-30));
        }

        public bool IsExpired(DateTime now)
        {
            return (Status == FormStatus.Approved) &&
                   (now > ValidTo);
        }

        public DateTime EarliestDateToExtensionReviewOrExpired(DateTime now)
        {
            // If the date is past extension review threshold, return the expiration date; 
            // otherwise return the extension review threshold date (i.e. 30 days before expiration).
            var extensionThreshold = ValidTo.AddDays(-30);

            return now >= extensionThreshold ? ValidTo : extensionThreshold;
        }

        public bool IsComplete()
        {
            return Status == FormStatus.Complete || Status == FormStatus.Cancelled;
        }

        public bool CanDelete(long userId)
        {
            return Status == FormStatus.Draft && CreatedByUserId == userId;
        }

        public bool CanEdit()
        {
            return Status == FormStatus.Draft || Status == FormStatus.RevisionInProgress ||
                   Status == FormStatus.Approved;
        }

        public bool CanCancel()
        {
            return Status == FormStatus.Approved;
        }
    }
}