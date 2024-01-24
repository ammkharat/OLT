using System;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ProcedureDeviationFormApprovalGridDisplayAdapter
    {
        private ProcedureDeviationFormApproval approval;

        public ProcedureDeviationFormApprovalGridDisplayAdapter(ProcedureDeviationFormApproval approval)
        {
            this.approval = approval;
            IsApproved = approval.IsApproved;
        }

        public bool IsApproved { get; set; }

        public bool? DisableEdit
        {
            get { return approval.DisableEdit; }
        }

        public string WorkAssignmentDisplayName
        {
            get { return approval.WorkAssignmentDisplayName; }
        }

        public string ApprovalType
        {
            get { return approval.ApprovalType.GetName(); }
        }

        public string Approver
        {
            get { return approval.Approver; }
        }

        public string ApprovedByUserName
        {
            get { return approval.ApprovedByUserName; }
        }

        public string ObtainedVia
        {
            get { return approval.ObtainedVia.GetName(); }
            set
            {
                var obtainedVia = ProcedureDeviationApprovalObtainedVia.GetByName(value);

                approval.ObtainedVia = obtainedVia ?? ProcedureDeviationApprovalObtainedVia.Email;
            }
        }

        public DateTime? ApprovalDateTime
        {
            get { return approval.ApprovalDateTime; }
        }

        public ProcedureDeviationFormApproval GetApproval()
        {
            return approval;
        }
    }
}