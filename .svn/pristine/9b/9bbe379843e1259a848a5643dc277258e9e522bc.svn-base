using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LabAlertDefinitionDTO : DomainObject, IIsActive, IHasStatus<LabAlertDefinitionStatus>
    {
        private readonly string description;
        private readonly string functionalLocationName;
        private readonly bool isActive;
        private readonly string lastModifiedFullNameWithUserName;
        private readonly long? lastModifiedUserId;
        private readonly string name;
        private readonly long statusId;
        private readonly string statusName;
        private readonly string tagName;

        public LabAlertDefinitionDTO(LabAlertDefinition domainObject) : this(
            domainObject.Id,
            domainObject.Status.IdValue,
            domainObject.Status.Name,
            domainObject.IsActive,
            domainObject.FunctionalLocation.FullHierarchy,
            domainObject.Name,
            domainObject.TagInfo.Name,
            domainObject.Description,
            domainObject.LastModifiedBy.IdValue,
            domainObject.LastModifiedBy.FullNameWithUserName)
        {
        }

        public LabAlertDefinitionDTO(
            long? id,
            long statusId,
            string statusName,
            bool isActive,
            string functionalLocationName,
            string name,
            string tagName,
            string description,
            long? lastModifiedUserId,
            string lastModifiedFullNameWithUserName)
        {
            this.id = id;
            this.statusId = statusId;
            this.statusName = statusName;
            this.isActive = isActive;
            this.functionalLocationName = functionalLocationName;
            this.name = name;
            this.tagName = tagName;
            this.description = description;
            this.lastModifiedUserId = lastModifiedUserId;
            this.lastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
        }

        public long StatusId
        {
            get { return statusId; }
        }

        [IncludeInSearch]
        public string StatusName
        {
            get { return statusName; }
        }

        [IncludeInSearch]
        public string FunctionalLocationName
        {
            get { return functionalLocationName; }
        }

        [IncludeInSearch]
        public string Name
        {
            get { return name; }
        }

        [IncludeInSearch]
        public string TagName
        {
            get { return tagName; }
        }

        [IncludeInSearch]
        public string Description
        {
            get { return description; }
        }

        public long? LastModifiedUserId
        {
            get { return lastModifiedUserId; }
        }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName
        {
            get { return lastModifiedFullNameWithUserName; }
        }

        public LabAlertDefinitionStatus Status
        {
            get { return LabAlertDefinitionStatus.Get(statusId); }
        }

        public bool IsActive
        {
            get { return isActive; }
        }
    }
}