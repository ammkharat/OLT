using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ActionItemDefinitionDTO : DomainObject, IHasSchedule, IIsActive, IHasPriority, IHasDataSource,
        IHasStatus<ActionItemDefinitionStatus>
    {
        private readonly List<string> functionalLocationNames = new List<string>();
        private readonly string scheduleTypeName;
        private readonly long sourceId;
        private readonly Time startTime;
        private readonly long statusId;
        private readonly List<string> visibilityGroupNames = new List<string>();

        public ActionItemDefinitionDTO(long id, string name, Date startDate, Time startTime, Date endDate, Time endTime,
            long statusId, long lastModifiedUserId, string lastModifiedFullNameUserName, string description,
            string scheduleTypeName, long? categoryId, string categoryName, long sourceId, bool isActive,
            long operatorModeId, Priority priority,bool reading)    //ayman custom fields DMND0010030
        {
            this.id = id;
            Name = name;
            StartDate = startDate;
            this.startTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            this.statusId = statusId;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedFullNameWithUserName = lastModifiedFullNameUserName;
            Description = description;
            this.scheduleTypeName = scheduleTypeName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            this.sourceId = sourceId;
            IsActive = isActive;
            OperationalModeId = operatorModeId;
            Priority = priority;
            Reading = reading;                           //ayman action item reading
        }

        public ActionItemDefinitionDTO(ActionItemDefinition actionItemDefinition)
            : this(
                actionItemDefinition.Id.GetValueOrDefault(),
                actionItemDefinition.Name,
                actionItemDefinition.Schedule.StartDate,
                actionItemDefinition.Schedule.StartTime,
                actionItemDefinition.Schedule.Type == ScheduleType.Single
                    ? actionItemDefinition.Schedule.EndDateTime.ToDate()
                    : actionItemDefinition.Schedule.EndDate,
                actionItemDefinition.Schedule.EndTime,
                actionItemDefinition.Status.IdValue,
                actionItemDefinition.LastModifiedBy.IdValue,
                actionItemDefinition.LastModifiedBy.FullNameWithUserName,
                actionItemDefinition.Description,
                actionItemDefinition.Schedule.Type.Name,
                actionItemDefinition.Category == null ? null : actionItemDefinition.Category.Id,
                actionItemDefinition.Category == null ? null : actionItemDefinition.Category.Name,
                actionItemDefinition.Source.IdValue,
                actionItemDefinition.Active,
                actionItemDefinition.OperationalMode.IdValue,
                actionItemDefinition.Priority,
                actionItemDefinition.Reading
                     //ayman custom fields DMND0010030
                )
        {
            actionItemDefinition.FunctionalLocations.ForEach(floc => AddFunctionalLocationName(floc.FullHierarchy));
            actionItemDefinition.WritableWorkAssignmentVisibilityGroups.ForEach(
                wavg => AddVisibilityGroupName(wavg.VisibilityGroupName));
        }
        [IncludeInSearch]
        public string Name { get; private set; }

        public long? CategoryId { get; private set; }

        public bool IsPending
        {
            get { return (Is(ActionItemDefinitionStatus.Pending)); }
        }

        public bool IsApproved
        {
            get { return (statusId == ActionItemDefinitionStatus.Approved.IdValue); }
        }

        public long OperationalModeId { get; private set; }

        public bool Reading { get; private set; }                  //ayman action item reading

        [IncludeInSearch]
        public string OperationalModeName
        {
            get { return OperationalMode.GetById(OperationalModeId).Name; }
        }

        public string ScheduleTypeName
        {
            get { return scheduleTypeName; }
        }

        public DateTime? StartDateAsDateTime
        {
            get { return StartDate == null ? null : (DateTime?) StartDate.CreateDateTime(StartTime); }
        }

        public DateTime? EndDateAsDateTime
        {
            get { return EndDate == null ? null : (DateTime?) EndDate.CreateDateTime(EndTime); }
        }

        [IncludeInSearch]
        public Time EndTimeAsNullableTime
        {
            get
            {
                // If continuous schedule with no EndDate return null; otherwise return the EndTime
                if (ScheduleTypeName == ScheduleType.Continuous.GetName())
                {
                    return HasEndTime ? EndTime : null;
                }

                return EndTime;
            }
        }

        public bool HasEndTime
        {
            get { return EndDateAsDateTime.HasValue; }
        }

        [IncludeInSearch]
        public Date StartDate { get; private set; }

        [IncludeInSearch]
        public Time StartTime
        {
            get { return startTime; }
        }

        [IncludeInSearch]
        public Date EndDate { get; private set; }

        public Time EndTime { get; private set; }

        [IncludeInSearch]
        public string SourceName
        {
            get { return DataSource.GetById(sourceId).Name; }
        }

        public long StatusId
        {
            get { return statusId; }
        }

        [IncludeInSearch]
        public string StatusName
        {
            get { return Status.Name; }
        }

        public long LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public string CategoryName { get; private set; }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string FunctionalLocationNamesCommaSeperated
        {
            get { return functionalLocationNames.BuildCommaSeparatedList(); }
        }

        public DataSource DataSource
        {
            get { return DataSource.GetById(sourceId); }
        }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        public bool IsRecurring
        {
            get { return scheduleTypeName != ScheduleType.Single.Name; }
        }

        public ActionItemDefinitionStatus Status
        {
            get { return ActionItemDefinitionStatus.GetById(statusId); }
        }

        public bool IsActive { get; private set; }

        public bool Is(ActionItemDefinitionStatus status)
        {
            return status.IdValue == statusId;
        }

        public List<string> GetFunctionalLocationNames()
        {
            {
                return functionalLocationNames.ToList();
            }
        }

        public void AddFunctionalLocationName(string functionalLocationName)
        {
            if (functionalLocationName.HasValue())
                functionalLocationNames.AddAndSort(functionalLocationName);
        }

        public void AddVisibilityGroupName(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }
    }
}