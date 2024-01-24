using System;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormApprovalGridDisplayAdapter
    {
        private readonly FormApproval approval;

        public FormApprovalGridDisplayAdapter(FormApproval approval)
        {
            this.approval = approval;
            IsApproved = approval.IsApproved;
        }

        public bool IsApproved { get; set; }
        public bool? DisableEdit { get { return approval.DisableEdit; }}

        public string Approver { get { return approval.Approver; } }

        public string ApprovedByUserName { get { return approval.ApprovedByUserName; } }

        public string WorkAssignmentDisplayName { get { return approval.WorkAssignmentDisplayName; } }

        public DateTime? ApprovalDateTime { get { return approval.ApprovalDateTime; } }

        public FormApproval GetApproval()
        {
            return approval;
        }
    }
}