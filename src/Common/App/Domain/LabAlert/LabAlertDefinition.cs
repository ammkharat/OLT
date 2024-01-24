using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertDefinition : DomainObject, IFunctionalLocationRelevant, IHistoricalDomainObject
    {
        private readonly User createdBy;
        private readonly DateTime createdDateTime;
        private readonly bool deleted;
        private string description;
        private FunctionalLocation functionalLocation;

        private bool isActive;
        private LabAlertTagQueryRange labAlertTagQueryRange;

        private User lastModifiedBy;
        private DateTime lastModifiedDate;
        private int minimumNumberOfSamples;
        private string name;
        private ISchedule schedule;
        private LabAlertDefinitionStatus status = LabAlertDefinitionStatus.Valid;
        private TagInfo tagInfo;

        public LabAlertDefinition(
            string name,
            string description,
            FunctionalLocation functionalLocation,
            TagInfo tagInfo,
            int minimumNumberOfSamples,
            LabAlertTagQueryRange labAlertTagQueryRange,
            ISchedule schedule,
            bool isActive,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            User createdBy,
            DateTime createdDateTime,
            LabAlertDefinitionStatus status) : this(
                null,
                name,
                description,
                functionalLocation,
                tagInfo,
                minimumNumberOfSamples,
                labAlertTagQueryRange,
                schedule,
                isActive,
                lastModifiedBy,
                lastModifiedDate,
                createdBy,
                createdDateTime,
                status,
                false)
        {
        }

        public LabAlertDefinition(
            long? id,
            string name,
            string description,
            FunctionalLocation functionalLocation,
            TagInfo tagInfo,
            int minimumNumberOfSamples,
            LabAlertTagQueryRange labAlertTagQueryRange,
            ISchedule schedule,
            bool isActive,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            User createdBy,
            DateTime createdDateTime,
            LabAlertDefinitionStatus status,
            bool deleted)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.functionalLocation = functionalLocation;
            this.tagInfo = tagInfo;
            this.minimumNumberOfSamples = minimumNumberOfSamples;
            this.labAlertTagQueryRange = labAlertTagQueryRange;
            this.schedule = schedule;
            this.isActive = isActive;
            this.lastModifiedBy = lastModifiedBy;
            this.lastModifiedDate = lastModifiedDate;
            this.createdBy = createdBy;
            this.createdDateTime = createdDateTime;
            this.status = status;
            this.deleted = deleted;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
            set { functionalLocation = value; }
        }

        public TagInfo TagInfo
        {
            get { return tagInfo; }
            set { tagInfo = value; }
        }

        public int MinimumNumberOfSamples
        {
            get { return minimumNumberOfSamples; }
            set { minimumNumberOfSamples = value; }
        }

        public LabAlertTagQueryRange LabAlertTagQueryRange
        {
            get { return labAlertTagQueryRange; }
            set { labAlertTagQueryRange = value; }
        }

        public ISchedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public LabAlertDefinitionStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public User LastModifiedBy
        {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { lastModifiedDate = value; }
        }

        public User CreatedBy
        {
            get { return createdBy; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public bool Deleted
        {
            get { return deleted; }
        }

        public string ScheduleDescription
        {
            get { return string.Format("{0}: {1}", schedule.Type.Name, schedule.SimpleDescription); }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public LabAlertDefinitionHistory TakeSnapshot()
        {
            return new LabAlertDefinitionHistory(
                IdValue,
                name,
                description,
                functionalLocation,
                tagInfo,
                minimumNumberOfSamples,
                labAlertTagQueryRange.ToString(),
                ScheduleDescription,
                isActive,
                status,
                lastModifiedBy,
                lastModifiedDate);
        }

        public void HasInvalidTag(User modifiedByUser, DateTime detectedInvalidTagDateTime)
        {
            status = LabAlertDefinitionStatus.InvalidTag;
            isActive = false;
            lastModifiedBy = modifiedByUser;
            lastModifiedDate = detectedInvalidTagDateTime;
        }

        public void HasValidTag(User modifiedByUser, DateTime detectedValidDateTime)
        {
            status = LabAlertDefinitionStatus.Valid;
            lastModifiedBy = modifiedByUser;
            lastModifiedDate = detectedValidDateTime;
        }
    }
}