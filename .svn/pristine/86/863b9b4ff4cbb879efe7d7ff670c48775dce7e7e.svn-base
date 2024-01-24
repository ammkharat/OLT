using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class DocumentSuggestion : BaseEdmontonForm, IDocumentLinksObject
    {
        public DocumentSuggestion(long? id,
            DateTime startDateTime,
            DateTime suggestedCompletionDateTime,
            FormStatus formStatus,
            User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime, long siteid)                  //ayman generic forms
            : base(id, formStatus, startDateTime, suggestedCompletionDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();
            FunctionalLocations = new List<FunctionalLocation>();
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public long SiteId { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public string LocationEquipmentNumber { get; set; }

        public DateTime? ScheduledCompletionDateTime { get; set; }

        public int NumberOfExtensions { get; set; }

        public List<Comment> ReasonsForExtension { get; set; }

        public List<Comment> ReasonsForExtensionSortedByCreatedDate
        {
            get
            {
                return ReasonsForExtension != null
                    ? ReasonsForExtension.OrderBy(comment => comment.CreatedDate).ToList()
                    : null;
            }
        }

        public bool IsExistingDocument { get; set; }

        public string DocumentOwner { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentTitle { get; set; }

        public bool OriginalMarkedUp { get; set; }

        public string HardCopySubmittedTo { get; set; }

        public bool RecommendedToBeArchived { get; set; }

        public string Description { get; set; }
        public string RichTextDescription { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.DocumentSuggestion; }
        }

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

        public bool AllowEditSuggestedCompletionDate
        {
            get { return (FormStatus == FormStatus.Draft || FormStatus == FormStatus.InitialReview); }
        }

        public bool AllowEditScheduledCompletionDate
        {
            get { return !(FormStatus == FormStatus.Draft || FormStatus == FormStatus.InitialReview); }
        }

        public override List<FormApproval> AllApprovals
        {
            get
            {
                var viewApprovals = new List<FormApproval>();
                var stubUser = CreatedBy;

                var initialReviewApproval = new FormApproval(null, Id, InitialReviewApprovedBy,
                    stubUser,
                    InitialReviewApprovedDateTime,
                    null, 1);
                initialReviewApproval.DisableEdit = true;
                if (InitialReviewApprovedBy.IsNullOrEmpty())
                {
                    initialReviewApproval.Unapprove();
                }
                initialReviewApproval.WorkAssignmentDisplayName = FormStatus.InitialReview.Name;
                viewApprovals.Add(initialReviewApproval);

                var ownerReviewApproval = new FormApproval(null, Id, OwnerReviewApprovedBy, stubUser,
                    OwnerReviewApprovedDateTime,
                    null, 2);
                ownerReviewApproval.DisableEdit = true;
                if (OwnerReviewApprovedBy.IsNullOrEmpty())
                {
                    ownerReviewApproval.Unapprove();
                }
                ownerReviewApproval.WorkAssignmentDisplayName = FormStatus.OwnerReview.Name;
                viewApprovals.Add(ownerReviewApproval);

                var documentIssuedApproval = new FormApproval(null, Id, DocumentIssuedApprovedBy,
                    stubUser,
                    DocumentIssuedApprovedDateTime,
                    null, 4);
                documentIssuedApproval.DisableEdit = true;
                if (DocumentIssuedApprovedBy.IsNullOrEmpty())
                {
                    documentIssuedApproval.Unapprove();
                }
                documentIssuedApproval.WorkAssignmentDisplayName = FormStatus.DocumentIssued.Name;
                viewApprovals.Add(documentIssuedApproval);

                var documentArchivedApproval = new FormApproval(null, Id, DocumentArchivedApprovedBy,
                    stubUser,
                    DocumentArchivedApprovedDateTime,
                    null, 5);
                documentArchivedApproval.DisableEdit = true;
                if (DocumentArchivedApprovedBy.IsNullOrEmpty())
                {
                    documentArchivedApproval.Unapprove();
                }
                documentArchivedApproval.WorkAssignmentDisplayName = FormStatus.DocumentArchived.Name;
                viewApprovals.Add(documentArchivedApproval);

                var notApproved = new FormApproval(null, Id, NotApprovedBy, stubUser,
                    NotApprovedDateTime,
                    null, 6);
                notApproved.DisableEdit = true;
                if (NotApprovedBy.IsNullOrEmpty())
                {
                    notApproved.Unapprove();
                }
                notApproved.WorkAssignmentDisplayName = FormStatus.NotApproved.Name;
                viewApprovals.Add(notApproved);

                return viewApprovals;
            }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new DocumentSuggestionDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                CreatedBy.IdValue,
                CreatedBy.FullName,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy.FullNameWithUserName,
                LastModifiedDateTime,
                ScheduledCompletionDateTime,
                NumberOfExtensions,
                DocumentOwner,
                DocumentNumber,
                DocumentTitle,
                Description,
                InitialReviewApprovedDateTime,
                OwnerReviewApprovedDateTime,
                DocumentIssuedApprovedDateTime,
                DocumentArchivedApprovedDateTime,
                NotApprovedDateTime,
                NotApprovedReason);
        }

        public DocumentSuggestionHistory TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var reasonsForExtension = ReasonsForExtension != null && ReasonsForExtension.Count > 0
                ? ReasonsForExtension.AsString(reason => reason.Text)
                : null;

            return new DocumentSuggestionHistory(IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy,
                LastModifiedDateTime,
                flocListString,
                LocationEquipmentNumber,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                ScheduledCompletionDateTime,
                NumberOfExtensions,
                reasonsForExtension,
                IsExistingDocument,
                DocumentOwner,
                DocumentNumber,
                DocumentTitle,
                OriginalMarkedUp,
                HardCopySubmittedTo,
                RecommendedToBeArchived,
                Description,
                InitialReviewApprovedBy,
                InitialReviewApprovedDateTime,
                OwnerReviewApprovedBy,
                OwnerReviewApprovedDateTime,
                DocumentIssuedApprovedBy,
                DocumentIssuedApprovedDateTime,
                DocumentArchivedApprovedBy,
                DocumentArchivedApprovedDateTime,
                NotApprovedBy,
                NotApprovedDateTime,
                NotApprovedReason);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }
    }
}