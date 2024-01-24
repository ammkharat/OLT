using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LogDefinitionDTO : DomainObject, IFlaggableAsOperatingEngineerLog, ICreatedByARole, IIsActive
    {
        private readonly List<string> functionalLocations;
        private readonly List<string> visibilityGroupNames;

        public LogDefinitionDTO(LogDefinition logDefinition)
            : this(
                logDefinition.Id.GetValueOrDefault(),
                logDefinition.PlainTextComments,
                logDefinition.LastModifiedBy.Id,
                logDefinition.LastModifiedBy.FullNameWithUserName,
                logDefinition.Schedule,
                logDefinition.FunctionalLocations.ConvertAll(fl => fl.FullHierarchy),
                logDefinition.CreatedDateTime,
                logDefinition.IsOperatingEngineerLog,
                logDefinition.CreatedByRole.IdValue,
                logDefinition.CreatedBy.IdValue,
                logDefinition.LogType,
                logDefinition.Active,
                logDefinition.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName)
                )
        {
        }

        public LogDefinitionDTO(
            long id,
            string comments,
            long? lastModifiedUserId,
            string lastModifiedFullNameWithUserName,
            ISchedule schedule,
            List<string> functionalLocations,
            DateTime logDateTime,
            bool isOperatingEngineerLog,
            long createdByRoleId,
            long createdByUserId,
            LogType logType,
            bool isActive,
            List<string> visibilityGroupNames)
        {
            this.id = id;
            Comments = comments;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
            ScheduleInformation = schedule.ToString(false);
            this.functionalLocations = functionalLocations;
            this.visibilityGroupNames = visibilityGroupNames ?? new List<string>();
            this.visibilityGroupNames.Sort();
            LogDateTime = logDateTime;
            IsOperatingEngineerLog = isOperatingEngineerLog;
            CreatedByRoleId = createdByRoleId;
            CreatedByUserId = createdByUserId;
            LogType = logType;
            IsActive = isActive;
        }

        public LogType LogType { get; private set; }

        [IncludeInSearch]
        public DateTime LogDateTime { get; private set; }

        [IncludeInSearch]
        public string Comments { get; private set; }

        [IncludeInSearch]
        public string ScheduleInformation { get; private set; }

        public long? LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        public long CreatedByRoleId { get; private set; }
        public long CreatedByUserId { get; private set; }
        public bool IsOperatingEngineerLog { get; private set; }
        public bool IsActive { get; private set; }

        public void AddFunctionalLocation(string functionalLocationFullHierarchy)
        {
            functionalLocations.AddAndSort(functionalLocationFullHierarchy);
        }

        public string ToDisplayString()
        {
            const string formatString = "{0}     {1}     {2}";
            return String.Format(formatString, FunctionalLocationNames, LastModifiedFullNameWithUserName, Comments);
        }

        public void AddVisibilityGroup(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }
    }
}