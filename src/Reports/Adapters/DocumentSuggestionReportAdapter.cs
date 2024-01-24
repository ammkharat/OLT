using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters

{
    public class DocumentSuggestionReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly DocumentSuggestion documentSuggestion;

        public DocumentSuggestionReportAdapter(DocumentSuggestion documentSuggestion)
        {
            this.documentSuggestion = documentSuggestion;
            Label_Title = StringResources.DocumentSuggestionReportTitle;
        }

        public long FormId
        {
            get { return documentSuggestion.IdValue; }
        }

        public string FormNumber
        {
            get
            {
                var id = documentSuggestion.IdValue;
                return PadFormNumber(id);
            }
        }

        public string CreatedByUser
        {
            get { return documentSuggestion.CreatedBy.FullNameWithUserName; }
        }

        public string LastModifiedUser
        {
            get { return documentSuggestion.LastModifiedBy.FullNameWithUserName; }
        }

        public string CreationDateTime
        {
            get { return documentSuggestion.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return documentSuggestion.LastModifiedDateTime.ToLongDateAndTimeString(); }
        }

        public List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    documentSuggestion.FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }

        public List<ExtensionReasonReportAdapter> ExtensionReasonComments
        {
            get
            {
                if (documentSuggestion.ReasonsForExtensionSortedByCreatedDate != null)
                {
                    return
                        documentSuggestion.ReasonsForExtensionSortedByCreatedDate.ConvertAll(
                            comment => new ExtensionReasonReportAdapter(comment));
                }
                return new List<ExtensionReasonReportAdapter>();
            }
        }

        public string LocationEquipmentNumber
        {
            get { return documentSuggestion.LocationEquipmentNumber; }
        }

        public string StartDate
        {
            get { return documentSuggestion.FromDateTime.ToLongDateAndTimeString(); }
        }

        public string SuggestedCompletionDateTime
        {
            get { return documentSuggestion.ToDateTime.ToLongDateAndTimeString(); }
        }

        public string ScheduledCompletionDateTime
        {
            get
            {
                return documentSuggestion.ScheduledCompletionDateTime != null
                    ? documentSuggestion.ScheduledCompletionDateTime.Value.ToLongDateAndTimeString()
                    : string.Empty;
            }
        }

        public string NumberOfExtensions
        {
            get { return documentSuggestion.NumberOfExtensions.ToString(); }
        }

// todo, do a sub for this  public string ReasonForExtension { get{return documentSuggestion.ReasonsForExtension}}

        public bool ExistingDocumentNo
        {
            get { return !documentSuggestion.IsExistingDocument; }
        }

        public bool ExistingDocumentYes
        {
            get { return documentSuggestion.IsExistingDocument; }
        }

        public string DocumentOwner
        {
            get { return documentSuggestion.DocumentOwner; }
        }

        public string DocumentNumber
        {
            get { return documentSuggestion.DocumentNumber; }
        }

        public string DocumentTitle
        {
            get { return documentSuggestion.DocumentTitle; }
        }

        public bool OriginallMarkedUpAndHardCopySubmittedNo
        {
            get
            {
                return !documentSuggestion.OriginalMarkedUp &&
                       documentSuggestion.HardCopySubmittedTo.IsNullOrEmptyOrWhitespace();
            }
        }

        public bool OriginallMarkedUpAndHardCopySubmittedYes
        {
            get { return !documentSuggestion.HardCopySubmittedTo.IsNullOrEmptyOrWhitespace(); }
        }

        public string HardCopySubmittedTo
        {
            get { return documentSuggestion.HardCopySubmittedTo; }
        }

        public bool RecommendedToBeArchivedNo
        {
            get { return !documentSuggestion.RecommendedToBeArchived; }
        }

        public bool RecommendedToBeArchivedYes
        {
            get { return documentSuggestion.RecommendedToBeArchived; }
        }

        public string EnhancementDescription
        {
            get { return documentSuggestion.RichTextDescription; }
        }

        public string ReasonForNotApproving
        {
            get { return documentSuggestion.NotApprovedReason; }
        }


        public List<ApprovalReportAdapter> ApprovalReportAdapters
        {
            get
            {
                return
                    documentSuggestion.AllApprovals.ConvertAll(
                        approval =>
                            new ApprovalReportAdapter(documentSuggestion.IdValue, approval.WorkAssignmentDisplayName,
                                approval.ApprovedByUser, approval.ApprovalDateTime, approval.WorkAssignmentDisplayName));
            }
        }

        public string WatermarkText
        {
            get { return documentSuggestion.FormStatus.Name; }
        }
    }
}