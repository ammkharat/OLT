using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class WorkPermitLubesDTO : DomainObject, IHasDataSource, IHasStatus<PermitRequestBasedWorkPermitStatus>
    {
        public WorkPermitLubesDTO()
        {
        }

        public WorkPermitLubesDTO(WorkPermitLubes permit)
        {
            Id = permit.Id;

            DataSource = permit.DataSource;
            Status = permit.WorkPermitStatus;
            AdditionalFollowupRequired = permit.AdditionalFollowupRequired;
            PermitNumber = permit.PermitNumberDisplayValue;
            FunctionalLocation = permit.FunctionalLocation.FullHierarchy;
            StartDateTime = permit.StartDateTime;
            ExpireDateTime = permit.ExpireDateTime;
            IssuedDateTime = permit.IssuedDateTime;
            Version = permit.Version;
            Trade = permit.Trade;
            RequestedByGroup = permit.RequestedByGroup != null ? permit.RequestedByGroup.Name : null;
            Description = permit.TaskDescription;
            WorkOrderNumber = permit.WorkOrderNumber;
            LastEditorFullNameWithUserName = permit.LastModifiedBy.FullNameWithUserName;
            RequestedByUserFullNameWithUserName = permit.PermitRequestCreatedByUser != null
                ? permit.PermitRequestCreatedByUser.FullNameWithUserName
                : null;
            SubmittedByUserFullNameWithUserName = permit.PermitRequestSubmittedByUser != null
                ? permit.PermitRequestSubmittedByUser.FullNameWithUserName
                : null;
            IssuedByUserFullNameWithUserName = permit.IssuedBy != null ? permit.IssuedBy.FullNameWithUserName : null;
            Company = permit.Company;
            CreatedByUserId = permit.CreatedBy.IdValue;
            LastModifiedUserId = permit.LastModifiedBy.IdValue;
        }

        public Version Version { get; set; }

        public bool AdditionalFollowupRequired { get; set; }

        [IncludeInSearch]
        public string PermitNumber { get; set; }

        [IncludeInSearch]
        public string FunctionalLocation { get; set; }

        [IncludeInSearch]
        public DateTime StartDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? IssuedDateTime { get; set; }

        public DateTime StartOrIssuedDateTime
        {
            get { return IssuedDateTime != null ? IssuedDateTime.Value : StartDateTime; }
        }

        public DateTime ExpireDateTime { get; set; }

        [IncludeInSearch]
        public string Trade { get; set; }

        [IncludeInSearch]
        public string RequestedByGroup { get; set; }

        [IncludeInSearch]
        public string Description { get; set; }

        [IncludeInSearch]
        public string WorkOrderNumber { get; set; }

        [IncludeInSearch]
        public string LastEditorFullNameWithUserName { get; set; }

        [IncludeInSearch]
        public string RequestedByUserFullNameWithUserName { get; set; }

        [IncludeInSearch]
        public string SubmittedByUserFullNameWithUserName { get; set; }

        [IncludeInSearch]
        public string IssuedByUserFullNameWithUserName { get; set; }

        [IncludeInSearch]
        public string Company { get; set; }

        public bool HasBeenIssued
        {
            get { return IssuedDateTime != null; }
        }

        public long CreatedByUserId { get; set; }

        public long LastModifiedUserId { get; set; }

        [IncludeInSearch]
        public DataSource DataSource { get; set; }

        [IncludeInSearch]
        public PermitRequestBasedWorkPermitStatus Status { get; set; }

    }
}