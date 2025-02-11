﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SummaryLog : DomainObject,
        IHistoricalDomainObject, IDocumentLinksObject, ISiteRelevant, IHasCustomFieldEntries, IVisibilityGroupRelevant
    {
        public SummaryLog(List<FunctionalLocation> functionalLocations, string rtfComments, string plainTextComments,
            string dorComments, DataSource dataSource, bool inspectionFollowUp, bool processControlFollowUp,
            bool operationsFollowUp, bool supervisionFollowUp, bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp, DateTime logDateTime, DateTime createdDateTime, ShiftPattern createdShiftPattern,
            User creationUser, Role createdByRole, User lastModifiedBy, DateTime lastModifiedDate,
            List<DocumentLink> documentLinks, WorkAssignment workAssignment, List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields, long? rootLogId, long? replyToLogId, bool hasChildren)
        {
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            CustomFields = customFields ?? new List<CustomField>();
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            LogDateTime = logDateTime;
            CreatedDateTime = createdDateTime;
            CreatedShiftPattern = createdShiftPattern;
            CreationUser = creationUser;
            CreatedByRole = createdByRole;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            DocumentLinks = documentLinks;
            WorkAssignment = workAssignment;
            RtfComments = rtfComments;
            PlainTextComments = plainTextComments;
            DorComments = dorComments;
            DataSource = dataSource;
            RootLogId = rootLogId;
            ReplyToLogId = replyToLogId;
            HasChildren = hasChildren;
        }


        //RITM0164968-  mangesh
        public SummaryLog(List<FunctionalLocation> functionalLocations, string rtfComments, string plainTextComments,
            string dorComments, DataSource dataSource, bool inspectionFollowUp, bool processControlFollowUp,
            bool operationsFollowUp, bool supervisionFollowUp, bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp, DateTime logDateTime, DateTime createdDateTime, ShiftPattern createdShiftPattern,
            User creationUser, Role createdByRole, User lastModifiedBy, DateTime lastModifiedDate,
            List<DocumentLink> documentLinks, WorkAssignment workAssignment, List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields, long? rootLogId, long? replyToLogId, bool hasChildren, string selectLogIDsForSummaryPresenter)
        {
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            CustomFields = customFields ?? new List<CustomField>();
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            LogDateTime = logDateTime;
            CreatedDateTime = createdDateTime;
            CreatedShiftPattern = createdShiftPattern;
            CreationUser = creationUser;
            CreatedByRole = createdByRole;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            DocumentLinks = documentLinks;
            WorkAssignment = workAssignment;
            RtfComments = rtfComments;
            PlainTextComments = plainTextComments;
            DorComments = dorComments;
            DataSource = dataSource;
            RootLogId = rootLogId;
            ReplyToLogId = replyToLogId;
            HasChildren = hasChildren;
            SelectLogIDsForSummaryPresenter = selectLogIDsForSummaryPresenter;
        }

        private bool copyClkSumm;

        public string SelectLogIDsForSummaryPresenter { get; set; }//RITM0164968-  mangesh

        //Aarti RITM0512605:Copy feature for Shift Summary log
        public bool copyClickedSumm
        {
            set { copyClkSumm = value; }
            get
            {
                if (copyClkSumm)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }

        public string RtfComments { get; set; }

        public string PlainTextComments { get; set; }

        public string DorComments { get; set; }

        public DataSource DataSource { get; set; }

        public Site SiteDerivedFromFunctionalLocations
        {
            // this should always work like it did before, because there has to be at least one floc in the list (where
            // before the floc couldn't be null
            get { return FunctionalLocations.Count > 0 ? FunctionalLocations[0].Site : null; }
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public string FunctionalLocationNames
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public DateTime CreatedDateTime { get; private set; }

        public bool Deleted { get; set; }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; set; }

        public bool OtherFollowUp { get; set; }

        public bool InspectionFollowUp { get; set; }

        public bool ProcessControlFollowUp { get; set; }

        public bool OperationsFollowUp { get; set; }

        public bool SupervisionFollowUp { get; set; }

        public string ShiftDisplayName
        {
            get
            {
                var userShift = new UserShift(CreatedShiftPattern, LogDateTime);
                return String.Format("{0} - {1}", userShift.StartDate, CreatedShiftPattern.Name);
            }
        }

        public ShiftPattern CreatedShiftPattern { get; private set; }

        public User CreationUser { get; private set; }

        public Role CreatedByRole { get; private set; }

        public string CreationUserFullName
        {
            get { return CreationUser.FullName; }
        }

        public long CreationUserId
        {
            get { return CreationUser.IdValue; }
        }

        [CachedRelationship]
        public WorkAssignment WorkAssignment { get; set; }

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
        public long? RootLogId { get; private set; }

        [IgnoreComparing]
        public long? ReplyToLogId { get; private set; }

        [IgnoreComparing]
        public bool HasChildren { get; set; }

        public bool IsPartOfThread
        {
            get { return HasChildren || ReplyToLogId.HasValue; }
        }

        public bool HasCustomFields
        {
            get { return CustomFields.Count > 0; }
        }

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

        public List<DocumentLink> DocumentLinks { get; set; }
        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }

        public List<CustomField> CustomFields { get; private set; }
        public DateTime LogDateTime { get; set; }

        public bool IsRelevantTo(long siteId)
        {
            return FunctionalLocations.Exists(obj => obj.Site.Id == siteId);
        }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(WorkAssignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public SummaryLogHistory TakeSnapshot(List<CustomField> customFields)
        {
            var flocHistoryString = FunctionalLocationsAsCommaSeparatedFullHierarchyList;

            return new SummaryLogHistory(
                IdValue,
                flocHistoryString,
                InspectionFollowUp,
                ProcessControlFollowUp,
                OperationsFollowUp,
                SupervisionFollowUp,
                EnvironmentalHealthSafetyFollowUp,
                OtherFollowUp,
                LogDateTime,
                LastModifiedBy,
                LastModifiedDate,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                PlainTextComments,
                DorComments,
                CustomFieldEntry.TakeSnapshots(CustomFieldEntries, customFields));
        }

        public void SetReplyTo(SummaryLog logToReplyTo)
        {
            ReplyToLogId = logToReplyTo.Id;
            RootLogId = logToReplyTo.IsRoot() ? logToReplyTo.Id : logToReplyTo.RootLogId;
        }

        public bool IsRoot()
        {
            return RootLogId == null;
        }


        //Mukesh for Log Image
        public List<LogImage> Imagelist { get; set; }
    }
}