using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FunctionalLocationOperationalMode : DomainObject
    {
        public FunctionalLocationOperationalMode(long functionalLocationId, OperationalMode operationalMode,
            AvailabilityReason availabilityReason, DateTime lastModifiedDateTime)
        {
            Id = functionalLocationId;
            OperationalMode = operationalMode;
            AvailabilityReason = availabilityReason;
            LastModifiedDateTime = lastModifiedDateTime;
        }


        public OperationalMode OperationalMode { get; private set; }

        public AvailabilityReason AvailabilityReason { get; private set; }

        public DateTime LastModifiedDateTime { get; private set; }
    }
}