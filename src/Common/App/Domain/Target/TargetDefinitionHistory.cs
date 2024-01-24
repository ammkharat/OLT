using System;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetDefinitionHistory : DomainObjectHistorySnapshot
    {
        public TargetDefinitionHistory(long id, string name, decimal? neverToExceedMinimum,
            decimal? neverToExceedMaximum, decimal? preApprovedNeverToExceedMinimum,
            decimal? preApprovedNeverToExceedMaximum, int? neverToExceedMinimumFrequency,
            int? neverToExceedMaximumFrequency, decimal? maxValue, decimal? minValue,
            decimal? preApprovedMinValue, decimal? preApprovedMaxValue, int? maxValueFrequency, int? minValueFrequency,
            string targetValue, decimal? gapUnitValue,
            string description, TargetCategory category, TagInfo tagInfo, bool generateActionItem, bool isAlertRequired,
            bool requiresResponseWhenAlerted, bool isActive,
            bool requiresApproval, FunctionalLocation functionalLocation, TargetDefinitionStatus status,
            User lastModifiedBy, DateTime lastModifiedDate,
            OperationalMode operationalMode, Priority priority, string schedule, string associatedTargets,
            string documentLinks,
            string readWriteConfiguration,
            string assignmentName) : base(id, lastModifiedBy, lastModifiedDate)
        {
            Name = name;
            NeverToExceedMinimum = neverToExceedMinimum;
            NeverToExceedMaximum = neverToExceedMaximum;
            PreApprovedNeverToExceedMinimum = preApprovedNeverToExceedMinimum;
            PreApprovedNeverToExceedMaximum = preApprovedNeverToExceedMaximum;
            NeverToExceedMinimumFrequency = neverToExceedMinimumFrequency;
            NeverToExceedMaximumFrequency = neverToExceedMaximumFrequency;
            MaxValue = maxValue;
            MinValue = minValue;
            PreApprovedMinValue = preApprovedMinValue;
            PreApprovedMaxValue = preApprovedMaxValue;
            MaxValueFrequency = maxValueFrequency;
            MinValueFrequency = minValueFrequency;
            TargetValue = targetValue;
            GapUnitValue = gapUnitValue;
            Description = description;
            Category = category;
            TagInfo = tagInfo;
            GenerateActionItem = generateActionItem;
            IsAlertRequired = isAlertRequired;
            RequiresResponseWhenAlerted = requiresResponseWhenAlerted;
            IsActive = isActive;
            RequiresApproval = requiresApproval;
            FunctionalLocation = functionalLocation;
            Status = status;
            OperationalMode = operationalMode;
            Priority = priority;
            Schedule = schedule;
            AssociatedTargets = associatedTargets;
            DocumentLinks = documentLinks;
            ReadWriteConfiguration = readWriteConfiguration;
            WorkAssignmentName = assignmentName;
        }

        public string Name { get; private set; }

        public decimal? NeverToExceedMinimum { get; private set; }

        public decimal? NeverToExceedMaximum { get; private set; }

        public decimal? PreApprovedNeverToExceedMinimum { get; private set; }

        public decimal? PreApprovedNeverToExceedMaximum { get; private set; }

        public int? NeverToExceedMinimumFrequency { get; private set; }

        public int? NeverToExceedMaximumFrequency { get; private set; }

        public decimal? MaxValue { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? PreApprovedMaxValue { get; private set; }

        public decimal? PreApprovedMinValue { get; set; }

        public int? MaxValueFrequency { get; private set; }

        public int? MinValueFrequency { get; private set; }

        public string TargetValue { get; private set; }

        public decimal? GapUnitValue { get; private set; }

        public string Description { get; set; }

        public TargetCategory Category { get; private set; }

        public TagInfo TagInfo { get; set; }

        public bool GenerateActionItem { get; private set; }

        public bool IsAlertRequired { get; private set; }

        public bool RequiresResponseWhenAlerted { get; private set; }

        public bool IsActive { get; private set; }

        public bool RequiresApproval { get; private set; }

        public FunctionalLocation FunctionalLocation { get; set; }

        public TargetDefinitionStatus Status { get; private set; }

        public OperationalMode OperationalMode { get; private set; }

        public Priority Priority { get; private set; }

        public string Schedule { get; private set; }

        public string AssociatedTargets { get; private set; }

        public string DocumentLinks { get; private set; }

        public string ReadWriteConfiguration { get; private set; }

        public string WorkAssignmentName { get; private set; }
    }
}