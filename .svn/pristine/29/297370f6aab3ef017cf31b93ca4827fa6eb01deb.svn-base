using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class SummaryLogDTO : DomainObject, IFollowUp, IShiftBased, ICreatedByARole, IThreadableDTO, IHasDataSource
    {
        private readonly string functionalLocations;
        private readonly List<string> visibilityGroupNames = new List<string>();
        private readonly string workAssignmentName;

        public SummaryLogDTO(long id,
            DataSource dataSource,
            string functionalLocations,
            bool inspectionFollowUp,
            bool processControlFollowUp,
            bool operationsFollowUp,
            bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp,
            DateTime logDateTime,
            DateTime createdDateTime,
            long createdByUserId,
            long createdByRoleId,
            string lastModifiedFullNameWithUserName,
            string createdByFullNameWithUserName,
            long createdShiftPatternId,
            Date createdShiftStartDate,
            Time createdShiftStartTime,
            Date createdShiftEndDate,
            Time createdShiftEndTime,
            string createdShiftName,
            string workAssignmentName,
            string plainTextComments,
            long? rootLogId,
            long? replyToLogId,
            bool hasChildren,
            List<string> visibilityGroupNames)
        {
            this.id = id;
            this.functionalLocations = functionalLocations;
            DataSource = dataSource;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            LogDateTime = logDateTime;
            CreatedDateTime = createdDateTime;
            CreatedByUserId = createdByUserId;
            CreatedByRoleId = createdByRoleId;
            LastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
            CreatedByFullnameWithUserName = createdByFullNameWithUserName;
            CreatedShiftPatternId = createdShiftPatternId;
            CreatedShiftStartDate = createdShiftStartDate;
            CreatedShiftStartTime = createdShiftStartTime;
            CreatedShiftEndDate = createdShiftEndDate;
            CreatedShiftEndTime = createdShiftEndTime;
            CreatedShiftName = createdShiftName;
            this.workAssignmentName = workAssignmentName;
            PlainTextComments = plainTextComments;
            RootLogId = rootLogId;
            ReplyToLogId = replyToLogId;
            HasChildren = hasChildren;
            this.visibilityGroupNames = visibilityGroupNames ?? new List<string>();
            this.visibilityGroupNames.Sort();
        }

        public SummaryLogDTO(SummaryLog log)
            : this(
                log.IdValue,
                log.DataSource,
                log.FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                log.InspectionFollowUp,
                log.ProcessControlFollowUp,
                log.OperationsFollowUp,
                log.SupervisionFollowUp,
                log.EnvironmentalHealthSafetyFollowUp,
                log.OtherFollowUp,
                log.LogDateTime,
                log.CreatedDateTime,
                log.CreationUser.IdValue,
                log.CreatedByRole.IdValue,
                log.LastModifiedBy.FullNameWithUserName,
                log.CreationUser.FullNameWithUserName,
                log.CreatedShiftPattern.IdValue,
                GetCreateUserShift(log).StartDate,
                new Time(GetCreateUserShift(log).StartDateTime),
                GetCreateUserShift(log).EndDate,
                new Time(GetCreateUserShift(log).EndDateTime),
                log.CreatedShiftPattern.Name,
                log.WorkAssignment != null ? log.WorkAssignment.Name : null,
                log.PlainTextComments,
                log.RootLogId,
                log.ReplyToLogId,
                log.HasChildren,
                log.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName)
                )
        {
        }

        [IncludeInSearch]
        public string FunctionalLocations
        {
            get { return functionalLocations; }
        }

        [IncludeInSearch]
        public DateTime LogDateTime { get; private set; }

        public string LoggedDate
        {
            get { return LogDateTime.ToLongDateAndTimeString(); }
        }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public string CreatedByFullnameWithUserName { get; private set; }

        public Date CreatedShiftStartDate { get; private set; }

        public Time CreatedShiftStartTime { get; private set; }

        public Time CreatedShiftEndTime { get; private set; }

        public string CreatedShiftName { get; private set; }

        [IncludeInSearch]
        public string Shift
        {
            get { return String.Format("{0} - {1}", CreatedShiftStartDate, CreatedShiftName); }
        }

        [IncludeInSearch]
        public string WorkAssignmentName
        {
            get { return workAssignmentName ?? StringResources.None; }
        }

        [IncludeInSearch]
        public string PlainTextComments { get; private set; }

        public bool HasChildren { get; set; }

        public bool ParentIsUnavailable { get; private set; }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        public long CreatedByRoleId { get; private set; }

        public long CreatedByUserId { get; private set; }

        public bool InspectionFollowUp { get; private set; }

        public bool ProcessControlFollowUp { get; private set; }

        public bool OperationsFollowUp { get; private set; }

        public bool SupervisionFollowUp { get; private set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }

        public bool OtherFollowUp { get; private set; }
        public DataSource DataSource { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public long CreatedShiftPatternId { get; private set; }
        public Date CreatedShiftEndDate { get; private set; }

        public long? RootLogId { get; private set; }

        public long? ReplyToLogId { get; private set; }

        public string ToDisplayString()
        {
            const string formatString = "{0}     {1}     {2}";
            return String.Format(formatString, LogDateTime.ToShortDateAndTimeString(), FunctionalLocations,
                LastModifiedFullNameWithUserName);
        }

        public bool IsPartOfThread
        {
            get { return HasChildren || ReplyToLogId.HasValue; }
        }

        private static UserShift GetCreateUserShift(SummaryLog log)
        {
            return new UserShift(log.CreatedShiftPattern, log.LogDateTime);
        }

        public void AddVisibilityGroup(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }

        public bool IsCreatedBy(User user)
        {
            return CreatedByUserId == user.Id.Value;
        }
    }
}