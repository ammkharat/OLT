using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Special requirements for a work permit (other than mandatory for work area). Only created by WorkPermit.
    /// </summary>
    [Serializable]
    [Alias("SpecialPPE")]
    public class WorkPermitSpecialPPERequirements : DomainObject
    {
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsEyeOrFaceProtectionNotApplicable { get; set; }

        [SarniaWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [DenverWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [SELCWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        public bool IsEyeOrFaceProtectionGoggles { get; set; }

        [SarniaWorkPermit("!IsEyeOrFaceProtectionNotApplicable"),
         DenverWorkPermit("!IsEyeOrFaceProtectionNotApplicable"),
         USPipelineWorkPermit("!IsEyeOrFaceProtectionNotApplicable"),
        SELCWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        public bool IsEyeOrFaceProtectionFaceshield { get; set; }

        [SarniaWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [DenverWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        [SELCWorkPermit("!IsEyeOrFaceProtectionNotApplicable")]
        public string EyeOrFaceProtectionOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsProtectiveClothingTypeNotApplicable { get; set; }

        [SarniaWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeRainCoat { get; set; }

        [SarniaWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeRainPants { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.SecondSet, "!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeAcidClothing { get; set; }

        [SarniaWorkPermit("IsProtectiveClothingTypeAcidClothing")]
        public AcidClothingType ProtectiveClothingTypeAcidClothingType { get; set; }

        [SarniaWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeCausticWear { get; set; }

        [SarniaWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypePaperCoveralls { get; set; }

        [DenverWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [SELCWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeTyvekSuit { get; set; }

        [DenverWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [SELCWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeKapplerSuit { get; set; }

        [DenverWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [SELCWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeElectricalFlashGear { get; set; }

        [DenverWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [SELCWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public bool IsProtectiveClothingTypeCorrosiveClothing { get; set; }

        [SarniaWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [DenverWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        [SELCWorkPermit("!IsProtectiveClothingTypeNotApplicable")]
        public string ProtectiveClothingTypeOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsProtectiveFootwearNotApplicable { get; set; }

        [SarniaWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [DenverWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [SELCWorkPermit("!IsProtectiveFootwearNotApplicable")]
        public bool IsProtectiveFootwearChemicalImperviousBoots { get; set; }

        [SarniaWorkPermit("!IsProtectiveFootwearNotApplicable")]
        public bool IsProtectiveFootwearMetatarsalGuard { get; set; }

        [DenverWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [USPipelineWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [SELCWorkPermit("!IsProtectiveFootwearNotApplicable")]
        public bool IsProtectiveFootwearToeGuard { get; set; }

        [SarniaWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [DenverWorkPermit("!IsProtectiveFootwearNotApplicable")]
        [SELCWorkPermit("!IsProtectiveFootwearNotApplicable")]
        public string ProtectiveFootwearOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsHandProtectionNotApplicable { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionChemicalNeoprene { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionNaturalRubber { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsHandProtectionNotApplicable")]
        [SELCWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionNitrile { get; set; }

        // TODO: This is to be removed as it doesn't apply to anything.  PVC, remove from views, forms, db.
        // [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionPVC { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsHandProtectionNotApplicable")]
        [SELCWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionHighVoltage { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsHandProtectionNotApplicable")]
        [SELCWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionWelding { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionLeather { get; set; }

        [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsHandProtectionNotApplicable")]
        [SELCWorkPermit("!IsHandProtectionNotApplicable")]
        public bool IsHandProtectionChemicalGloves { get; set; }

        [SarniaWorkPermit("!IsHandProtectionNotApplicable")]
        [DenverWorkPermit("!IsHandProtectionNotApplicable")]
        [USPipelineWorkPermit("!IsHandProtectionNotApplicable")]
        [SELCWorkPermit("!IsHandProtectionNotApplicable")]
        public string HandProtectionOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsRescueOrFallNotApplicable { get; set; }

        [SarniaWorkPermit("!IsRescueOrFallNotApplicable")]
        [DenverWorkPermit("!IsRescueOrFallNotApplicable")]
        [USPipelineWorkPermit("!IsRescueOrFallNotApplicable")]
        [SELCWorkPermit("!IsRescueOrFallNotApplicable")]
        public bool IsRescueOrFallBodyHarness { get; set; }

        [SarniaWorkPermit("!IsRescueOrFallNotApplicable")]
        [DenverWorkPermit("!IsRescueOrFallNotApplicable")]
        [USPipelineWorkPermit("!IsRescueOrFallNotApplicable")]
        [SELCWorkPermit("!IsRescueOrFallNotApplicable")]
        public bool IsRescueOrFallLifeline { get; set; }

        [DenverWorkPermit("!IsRescueOrFallNotApplicable")]
        [USPipelineWorkPermit("!IsRescueOrFallNotApplicable")]
        [SELCWorkPermit("!IsRescueOrFallNotApplicable")]
        public bool IsRescueOrFallYoYo { get; set; }

        [SarniaWorkPermit("!IsRescueOrFallNotApplicable")]
        [DenverWorkPermit("!IsRescueOrFallNotApplicable")]
        [USPipelineWorkPermit("!IsRescueOrFallNotApplicable")]
        [SELCWorkPermit("!IsRescueOrFallNotApplicable")]
        public bool IsRescueOrFallRescueDevice { get; set; }

        [SarniaWorkPermit("!IsRescueOrFallNotApplicable")]
        [DenverWorkPermit("!IsRescueOrFallNotApplicable")]
        [USPipelineWorkPermit("!IsRescueOrFallNotApplicable")]
        [SELCWorkPermit("!IsRescueOrFallNotApplicable")]
        public string RescueOrFallOtherDescription { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]                        //ayman USPipeline workpermit
        [SELCWorkPermit] 
        public bool FallRestraint { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool FallSelfRetractingDevice { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool? FallTieoffRequired { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public string FallOtherDescription { get; set; }

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            HandProtectionOtherDescription = null;
            IsEyeOrFaceProtectionNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsProtectiveClothingTypeNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsProtectiveFootwearNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsHandProtectionNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsRescueOrFallNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        public WorkPermitSpecialPPERequirements Copy()
        {
            return (WorkPermitSpecialPPERequirements) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return HasEyeOrFaceProtectionData()
                   || HasProtectiveClothingData()
                   || HasProtectiveFootwearData()
                   || HasHandProtectionData()
                   || HasRescueProtectionData()
                   || HasFallProtectionData();
        }

        public bool HasEyeOrFaceProtectionData()
        {
            return IsEyeOrFaceProtectionGoggles
                   || IsEyeOrFaceProtectionFaceshield
                   || EyeOrFaceProtectionOtherDescription.HasValue();
        }

        public bool HasProtectiveClothingData()
        {
            return IsProtectiveClothingTypeRainCoat
                   || IsProtectiveClothingTypeRainPants
                   || IsProtectiveClothingTypeAcidClothing
                   || IsProtectiveClothingTypeCausticWear
                   || IsProtectiveClothingTypePaperCoveralls
                   || IsProtectiveClothingTypeTyvekSuit
                   || IsProtectiveClothingTypeKapplerSuit
                   || IsProtectiveClothingTypeElectricalFlashGear
                   || IsProtectiveClothingTypeCorrosiveClothing
                   || ProtectiveClothingTypeOtherDescription.HasValue()
                   || ProtectiveClothingTypeAcidClothingType != null;
        }

        public bool HasProtectiveFootwearData()
        {
            return IsProtectiveFootwearChemicalImperviousBoots
                   || IsProtectiveFootwearMetatarsalGuard
                   || IsProtectiveFootwearToeGuard
                   || ProtectiveFootwearOtherDescription.HasValue();
        }

        public bool HasHandProtectionData()
        {
            return IsHandProtectionChemicalNeoprene
                   || IsHandProtectionNaturalRubber
                   || IsHandProtectionNitrile
                   || IsHandProtectionPVC
                   || IsHandProtectionHighVoltage
                   || IsHandProtectionLeather
                   || IsHandProtectionWelding
                   || IsHandProtectionChemicalGloves
                   || HandProtectionOtherDescription.HasValue();
        }

        public bool HasRescueProtectionData()
        {
            return IsRescueOrFallBodyHarness
                   || IsRescueOrFallLifeline
                   || IsRescueOrFallYoYo
                   || IsRescueOrFallRescueDevice
                   || RescueOrFallOtherDescription.HasValue();
        }

        public bool HasFallProtectionData()
        {
            return FallSelfRetractingDevice
                   || FallTieoffRequired.HasValue
                   || FallRestraint
                   || FallOtherDescription.HasValue();
        }
    }
}