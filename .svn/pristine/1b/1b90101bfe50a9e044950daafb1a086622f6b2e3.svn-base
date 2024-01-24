using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class TargetDefinitionDTO : DomainObject, IHasPriority, IIsActive, IHasStatus<TargetDefinitionStatus>
    {
        private readonly string scheduleTypeName;
        private readonly TargetValue targetValue;

        public TargetDefinitionDTO(TargetDefinition targetDefinition) :
            this(targetDefinition.IdValue,
                targetDefinition.Name,
                targetDefinition.Category.IdValue,
                targetDefinition.Description,
                targetDefinition.Schedule.Type.GetName(),
                targetDefinition.FunctionalLocation.FullHierarchy,
                targetDefinition.Schedule.StartDate,
                targetDefinition.Schedule.EndDate,
                targetDefinition.Schedule.StartTime,
                targetDefinition.Schedule.EndTime,
                targetDefinition.Schedule.HasEndTime,
                targetDefinition.Status.IdValue,
                targetDefinition.Status.Name,
                targetDefinition.Priority,
                targetDefinition.OperationalMode.Name,
                targetDefinition.TagInfo.Name,
                targetDefinition.RequiresApproval,
                targetDefinition.LastModifiedBy.Id,
                targetDefinition.LastModifiedBy.FullNameWithUserName,
                targetDefinition.IsActive,
                targetDefinition.TargetValue,
                targetDefinition.GapUnitValue,
                targetDefinition.NeverToExceedMinimum,
                targetDefinition.MinValue,
                targetDefinition.MaxValue,
                targetDefinition.NeverToExceedMaximum,
                targetDefinition.AssignmentName
            )
        {
        }

        public TargetDefinitionDTO(long id, string name, long categoryId, string description,
            string scheduleTypeName, string functionalLocationName,
            Date startDate, Date endDate, Time startPollingTime, Time endPollingTime,
            bool hasEndTime, long statusId,
            string statusName, Priority priority, string operationalModeName, string tagName,
            bool requiresApproval, long? lastModifiedUserId,
            string lastModifiedFullNameWithUserName, bool isActive, TargetValue targetValue,
            decimal? gapUnitValue, decimal? neverToExceedMin, decimal? min, decimal? max, decimal? neverToExceedMax,
            string workAssignmentName)
        {
            this.id = id;
            Name = name;
            CategoryId = categoryId;
            Description = description;
            this.scheduleTypeName = scheduleTypeName;
            FunctionalLocationName = functionalLocationName;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startPollingTime;
            EndTime = endPollingTime;
            HasEndTime = hasEndTime;
            StatusId = statusId;
            StatusName = statusName;
            Priority = priority;
            OperationalModeName = operationalModeName;
            TagName = tagName;
            RequiresApproval = requiresApproval;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
            IsActive = isActive;
            this.targetValue = targetValue;
            GapUnitValue = gapUnitValue;
            NeverToExceedMin = neverToExceedMin;
            Min = min;
            Max = max;
            NeverToExceedMax = neverToExceedMax;
            WorkAssignmentName = workAssignmentName;
        }

        public long? LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        public bool RequiresApproval { get; private set; }

        [IncludeInSearch]
        public string Name { get; private set; }

        public long CategoryId { get; private set; }

        [IncludeInSearch]
        public string CategoryName
        {
            get { return TargetCategory.GetTargetCategory(CategoryId).Name; }
        }

        [IncludeInSearch]
        public string WorkAssignmentName { get; set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationName { get; private set; }

        public string ScheduleTypeName
        {
            get { return scheduleTypeName; }
        }

        [IncludeInSearch]
        public Date StartDate { get; private set; }

        [IncludeInSearch]
        public Time StartTime { get; private set; }

        [IncludeInSearch]
        public Date EndDate { get; private set; }

        public Time EndTime { get; private set; }

        public DateTime? StartDateAsDateTime
        {
            get { return StartDate != null ? (DateTime?) StartDate.CreateDateTime(StartTime) : null; }
        }

        public DateTime? EndDateAsDateTime
        {
            get { return EndDate != null ? (DateTime?) EndDate.CreateDateTime(StartTime) : null; }
        }

        [IncludeInSearch]
        public Time EndTimeAsNullableTime
        {
            get
            {
                // If "Round the Clock" schedule with no EndDate return null; otherwise return the EndTime
                if (ScheduleTypeName == ScheduleType.RoundTheClock.GetName())
                {
                    return EndDateAsDateTime.HasValue ? EndTime : null;
                }

                return HasEndTime ? EndTime : null;
            }
        }

        public bool HasEndTime { get; private set; }

        public long StatusId { get; private set; }

        public string StatusName { get; private set; }

        public string TagName { get; private set; }

        // ReSharper disable UnusedAutoPropertyAccessor.Global
        [IncludeInSearch]
        public decimal? GapUnitValue { get; private set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Global


        // ReSharper disable UnusedAutoPropertyAccessor.Global
        [IncludeInSearch]
        public string OperationalModeName { get; private set; }

        // ReSharper restore UnusedAutoPropertyAccessor.Global

        [IncludeInSearch]
        public string TargetValue
        {
            get { return targetValue.Title; }
        }

        public decimal? NeverToExceedMin { get; private set; }
        public decimal? Min { get; private set; }
        public decimal? Max { get; private set; }
        public decimal? NeverToExceedMax { get; private set; }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        [IncludeInSearch]
        public TargetDefinitionStatus Status
        {
            get { return TargetDefinitionStatus.Get(StatusId); }
        }

        public bool IsActive { get; private set; }
    }
}