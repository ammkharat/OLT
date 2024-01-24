using System;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionDefinitionHistory : DomainObjectHistorySnapshot
    {
        public RestrictionDefinitionHistory(
            long id,
            string name,
            string description,
            FunctionalLocation functionalLocation,
            TagInfo measurementTagInfo,
            decimal? productionTargetValue,
            TagInfo productionTargetTagInfo,
            bool isActive,
            bool isOnlyVisibleOnReports,
            RestrictionDefinitionStatus status,
            User lastModifiedBy,
            DateTime lastModifiedDate) : base(id, lastModifiedBy, lastModifiedDate)
        {
            Name = name;
            Description = description;
            FunctionalLocation = functionalLocation;
            MeasurementTagInfo = measurementTagInfo;
            ProductionTargetValue = productionTargetValue;
            ProductionTargetTagInfo = productionTargetTagInfo;
            IsActive = isActive;
            IsOnlyVisibleOnReports = isOnlyVisibleOnReports;
            Status = status;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public FunctionalLocation FunctionalLocation { get; private set; }

        public TagInfo MeasurementTagInfo { get; private set; }

        public decimal? ProductionTargetValue { get; private set; }

        public TagInfo ProductionTargetTagInfo { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsOnlyVisibleOnReports { get; private set; }

        public RestrictionDefinitionStatus Status { get; private set; }

        //Added by Mukesh for RITM0219490
        public int? ToleranceValue { get; set; }
        //End

        public string HourFrequency { get; set; } //DMND0010124 mangesh
    }
}