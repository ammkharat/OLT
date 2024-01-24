using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public abstract class BasePermitRequestHistory : DomainObjectHistorySnapshot
    {
        protected BasePermitRequestHistory(long id, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
        }

        protected BasePermitRequestHistory(long id, Date endDate, string workOrderNumber, string operationNumber,
            string description, string sapDescription, string company,  string supervisor, User lastImportedByUser,
            DateTime? lastImportedDateTime,
            User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            EndDate = endDate;
            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;

            Description = description;
            SapDescription = sapDescription;

            Company = company;
            
            Supervisor = supervisor;

            LastImportedByUser = lastImportedByUser;
            LastImportedDateTime = lastImportedDateTime;
            LastSubmittedByUser = lastSubmittedByUser;
            LastSubmittedDateTime = lastSubmittedDateTime;
        }

// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        protected BasePermitRequestHistory(long id, Date endDate, string workOrderNumber, string operationNumber,
          string description, string sapDescription, string company, string company_1, string company_2, string supervisor, User lastImportedByUser,
          DateTime? lastImportedDateTime,
          User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User lastModifiedBy, DateTime lastModifiedDate)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            EndDate = endDate;
            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;

            Description = description;
            SapDescription = sapDescription;

            Company = company;
            Company_1 = company_1;
            Company_1 = company_2;
            Supervisor = supervisor;

            LastImportedByUser = lastImportedByUser;
            LastImportedDateTime = lastImportedDateTime;
            LastSubmittedByUser = lastSubmittedByUser;
            LastSubmittedDateTime = lastSubmittedDateTime;
        }

        public Date EndDate { get; set; }
        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }

        public string Description { get; set; }
        public string SapDescription { get; set; }

        public string Company { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Company_1 { get; set; }
        public string Company_2 { get; set; }
        public string Supervisor { get; set; }

        [IgnoreDifference]
        public User LastImportedByUser { get; set; }

        public string LastImportedByUserFullNameWithUserName
        {
            get { return LastImportedByUser == null ? null : LastImportedByUser.FullNameWithUserName; }
        }

        public DateTime? LastImportedDateTime { get; set; }

        [IgnoreDifference]
        public User LastSubmittedByUser { get; set; }

        public string LastSubmittedByUserFullNameWithUserName
        {
            get { return LastSubmittedByUser == null ? null : LastSubmittedByUser.FullNameWithUserName; }
        }

        public DateTime? LastSubmittedDateTime { get; set; }
    }
}