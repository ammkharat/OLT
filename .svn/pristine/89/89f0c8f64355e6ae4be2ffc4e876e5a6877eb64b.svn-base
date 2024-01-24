using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public abstract class BaseEdmontonForm : ModifiableDomainObject, IFunctionalLocationRelevant, IEdmontonForm
    {
        private List<FormApproval> approvals = new List<FormApproval>();
        private FormStatus formStatus;

       
        protected BaseEdmontonForm(long? id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User createdBy, DateTime createdDateTime)   
            : base(createdBy, createdDateTime)
        {
            this.id = id;
            FormStatus = formStatus;

            FromDateTime = validFromDateTime;
            ToDateTime = validToDateTime;

            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;

           Approvals = new List<FormApproval>();
        }

       public DateTime CreatedDateTime { get; protected set; }

        public DateTime? ApprovedDateTime { get; set; }
        public DateTime? ClosedDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public List<FormApproval> EnabledApprovals
        {
            get { return approvals.FindAll(a => a.Enabled); }
        }

        public List<FormApproval> Approvals
        {
            get { return approvals; }
            set { approvals = value; }
        }

        public virtual List<FormApproval> AllApprovals
        {
            get { return Approvals; }
        }

        public abstract EdmontonFormType FormType { get; }

        
        public long FormNumber
        {
            get { return IdValue; }
        }

        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        public User CreatedBy { get; protected set; }

        public abstract IFormEdmontonDTO CreateDTO();

      
        // TODO: This should include the LastModifiedDateTime and LastModifiedByUser because the class implements ModifiableDomainObject whose base constructor takes
        // these, not createdBy and createdDateTime

        public virtual void ConvertToClone(User createdByUser)
        {
            var now = Clock.Now;

            Id = null;
            CreatedBy = createdByUser;
            CreatedDateTime = now;
            LastModifiedBy = createdByUser;
            LastModifiedDateTime = now;

            FromDateTime = now;
            SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());

            FormStatus = FormStatus.Draft;
            
            ApprovedDateTime = null;
            ClosedDateTime = null;

            AllApprovals.ForEach(approval => approval.Unapprove());
        }

        public virtual void MarkAsClosed(DateTime closedDateTime, User user)
        {
            ClosedDateTime = closedDateTime;
            FormStatus = FormStatus.Closed;
            LastModifiedBy = user;
        }

        public virtual FormStatus FormStatus
        {


            get {return formStatus;}

            set
            {
                formStatus = value;
                if (value == FormStatus.Draft)
                {
                    ApprovedDateTime = null;
                    ClosedDateTime = null;
                }

                if (value == FormStatus.Approved)
                {
                    ClosedDateTime = null;
                }
            }
        }

        public bool IsRelevantTo(long siteIdOfClient, 
            List<string> clientFullHierarchies, 
            List<string> workPermitEdmontonFullHierarchies, 
            List<string> restrictionsFullHierarchies, 
            SiteConfiguration siteConfiguration)
        {
            List<string> fullHierarchies;

            if (siteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                !workPermitEdmontonFullHierarchies.IsEmpty())
            {
                fullHierarchies = workPermitEdmontonFullHierarchies;
            }
            else
            {
                fullHierarchies = clientFullHierarchies;
            }

            return CheckFlocRelevancy(siteIdOfClient, fullHierarchies);
        }

        protected virtual List<string> RemainingApprovalsAsStringList()
        {
            var remainingApprovals =
                AllApprovals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        }

        protected virtual bool ThereAreCurrentlyApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(AllApprovals, currentUser);
        }

        public virtual bool AllApprovalsAreIn()
        {
            return FormApproval.AllApprovalsAreIn(AllApprovals);
        }

        public virtual void MarkAsApproved(DateTime? approvedDateTime)
        {
            ApprovedDateTime = approvedDateTime;
            FormStatus = ((Clock.Now > ToDateTime) && FormStatus != FormStatus.Closed) ? FormStatus.Expired : FormStatus.Approved;
            //FormStatus = ((DateTime.Now > ToDateTime) && FormStatus != FormStatus.Closed) ? FormStatus.Expired : FormStatus.Approved;   //ayman expired when old
        }

        public void MarkAsUnapproved()
        {
            ApprovedDateTime = null;
            FormStatus = ((DateTime.Now > ToDateTime) && FormStatus != FormStatus.Closed) ? FormStatus.Expired : FormStatus.Draft;    //ayman expired when old  
        }

        public void MarkAsWaitingForApproval() // Swapnil Patki For DMND0005325 Point Number 7
        {
            ApprovedDateTime = null;
            FormStatus = ((DateTime.Now > ToDateTime) && FormStatus != FormStatus.Closed) ? FormStatus.Expired : FormStatus.WaitingForApproval;  //ayman expired when old  
        }

        public bool IsApproved()
        {
            return FormStatus.Approved.Equals(FormStatus);
        }

        public bool IsDraft()
        {
            return FormStatus.Draft.Equals(FormStatus);
        }

        public virtual void SetDefaultDatesBasedOnShift(bool isDayShift, Date currentDate, Time currentTime)
        {
            var validToTime = WorkPermitEdmonton.NightShiftStartTime;

            Date validToDate;

            if (isDayShift)
            {
                validToDate = currentDate;
            }
            else
            {
                if (currentTime.InRange(Time.NOON, Time.MIDNIGHT))
                {
                    // Must be evening in the night shift
                    validToDate = currentDate.AddDays(1);
                }
                else
                {
                    // must be morning in the night shift
                    validToDate = currentDate;
                }
            }

            ToDateTime = validToDate.CreateDateTime(validToTime);
        }

        protected virtual string GetApprovalsSnapshot()
        {
            return FormApproval.GetApprovalsSnapshot(AllApprovals);
        }

        protected abstract bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies);

        protected static bool CheckFlocRelevancyForMultipleFlocs(long siteIdOfClient, List<string> fullHierarchies,
            List<FunctionalLocation> flocsForThisForm)
        {
            foreach (var floc in flocsForThisForm)
            {
                var isRelevant = CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, floc);

                if (isRelevant)
                    return true;
            }

            return false;
        }

        protected static bool CheckFlocRelevancyForASingleFloc(long siteIdOfClient, List<string> fullHierarchies,
            FunctionalLocation floc)
        {
            var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                             new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                             new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies);

            return isRelevant;
        }

        public bool IsWorkPermitDatesWithinFormDates(WorkPermitEdmonton workPermitEdmonton)
        {
            var formRange = new Range<DateTime>(FromDateTime, ToDateTime);
            return formRange.ContainsInclusive(workPermitEdmonton.RequestedStartDateTime) &&
                   formRange.ContainsInclusive(workPermitEdmonton.ExpiredDateTime);
        }

        //mangesh - clone permit request
        public bool IsWorkPermitDatesWithinFormDates(PermitRequestEdmonton workPermitEdmonton)
        {
            //DateTime s = Date.ToDateTimeOrMaxValue(workPermitEdmonton.RequestedStartDate);
            //DateTime e = Date.ToDateTimeOrMaxValue(workPermitEdmonton.EndDate);

            //var formRange = new Range<DateTime>(FromDateTime, ToDateTime);
            //return formRange.ContainsInclusive(s) &&
            //       formRange.ContainsInclusive(e);

            if (ToDateTime > Clock.Now)
            {
                return false;
            }
            return true;
        }

    }

    public interface IEdmontonForm
    {
        EdmontonFormType FormType { get; }
        long FormNumber { get; }
        FormStatus FormStatus { get; }
        User CreatedBy { get; }
        User LastModifiedBy { get; }
        DateTime FromDateTime { get; }
        DateTime ToDateTime { get; }
        void ConvertToClone(User user);
        void MarkAsClosed(DateTime dateTime, User user);
        IFormEdmontonDTO CreateDTO();
    }
}