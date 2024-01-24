using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    public enum LogType
    {
        Standard = 1,
        DailyDirective = 3
    }

    /// <summary>
    ///     Log Domain Object
    /// </summary>
    [Serializable]
    public class Log : DomainObject, IDocumentLinksObject, IHistoricalDomainObject, IFunctionalLocationRelevant,
        IVisibilityGroupRelevant, IHasCustomFieldEntries
    {
        public Log(
            long? rootLogId,
            long? replyToLogId,
            LogDefinition logDefinition,
            DataSource source,
            List<FunctionalLocation> functionalLocations,
            bool inspectionFollowUp,
            bool processControlFollowUp,
            bool operationsFollowUp,
            bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp,
            string comments,
            string commentsAsPlainText,
            DateTime loggedDateTime,
            ShiftPattern createdShiftPattern,
            User createdBy,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            DateTime createdDateTime,
            bool hasChildren,
            bool isOperatingEngineerLog,
            Role createdByRole,
            LogType logType,
            WorkAssignment workAssignment)
            : this(
                rootLogId,
                replyToLogId,
                logDefinition,
                source,
                functionalLocations,
                inspectionFollowUp,
                processControlFollowUp,
                operationsFollowUp,
                supervisionFollowUp,
                environmentalHealthSafetyFollowUp,
                otherFollowUp,
                comments,
                commentsAsPlainText,
                loggedDateTime,
                createdShiftPattern,
                createdBy,
                lastModifiedBy,
                lastModifiedDate,
                createdDateTime,
                hasChildren,
                isOperatingEngineerLog,
                createdByRole,
                new List<DocumentLink>(),
                logType,
                false,
                workAssignment,
                new List<CustomFieldEntry>(),
                new List<CustomField>()
                )
        {
        }

        public Log(
            long? rootLogId,
            long? replyToLogId,
            LogDefinition logDefinition,
            DataSource source,
            List<FunctionalLocation> functionalLocations,
            bool inspectionFollowUp,
            bool processControlFollowUp,
            bool operationsFollowUp,
            bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp,
            string comments,
            string commentsAsPlainText,
            DateTime logDateTime,
            ShiftPattern createdShiftPattern,
            User creationUser,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            DateTime createdDateTime,
            bool hasChildren,
            bool isOperatingEngineerLog,
            Role createdByRole,
            List<DocumentLink> documentLinks,
            LogType logType,
            bool recommendForShiftSummary,
            WorkAssignment workAssignment,
            List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields)
        {
            RootLogId = rootLogId;
            ReplyToLogId = replyToLogId;
            LogDefinition = logDefinition;
            Source = source;
            FunctionalLocations = functionalLocations;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            RtfComments = comments;
            PlainTextComments = commentsAsPlainText;
            LogDateTime = logDateTime;
            CreatedShiftPattern = createdShiftPattern;
            CreationUser = creationUser;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            CreatedDateTime = createdDateTime;
            HasChildren = hasChildren;
            IsOperatingEngineerLog = isOperatingEngineerLog;
            CreatedByRole = createdByRole;
            DocumentLinks = documentLinks;
            LogType = logType;
            RecommendForShiftSummary = recommendForShiftSummary;
            WorkAssignment = workAssignment;
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            CustomFields = customFields ?? new List<CustomField>();
        }

        [CachedRelationship]
        public LogDefinition LogDefinition { get; set; }

        public DataSource Source { get; private set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public string RtfComments { get; set; }

        public string PlainTextComments { get; set; }

        public bool Deleted { get; set; }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; set; }

        public bool OtherFollowUp { get; set; }

        public bool InspectionFollowUp { get; set; }

        public bool ProcessControlFollowUp { get; set; }

        public bool OperationsFollowUp { get; set; }

        public bool SupervisionFollowUp { get; set; }

        public ShiftPattern CreatedShiftPattern { get;  set; }

        public User CreationUser { get; private set; }
        // By Vibhor : RITM0272920

        public bool isAdminRole { get; set; }
        //End

        public string CreationUserFullName
        {
            get { return CreationUser != null ? CreationUser.FullName : ""; }
        }

        [IgnoreComparing]
        public DateTime CreatedShiftStartDateWithPadding
        {
            get { return new UserShift(CreatedShiftPattern, CreatedDateTime).StartDateTimeWithPadding; }
        }

        [IgnoreComparing]
        public DateTime CreatedShiftEndDateWithPadding
        {
            get { return new UserShift(CreatedShiftPattern, CreatedDateTime).EndDateTimeWithPadding; }
        }

        [IgnoreComparing]
        public long? RootLogId { get; set; }

        [IgnoreComparing]
        public long? ReplyToLogId { get; set; }

        [IgnoreComparing]
        public bool HasChildren { get; set; }

        public bool IsPartOfThread
        {
            get { return HasChildren || ReplyToLogId.HasValue; }
        }

        public bool IsOperatingEngineerLog { get; set; }

        public Role CreatedByRole { get; private set; }

        public LogType LogType { get; private set; }

        public bool RecommendForShiftSummary { get; set; }

        [CachedRelationship]
        public WorkAssignment WorkAssignment { get; set; }

        public List<WorkAssignmentVisibilityGroup> WritableWorkAssignmentVisibilityGroups
        {
            get
            {
                if (WorkAssignment == null)
                {
                    return new List<WorkAssignmentVisibilityGroup>();
                }
                return new List<WorkAssignmentVisibilityGroup>(WorkAssignment.WriteWorkAssignmentVisibilityGroups);
            }
        }

        public string ShiftDisplayName
        {
            get
            {
                var userShift = new UserShift(CreatedShiftPattern, LogDateTime);
                return userShift.ShiftDisplayName;
            }
        }

        public bool HasCustomFields
        {
            get { return CustomFields.Count > 0; }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                    return true;
            }
            return false;
        }

        public DateTime LogDateTime { get; set; }
        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }

        public List<CustomField> CustomFields { get; private set; }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(WorkAssignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public bool IsRoot()
        {
            return RootLogId == null;
        }

        public void SetReplyTo(Log logToReplyTo)
        {
            ReplyToLogId = logToReplyTo.Id;

            RootLogId = logToReplyTo.IsRoot() ? logToReplyTo.Id : logToReplyTo.RootLogId;
        }

        public bool IsRelevantTo(long siteId)
        {
            return FunctionalLocations[0].Site.Id == siteId;
        }

       
        

        public LogHistory TakeSnapshot(List<CustomField> customFields)
        {
            return new LogHistory(IdValue,
                FunctionalLocations.FullHierarchyListToString(true, false),
                InspectionFollowUp,
                ProcessControlFollowUp,
                OperationsFollowUp,
                SupervisionFollowUp,
                EnvironmentalHealthSafetyFollowUp,
                OtherFollowUp,
                LastModifiedBy,
                LastModifiedDate,
                IsOperatingEngineerLog,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                RecommendForShiftSummary,
                PlainTextComments,
                LogDateTime,
                CustomFieldEntry.TakeSnapshots(CustomFieldEntries, customFields));
        }

        public void SetRTFAndPlainTextComments(string comment)
        {
            RtfComments = comment;
            PlainTextComments = comment;
        }

        //Mukesh for Log Image
        public List<LogImage> Imagelist { get; set; }
    }

    //Mukesh for Log Image
    [Serializable]
    public class LogImage : DomainObject
    {
       public enum Type
        {
            Title=0,
            Image=1
        }
       public enum RecordTypes
       {
           Log = 0,
           Summary = 1
       }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

       // public  string Id { get; set; }

        public string Action { get; set; }
        public Type Types { get; set; }
        public RecordTypes RecordType { get; set; }

       

    }
}