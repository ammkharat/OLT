﻿using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class WorkPermitFortHillsDTO : DomainObject, IHasStatus<PermitRequestBasedWorkPermitStatus>, IHasDataSource,
        IHasPriority
    {
        private readonly long dataSourceId;
        private readonly long workPermitStatusId;
        private readonly long workPermitTypeId;
        

        public WorkPermitFortHillsDTO(long id, long dataSourceId, long workPermitStatusId, int workPermitTypeId,
            DateTime requestedStartDateTime, DateTime? startDateTime,
            DateTime endDateTime, long? permitNumber, string workOrderNumber, string trade, string @group,
            string description, string functionalLocation,
            DateTime createdDateTime, long createdByUserId, DateTime lastModifiedDateTime, long lastModifiedUserId,
            string lastModifiedByFullnameWithUserName, string issuedByFullnameWithUserName,
            string permitRequestCreatedByFullnameWithUserName,
            string company, string permitAcceptor, Priority priority, DateTime? revalidationDatetime, DateTime? extensionDateTime)
        {
            Id = id;
            this.dataSourceId = dataSourceId;
            this.workPermitStatusId = workPermitStatusId;
            this.workPermitTypeId = workPermitTypeId;
            RevalidationDateTime = revalidationDatetime;
            ExtensionDateTime = extensionDateTime;
            RequestedStartDateTime = requestedStartDateTime;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;

            PermitNumber = permitNumber;
            WorkOrderNumber = workOrderNumber;
            Occupation = trade;
            Group = group;
            Description = description;
            FunctionalLocation = functionalLocation;
            CreatedDateTime = createdDateTime;
            CreatedByUserId = createdByUserId;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedByFullnameWithUserName = lastModifiedByFullnameWithUserName;
            IssuedByFullnameWithUserName = issuedByFullnameWithUserName;
            PermitRequestCreatedByFullnameWithUserName = permitRequestCreatedByFullnameWithUserName;
            Company = company;
            PermitAcceptor = permitAcceptor;
            Priority = priority;
            
        }

        public WorkPermitFortHillsDTO(WorkPermitFortHills permit)
        {
            Id = permit.Id;

            dataSourceId = permit.DataSource.IdValue;
            workPermitStatusId = permit.WorkPermitStatus.IdValue;
            workPermitTypeId = permit.WorkPermitType.IdValue;

            RequestedStartDateTime = permit.RequestedStartDateTime;
            StartDateTime = permit.IssuedDateTime;
            EndDateTime = permit.ExpiredDateTime;
            RevalidationDateTime = permit.RevalidationDateTime;
            ExtensionDateTime = permit.ExtensionDateTime;
            if (ExtensionDateTime != null)
            {
                ExtensionReasonPartJ = permit.ExtensionReasonPartJ;
                ExtendedByUserId = permit.ExtendedByUser.IdValue;
                ExtendedByUserFullnameWithUserName = permit.ExtendedByUser.FullNameWithUserName;
            }
            
            PermitNumber = permit.PermitNumber;
            WorkOrderNumber = permit.WorkOrderNumber;

            Group = permit.Group != null ? permit.Group.Name : null;
            Occupation = permit.Occupation;
            Description = permit.TaskDescription;
            FunctionalLocation = permit.FunctionalLocation.FullHierarchy;
            CreatedDateTime = permit.CreatedDateTime;
            CreatedByUserId = permit.CreatedBy.IdValue;
            LastModifiedDateTime = permit.LastModifiedDateTime;
            LastModifiedUserId = permit.LastModifiedBy.IdValue;
            IssuedByFullnameWithUserName = permit.IssuedByUser != null ? permit.IssuedByUser.FullNameWithUserName : null;
            LastModifiedByFullnameWithUserName = permit.LastModifiedBy.FullNameWithUserName;
            Company = permit.Company;
            PermitAcceptor = permit.PermitAcceptor;
            Priority = permit.Prioritydata;
           // AreaLabelName = permit.AreaLabel == null ? null : permit.AreaLabel.Name;

            if (permit.PermitRequestCreatedByUser != null)
            {
                PermitRequestCreatedByFullnameWithUserName = permit.PermitRequestCreatedByUser.FullNameWithUserName;
            }
        }

        public PermitRequestBasedWorkPermitStatus WorkPermitStatus
        {
            get { return PermitRequestBasedWorkPermitStatus.Get(workPermitStatusId); }
        }

        [IncludeInSearch]
        public WorkPermitType WorkPermitType
        {
            get { return WorkPermitType.Get(workPermitTypeId); }
        }

        public string RequestedShiftName
        {
            get
            {
                var userShift = WorkPermitFortHills.UserShift(RequestedStartDateTime);
                return userShift.ShiftDisplayName;
            }
        }

        //public Date RequestedStartDate
        //{
        //    get { return new Date(RequestedStartDateTime); }
        //}

        [IncludeInSearch]
        public DateTime RequestedStartDateTime { get; private set; }

        // This is really the IssuedDateTime. It should be renamed
        [IncludeInSearch]
        public DateTime? StartDateTime { get; private set; }

        public DateTime RequestedOrIssuedDateTime
        {
            get { return StartDateTime != null ? StartDateTime.Value : RequestedStartDateTime; }
        }

        public DateTime EndDateTime { get; private set; }
        public DateTime? RevalidationDateTime { get; private set; }
        public DateTime? ExtensionDateTime { get; private set; }
        public string ExtensionReasonPartJ { get; private set; }
        public long ExtendedByUserId { get; private set; }
        public string ExtendedByUserFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public long? PermitNumber { get; private set; }

        [IncludeInSearch]
        public string WorkOrderNumber { get; private set; }

        [IncludeInSearch]
        public string Occupation { get; private set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public string Group { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocation { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public long CreatedByUserId { get; private set; }

        public DateTime LastModifiedDateTime { get; private set; }

        public long LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public string IssuedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public string LastModifiedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public string PermitRequestCreatedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public string Company { get; private set; }

        [IncludeInSearch]
        public string PermitAcceptor { get; private set; }

        public bool HasBeenIssued
        {
            get { return IssuedByFullnameWithUserName.HasValue(); }
        }
       
       

        [IncludeInSearch]
        public string AreaLabelName { get; private set; }

        [IncludeInSearch]
        public DataSource DataSource
        {
            get { return DataSource.GetById(dataSourceId); }
        }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        [IncludeInSearch]
        public PermitRequestBasedWorkPermitStatus Status
        {
            get { return WorkPermitStatus; }
        }
    }
}