using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Fire or Confined Space Protection requirement lists for a work permit
    /// </summary>
    [Serializable]
    [Alias("Fire")]
    public class WorkPermitFireConfinedSpaceRequirements : DomainObject
    {
        private string fireWatchNumber;
        private string holeWatchNumber;
        private string otherRequirement;
        private string spotterNumber;

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]      //ayman USPipeline workpermit
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]  // mangesh uspipeline to selc
        public bool IsNotApplicable { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        public bool IsTwentyABCorDryChemicalExtinguisher { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsC02Extinguisher { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsFireResistantTarp { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        public bool IsWatchmen { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public string OtherDescription { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsSparkContainment { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsSteamHose { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsWaterHose { get; set; }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public string HoleWatchNumber
        {
            get { return holeWatchNumber; }
            set { holeWatchNumber = value.EmptyToNull(); }
        }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public string FireWatchNumber
        {
            get { return fireWatchNumber; }
            set { fireWatchNumber = value.EmptyToNull(); }
        }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public string SpotterNumber
        {
            get { return spotterNumber; }
            set { spotterNumber = value.EmptyToNull(); }
        }

        public bool IsFireConfinedSpaceRequirementsApplicableAndFireConfinedSpaceRequirementsIsWatchmen
        {
            get { return !IsNotApplicable && IsWatchmen; }
        }

        #region Work Permit Validation Properties (called via reflection)

        public bool IsOtherRequirement
        {
            get { return otherRequirement.IsNullOrEmptyOrWhitespace(); }
            set
            {
                if (!value)
                    otherRequirement = string.Empty;
            }
        }

        #endregion

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            IsNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        public WorkPermitFireConfinedSpaceRequirements Copy()
        {
            return (WorkPermitFireConfinedSpaceRequirements) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return IsTwentyABCorDryChemicalExtinguisher
                   || IsC02Extinguisher
                   || IsFireResistantTarp
                   || IsSteamHose
                   || IsWaterHose
                   || IsSparkContainment
                   || HoleWatchNumber.HasValue()
                   || FireWatchNumber.HasValue()
                   || SpotterNumber.HasValue()
                   || OtherDescription.HasValue()
                   || IsWatchmen;
        }
    }
}