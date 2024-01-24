using System;
using Castle.Core.Internal;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class DocumentSuggestionHistory : BaseFormHistory
    {
        public DocumentSuggestionHistory(long? id,
            DateTime fromDateTime,
            DateTime toDateTime,
            FormStatus formStatus,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            string flocListString,
            string locationEquipmentNumber,
            string documentLinks,
            DateTime? scheduledCompletionDateTime,
            int numberOfExtensions,
            string reasonsForExtension,
            bool isExistingDocument,
            string documentOwner,
            string documentNumber,
            string documentTitle,
            bool originalMarkedUp,
            string hardCopySubmittedTo,
            bool recommendedToBeArchived,
            string description,
            string initialReviewApprovedBy,
            DateTime? initialReviewApprovedDateTime,
            string ownerReviewApprovedBy,
            DateTime? ownerReviewApprovedDateTime,
            string documentIssuedApprovedBy,
            DateTime? documentIssuedApprovedDateTime,
            string documentArchivedApprovedBy,
            DateTime? documentArchivedApprovedDateTime,
            string notApprovedBy,
            DateTime? notApprovedDateTime,
            string notApprovedReason)
            : base(id.Value, formStatus, fromDateTime, toDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocations = flocListString;
            LocationEquipmentNumber = locationEquipmentNumber;
            DocumentLinks = documentLinks;
            ScheduledCompletionDateTime = scheduledCompletionDateTime;
            NumberOfExtensions = numberOfExtensions;
            ReasonsForExtension = reasonsForExtension;
            IsExistingDocument = isExistingDocument;
            DocumentOwner = documentOwner;
            DocumentNumber = documentNumber;
            DocumentTitle = documentTitle;
            OriginalMarkedUp = originalMarkedUp;
            HardCopySubmittedTo = hardCopySubmittedTo;
            RecommendedToBeArchived = recommendedToBeArchived;
            Description = description;
            InitialReviewApprovedBy = initialReviewApprovedBy;
            InitialReviewApprovedDateTime = initialReviewApprovedDateTime;
            OwnerReviewApprovedBy = ownerReviewApprovedBy;
            OwnerReviewApprovedDateTime = ownerReviewApprovedDateTime;
            DocumentIssuedApprovedBy = documentIssuedApprovedBy;
            DocumentIssuedApprovedDateTime = documentIssuedApprovedDateTime;
            DocumentArchivedApprovedBy = documentArchivedApprovedBy;
            DocumentArchivedApprovedDateTime = documentArchivedApprovedDateTime;
            NotApprovedBy = notApprovedBy;
            NotApprovedDateTime = notApprovedDateTime;
            NotApprovedReason = notApprovedReason;
        }

        public string FunctionalLocations { get; private set; }

        public string DocumentLinks { get; private set; }

        public string LocationEquipmentNumber { get; set; }

        public DateTime? ScheduledCompletionDateTime { get; set; }

        public int NumberOfExtensions { get; set; }

        public string ReasonsForExtension { get; set; }

        public bool IsExistingDocument { get; set; }

        public string DocumentOwner { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentTitle { get; set; }

        public bool OriginalMarkedUp { get; set; }

        public string HardCopySubmittedTo { get; set; }

        public bool RecommendedToBeArchived { get; set; }

        public string Description { get; set; }

        public string InitialReviewApprovedBy { get; set; }
        public DateTime? InitialReviewApprovedDateTime { get; set; }

        public string OwnerReviewApprovedBy { get; set; }
        public DateTime? OwnerReviewApprovedDateTime { get; set; }

        public string DocumentIssuedApprovedBy { get; set; }
        public DateTime? DocumentIssuedApprovedDateTime { get; set; }

        public string DocumentArchivedApprovedBy { get; set; }
        public DateTime? DocumentArchivedApprovedDateTime { get; set; }

        public string NotApprovedBy { get; set; }
        public DateTime? NotApprovedDateTime { get; set; }
        public string NotApprovedReason { get; set; }
    }
}