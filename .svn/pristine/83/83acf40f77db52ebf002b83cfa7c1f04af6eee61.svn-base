using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FunctionalLocationOperationalModeHistory : DomainObject, IHistorySnapshot
    {
        public FunctionalLocationOperationalModeHistory(long flocUnitId,
            OperationalMode operationalMode,
            AvailabilityReason availabilityReason,
            DateTime lastModifiedDate,
            User lastModifiedBy)
        {
            UnitId = flocUnitId;
            OperationalMode = operationalMode;
            AvailabilityReason = availabilityReason;
            LastModifiedDate = lastModifiedDate;
            LastModifiedBy = lastModifiedBy;
        }

        public long UnitId { get; private set; }

        public OperationalMode OperationalMode { get; private set; }

        public AvailabilityReason AvailabilityReason { get; private set; }

        public User LastModifiedBy { get; private set; }

        public DateTime LastModifiedDate { get; private set; }
    }
}