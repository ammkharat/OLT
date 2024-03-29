using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitHistory : DomainObject, IHistorySnapshot
    {
        #region WorkPermitEquipmentPreparationCondition

        #endregion

        #region WorkPermitJobWorksitePreparation

        #endregion

        #region WorkPermitRespiratoryProtectionRequirements

        #endregion

        #region WorkPermitSpecialPPERequirements

        public WorkPermitHistory()
        {
            ProtectiveClothingTypeNotApplicable = true;
            EyeOrFaceProtectionNotApplicable = true;
            RespiratoryProtectionNotApplicable = true;
            CriticalConditionRemainJobSiteNotApplicable = true;
            ControlRoomContactedNotApplicable = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            IsControlRoomContactedOrNot = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            Revalidation = 0;
            BondingOrGroundingRequiredNotApplicable = true;
            FlowRequiredForJobNotApplicable = true;
            IsIsolationMethodNotApplicable = true;
            IsAsbestosGasketsNotApplicable = true;
            IsPreviousContentsNotApplicable = true;
            IsConditionNotApplicable = true;
            IsLeakingValvesNotApplicable = true;
            IsStillContainsResidualNotApplicable = true;
            IsTestBumpNotApplicable = true;
            SealedSourceIsolationNotApplicable = true;
            LightingElectricalRequirementNotApplicable = true;
            AreaPreparationNotApplicable = true;
            VentilationMethodNotApplicable = true;
            SewerIsolationMethodNotApplicable = true;
            PermitReceiverFieldOrEquipmentOrientationNotApplicable = true;
            VestedBuddySystemInEffectNotApplicable = true;
            SurroundingConditionsAffectOrContaminatedNotApplicable = true;
        }

        #endregion

        public User ApprovedBy { get; set; }

        public string DocumentLinks { get; set; }

        public string PermitNumber { get; set; }

        public DateTime? PermitValidDateTime { get; set; }

        public WorkPermitType WorkPermitType { get; set; }

        public WorkPermitTypeClassification WorkPermitClassification { get; set; }

        public WorkPermitStatus WorkPermitStatus { get; set; }

        public string SpecialPrecautionsOrConsiderations { get; set; }

        public bool? IsCoauthorizationRequired { get; set; }

        public bool? IsControlRoomContacted { get; set; }        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        
        public int? Revalidation { get; set; }
       

        public string CoauthorizationDescription { get; set; }

        public DataSource Source { get; set; }

        public long? SapOperationId { get; set; }

        public bool IsConfinedSpaceEntry { get; set; }

        public bool IsInertConfinedSpaceEntry { get; set; }

        public bool IsLeadAbatement { get; set; }

        public bool IsBreathingAirOrSCBA { get; set; }

        public bool IsVehicleEntry { get; set; }

        public bool IsHotTap { get; set; }

        public bool IsBurnOrOpenFlame { get; set; }

        public bool IsSystemEntry { get; set; }

        public bool IsCriticalLift { get; set; }

        public string AdditionalCriticalLiftDescription { get; set; }

        public bool IsExcavation { get; set; }

        public string AdditionalExcavationDescription { get; set; }

        public bool IsAsbestos { get; set; }

        public string AdditionalAsbestosHandlingDescription { get; set; }

        public bool IsRadiationRadiography { get; set; }

        public bool IsFreshAir { get; set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        public bool IsRadiationSealed { get; set; }

        public bool IsAdditionalCSEAssessmentOrAuthorization { get; set; }

        public string AdditionalCSEAssessmentOrAuthorizationDescription { get; set; }

        public bool IsAdditionalFlareEntry { get; set; }

        public bool IsAdditionalCriticalLift { get; set; }

        public bool IsAdditionalExcavation { get; set; }

        public bool IsAdditionalHotTap { get; set; }

        public bool IsAdditionalSpecialWasteDisposal { get; set; }

        public bool IsAdditionalBlankOrBlindLists { get; set; }

        public bool IsAdditionalPJSROrSafetyPause { get; set; }

        public bool IsAdditionalAsbestosHandling { get; set; }

        public bool IsAdditionalRoadClosure { get; set; }

        public bool IsAdditionalElectrical { get; set; }

        public string AdditionalElectricalDescription { get; set; }

        public bool IsAdditionalBurnOrOpenFlameAssessment { get; set; }

        public string AdditionalBurnOrOpenFlameAssessmentDescription { get; set; }

        public bool IsAdditionalWaiverOrDeviation { get; set; }

        public string AdditionalWaiverOrDeviationDescription { get; set; }

        public bool IsAdditionalMSDS { get; set; }

        public bool IsAdditionalRadiationApproval { get; set; }

        public bool IsAdditionalOnlineLeakRepairForm { get; set; }

        public bool IsAdditionalEnergizedElectricalForm { get; set; }

        public bool IsAdditionalNotApplicable { get; set; }

        public string AdditionalOtherItemDescription { get; set; }

        public FunctionalLocation FunctionalLocation { get; set; }

        public WorkAssignment WorkAssignment { get; set; }

        public string WorkOrderNumber { get; set; }

        public DateTime StartDateTime { get; set; }

        public bool StartTimeNotApplicable { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool StartAndOrEndTimesFinalized { get; set; }

        public string WorkOrderDescription { get; set; }

        public string JobStepsDescription { get; set; }

        public string ContactName { get; set; }

        public string ContractorCompanyName { get; set; }

        public long? CraftOrTradeId { get; set; }

        public string CraftOrTradeOther { get; set; }

        public string RadioChannel { get; set; }

        public string RadioColor { get; set; }

        public string CommunicationDescription { get; set; }

        public bool IsWorkPermitCommunicationNotApplicable { get; set; }

        public bool? ByRadio { get; set; }

        public bool IsElectricalIsolationMethodNotApplicable { get; set; }

        public bool IsElectricalIsolationMethodLOTO { get; set; }

        public bool IsElectricalIsolationMethodWiring { get; set; }

        public bool IsTestBumpNotApplicable { get; set; }

        public bool? IsTestBump { get; set; }

        public bool IsStillContainsResidualNotApplicable { get; set; }

        public bool? IsStillContainsResidual { get; set; }

        public bool IsLeakingValvesNotApplicable { get; set; }

        public bool? IsLeakingValves { get; set; }

        public bool? IsOutOfService { get; set; }

        public bool IsConditionNotApplicable { get; set; }

        public bool IsConditionDepressured { get; set; }

        public bool IsConditionDrained { get; set; }

        public bool IsConditionCleaned { get; set; }

        public bool IsConditionPurgedCheckbox { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        public bool IsConditionVentilated { get; set; }

        public bool IsConditionH20Washed { get; set; }

        public bool IsConditionNeutralized { get; set; }

        public bool IsConditionPurged { get; set; }

        public string ConditionPurgedDescription { get; set; }

        public bool IsConditionPurgedN2 { get; set; }

        public bool IsConditionPurgedSteamed { get; set; }

        public bool IsConditionPurgedAir { get; set; }

        public string ConditionOtherDescription { get; set; }

        public bool IsPreviousContentsNotApplicable { get; set; }

        public bool IsPreviousContentsHydrocarbon { get; set; }

        public bool IsPreviousContentsAcid { get; set; }

        public bool IsPreviousContentsCaustic { get; set; }

        public bool IsPreviousContentsH2S { get; set; }

        public string PreviousContentsOtherDescription { get; set; }

        public bool IsAsbestosGasketsNotApplicable { get; set; }

        public bool? IsAsbestosGaskets { get; set; }

        public bool IsIsolationMethodNotApplicable { get; set; }

        public bool IsIsolationMethodBlindedorBlanked { get; set; }

        public bool IsIsolationMethodSeparation { get; set; }

        public bool IsIsolationMethodMudderPlugs { get; set; }

        public bool IsIsolationMethodBlockedIn { get; set; }

        public bool IsIsolationMethodCarBer { get; set; }

        public bool IsIsolationMethodLOTO { get; set; }

        public string IsolationMethodOtherDescription { get; set; }

        public string EquipmentInServiceComments { get; set; }

        public string EquipmentInAsbestosHazardPresentComments { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        //public string EquipmentInHazardousEnergyIsolationComments { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

        
        public string LeakingValvesComments { get; set; }

        public string StillContainsResidualComments { get; set; }

        public string NoElectricalTestBumpComments { get; set; }

        public bool IsHazardousEnergyIsolationRequiredNotApplicable { get; set; }
        public bool? IsHazardousEnergyIsolationRequired { get; set; }
        public WorkPermitLockOutMethodType EquipmentLockOutMethod { get; set; }
        public string EquipmentLockOutMethodComments { get; set; }
        public string EnergyIsolationPlanNumber { get; set; }
        public bool? ConditionsOfEIPSatisfied { get; set; }
        public string ConditionsOfEIPNotSatisfiedComments { get; set; }
        public bool AsbestosHazardsConsideredNotApplicable { get; set; }
        public bool? AsbestosHazardsConsidered { get; set; }

        public bool FlowRequiredForJobNotApplicable { get; set; }

        public bool? FlowRequiredForJob { get; set; }

        public bool BondingOrGroundingRequiredNotApplicable { get; set; }

        public bool? BondingOrGroundingRequired { get; set; }

        public bool WeldingGroundWireInTestAreaNotApplicable { get; set; }

        public bool? WeldingGroundWireInTestArea { get; set; }

        public bool CriticalConditionRemainJobSiteNotApplicable { get; set; }

        public bool ControlRoomContactedNotApplicable { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        public bool? IsControlRoomContactedOrNot { get; set; }  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        

        

        public bool? CriticalConditionRemainJobSite { get; set; }

        public bool SurroundingConditionsAffectOrContaminatedNotApplicable { get; set; }

        public bool? SurroundingConditionsAffectOrContaminated { get; set; }

        public bool VestedBuddySystemInEffectNotApplicable { get; set; }

        public bool? VestedBuddySystemInEffect { get; set; }

        public bool PermitReceiverFieldOrEquipmentOrientationNotApplicable { get; set; }

        public bool? PermitReceiverFieldOrEquipmentOrientation { get; set; }

        public bool SewerIsolationMethodNotApplicable { get; set; }

        public bool SewerIsolationMethodSealedOrCovered { get; set; }

        public bool SewerIsolationMethodPlugged { get; set; }

        public bool SewerIsolationMethodBlindedOrBlanked { get; set; }

        public string SewerIsolationMethodOtherDescription { get; set; }

        public bool VentilationMethodNotApplicable { get; set; }

        public bool VentilationMethodNaturalDraft { get; set; }

        public bool VentilationMethodLocalExhaust { get; set; }

        public bool VentilationMethodForced { get; set; }

        public bool AreaPreparationNotApplicable { get; set; }

        public bool AreaPreparationBarricade { get; set; }

        public bool AreaPreparationNonEssentialEvac { get; set; }

        public bool AreaPreparationPreopBoundaryRopeTape { get; set; }

        public bool AreaPreparationRadiationRope { get; set; }

        public string AreaPreparationOtherDescription { get; set; }

        public bool LightingElectricalRequirementNotApplicable { get; set; }

        public bool LightingElectricalRequirementLowVoltage12V { get; set; }

        public bool LightingElectricalRequirement110VWithGFCI { get; set; }

        public bool LightingElectricalRequirementGeneratorLights { get; set; }

        public string LightingElectricalRequirementOtherDescription { get; set; }

        public string PermitReceiverRequiresOrientationComments { get; set; }

        public string SurroundingConditionsAffectAreaComments { get; set; }

        public string CriticalConditionsComments { get; set; }

        public string WeldingGroundWireNotWithinGasTestAreaComments { get; set; }

        public string BondingGroundingNotRequiredComments { get; set; }

        public string FlowRequiredComments { get; set; }

        public bool SealedSourceIsolationNotApplicable { get; set; }

        public bool SealedSourceIsolationLOTO { get; set; }

        public bool SealedSourceIsolationOpen { get; set; }

        public int? SealedSourceIsolationNumberOfSources { get; set; }

        public string GasTestFrequencyOrDuration { get; set; }

        public bool GasTestConstantMonitoringRequired { get; set; }

        public bool GasTestForkliftNotUsed { get; set; }

        public Time GasTestTestTime { get; set; }

        public Time GasTestConfinedSpaceTestTime { get; set; }

        public Time GasTestSystemEntryTestTime { get; set; }

        public string GasTestElements { get; set; }

        public bool FireConfinedSpaceNotApplicable { get; set; }

        public bool TwentyABCorDryChemicalExtinguisher { get; set; }

        public bool C02Extinguisher { get; set; }

        public bool FireResistantTarp { get; set; }

        public bool Watchmen { get; set; }

        public string FireConfinedSpaceRequirementsOtherRequirementsDescription { get; set; }

        public bool SparkContainment { get; set; }

        public bool SteamHose { get; set; }

        public bool WaterHose { get; set; }

        public bool RespiratoryProtectionNotApplicable { get; set; }

        public bool AirCartorAirLine { get; set; }

        public bool DustMask { get; set; }

        public bool SCBA { get; set; }

        public bool AirHood { get; set; }

        public bool HalfFaceRespirator { get; set; }

        public bool FullFaceRespirator { get; set; }

        public string RespiratoryProtectionRequirementsOtherDescription { get; set; }

        public string RespiratoryCartridgeTypeDescription { get; set; }

        public WorkPermitRespiratoryCartridgeType RespiratoryCartridgeType { get; set; }

        public bool EyeOrFaceProtectionNotApplicable { get; set; }

        public bool EyeOrFaceProtectionGoggles { get; set; }

        public bool EyeOrFaceProtectionFaceshield { get; set; }

        public string EyeOrFaceProtectionOtherDescription { get; set; }

        public bool ProtectiveClothingTypeNotApplicable { get; set; }

        public bool ProtectiveClothingTypeRainCoat { get; set; }

        public bool ProtectiveClothingTypeRainPants { get; set; }

        public bool ProtectiveClothingTypeAcidClothing { get; set; }

        public AcidClothingType ProtectiveClothingTypeAcidClothingType { get; set; }

        public bool ProtectiveClothingTypeCausticWear { get; set; }

        public bool ProtectiveClothingTypePaperCoveralls { get; set; }

        public bool ProtectiveClothingTypeTyvekSuit { get; set; }

        public bool ProtectiveClothingTypeKapplerSuit { get; set; }

        public bool ProtectiveClothingTypeElectricalFlashGear { get; set; }

        public bool ProtectiveClothingTypeCorrosiveClothing { get; set; }

        public string ProtectiveClothingTypeOtherDescripton { get; set; }

        public bool ProtectiveFootwearNotApplicable { get; set; }

        public bool ProtectiveFootwearChemicalImperviousBoots { get; set; }

        public bool ProtectiveFootwearToeGuard { get; set; }

        public bool ProtectiveFootwearMetatarsalGuard { get; set; }

        public string ProtectiveFootwearOtherDescription { get; set; }

        public bool HandProtectionNotApplicable { get; set; }

        public bool HandProtectionChemicalNeprene { get; set; }

        public bool HandProtectionNaturalRubber { get; set; }

        public bool HandProtectionNitrile { get; set; }

        public bool HandProtectionPVC { get; set; }

        public bool HandProtectionHighVoltage { get; set; }

        public bool HandProtectionWelding { get; set; }

        public bool HandProtectionLeather { get; set; }

        public bool HandProtectionChemicalGloves { get; set; }

        public string HandProtectionOtherDescription { get; set; }

        public bool RescueOrFallNotApplicable { get; set; }

        public bool RescueOrFallBodyHarness { get; set; }

        public bool RescueOrFallLifeline { get; set; }

        public bool RescueOrFallYoYo { get; set; }

        public bool RescueOrFallRescueDevice { get; set; }

        public string RescueOrFallOtherDescription { get; set; }

        public bool FallRestraint { get; set; }

        public bool? FallTieoffRequired { get; set; }

        public bool FallSelfRetractingDevice { get; set; }

        public string FallOtherDescription { get; set; }

        public bool IsElectricalWork { get; set; }

        public string HoleWatchNumber { get; set; }

        public string FireWatchNumber { get; set; }

        public string SpotterNumber { get; set; }

        //Added By Vibhor : RITM0627539 - Denver Site upgrades

        public bool PreExcavationAuthorization { get; set; }
        
        public bool SuspendedWorkPlatform { get; set; }
        
        public bool HotTurnoverApproval { get; set; }
        
        public bool ConfinedSpaceEntryAuthorizationForm { get; set; }
        
        public bool PreExcavationAuthorizationForm { get; set; }
        
        public bool SupplementalJobSiteSignInForm { get; set; }
        
        public bool SystemEntryGasTestLogFrom { get; set; }
        
        public bool HeatStressMonitoringForm { get; set; }
        
        public bool CriticalLiftApprovalForm { get; set; }
        public bool PjsrSecondSection { get; set; }
        
        public bool DeviationRequestForm { get; set; }
        
        public bool RoadClosureform { get; set; }
        
        public bool RadiographyApprovalForm { get; set; }
        
        public bool ConfinedSpaceEntryTrackingLog { get; set; }
        
        public bool FlareLineChecklists { get; set; }
        
        public bool HotTurnoverApprovalForm { get; set; }
        
        public bool IndustrialHygieneAreaRealTimeSamplingForm { get; set; }
        
        public bool CraneSuspendedWorkPlatformChecklist { get; set; }
        
        public bool ConfinedSpaceEntryAuthorizationFormSecondSection { get; set; }

        public bool NASecondSection { get; set; }

        #region Tools

        public bool IsAirTools { get; set; }

        public bool IsCementSaw { get; set; }

        public bool IsChemicals { get; set; }

        public bool IsCompressor { get; set; }

        public bool IsCraneOrCarrydeck { get; set; }

        public bool IsElectricTools { get; set; }

        public bool IsForklift { get; set; }

        public bool IsHandTools { get; set; }

        public bool IsHeavyEquipment { get; set; }

        public bool IsHepaVacuum { get; set; }

        public bool IsHotTapMachine { get; set; }

        public bool IsJackhammer { get; set; }

        public bool IsLanda { get; set; }

        public bool IsManlift { get; set; }

        public bool IsPortLighting { get; set; }

        public bool IsScaffolding { get; set; }

        public bool IsTamper { get; set; }

        public bool IsTorch { get; set; }

        public bool IsVacuumTruck { get; set; }

        public bool IsVehicle { get; set; }

        public bool IsWelder { get; set; }

        public string OtherToolsDescription { get; set; }

        #endregion

        public User LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}