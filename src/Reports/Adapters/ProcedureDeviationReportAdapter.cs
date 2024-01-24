using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ProcedureDeviationReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly ProcedureDeviation procedureDeviation;

        public ProcedureDeviationReportAdapter(ProcedureDeviation documentSuggestion)
        {
            procedureDeviation = documentSuggestion;
            Label_Title = StringResources.ProcedureDeviationReportTitle;
        }

        public long FormId
        {
            get { return procedureDeviation.IdValue; }
        }

        public string FormNumber
        {
            get
            {
                var id = procedureDeviation.IdValue;
                return PadFormNumber(id);
            }
        }

        public string DeviationType
        {
            get { return procedureDeviation.Type.GetName(); }
        }

        public bool PermanentRevisionRequiredNo
        {
            get { return !procedureDeviation.PermanentRevisionRequired; }
        }

        public bool PermanentRevisionRequiredYes
        {
            get { return procedureDeviation.PermanentRevisionRequired; }
        }

        public bool RevertedBackToOriginalNo
        {
            get { return !procedureDeviation.RevertedBackToOriginal; }
        }

        public bool RevertedBackToOriginalYes
        {
            get { return procedureDeviation.RevertedBackToOriginal; }
        }


        public string CreatedByUser
        {
            get { return procedureDeviation.CreatedBy.FullNameWithUserName; }
        }

        public string LastModifiedUser
        {
            get { return procedureDeviation.LastModifiedBy.FullNameWithUserName; }
        }

        public string CreationDateTime
        {
            get { return procedureDeviation.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return procedureDeviation.LastModifiedDateTime.ToLongDateAndTimeString(); }
        }

        public string OperatingProcedureNumber
        {
            get { return procedureDeviation.OperatingProcedureNumber; }
        }

        public string OperatingProcedureTitle
        {
            get { return procedureDeviation.OperatingProcedureTitle; }
        }


        public string ReasonForDeviation
        {
            get { return procedureDeviation.Description; }
        }

        public string OperatingProcedureLevel
        {
            get
            {
                return procedureDeviation.OperatingProcedureLevel != null
                    ? procedureDeviation.OperatingProcedureLevel.GetName()
                    : string.Empty;
            }
        }

        public List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    procedureDeviation.FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }

        public List<DocumentLinkReportAdapter> DocumentLinkReportAdapters
        {
            get
            {
                return procedureDeviation.DocumentLinks.ConvertAll(obj => new DocumentLinkReportAdapter(
                    procedureDeviation.IdValue.ToString(CultureInfo.InvariantCulture), obj.Url, obj.Title));
            }
        }


        public List<ExtensionReasonReportAdapter> ExtensionReasonComments
        {
            get
            {
                if (procedureDeviation.ReasonsForExtensionSortedByCreatedDate != null)
                {
                    return
                        procedureDeviation.ReasonsForExtensionSortedByCreatedDate.ConvertAll(
                            comment => new ExtensionReasonReportAdapter(comment));
                }
                return new List<ExtensionReasonReportAdapter>();
            }
        }

        public string LocationEquipmentNumber
        {
            get { return procedureDeviation.LocationEquipmentNumber; }
        }

        public string StartDate
        {
            get { return procedureDeviation.FromDateTime.ToLongDateAndTimeString(); }
        }

        public string SuggestedCompletionDateTime
        {
            get { return procedureDeviation.ToDateTime.ToLongDateAndTimeString(); }
        }


        public string NumberOfExtensions
        {
            get { return procedureDeviation.NumberOfExtensions.ToString(); }
        }


        public string EnhancementDescription
        {
            get { return procedureDeviation.RichTextDescription; }
        }


        // TODO: update the report adapter and report
        public string CauseDeterminationComments
        {
            get
            {
                return procedureDeviation.CauseDeterminationComments;
            }
        }

        public bool FixDocumentForDurationOfDeviation
        {
            get
            {
                return procedureDeviation.FixDocumentDurationType ==
                       CorrectiveActionFixDocumentDurationType.DeviationDurationOnly;
            }
        }

        public bool FixDocumentForDurationOfDeviationAndPermanentRevisionRequired
        {
            get
            {
                return procedureDeviation.FixDocumentDurationType ==
                       CorrectiveActionFixDocumentDurationType.DeviationDurationAndPermanentRevisionRequired;
            }
        }

        public string FixEquipmentIlpWrNumbers
        {
            get
            {
                var sb = new StringBuilder();
                if (!procedureDeviation.CorrectiveActionIlpNumber.IsNullOrEmptyOrWhitespace())
                {
                    sb.AppendLine("ILP#: " + procedureDeviation.CorrectiveActionIlpNumber);
                }
                if (!procedureDeviation.CorrectiveActionWorkRequestNumber.IsNullOrEmptyOrWhitespace())
                {
                    sb.AppendLine("WR#: " + procedureDeviation.CorrectiveActionWorkRequestNumber);
                }
                return sb.ToString();
            }
        }

        public string CorrectiveActions
        {
            get { return procedureDeviation.CorrectiveActionOtherComments; }
        }

        public List<ApprovalReportAdapter> ImmediateApprovalReportAdapters
        {
            get
            {
                return
                    procedureDeviation.ImmediateApprovals.ConvertAll(
                        approval =>
                            new ApprovalReportAdapter(procedureDeviation.IdValue, approval.Approver,
                                approval.ApprovedByUser, approval.ApprovalDateTime, approval.WorkAssignmentDisplayName));
            }
        }

        public List<ApprovalReportAdapter> TemporaryApprovalReportAdapters
        {
            get
            {
                return
                    procedureDeviation.TemporaryApprovals.ConvertAll(
                        approval =>
                            new ApprovalReportAdapter(procedureDeviation.IdValue, approval.Approver,
                                approval.ApprovedByUser, approval.ApprovalDateTime, approval.WorkAssignmentDisplayName));
            }
        }

        public string WatermarkText
        {
            get { return procedureDeviation.FormStatus.Name; }
        }
    }
}