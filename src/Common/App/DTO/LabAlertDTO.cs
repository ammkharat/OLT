using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LabAlertDTO : DomainObject, IHasStatus<LabAlertStatus>
    {
        private readonly int actualNumberOfSamples;
        private readonly DateTime createdDateTime;
        private readonly string functionalLocationName;
        private readonly long lastModifiedByUserId;
        private readonly int minimumNumberOfSamples;
        private readonly string name;
        private readonly long statusId;
        private readonly string tagName;

        public LabAlertDTO(LabAlert domainObject) : this(
            domainObject.Id,
            domainObject.Status.IdValue,
            domainObject.FunctionalLocation.FullHierarchy,
            domainObject.Name,
            domainObject.TagInfo.Name,
            domainObject.MinimumNumberOfSamples,
            domainObject.ActualNumberOfSamples,
            domainObject.CreatedDateTime,
            domainObject.LastModifiedBy.IdValue)
        {
        }

        public LabAlertDTO(
            long? id,
            long statusId,
            string functionalLocationName,
            string name,
            string tagName,
            int minimumNumberOfSamples,
            int actualNumberOfSamples,
            DateTime createdDateTime,
            long lastModifiedByUserId)
        {
            this.id = id;
            this.statusId = statusId;
            this.functionalLocationName = functionalLocationName;
            this.name = name;
            this.tagName = tagName;
            this.minimumNumberOfSamples = minimumNumberOfSamples;
            this.actualNumberOfSamples = actualNumberOfSamples;
            this.createdDateTime = createdDateTime;
            this.lastModifiedByUserId = lastModifiedByUserId;
        }

        public long StatusId
        {
            get { return statusId; }
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
        public int MinimumNumberOfSamples
        {
            get { return minimumNumberOfSamples; }
        }

        [IncludeInSearch]
        public int ActualNumberOfSamples
        {
            get { return actualNumberOfSamples; }
        }

        [IncludeInSearch]
        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public long LastModifiedByUserId
        {
            get { return lastModifiedByUserId; }
        }

        [IncludeInSearch]
        public LabAlertStatus Status
        {
            get { return LabAlertStatus.Get(statusId); }
        }

        public LabAlertStatus GetStatus(UserShift userShift)
        {
            var status = LabAlertStatus.Get(statusId);
            if (status == LabAlertStatus.NotResponded &&
                createdDateTime < userShift.StartDateTime)
            {
                return LabAlertStatus.NotRespondedLate;
            }
            if (status == LabAlertStatus.DataUnavailable &&
                createdDateTime < userShift.StartDateTime)
            {
                return LabAlertStatus.DataUnavailableLate;
            }
            return status;
        }
    }
}