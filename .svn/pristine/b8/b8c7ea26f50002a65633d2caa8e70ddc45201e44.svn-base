using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LogDTO : DomainObject, IHasSchedule, IHasDataSource, IFollowUp, IFlaggableAsOperatingEngineerLog,
        IShiftBased, ICreatedByARole, IRecommendForShiftSummary, IHasReadByCurrentUserInfo, IThreadableDTO
    {
        private readonly string functionalLocationFullHierarchies;
        private readonly List<string> visibilityGroupNames;

        public LogDTO(long id, long? rootLogId, long? replyToLogId, string functionalLocationNames,
            bool inspectionFollowUp,
            bool processControlFollowUp, bool operationsFollowUp, bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp, DateTime logDateTime, long createdByUserId, string createdByUserFirstName,
            string createdByUserLastName,
            string createdByUserUserName, string lastModifiedFullNameWithUserName, DateTime createdDateTime,
            DateTime lastModifiedDateTime,
            long createdShiftPatternId, Date createdShiftStartDate, Time createdShiftStartTime, Date createdShiftEndDate,
            Time createdShiftEndTime,
            string createdShiftName, bool hasChildren, bool isRecurring, long sourceId, bool isOperatingEngineerLog,
            long createdByRoleId, long? logDefinitionId, bool? logDefinitionDeleted, bool recommendForShiftSummary,
            string workAssignmentName, string comments, bool? isReadByCurrentUser,
            List<string> visibilityGroupNames)
        {
            this.id = id;
            RootLogId = rootLogId;
            ReplyToLogId = replyToLogId;
            functionalLocationFullHierarchies = functionalLocationNames;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            LogDateTime = logDateTime;
            CreatedByUserId = createdByUserId;
            CreatedByUserFirstName = createdByUserFirstName;
            CreatedByUserLastName = createdByUserLastName;
            CreatedByUserUserName = createdByUserUserName;
            LastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
            CreatedDateTime = createdDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            CreatedShiftPatternId = createdShiftPatternId;
            CreatedShiftStartDate = createdShiftStartDate;
            CreatedShiftStartTime = createdShiftStartTime;
            CreatedShiftEndDate = createdShiftEndDate;
            CreatedShiftEndTime = createdShiftEndTime;
            CreatedShiftName = createdShiftName;
            HasChildren = hasChildren;
            IsRecurring = isRecurring;
            SourceId = sourceId;
            IsOperatingEngineerLog = isOperatingEngineerLog;
            CreatedByRoleId = createdByRoleId;
            LogDefinitionId = logDefinitionId;
            LogDefinitionDeleted = logDefinitionDeleted;
            RecommendForShiftSummary = recommendForShiftSummary;
            WorkAssignmentName = workAssignmentName;
            Comments = comments;
            IsReadByCurrentUser = isReadByCurrentUser;
            this.visibilityGroupNames = visibilityGroupNames ?? new List<string>();
            this.visibilityGroupNames.Sort();
        }

        public LogDTO(Log log)
            : this(
                log.IdValue,
                log.RootLogId,
                log.ReplyToLogId,
                log.FunctionalLocations.FullHierarchyListToString(true, false),
                log.InspectionFollowUp,
                log.ProcessControlFollowUp,
                log.OperationsFollowUp,
                log.SupervisionFollowUp,
                log.EnvironmentalHealthSafetyFollowUp,
                log.OtherFollowUp,
                log.LogDateTime,
                log.CreationUser.IdValue,
                log.CreationUser.FirstName,
                log.CreationUser.LastName,
                log.CreationUser.Username,
                log.LastModifiedBy.FullNameWithUserName,
                log.CreatedDateTime,
                log.LastModifiedDate,
                log.CreatedShiftPattern.IdValue,

                // By Vibhor : RITM0272920
               log.isAdminRole ? new Date(log.LogDateTime) : GetCreateUserShift(log).StartDate,
               log.isAdminRole ? new Time(log.LogDateTime) : new Time(GetCreateUserShift(log).StartDateTime), //new Time(GetCreateUserShift(log).StartDateTime),
               log.isAdminRole ? new Date(log.LogDateTime) : GetCreateUserShift(log).EndDate, //GetCreateUserShift(log).EndDate,
               log.isAdminRole ? new Time(log.LogDateTime) : new Time(GetCreateUserShift(log).EndDateTime),
                //END
                log.CreatedShiftPattern.Name,
                log.HasChildren,
                log.LogDefinition != null && log.LogDefinition.Schedule.IsRecurring,
                log.Source.IdValue,
                log.IsOperatingEngineerLog,
                log.CreatedByRole.IdValue,
                (log.LogDefinition == null) ? null : log.LogDefinition.Id,
                (log.LogDefinition == null) ? (bool?) null : log.LogDefinition.Deleted,
                log.RecommendForShiftSummary,
                log.WorkAssignment != null ? log.WorkAssignment.Name : null,
                log.PlainTextComments,
                null,
                log.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName))
        {
        }

        public bool ParentIsUnavailable { get; set; }

        [IncludeInSearch]
        public string FunctionalLocationNames
        {
            get { return functionalLocationFullHierarchies; }
        }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public DateTime LogDateTime { get; private set; }

        public DateTime LastModifiedDateTime { get; private set; }

        public string CreatedByUserFirstName { get; private set; }
        public string CreatedByUserLastName { get; private set; }
        public string CreatedByUserUserName { get; private set; }

        public string CreatedByFullName
        {
            get { return User.ToFullName(CreatedByUserFirstName, CreatedByUserLastName); }
        }

        [IncludeInSearch]
        public string CreatedByFullnameWithUserName
        {
            get
            {
                return User.ToFullNameWithUserName(CreatedByUserLastName, CreatedByUserFirstName, CreatedByUserUserName);
            }
        }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        public Date CreatedShiftStartDate { get; private set; }

        public Time CreatedShiftStartTime { get; private set; }

        public Time CreatedShiftEndTime { get; private set; }

        public string CreatedShiftName { get; private set; }

        [IncludeInSearch]
        public string Shift
        {
            get { return String.Format("{0} - {1}", CreatedShiftStartDate, CreatedShiftName); }
        }

        public bool HasChildren { get; private set; }
        public long SourceId { get; private set; }

        [IncludeInSearch]
        public string SourceName
        {
            get { return DataSource.GetById(SourceId).Name; }
        }

        public long? LogDefinitionId { get; private set; }

        public bool? LogDefinitionDeleted { get; private set; }

        [IncludeInSearch]
        public string WorkAssignmentName { get; private set; }

        [IncludeInSearch]
        public string Comments { get; private set; }

        public string IsModified
        {
            get
            {
                var timeSpan = LastModifiedDateTime.Subtract(CreatedDateTime);
                return timeSpan.TotalSeconds < 2 ? StringResources.No : StringResources.Yes;
            }
        }

        public long CreatedByRoleId { get; private set; }
        public long CreatedByUserId { get; private set; }
        public bool IsOperatingEngineerLog { get; private set; }

        public bool InspectionFollowUp { get; private set; }

        public bool ProcessControlFollowUp { get; private set; }

        public bool OperationsFollowUp { get; private set; }

        public bool SupervisionFollowUp { get; private set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }

        public bool OtherFollowUp { get; private set; }

        public DataSource DataSource
        {
            get { return DataSource.GetById(SourceId); }
        }

        public bool? IsReadByCurrentUser { get; set; }
        public bool IsRecurring { get; private set; }

        public bool RecommendForShiftSummary { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public long CreatedShiftPatternId { get; private set; }
        public Date CreatedShiftEndDate { get; private set; }
        public long? RootLogId { get; set; }

        public long? ReplyToLogId { get; private set; }

        public bool IsPartOfThread
        {
            get { return HasChildren || ReplyToLogId.HasValue; }
        }

        // This is used in the log thread view.
        public string ToDisplayString()
        {
            const string formatString = "{0}     {1}     {2}     {3}";
            var comments = Comments != null ? Comments.Replace(Environment.NewLine, "  ") : "";
            return String.Format(formatString, LogDateTime.ToShortDateAndTimeString(), FunctionalLocationNames,
                LastModifiedFullNameWithUserName, comments);
        }

        private static UserShift GetCreateUserShift(Log log)
        {
            return new UserShift(log.CreatedShiftPattern, log.LogDateTime);
        }

        public List<string> GetFunctionalLocationNames()
        {
            return functionalLocationFullHierarchies.BuildListFromCommaSeparatedList();
        }

        public List<string> GetVisibilityGroupNames()
        {
            return visibilityGroupNames;
        }

        public bool IsCreatedBy(User user)
        {
            return CreatedByUserId == user.IdValue;
        }

        public void AddVisibilityGroup(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }

        public static void ConvertChildrenWithoutParentsToParentsAndFlag(List<LogDTO> logDtoList)
        {
            logDtoList.Sort();

            // building this dictionary and using it inside the loop is significantly faster than doing a Find on the list within the loop (for 14000 logs, 6 seconds went down to about 0.1 seconds)
            var dictionary = new Dictionary<long, LogDTO>();
            foreach (var logDto in logDtoList)
            {
                dictionary.Add(logDto.IdValue, logDto);
            }

            foreach (var logDto in logDtoList)
            {
                LogDTO parentDto = null;
                if (logDto.ReplyToLogId != null && dictionary.ContainsKey(logDto.ReplyToLogId.Value))
                {
                    parentDto = dictionary[logDto.ReplyToLogId.Value];
                }

                // the parent might be null because it's beyond the display limit, but it might be because it IS the parent.
                if (parentDto == null)
                {
                    // Parent is unavailable, so make this the new parent.
                    if (logDto.RootLogId != null)
                    {
                        logDto.ParentIsUnavailable = true;
                        logDto.RootLogId = null;
                    }
                }
                else
                {
                    logDto.RootLogId = parentDto.RootLogId ?? parentDto.Id;

                    if (parentDto.ParentIsUnavailable)
                    {
                        logDto.ParentIsUnavailable = true;
                    }
                }
            }
        }
    }
}