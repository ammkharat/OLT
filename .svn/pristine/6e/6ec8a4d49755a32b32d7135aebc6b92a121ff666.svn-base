using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FunctionalLocationOperationalModeDTO : DomainObject
    {
        private readonly AvailabilityReason availabilityReason;
        private readonly string description;
        private readonly string fullHierarchy;
        private readonly long functionalLocationId;
        private readonly DateTime lastModifiedDate;
        private readonly OperationalMode operationalMode;

        public FunctionalLocationOperationalModeDTO(long functionalLocationId,
            string fullHierarchy,
            string description,
            OperationalMode operationalMode,
            AvailabilityReason availabilityReason,
            DateTime lastModifiedDate)
        {
            Id = functionalLocationId;
            this.functionalLocationId = functionalLocationId;
            this.fullHierarchy = fullHierarchy;
            this.description = description;
            this.operationalMode = operationalMode;
            this.availabilityReason = availabilityReason;
            this.lastModifiedDate = lastModifiedDate;
        }

        public long FunctionalLocationId
        {
            get { return functionalLocationId; }
        }

        public string FullHierarchy
        {
            get { return fullHierarchy; }
        }

        public string Description
        {
            get { return description; }
        }

        public string FullHierarchyAndDescription
        {
            get { return string.Format("{0} ({1})", fullHierarchy, description); }
        }

        public OperationalMode OperationalMode
        {
            get { return operationalMode; }
        }

        public string FunctionalLocationOperatinalModeName
        {
            get { return operationalMode.Name; }
        }

        public AvailabilityReason AvailabilityReason
        {
            get { return availabilityReason; }
        }

        public string OperationalModeAvailabilityReasonName
        {
            get { return availabilityReason.Name; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
        }
    }
}