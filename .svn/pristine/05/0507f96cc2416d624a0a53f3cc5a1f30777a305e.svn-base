using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class DocumentSuggestionDTO : FormEdmontonDTO
    {
        public DocumentSuggestionDTO(long id,
            List<string> functionalLocations,
            long createdByUserId,
            string createdByFullName,
            string createdByFullNameWithUserName,
            DateTime createdDateTime,
            long lastModifiedByUserId,
            DateTime startDateTime,
            DateTime suggestedCompletionDateTime,
            FormStatus formStatus,
            string lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? scheduledCompletionDateTime,
            int numberOfExtensions,
            string documentOwner,
            string documentNumber,
            string documentTitle,
            string description,
            DateTime? initialReviewApprovedDateTime,
            DateTime? ownerReviewApprovedDateTime,
            DateTime? documentIssuedApprovedDateTime,
            DateTime? documentArchivedApprovedDateTime,
            DateTime? notApprovedDateTime,
            string notApprovedReason)
            : base(
                id,
                functionalLocations,
                EdmontonFormType.DocumentSuggestion,
                createdByUserId,
                createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId,
                startDateTime,
                suggestedCompletionDateTime,
                formStatus,
                null,
                null,
                null)
        {
            CreatedByFullName = createdByFullName;
            LastModifiedBy = lastModifiedBy;
            LastModified = lastModifiedDateTime;
            ScheduledCompletionDateTime = scheduledCompletionDateTime;
            NumberOfExtensions = numberOfExtensions;
            DocumentOwner = documentOwner;
            DocumentNumber = documentNumber;
            DocumentTitle = documentTitle;
            Description = description;
            InitialReviewApprovedDateTime = initialReviewApprovedDateTime;
            OwnerReviewApprovedDateTime = ownerReviewApprovedDateTime;
            DocumentIssuedApprovedDateTime = documentIssuedApprovedDateTime;
            DocumentArchivedApprovedDateTime = documentArchivedApprovedDateTime;
            NotApprovedDateTime = notApprovedDateTime;
            NotApprovedReason = notApprovedReason;
        }

        [IncludeInSearch]
        public string CreatedByFullName { get; set; }

        [IncludeInSearch]
        public string LastModifiedBy { get; set; }

        [IncludeInSearch]
        public DateTime LastModified { get; set; }

        [IncludeInSearch]
        public DateTime? ScheduledCompletionDateTime { get; set; }

        [IncludeInSearch]
        public int NumberOfExtensions { get; set; }

        [IncludeInSearch]
        public string DocumentOwner { get; set; }

        [IncludeInSearch]
        public string DocumentNumber { get; set; }

        [IncludeInSearch]
        public string DocumentTitle { get; set; }

        [IncludeInSearch]
        public string Description { get; set; }

        [IncludeInSearch]
        public DateTime? InitialReviewApprovedDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? OwnerReviewApprovedDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? DocumentIssuedApprovedDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? DocumentArchivedApprovedDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? NotApprovedDateTime { get; set; }

        [IncludeInSearch]
        public string NotApprovedReason { get; set; }

        public FormStatus GetStatusForDisplay()
        {
            return IsLate(Clock.Now) ? FormStatus.Late : Status;
        }

        public DateTime LatestCompletionDate
        {
            get
            {
                // Return the later of the suggested completion date (i.e. ValidTo) and ScheduledCompletionDate

                DateTime maxCompletionDate;

                if (ScheduledCompletionDateTime.HasValue == false)
                {
                    maxCompletionDate = ValidTo;
                }
                else
                {
                    maxCompletionDate = ScheduledCompletionDateTime.Value > ValidTo
                        ? ScheduledCompletionDateTime.Value
                        : ValidTo;
                }

                return maxCompletionDate;
            }
        }

        public bool IsLate(DateTime now)
        {
            return LatestCompletionDate < now &&
                   (Status == FormStatus.RevisionInProgress || Status == FormStatus.InitialReview ||
                    Status == FormStatus.OwnerReview);
        }

        public bool IsComplete()
        {
            return Status == FormStatus.DocumentIssued || Status == FormStatus.DocumentArchived ||
                   Status == FormStatus.NotApproved;
        }

        public bool CanDelete(long userId)
        {
            return Status == FormStatus.Draft && CreatedByUserId == userId;
        }

        public bool CanEdit()
        {
            return Status == FormStatus.Draft || Status == FormStatus.InitialReview || Status == FormStatus.OwnerReview ||
                   Status == FormStatus.RevisionInProgress;
        }
    }
}