using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogDefinition : DomainObject, IFunctionalLocationRelevant, IDocumentLinksObject,
        IHistoricalDomainObject, IVisibilityGroupRelevant, IHasCustomFieldEntries
    {
        private bool active;

        public LogDefinition(ISchedule schedule,
            List<FunctionalLocation> functionalLocations,
            bool inspectionFollowUp,
            bool processControlFollowUp,
            bool operationsFollowUp,
            bool supervisionFollowUp,
            bool environmentalHealthSafetyFollowUp,
            bool otherFollowUp,
            bool isOperatingEngineerLog,
            Role createdByRole,
            DateTime logDateTime,
            User createdBy,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            List<DocumentLink> documentLinks,
            string rtfComments,
            string plainTextComments,
            LogType logType,
            WorkAssignment workAssignment,
            bool createALogForEachFunctionalLocation,
            List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields,
            bool active)
        {
            RtfComments = rtfComments;
            PlainTextComments = plainTextComments;
            LogType = logType;
            Schedule = schedule;
            FunctionalLocations = functionalLocations;
            InspectionFollowUp = inspectionFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            OtherFollowUp = otherFollowUp;
            CreatedDateTime = logDateTime;
            CreatedBy = createdBy;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            DocumentLinks = documentLinks;
            IsOperatingEngineerLog = isOperatingEngineerLog;
            CreatedByRole = createdByRole;
            WorkAssignment = workAssignment;
            CreateALogForEachFunctionalLocation = createALogForEachFunctionalLocation;
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            CustomFields = customFields ?? new List<CustomField>();
            this.active = active;

            if (logType == LogType.Standard && !active)
            {
                // This can be removed later if ever needed, but I wanted to be sure that we're not ever accidentally 
                // setting standard logs inactive until it's called for.
                throw new InvalidOperationException("Standard logs must always be active");
            }
        }

        public LogType LogType { get; private set; }

        [CachedRelationship]
        public WorkAssignment WorkAssignment { get; private set; }

        public bool CreateALogForEachFunctionalLocation { get; private set; }

        public User CreatedBy { get; set; }

        public bool IsOperatingEngineerLog { get; set; }

        public Role CreatedByRole { get; private set; }

        public ISchedule Schedule { get; set; }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public string RtfComments { get; set; }

        public string PlainTextComments { get; set; }

        public bool EnvironmentalHealthSafetyFollowUp { get; set; }

        public bool InspectionFollowUp { get; set; }

        public bool ProcessControlFollowUp { get; set; }

        public bool OperationsFollowUp { get; set; }

        public bool SupervisionFollowUp { get; set; }

        public bool OtherFollowUp { get; set; }

        public DateTime CreatedDateTime { get; private set; }

        public bool Active
        {
            get { return active; }
            set
            {
                // This can be removed later if ever needed, but I wanted to be sure that we're not ever accidentally 
                // setting standard logs inactive until it's called for.
                if (LogType.Standard == LogType && !value)
                {
                    throw new InvalidOperationException("Standard logs must always be active");
                }

                active = value;
            }
        }

        public bool Deleted { get; set; }

        public string FunctionalLocationsAsCommaSeparatedString
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
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

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
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

        public DateTime LogDateTime
        {
            get { return LastModifiedDate; }
        }

        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }

        public List<CustomField> CustomFields { get; private set; }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(WorkAssignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public LogDefinitionHistory TakeSnapshot(List<CustomField> customFields)
        {
            return new LogDefinitionHistory(id.Value,
                LastModifiedDate,
                LastModifiedBy,
                Schedule.ToString(false),
                FunctionalLocationsAsCommaSeparatedString,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                InspectionFollowUp,
                ProcessControlFollowUp,
                OperationsFollowUp,
                SupervisionFollowUp,
                EnvironmentalHealthSafetyFollowUp,
                OtherFollowUp,
                Deleted,
                PlainTextComments,
                active,
                CustomFieldEntry.TakeSnapshots(CustomFieldEntries, customFields));
        }
    }
}