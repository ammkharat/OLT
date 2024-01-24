using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormOvertimeFormReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly OvertimeForm overtimeForm;

        public FormOvertimeFormReportAdapter(OvertimeForm overtimeForm)
        {
            this.overtimeForm = overtimeForm;
            Label_Title = StringResources.DomainObjectName_OvertimeForm;
        }

        public string FormNumber
        {
            get
            {
                var id = overtimeForm.IdValue;
                return PadFormNumber(id);
            }
        }

        public string StartDate
        {
            get { return overtimeForm.FromDateTime.ToLongDateAndTimeString(); }
        }

        public string EndDate
        {
            get { return overtimeForm.ToDateTime.ToLongDateAndTimeString(); }
        }

        public long FormId
        {
            get { return overtimeForm.IdValue; }
        }

        public string CreatedByUser
        {
            get { return overtimeForm.CreatedBy.FullName; }
        }

        public string LastModifiedUser
        {
            get { return overtimeForm.LastModifiedBy.FullName; }
        }

        public string CreationDateTime
        {
            get { return overtimeForm.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return overtimeForm.LastModifiedDateTime.ToLongDateAndTimeString(); }
        }

        public string TradeOccupation
        {
            get { return overtimeForm.Trade; }
        }

        public string FunctionalLocation
        {
            get { return overtimeForm.FunctionalLocation.FullHierarchyWithDescription; }
        }

        public List<OnPremiseContractorReportAdapter> OnPremiseContractorReportAdapters
        {
            get
            {
                return
                    overtimeForm.OnPremiseContractors.ConvertAll(
                        item => new OnPremiseContractorReportAdapter(overtimeForm.IdValue, item));
            }
        }

        public List<ApprovalReportAdapter> ApprovalReportAdapters
        {
            get
            {
                return
                    overtimeForm.Approvals.ConvertAll(
                        approval =>
                            new ApprovalReportAdapter(overtimeForm.IdValue,
                                approval.Approver,
                                approval.ApprovedByUser,
                                approval.ApprovalDateTime,
                                approval.WorkAssignmentDisplayName));
            }
        }

        public string WatermarkText
        {
            get { return overtimeForm.FormStatus.Name; }
        }
    }
}