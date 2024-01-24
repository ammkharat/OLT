using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationFormApproval : FormApproval
    {
        public ProcedureDeviationFormApproval(long? formId,
            ProcedureDeviationApprovalType approvalType, string approverTitle, string approverName, User approvedByUser,
            ProcedureDeviationApprovalObtainedVia obtainedVia, DateTime? approvalDateTime, int displayOrder)
            : this(null, formId, approverName, approvedByUser, approvalDateTime, approverTitle, displayOrder)
        {
            ApprovalType = approvalType;
            ObtainedVia = obtainedVia;
            WorkAssignmentDisplayName = approverTitle;
        }

        private ProcedureDeviationFormApproval(long? id,
            long? formId,
            string approver,
            User approvedByUser,
            DateTime? approvalDateTime,
            string workAssignmentDisplayName,
            int displayOrder)
            : base(
                id, formId, approver, approvedByUser, approvalDateTime, workAssignmentDisplayName, displayOrder,
                ApprovalShouldBeEnabledBehaviour.Always, true)
        {
        }

        public ProcedureDeviationApprovalType ApprovalType { get; set; }

        public ProcedureDeviationApprovalObtainedVia ObtainedVia { get; set; }

        public static bool HasAtLeastOneApproval(List<ProcedureDeviationFormApproval> approvals)
        {
            return approvals.Any(approval => approval.IsApproved);
        }

        public override void Unapprove()
        {
            ApprovedByUser = null;
            ApprovalDateTime = null;
        }
    }
}