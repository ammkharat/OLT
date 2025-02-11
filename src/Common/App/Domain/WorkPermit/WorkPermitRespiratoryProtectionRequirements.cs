using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    [Alias("Respiratory")]
    public class WorkPermitRespiratoryProtectionRequirements : DomainObject
    {
        private string cartridgeType;

        public bool IsOther
        {
            get { return string.IsNullOrEmpty(OtherDescription); }
        }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsAirCartorAirLine { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        public bool IsDustMask { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsSCBA { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsAirHood { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsHalfFaceRespirator { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public bool IsFullFaceRespirator { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public string OtherDescription { get; set; }

        [SarniaWorkPermit("!IsNotApplicable")]
        public string CartridgeTypeDescription
        {
            set { cartridgeType = value.EmptyToNull(); }
            get { return cartridgeType; }
        }

        [DenverWorkPermit("!IsNotApplicable")]
        [USPipelineWorkPermit("!IsNotApplicable")]
        [SELCWorkPermit("!IsNotApplicable")]
        public WorkPermitRespiratoryCartridgeType CartridgeType { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsNotApplicable { get; set; }

        # region Work Permit Validation Properties (called via reflection)

        public bool IsFaceRespirator
        {
            get { return IsHalfFaceRespirator || IsFullFaceRespirator; }
        }

        #endregion

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            IsNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        public WorkPermitRespiratoryProtectionRequirements Copy()
        {
            return (WorkPermitRespiratoryProtectionRequirements) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return HasNonCartridgeTypeData()
                   || CartridgeTypeDescription.HasValue()
                   || CartridgeType != null;
        }

        public bool HasNonCartridgeTypeData()
        {
            return IsAirCartorAirLine
                   || IsDustMask
                   || IsSCBA
                   || IsAirHood
                   || IsHalfFaceRespirator
                   || IsFullFaceRespirator
                   || OtherDescription.HasValue();
        }
    }
}