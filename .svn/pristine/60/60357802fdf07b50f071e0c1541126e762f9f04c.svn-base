using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ApprovalReportAdapter
    {
        internal ApprovalReportAdapter(long? parentId, string approver, User approvedBy, DateTime? approvedDateTime,
            string workAssignmentDisplayName)
        {
            ParentId = parentId;
            Approver = approver;
            ApprovedBy = approvedBy != null ? approvedBy.FullName : string.Empty;
            ApprovedDateTime = approvedDateTime.HasValue
                ? approvedDateTime.Value.ToLongDateAndTimeString()
                : string.Empty;
            WorkAssignmentDisplayName = workAssignmentDisplayName;
        }

        public ApprovalReportAdapter(FormApproval formApproval)
            : this(
                null, formApproval.Approver, formApproval.ApprovedByUser, formApproval.ApprovalDateTime,
                formApproval.WorkAssignmentDisplayName)
        {
        }

        public string Approver { get; private set; }
        public string ApprovedBy { get; private set; }
        public string ApprovedDateTime { get; private set; }
        public long? ParentId { get; private set; }

        public string WorkAssignmentDisplayName { get; private set; }
    }
}