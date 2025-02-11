﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormApproval : DomainObject, IHasDisplayOrder
    {
        private readonly ApprovalShouldBeEnabledBehaviour shouldBeEnabledBehaviour;
        private int displayOrder;

        public FormApproval(long? id,
            long? formId,
            string approver,
            User approvedByUser,
            DateTime? approvalDateTime,
            string workAssignmentDisplayName,
            int displayOrder)
            : this(
                id, formId, approver, approvedByUser, approvalDateTime, workAssignmentDisplayName, displayOrder,
                ApprovalShouldBeEnabledBehaviour.Always, true)
        {
        }

        public FormApproval(long? id,
            long? formId,
            string approver,
            User approvedByUser,
            DateTime? approvalDateTime,
            string workAssignmentDisplayName,
            int displayOrder,
            ApprovalShouldBeEnabledBehaviour shouldBeEnabledBehaviour,
            bool enabled)
        {
            Id = id;
            FormId = formId;
            Approver = approver;
            ApprovedByUser = approvedByUser;
            ApprovalDateTime = approvalDateTime;
            WorkAssignmentDisplayName = workAssignmentDisplayName;
            Enabled = enabled;
            this.displayOrder = displayOrder;
            this.shouldBeEnabledBehaviour = shouldBeEnabledBehaviour;
        }
       
        //Added by ppanigrahi.
        public FormApproval(long? id,
           long? formId,
           string approver,
           User approvedByUser,
           DateTime? approvalDateTime,
           string workAssignmentDisplayName,
           int displayOrder,
           ApprovalShouldBeEnabledBehaviour shouldBeEnabledBehaviour,
           bool enabled, string emaillist,bool isMailSent)
        {
            Id = id;
            FormId = formId;
            Approver = approver;
            ApprovedByUser = approvedByUser;
            ApprovalDateTime = approvalDateTime;
            WorkAssignmentDisplayName = workAssignmentDisplayName;
            Enabled = enabled;
            this.displayOrder = displayOrder;
            this.shouldBeEnabledBehaviour = shouldBeEnabledBehaviour;
            this.EmailList = emaillist;
            this.isMailSent = isMailSent;

        }
        public FormApproval(long? id,
           long? formId,
           string approver,
           User approvedByUser,
           DateTime? approvalDateTime,
           string workAssignmentDisplayName,
           int displayOrder,
           ApprovalShouldBeEnabledBehaviour shouldBeEnabledBehaviour,
           bool enabled,  bool isMailSent)
        {
            Id = id;
            FormId = formId;
            Approver = approver;
            ApprovedByUser = approvedByUser;
            ApprovalDateTime = approvalDateTime;
            WorkAssignmentDisplayName = workAssignmentDisplayName;
            Enabled = enabled;
            this.displayOrder = displayOrder;
            this.shouldBeEnabledBehaviour = shouldBeEnabledBehaviour;
          
            this.isMailSent = isMailSent;

        }
        public string EmailList { get; set; }//Added by ppanigrahi
        public long? FormId { get; private set; }
        public string Approver { get; set; }
        public User ApprovedByUser { get; set; }
        public DateTime? ApprovalDateTime { get; set; }
        public bool isMailSent;//Added by ppanigrahi

        public string ApprovedByUserName
        {
            get
            {
                if (ApprovedByUser != null)
                {
                    return ApprovedByUser.FullNameWithUserName;
                }

                return null;
            }
        }

        public bool IsApproved
        {
            get { return ApprovedByUser != null; }
        }

        public long ShouldBeEnabledBehaviourId
        {
            get { return shouldBeEnabledBehaviour.IdValue; }
        }

        public bool Enabled { get; set; }
        public string WorkAssignmentDisplayName { get; set; }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }

        public bool? DisableEdit { get; set; }

        public virtual void Unapprove()
        {
            ApprovedByUser = null;
            ApprovalDateTime = null;
            WorkAssignmentDisplayName = null;
        }

        //ayman Sarnia eip DMND0008992
        public bool ShouldBeEnabledForSarnia(FormGN75B form, DateTime now)
        {
            return shouldBeEnabledBehaviour.ShouldBeEnabledForSarnia(form, now);
        }
        
        public bool ShouldBeEnabled(BaseEdmontonForm form, DateTime now)
        {
            return shouldBeEnabledBehaviour.ShouldBeEnabled(form, now);
        }

        public static bool AllApprovalsAreIn(List<FormApproval> approvals)
        {
            return approvals.TrueForAll(approval => !approval.Enabled || approval.IsApproved);
        }

        public static string GetApprovalsSnapshot(List<FormApproval> approvals)
        {
            var stringList =
                approvals.Any(approval => !approval.WorkAssignmentDisplayName.IsNullOrEmptyOrWhitespace())
                    ? approvals.FindAll(approval => approval.IsApproved)
                        .ConvertAll(
                            approval =>
                                String.Format("{0} ({1}), {2}", approval.Approver, approval.ApprovedByUser.Username,
                                    approval.WorkAssignmentDisplayName))
                    : approvals.FindAll(approval => approval.IsApproved)
                        .ConvertAll(
                            approval => String.Format("{0} ({1})", approval.Approver, approval.ApprovedByUser.Username));
            stringList.Sort();
            return stringList.BuildCommaSeparatedList();
        }

        public static bool ThereAreCurrentlyApprovalsByOtherPeople(List<FormApproval> approvals, User currentUser)
        {
            return approvals.Exists(approval => approval.IsApproved && approval.ApprovedByUser.Id != currentUser.Id);
        }

        public static void UnapproveApprovalsThatWereNotApprovedByUser(User user, List<FormApproval> approvals)
        {
            approvals.FindAll(approval => approval.IsApproved && approval.ApprovedByUser.Id != user.Id)
                .ForEach(approval => approval.Unapprove());
        }

        public static void UnapproveApprovals(List<FormApproval> approvals)
        {
            approvals.ForEach(approval => approval.Unapprove());
        }
    }
}