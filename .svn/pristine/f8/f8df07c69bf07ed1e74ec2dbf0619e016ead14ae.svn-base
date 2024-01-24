using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     The job or worksite prepartion pieces of a work permit
    /// </summary>
    [Serializable]
    [Alias("JobWorksite")]
    public class WorkPermitJobWorksitePreparation : DomainObject
    {
        public WorkPermitJobWorksitePreparation()
        {
            IsFlowRequiredForJobNotApplicable = true;
            IsBondingOrGroundingRequiredNotApplicable = true;
            IsCriticalConditionRemainJobSiteNotApplicable = true;

            IsControlRoomContactedNotApplicable = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

            IsSurroundingConditionsAffectOrContaminatedNotApplicable = true;
            IsVestedBuddySystemInEffectNotApplicable = true;
            IsPermitReceiverFieldOrEquipmentOrientationNotApplicable = true;
            IsSewerIsolationMethodNotApplicable = true;
            IsLightingElectricalRequirementNotApplicable = true;
            IsAreaPreparationNotApplicable = true;
            
        }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]               //ayman USPipeline workpermit
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]       //mangesh uspipeline to selc
        public bool? IsFlowRequiredForJob { set; get; }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsFlowRequiredForJobNotApplicable { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsBondingOrGroundingRequiredNotApplicable { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsBondingOrGroundingRequired { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsWeldingGroundWireInTestAreaNotApplicable { set; get; }

        //ayman sarnia not applicable
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsHazardousEnergyIsolationRequiredNotApplicable { set; get; }

        //ayman sarnia not applicable
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsAspestosRequiredNotApplicable { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsWeldingGroundWireInTestArea { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsCriticalConditionRemainJobSiteNotApplicable { get; set; }

        [SarniaWorkPermit]
        public bool IsControlRoomContactedNotApplicable { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

         
        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsCriticalConditionRemainJobSite { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
        SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsSurroundingConditionsAffectOrContaminatedNotApplicable { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsSurroundingConditionsAffectOrContaminated { set; get; }

        [SarniaWorkPermit]
        public bool IsVestedBuddySystemInEffectNotApplicable { get; set; }

        [SarniaWorkPermit]
        public bool? IsVestedBuddySystemInEffect { set; get; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsPermitReceiverFieldOrEquipmentOrientationNotApplicable { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool? IsPermitReceiverFieldOrEquipmentOrientation { set; get; }

        [SarniaWorkPermit]
        public bool? IsControlRoomContactedOrNot { set; get; }    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsSewerIsolationMethodNotApplicable { get; set; }

        [SarniaWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        public bool IsSewerIsolationMethodSealedOrCovered { set; get; }

        [SarniaWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        public bool IsSewerIsolationMethodPlugged { set; get; }

        [SarniaWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [DenverWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [USPipelineWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        [SELCWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        public bool IsSewerIsolationMethodBlindedOrBlanked { set; get; }


        [SarniaWorkPermit("!IsSewerIsolationMethodNotApplicable"),
         DenverWorkPermit("!IsSewerIsolationMethodNotApplicable"),
         USPipelineWorkPermit("!IsSewerIsolationMethodNotApplicable"),
        SELCWorkPermit("!IsSewerIsolationMethodNotApplicable")]
        public string SewerIsolationMethodOtherDescription { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
         USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet),
        SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsAreaPreparationNotApplicable { get; set; }

        [SarniaWorkPermit("!IsAreaPreparationNotApplicable")]
        [DenverWorkPermit("!IsAreaPreparationNotApplicable")]
        [USPipelineWorkPermit("!IsAreaPreparationNotApplicable")]
        [SELCWorkPermit("!IsAreaPreparationNotApplicable")]
        public bool IsAreaPreparationBarricade { set; get; }

        [DenverWorkPermit("!IsAreaPreparationNotApplicable")]
        [USPipelineWorkPermit("!IsAreaPreparationNotApplicable")]
        [SELCWorkPermit("!IsAreaPreparationNotApplicable")]
        public bool IsAreaPreparationNonEssentialEvac { set; get; }

        [SarniaWorkPermit("!IsAreaPreparationNotApplicable")]
        [DenverWorkPermit("!IsAreaPreparationNotApplicable")]
        [USPipelineWorkPermit("!IsAreaPreparationNotApplicable")]
        [SELCWorkPermit("!IsAreaPreparationNotApplicable")]
        public bool IsAreaPreparationBoundaryRopeTape { set; get; }

        [SarniaWorkPermit("!IsAreaPreparationNotApplicable"), DenverWorkPermit("!IsAreaPreparationNotApplicable"), USPipelineWorkPermit("!IsAreaPreparationNotApplicable"),
        SELCWorkPermit("!IsAreaPreparationNotApplicable")]
        public string AreaPreparationOtherDescription { get; set; }

        [DenverWorkPermit("!IsAreaPreparationNotApplicable")]
        [USPipelineWorkPermit("!IsAreaPreparationNotApplicable")]
        [SELCWorkPermit("!IsAreaPreparationNotApplicable")]
        public bool IsAreaPreparationRadiationRope { get; set; }

        [DenverWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [USPipelineWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        [SELCWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
        public bool IsLightingElectricalRequirementNotApplicable { get; set; }

        [DenverWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [USPipelineWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [SELCWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        public bool IsLightingElectricalRequirementLowVoltage12V { set; get; }

        [DenverWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [USPipelineWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [SELCWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        public bool IsLightingElectricalRequirement110VWithGFCI { set; get; }

        [DenverWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [USPipelineWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [SELCWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        public bool IsLightingElectricalRequirementGeneratorLights { set; get; }

        [DenverWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [USPipelineWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        [SELCWorkPermit("!IsLightingElectricalRequirementNotApplicable")]
        public string LightingElectricalRequirementOtherDescription { get; set; }

        [DenverWorkPermit(Constants.VERSION_4_9_STRING, "IsFlowRequiredForJobApplicableAndIsFlowRequiredForJob")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, "IsFlowRequiredForJobApplicableAndIsFlowRequiredForJob")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, "IsFlowRequiredForJobApplicableAndIsFlowRequiredForJob")]
        public string FlowRequiredComments { get; set; }

        [SarniaWorkPermit("IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired")]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING,
            "IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING,
            "IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING,
           "IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired")]
        public string BondingGroundingNotRequiredComments { get; set; }

        [SarniaWorkPermit("IsWeldingGroundWireInTestAreaApplicableAndIsNotWeldingGroundWireInTestArea")]
        public string WeldingGroundWireNotWithinGasTestAreaComments { get; set; }

        [SarniaWorkPermit("IsCriticalConditionRemainJobSiteApplicableAndIsCriticalConditionRemainJobSite")]
        public string CriticalConditionsComments { get; set; }

        [SarniaWorkPermit(
            "IsSurroundingConditionsAffectOrContaminatedApplicableAndIsSurroundingConditionsAffectOrContaminated")]
        [DenverWorkPermit(Constants.VERSION_4_9_STRING,
            "IsSurroundingConditionsAffectOrContaminatedApplicableAndIsSurroundingConditionsAffectOrContaminated")]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING,
            "IsSurroundingConditionsAffectOrContaminatedApplicableAndIsSurroundingConditionsAffectOrContaminated")]
        [SELCWorkPermit(Constants.VERSION_4_9_STRING,
           "IsSurroundingConditionsAffectOrContaminatedApplicableAndIsSurroundingConditionsAffectOrContaminated")]
        public string SurroundingConditionsAffectAreaComments { get; set; }

        //[SarniaWorkPermit(
        //    "IsPermitReceiverFieldOrEquipmentOrientationApplicableAndIsPermitReceiverFieldOrEquipmentOrientation")]
        [SarniaWorkPermit]
        public string PermitReceiverRequiresOrientationComments { get; set; }

        public void InitializeWithSensibleDefaults(SiteConfiguration siteConfiguration)
        {
            SetOptionDefaults(siteConfiguration);

            // Set N/A defaults:
            IsAreaPreparationNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsBondingOrGroundingRequiredNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsCriticalConditionRemainJobSiteNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsControlRoomContactedNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            IsFlowRequiredForJobNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsLightingElectricalRequirementNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsPermitReceiverFieldOrEquipmentOrientationNotApplicable =
                siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsSewerIsolationMethodNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsSurroundingConditionsAffectOrContaminatedNotApplicable =
                siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsVestedBuddySystemInEffectNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
            IsHazardousEnergyIsolationRequiredNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;                       //ayman sarnia not applicable
            IsAspestosRequiredNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;                                       //ayman sarnia not applicable

            IsWeldingGroundWireInTestAreaNotApplicable = siteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        private void SetOptionDefaults(SiteConfiguration siteConfiguration)
        {
            if (siteConfiguration.WorkPermitOptionAutoSelected)
            {
                IsFlowRequiredForJob = false;
                IsBondingOrGroundingRequired = true;
                IsWeldingGroundWireInTestArea = true;
                IsSurroundingConditionsAffectOrContaminated = false;
                IsVestedBuddySystemInEffect = false;
                IsCriticalConditionRemainJobSite = false;
                IsPermitReceiverFieldOrEquipmentOrientation = null;
                IsControlRoomContactedOrNot = false; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }
            else
            {
                IsFlowRequiredForJob = null;
                IsBondingOrGroundingRequired = null;
                IsWeldingGroundWireInTestArea = null;
                IsSurroundingConditionsAffectOrContaminated = null;
                IsVestedBuddySystemInEffect = null;
                IsCriticalConditionRemainJobSite = null;
                IsPermitReceiverFieldOrEquipmentOrientation = null;
                IsControlRoomContactedOrNot = null;// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                
            }
        }

        public WorkPermitJobWorksitePreparation Copy()
        {
            return (WorkPermitJobWorksitePreparation) Clone();
        }

        /// <summary>Tests if this section of the work permit has data (has been "filled out").</summary>
        public bool HasData()
        {
            return HasSewerIsolationMethodData()
                   || HasAreaPreparationData()
                   || HasLightingElectricalRequirementData()
                   || PermitReceiverRequiresOrientationComments.HasValue()
                   || SurroundingConditionsAffectAreaComments.HasValue()
                   || CriticalConditionsComments.HasValue()
                   || WeldingGroundWireNotWithinGasTestAreaComments.HasValue()
                   || BondingGroundingNotRequiredComments.HasValue()
                   || FlowRequiredComments.HasValue();
        }

        public bool HasSewerIsolationMethodData()
        {
            return IsSewerIsolationMethodSealedOrCovered
                   || IsSewerIsolationMethodPlugged
                   || IsSewerIsolationMethodBlindedOrBlanked
                   || SewerIsolationMethodOtherDescription.HasValue();
        }

        public bool HasAreaPreparationData()
        {
            return IsAreaPreparationBarricade
                   || IsAreaPreparationNonEssentialEvac
                   || IsAreaPreparationBoundaryRopeTape
                   || IsAreaPreparationRadiationRope
                   || AreaPreparationOtherDescription.HasValue();
        }

        public bool HasLightingElectricalRequirementData()
        {
            return IsLightingElectricalRequirementLowVoltage12V
                   || IsLightingElectricalRequirement110VWithGFCI
                   || IsLightingElectricalRequirementGeneratorLights
                   || LightingElectricalRequirementOtherDescription.HasValue();
        }

        # region Work Permit Attribute Pre-Setter Condition Properties (called via reflection)

        public bool IsPermitReceiverFieldOrEquipmentOrientationApplicableAndIsPermitReceiverFieldOrEquipmentOrientation
        {
            get
            {
                return !IsPermitReceiverFieldOrEquipmentOrientationNotApplicable &&
                       IsPermitReceiverFieldOrEquipmentOrientation.GetValueOrDefault(false);
            }
        }

        public bool IsControlRoomContactedField // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get
            {
                return !IsControlRoomContactedNotApplicable &&
                       IsControlRoomContactedOrNot.GetValueOrDefault(false);
            }
        }

        

        public bool IsSurroundingConditionsAffectOrContaminatedApplicableAndIsSurroundingConditionsAffectOrContaminated
        {
            get
            {
                return !IsSurroundingConditionsAffectOrContaminatedNotApplicable &&
                       IsSurroundingConditionsAffectOrContaminated.GetValueOrDefault(false);
            }
        }

        public bool IsCriticalConditionRemainJobSiteApplicableAndIsCriticalConditionRemainJobSite
        {
            get
            {
                return !IsCriticalConditionRemainJobSiteNotApplicable &&
                       IsCriticalConditionRemainJobSite.GetValueOrDefault(false);
            }
        }

        
        //ayman Sarnia not applicable
        public bool IsHazardousEnergyIsolationRequired
        {
            get { return IsHazardousEnergyIsolationRequiredNotApplicable; }
        }

        //ayman Sarnia not applicable
        public bool IsAspestosRequired
        {
            get { return IsAspestosRequiredNotApplicable; }
        }


        public bool IsWeldingGroundWireInTestAreaApplicableAndIsNotWeldingGroundWireInTestArea
        {
            get
            {
                return !IsWeldingGroundWireInTestAreaNotApplicable &&
                       !IsWeldingGroundWireInTestArea.GetValueOrDefault(false);
            }
        }

        public bool IsBondingOrGroundingRequiredApplicableAndIsNotBondingOrGroundingRequired
        {
            get
            {
                return !IsBondingOrGroundingRequiredNotApplicable &&
                       !IsBondingOrGroundingRequired.GetValueOrDefault(true);
            }
        }

        public bool IsFlowRequiredForJobApplicableAndIsFlowRequiredForJob
        {
            get { return !IsFlowRequiredForJobNotApplicable && IsFlowRequiredForJob.GetValueOrDefault(false); }
        }

        #endregion
    }
}