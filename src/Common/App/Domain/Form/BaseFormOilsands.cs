using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public abstract class BaseFormOilsands : ModifiableDomainObject
    {
        protected BaseFormOilsands(User createdBy, DateTime createdDateTime) : base(createdBy, createdDateTime)
        {
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
        }

        public abstract List<FormApproval> Approvals { get; set; }

        public abstract Date FromDate { get; }
        public abstract Date ToDate { get; }

        public User CreatedBy { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public abstract FormOilsandsPriorityPageDTO CreatePriorityPageDTO();

        protected List<string> RemainingApprovalsAsStringList()
        {
            var remainingApprovals =
                Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        }

        public bool AllApprovalsAreIn()
        {
            return FormApproval.AllApprovalsAreIn(Approvals);
        }

        public virtual void ConvertToClone(User createdByUser, DateTime now)
        {
            Id = null;
            CreatedBy = createdByUser;
            CreatedDateTime = now;
            LastModifiedBy = createdByUser;
            LastModifiedDateTime = now;

            Approvals.Clear();
        }
    }
}