using System;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertDefinitionHistory : DomainObjectHistorySnapshot
    {
        public LabAlertDefinitionHistory(
            long id,
            string name,
            string description,
            FunctionalLocation functionalLocation,
            TagInfo tagInfo,
            int minimumNumberOfSamples,
            string labAlertTagQueryRange,
            string schedule,
            bool isActive,
            LabAlertDefinitionStatus status,
            User lastModifiedBy,
            DateTime lastModifiedDate) : base(id, lastModifiedBy, lastModifiedDate)
        {
            Name = name;
            Description = description;
            FunctionalLocation = functionalLocation;
            TagInfo = tagInfo;
            MinimumNumberOfSamples = minimumNumberOfSamples;
            LabAlertTagQueryRange = labAlertTagQueryRange;
            Schedule = schedule;
            IsActive = isActive;
            Status = status;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public FunctionalLocation FunctionalLocation { get; private set; }

        public TagInfo TagInfo { get; private set; }

        public int MinimumNumberOfSamples { get; private set; }

        public string LabAlertTagQueryRange { get; private set; }

        public string Schedule { get; private set; }

        public bool IsActive { get; private set; }

        public LabAlertDefinitionStatus Status { get; private set; }
    }
}