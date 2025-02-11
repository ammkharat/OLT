using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class WorkPermitSnapshotTaker
    {
        private readonly WorkPermit permit;

        public WorkPermitSnapshotTaker(WorkPermit workPermitToSnapshot)
        {
            permit = workPermitToSnapshot;
        }

        public WorkPermitHistory CreateWorkPermitHistorySnapshot()
        {
            var history = new WorkPermitHistory();

            AssignRootLevelFields(history);

            AssignAttributes(history);

            AssignAdditionalItemsRequired(history);

            AssignSpecifics(history);

            AssignTools(history);

            AssignEquipmentPreparationConditionFields(history);

            AssignAsbestosFields(history);

            AssignJobWorksitePreparationFields(history);

            AssignRadiationInformationFields(history);

            AssignFireConfinedSpaceRequirementsFields(history);

            AssignRespiratoryProtectionRequirementsFields(history);

            AssignSpecialProtectionRequirementsFields(history);

            AssignGasTests(history);

            return history;
        }

        private void AssignGasTests(WorkPermitHistory history)
        {
            if (permit.GasTests != null)
            {
                history.GasTestConstantMonitoringRequired = permit.GasTests.ConstantMonitoringRequired;
                history.GasTestForkliftNotUsed = permit.GasTests.ForkliftNotUsed;
                history.GasTestFrequencyOrDuration = permit.GasTests.FrequencyOrDuration;
                history.GasTestTestTime = permit.GasTests.ImmediateAreaTestTime;
                history.GasTestConfinedSpaceTestTime = permit.GasTests.ConfinedSpaceTestTime;
                history.GasTestSystemEntryTestTime = permit.GasTests.SystemEntryTestTime;
                var gasTestElements = permit.GasTests.Elements;
                history.GasTestElements = gasTestElements.AsString(gasTestElement => gasTestElement.ToHistoryString());
            }
        }

        private void AssignSpecialProtectionRequirementsFields(WorkPermitHistory history)
        {
            #region EyeOrFaceProtection

            history.EyeOrFaceProtectionNotApplicable =
                permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable;
            history.EyeOrFaceProtectionGoggles = permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionGoggles;
            history.EyeOrFaceProtectionFaceshield = permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield;
            history.EyeOrFaceProtectionOtherDescription =
                permit.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription;

            #endregion

            #region ProtectiveClothingType

            history.ProtectiveClothingTypeNotApplicable =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable;
            history.ProtectiveClothingTypeRainCoat =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainCoat;
            history.ProtectiveClothingTypeRainPants =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainPants;
            history.ProtectiveClothingTypeAcidClothing =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeAcidClothing;
            history.ProtectiveClothingTypeAcidClothingType =
                permit.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType;
            history.ProtectiveClothingTypeCausticWear =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeCausticWear;
            history.ProtectiveClothingTypePaperCoveralls =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypePaperCoveralls;
            history.ProtectiveClothingTypeTyvekSuit =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeTyvekSuit;
            history.ProtectiveClothingTypeKapplerSuit =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeKapplerSuit;
            history.ProtectiveClothingTypeElectricalFlashGear =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeElectricalFlashGear;
            history.ProtectiveClothingTypeCorrosiveClothing =
                permit.SpecialProtectionRequirements.IsProtectiveClothingTypeCorrosiveClothing;
            history.ProtectiveClothingTypeOtherDescripton =
                permit.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription;

            #endregion

            #region ProtectiveFootwear

            history.ProtectiveFootwearNotApplicable =
                permit.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable;
            history.ProtectiveFootwearChemicalImperviousBoots =
                permit.SpecialProtectionRequirements.IsProtectiveFootwearChemicalImperviousBoots;
            history.ProtectiveFootwearMetatarsalGuard =
                permit.SpecialProtectionRequirements.IsProtectiveFootwearMetatarsalGuard;
            history.ProtectiveFootwearToeGuard = permit.SpecialProtectionRequirements.IsProtectiveFootwearToeGuard;
            history.ProtectiveFootwearOtherDescription =
                permit.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription;

            #endregion

            #region HandProtection

            history.HandProtectionNotApplicable = permit.SpecialProtectionRequirements.IsHandProtectionNotApplicable;
            history.HandProtectionChemicalNeprene =
                permit.SpecialProtectionRequirements.IsHandProtectionChemicalNeoprene;
            history.HandProtectionNaturalRubber = permit.SpecialProtectionRequirements.IsHandProtectionNaturalRubber;
            history.HandProtectionNitrile = permit.SpecialProtectionRequirements.IsHandProtectionNitrile;
            history.HandProtectionPVC = permit.SpecialProtectionRequirements.IsHandProtectionPVC;
            history.HandProtectionHighVoltage = permit.SpecialProtectionRequirements.IsHandProtectionHighVoltage;
            history.HandProtectionWelding = permit.SpecialProtectionRequirements.IsHandProtectionWelding;
            history.HandProtectionLeather = permit.SpecialProtectionRequirements.IsHandProtectionLeather;
            history.HandProtectionChemicalGloves = permit.SpecialProtectionRequirements.IsHandProtectionChemicalGloves;
            history.HandProtectionOtherDescription = permit.SpecialProtectionRequirements.HandProtectionOtherDescription;

            #endregion

            #region RescueOrFall

            history.RescueOrFallNotApplicable = permit.SpecialProtectionRequirements.IsRescueOrFallNotApplicable;
            history.RescueOrFallBodyHarness = permit.SpecialProtectionRequirements.IsRescueOrFallBodyHarness;
            history.RescueOrFallLifeline = permit.SpecialProtectionRequirements.IsRescueOrFallLifeline;
            history.RescueOrFallYoYo = permit.SpecialProtectionRequirements.IsRescueOrFallYoYo;
            history.RescueOrFallRescueDevice = permit.SpecialProtectionRequirements.IsRescueOrFallRescueDevice;
            history.RescueOrFallOtherDescription = permit.SpecialProtectionRequirements.RescueOrFallOtherDescription;

            history.FallOtherDescription = permit.SpecialProtectionRequirements.FallOtherDescription;
            history.FallRestraint = permit.SpecialProtectionRequirements.FallRestraint;
            history.FallSelfRetractingDevice = permit.SpecialProtectionRequirements.FallSelfRetractingDevice;
            history.FallTieoffRequired = permit.SpecialProtectionRequirements.FallTieoffRequired;

            #endregion
        }

        private void AssignRespiratoryProtectionRequirementsFields(WorkPermitHistory history)
        {
            history.RespiratoryProtectionNotApplicable = permit.RespiratoryProtectionRequirements.IsNotApplicable;
            history.AirCartorAirLine = permit.RespiratoryProtectionRequirements.IsAirCartorAirLine;
            history.DustMask = permit.RespiratoryProtectionRequirements.IsDustMask;
            history.SCBA = permit.RespiratoryProtectionRequirements.IsSCBA;
            history.AirHood = permit.RespiratoryProtectionRequirements.IsAirHood;
            history.HalfFaceRespirator = permit.RespiratoryProtectionRequirements.IsHalfFaceRespirator;
            history.FullFaceRespirator = permit.RespiratoryProtectionRequirements.IsFullFaceRespirator;
            history.RespiratoryProtectionRequirementsOtherDescription =
                permit.RespiratoryProtectionRequirements.OtherDescription;
            history.RespiratoryCartridgeTypeDescription =
                permit.RespiratoryProtectionRequirements.CartridgeTypeDescription;
            history.RespiratoryCartridgeType = permit.RespiratoryProtectionRequirements.CartridgeType;
        }

        private void AssignFireConfinedSpaceRequirementsFields(WorkPermitHistory history)
        {
            history.FireConfinedSpaceNotApplicable = permit.FireConfinedSpaceRequirements.IsNotApplicable;
            history.TwentyABCorDryChemicalExtinguisher =
                permit.FireConfinedSpaceRequirements.IsTwentyABCorDryChemicalExtinguisher;
            history.C02Extinguisher = permit.FireConfinedSpaceRequirements.IsC02Extinguisher;
            history.FireResistantTarp = permit.FireConfinedSpaceRequirements.IsFireResistantTarp;
            history.Watchmen = permit.FireConfinedSpaceRequirements.IsWatchmen;
            history.FireConfinedSpaceRequirementsOtherRequirementsDescription =
                permit.FireConfinedSpaceRequirements.OtherDescription;
            history.SparkContainment = permit.FireConfinedSpaceRequirements.IsSparkContainment;
            history.SteamHose = permit.FireConfinedSpaceRequirements.IsSteamHose;
            history.WaterHose = permit.FireConfinedSpaceRequirements.IsWaterHose;
            history.HoleWatchNumber = permit.FireConfinedSpaceRequirements.HoleWatchNumber;
            history.FireWatchNumber = permit.FireConfinedSpaceRequirements.FireWatchNumber;
            history.SpotterNumber = permit.FireConfinedSpaceRequirements.SpotterNumber;
        }

        private void AssignRadiationInformationFields(WorkPermitHistory history)
        {
            history.SealedSourceIsolationNotApplicable =
                permit.RadiationInformation.IsSealedSourceIsolationNotApplicable;
            history.SealedSourceIsolationLOTO = permit.RadiationInformation.IsSealedSourceIsolationLOTO;
            history.SealedSourceIsolationOpen = permit.RadiationInformation.IsSealedSourceIsolationOpen;
            history.SealedSourceIsolationNumberOfSources =
                permit.RadiationInformation.SealedSourceIsolationNumberOfSources;
        }

        private void AssignJobWorksitePreparationFields(WorkPermitHistory history)
        {
            history.FlowRequiredForJobNotApplicable = permit.JobWorksitePreparation.IsFlowRequiredForJobNotApplicable;
            history.FlowRequiredForJob = permit.JobWorksitePreparation.IsFlowRequiredForJob;
            history.BondingOrGroundingRequiredNotApplicable =
                permit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable;
            history.BondingOrGroundingRequired = permit.JobWorksitePreparation.IsBondingOrGroundingRequired;
            history.WeldingGroundWireInTestAreaNotApplicable =
                permit.JobWorksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable;
            history.WeldingGroundWireInTestArea = permit.JobWorksitePreparation.IsWeldingGroundWireInTestArea;
            history.CriticalConditionRemainJobSiteNotApplicable =
                permit.JobWorksitePreparation.IsCriticalConditionRemainJobSiteNotApplicable;

            history.ControlRoomContactedNotApplicable =
                permit.JobWorksitePreparation.IsControlRoomContactedNotApplicable;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            history.IsControlRoomContactedOrNot = permit.JobWorksitePreparation.IsControlRoomContactedOrNot;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            history.Revalidation = permit.Revalidation;//Added by ppanigrahi

            history.CriticalConditionRemainJobSite = permit.JobWorksitePreparation.IsCriticalConditionRemainJobSite;
            history.SurroundingConditionsAffectOrContaminatedNotApplicable =
                permit.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable;
            history.SurroundingConditionsAffectOrContaminated =
                permit.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated;
            history.VestedBuddySystemInEffectNotApplicable =
                permit.JobWorksitePreparation.IsVestedBuddySystemInEffectNotApplicable;
            history.VestedBuddySystemInEffect = permit.JobWorksitePreparation.IsVestedBuddySystemInEffect;
            history.PermitReceiverFieldOrEquipmentOrientationNotApplicable =
                permit.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable;
            history.PermitReceiverFieldOrEquipmentOrientation =
                permit.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation;

            history.IsControlRoomContacted =
                permit.JobWorksitePreparation.IsControlRoomContactedOrNot;      // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

           // history.Revalidation = permit.ExtensionRevalidationDateTime;//Added by ppanigrahi

            history.SewerIsolationMethodNotApplicable =
                permit.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable;
            history.SewerIsolationMethodSealedOrCovered =
                permit.JobWorksitePreparation.IsSewerIsolationMethodSealedOrCovered;
            history.SewerIsolationMethodPlugged = permit.JobWorksitePreparation.IsSewerIsolationMethodPlugged;
            history.SewerIsolationMethodBlindedOrBlanked =
                permit.JobWorksitePreparation.IsSewerIsolationMethodBlindedOrBlanked;
            history.SewerIsolationMethodOtherDescription =
                permit.JobWorksitePreparation.SewerIsolationMethodOtherDescription;
            history.AreaPreparationNotApplicable = permit.JobWorksitePreparation.IsAreaPreparationNotApplicable;
            history.AreaPreparationBarricade = permit.JobWorksitePreparation.IsAreaPreparationBarricade;
            history.AreaPreparationNonEssentialEvac = permit.JobWorksitePreparation.IsAreaPreparationNonEssentialEvac;
            history.AreaPreparationPreopBoundaryRopeTape =
                permit.JobWorksitePreparation.IsAreaPreparationBoundaryRopeTape;
            history.AreaPreparationRadiationRope = permit.JobWorksitePreparation.IsAreaPreparationRadiationRope;
            history.AreaPreparationOtherDescription = permit.JobWorksitePreparation.AreaPreparationOtherDescription;
            history.LightingElectricalRequirementNotApplicable =
                permit.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable;
            history.LightingElectricalRequirementLowVoltage12V =
                permit.JobWorksitePreparation.IsLightingElectricalRequirementLowVoltage12V;
            history.LightingElectricalRequirement110VWithGFCI =
                permit.JobWorksitePreparation.IsLightingElectricalRequirement110VWithGFCI;
            history.LightingElectricalRequirementGeneratorLights =
                permit.JobWorksitePreparation.IsLightingElectricalRequirementGeneratorLights;
            history.LightingElectricalRequirementOtherDescription =
                permit.JobWorksitePreparation.LightingElectricalRequirementOtherDescription;
            history.PermitReceiverRequiresOrientationComments =
                permit.JobWorksitePreparation.PermitReceiverRequiresOrientationComments;
            history.SurroundingConditionsAffectAreaComments =
                permit.JobWorksitePreparation.SurroundingConditionsAffectAreaComments;
            history.CriticalConditionsComments = permit.JobWorksitePreparation.CriticalConditionsComments;
            history.WeldingGroundWireNotWithinGasTestAreaComments =
                permit.JobWorksitePreparation.WeldingGroundWireNotWithinGasTestAreaComments;
            history.BondingGroundingNotRequiredComments =
                permit.JobWorksitePreparation.BondingGroundingNotRequiredComments;
            history.FlowRequiredComments = permit.JobWorksitePreparation.FlowRequiredComments;
        }

        private void AssignEquipmentPreparationConditionFields(WorkPermitHistory history)
        {
            history.IsElectricalIsolationMethodNotApplicable =
                permit.EquipmentPreparationCondition.IsElectricalIsolationMethodNotApplicable;
            history.IsElectricalIsolationMethodLOTO =
                permit.EquipmentPreparationCondition.IsElectricalIsolationMethodLOTO;
            history.IsElectricalIsolationMethodWiring =
                permit.EquipmentPreparationCondition.IsElectricalIsolationMethodWiring;
            history.IsTestBumpNotApplicable = permit.EquipmentPreparationCondition.IsTestBumpNotApplicable;
            history.IsTestBump = permit.EquipmentPreparationCondition.IsTestBump;
            history.IsStillContainsResidualNotApplicable =
                permit.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable;
            history.IsStillContainsResidual = permit.EquipmentPreparationCondition.IsStillContainsResidual;
            history.IsLeakingValvesNotApplicable = permit.EquipmentPreparationCondition.IsLeakingValvesNotApplicable;
            history.IsLeakingValves = permit.EquipmentPreparationCondition.IsLeakingValves;
            history.IsOutOfService = permit.EquipmentPreparationCondition.IsOutOfService;
            history.IsConditionNotApplicable = permit.EquipmentPreparationCondition.IsConditionNotApplicable;
            history.IsConditionDepressured = permit.EquipmentPreparationCondition.IsConditionDepressured;
            history.IsConditionDrained = permit.EquipmentPreparationCondition.IsConditionDrained;
            history.IsConditionCleaned = permit.EquipmentPreparationCondition.IsConditionCleaned;
            history.IsConditionPurgedCheckbox = permit.EquipmentPreparationCondition.IsConditionPurgedCheckbox; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            history.IsConditionVentilated = permit.EquipmentPreparationCondition.IsConditionVentilated;
            history.IsConditionH20Washed = permit.EquipmentPreparationCondition.IsConditionH20Washed;
            history.IsConditionNeutralized = permit.EquipmentPreparationCondition.IsConditionNeutralized;
            history.IsConditionPurged = permit.EquipmentPreparationCondition.IsConditionPurged;
            history.ConditionPurgedDescription = permit.EquipmentPreparationCondition.ConditionPurgedDescription;
            history.IsConditionPurgedN2 = permit.EquipmentPreparationCondition.IsConditionPurgedN2;
            history.IsConditionPurgedSteamed = permit.EquipmentPreparationCondition.IsConditionPurgedSteamed;
            history.IsConditionPurgedAir = permit.EquipmentPreparationCondition.IsConditionPurgedAir;
            history.ConditionOtherDescription = permit.EquipmentPreparationCondition.ConditionOtherDescription;
            history.IsAsbestosGasketsNotApplicable = permit.EquipmentPreparationCondition.IsAsbestosGasketsNotApplicable;
            history.IsAsbestosGaskets = permit.EquipmentPreparationCondition.IsAsbestosGaskets;
            history.IsPreviousContentsNotApplicable =
                permit.EquipmentPreparationCondition.IsPreviousContentsNotApplicable;
            history.IsPreviousContentsHydrocarbon = permit.EquipmentPreparationCondition.IsPreviousContentsHydrocarbon;
            history.IsPreviousContentsAcid = permit.EquipmentPreparationCondition.IsPreviousContentsAcid;
            history.IsPreviousContentsCaustic = permit.EquipmentPreparationCondition.IsPreviousContentsCaustic;
            history.IsPreviousContentsH2S = permit.EquipmentPreparationCondition.IsPreviousContentsH2S;
            history.PreviousContentsOtherDescription =
                permit.EquipmentPreparationCondition.PreviousContentsOtherDescription;
            history.IsIsolationMethodNotApplicable = permit.EquipmentPreparationCondition.IsIsolationMethodNotApplicable;
            history.IsIsolationMethodBlindedorBlanked =
                permit.EquipmentPreparationCondition.IsIsolationMethodBlindedorBlanked;
            history.IsIsolationMethodSeparation = permit.EquipmentPreparationCondition.IsIsolationMethodSeparation;
            history.IsIsolationMethodMudderPlugs = permit.EquipmentPreparationCondition.IsIsolationMethodMudderPlugs;
            history.IsIsolationMethodBlockedIn = permit.EquipmentPreparationCondition.IsIsolationMethodBlockedIn;
            history.IsIsolationMethodCarBer = permit.EquipmentPreparationCondition.IsIsolationMethodCarBer;
            history.IsIsolationMethodLOTO = permit.EquipmentPreparationCondition.IsIsolationMethodLOTO;
            history.IsolationMethodOtherDescription =
                permit.EquipmentPreparationCondition.IsolationMethodOtherDescription;
            history.EquipmentInServiceComments = permit.EquipmentPreparationCondition.InServiceComments;

            history.EquipmentInAsbestosHazardPresentComments = permit.EquipmentPreparationCondition.InAsbestosHazardPresentComments; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            //history.EquipmentInHazardousEnergyIsolationComments = permit.EquipmentPreparationCondition.InHazardousEnergyIsolationComments; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            
            history.LeakingValvesComments = permit.EquipmentPreparationCondition.LeakingValvesComments;
            history.StillContainsResidualComments = permit.EquipmentPreparationCondition.StillContainsResidualComments;
            history.NoElectricalTestBumpComments = permit.EquipmentPreparationCondition.NoElectricalTestBumpComments;

            history.IsHazardousEnergyIsolationRequiredNotApplicable =
                permit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable;
            history.IsHazardousEnergyIsolationRequired =
                permit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired;
            history.EquipmentLockOutMethod = permit.EquipmentPreparationCondition.LockOutMethod;
            history.EquipmentLockOutMethodComments = permit.EquipmentPreparationCondition.LockOutMethodComments;
            history.EnergyIsolationPlanNumber = permit.EquipmentPreparationCondition.EnergyIsolationPlanNumber;
            history.ConditionsOfEIPSatisfied = permit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied;
            history.ConditionsOfEIPNotSatisfiedComments =
                permit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments;

            history.VentilationMethodNotApplicable =
                permit.EquipmentPreparationCondition.IsVentilationMethodNotApplicable;
            history.VentilationMethodNaturalDraft = permit.EquipmentPreparationCondition.IsVentilationMethodNaturalDraft;
            history.VentilationMethodLocalExhaust = permit.EquipmentPreparationCondition.IsVentilationMethodLocalExhaust;
            history.VentilationMethodForced = permit.EquipmentPreparationCondition.IsVentilationMethodForced;
        }

        private void AssignAsbestosFields(WorkPermitHistory history)
        {
            history.AsbestosHazardsConsideredNotApplicable = permit.Asbestos.HazardsConsideredNotApplicable;
            history.AsbestosHazardsConsidered = permit.Asbestos.HazardsConsidered;
        }

        private void AssignRootLevelFields(WorkPermitHistory history)
        {
            history.Id = permit.Id;
            history.LastModifiedBy = permit.LastModifiedBy;
            history.ApprovedBy = permit.ApprovedBy;
            history.LastModifiedDate = permit.LastModifiedDate;

            if (permit.DocumentLinks != null)
            {
                history.DocumentLinks = permit.DocumentLinks.AsString(link => link.TitleWithUrl);
            }

            history.PermitNumber = permit.PermitNumber;
            history.PermitValidDateTime = permit.PermitValidDateTime;

            history.WorkPermitType = permit.WorkPermitType;
            history.WorkPermitClassification = permit.WorkPermitTypeClassification;
            history.WorkPermitStatus = permit.WorkPermitStatus;

            history.SpecialPrecautionsOrConsiderations = permit.SpecialPrecautionsOrConsiderations;
            history.IsCoauthorizationRequired = permit.IsCoauthorizationRequired;
            history.IsControlRoomContacted = permit.IsControlRoomContacted;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            history.Revalidation = permit.Revalidation;//Added by ppanigrahi
           
            history.CoauthorizationDescription = permit.CoauthorizationDescription;
            history.Source = permit.Source;
        }

        private void AssignTools(WorkPermitHistory history)
        {
            history.IsAirTools = permit.Tools.IsAirTools;
            history.IsCraneOrCarrydeck = permit.Tools.IsCraneOrCarrydeck;
            history.IsHandTools = permit.Tools.IsHandTools;
            history.IsJackhammer = permit.Tools.IsJackhammer;
            history.IsVacuumTruck = permit.Tools.IsVacuumTruck;
            history.IsCementSaw = permit.Tools.IsCementSaw;
            history.IsElectricTools = permit.Tools.IsElectricTools;
            history.IsHeavyEquipment = permit.Tools.IsHeavyEquipment;
            history.IsLanda = permit.Tools.IsLanda;
            history.IsScaffolding = permit.Tools.IsScaffolding;
            history.IsVehicle = permit.Tools.IsVehicle;
            history.IsCompressor = permit.Tools.IsCompressor;
            history.IsForklift = permit.Tools.IsForklift;
            history.IsHepaVacuum = permit.Tools.IsHEPAVacuum;
            history.IsManlift = permit.Tools.IsManlift;
            history.IsTamper = permit.Tools.IsTamper;
            history.IsHotTapMachine = permit.Tools.IsHotTapMachine;
            history.IsPortLighting = permit.Tools.IsPortLighting;
            history.IsTorch = permit.Tools.IsTorch;
            history.IsWelder = permit.Tools.IsWelder;
            history.IsChemicals = permit.Tools.IsChemicals;
            history.OtherToolsDescription = permit.Tools.OtherToolsDescription;
        }

        private void AssignSpecifics(WorkPermitHistory history)
        {
            history.FunctionalLocation = permit.Specifics.FunctionalLocation;
            history.WorkAssignment = permit.WorkAssignment;
            history.WorkOrderNumber = permit.Specifics.WorkOrderNumber;
            history.StartDateTime = permit.Specifics.StartDateTime;
            history.StartTimeNotApplicable = permit.Specifics.StartTimeNotApplicable;
            history.EndDateTime = permit.Specifics.EndDateTime;
            history.StartAndOrEndTimesFinalized = permit.Specifics.StartAndOrEndTimesFinalized;
            history.WorkOrderDescription = permit.Specifics.WorkOrderDescription;
            history.JobStepsDescription = permit.Specifics.JobStepDescription;
            history.ContactName = permit.Specifics.ContactName;
            history.ContractorCompanyName = permit.Specifics.ContractorCompanyName;

            if (permit.Specifics.CraftOrTrade == null)
            {
                history.CraftOrTradeId = null;
                history.CraftOrTradeOther = null;
            }
            else
            {
                permit.Specifics.CraftOrTrade.PerformAction(() =>
                {
                    var craftOrTrade =
                        (CraftOrTrade) permit.Specifics.CraftOrTrade;
                    history.CraftOrTradeId = craftOrTrade.Id;
                    history.CraftOrTradeOther = null;
                },
                    () =>
                    {
                        history.CraftOrTradeId = null;
                        history.CraftOrTradeOther =
                            permit.Specifics.CraftOrTrade.Name;
                    });
            }

            history.RadioChannel = permit.Specifics.Communication.RadioChannel;
            history.RadioColor = permit.Specifics.Communication.RadioColor;
            history.CommunicationDescription = permit.Specifics.Communication.Description;
            history.IsWorkPermitCommunicationNotApplicable =
                permit.Specifics.Communication.IsWorkPermitCommunicationNotApplicable;
            history.ByRadio = permit.Specifics.Communication.ByRadio;
        }

        private void AssignAdditionalItemsRequired(WorkPermitHistory history)
        {
            history.IsAdditionalCSEAssessmentOrAuthorization =
                permit.AdditionItemsRequired.IsCSEAssessmentOrAuthorization;
            history.AdditionalCSEAssessmentOrAuthorizationDescription =
                permit.AdditionItemsRequired.CSEAssessmentOrAuthorizationDescription;
            history.IsAdditionalFlareEntry = permit.AdditionItemsRequired.IsFlareEntry;
            history.IsAdditionalCriticalLift = permit.AdditionItemsRequired.IsCriticalLift;
            history.AdditionalCriticalLiftDescription = permit.AdditionItemsRequired.CriticalLiftDescription;
            history.IsAdditionalExcavation = permit.AdditionItemsRequired.IsExcavation;
            history.AdditionalExcavationDescription = permit.AdditionItemsRequired.ExcavationDescription;
            history.IsAdditionalHotTap = permit.AdditionItemsRequired.IsHotTap;
            history.IsAdditionalSpecialWasteDisposal = permit.AdditionItemsRequired.IsSpecialWasteDisposal;
            history.IsAdditionalBlankOrBlindLists = permit.AdditionItemsRequired.IsBlankOrBlindLists;
            history.IsAdditionalPJSROrSafetyPause = permit.AdditionItemsRequired.IsPJSROrSafetyPause;
            history.IsAdditionalAsbestosHandling = permit.AdditionItemsRequired.IsAsbestosHandling;
            history.AdditionalAsbestosHandlingDescription = permit.AdditionItemsRequired.AsbestosHandlingDescription;
            history.IsAdditionalRoadClosure = permit.AdditionItemsRequired.IsRoadClosure;
            history.IsAdditionalElectrical = permit.AdditionItemsRequired.IsElectrical;
            history.AdditionalElectricalDescription = permit.AdditionItemsRequired.ElectricalDescription;
            history.IsAdditionalBurnOrOpenFlameAssessment = permit.AdditionItemsRequired.IsBurnOrOpenFlameAssessment;
            history.AdditionalBurnOrOpenFlameAssessmentDescription =
                permit.AdditionItemsRequired.BurnOrOpenFlameAssessmentDescription;
            history.IsAdditionalWaiverOrDeviation = permit.AdditionItemsRequired.IsWaiverOrDeviation;
            history.AdditionalWaiverOrDeviationDescription = permit.AdditionItemsRequired.WaiverOrDeviationDescription;
            history.IsAdditionalMSDS = permit.AdditionItemsRequired.IsMSDS;
            history.IsAdditionalRadiationApproval = permit.AdditionItemsRequired.IsRadiationApproval;
            history.IsAdditionalOnlineLeakRepairForm = permit.AdditionItemsRequired.IsOnlineLeakRepairForm;
            history.IsAdditionalEnergizedElectricalForm = permit.AdditionItemsRequired.IsEnergizedElectricalForm;
            history.AdditionalOtherItemDescription = permit.AdditionItemsRequired.OtherItemDescription;

//Added By Vibhor : RITM0627539 - Denver Site upgrades

            history.PreExcavationAuthorization = permit.AdditionItemsRequired.PreExcavationAuthorization;
            history.SuspendedWorkPlatform = permit.AdditionItemsRequired.SuspendedWorkPlatform;
            history.HotTurnoverApproval = permit.AdditionItemsRequired.HotTurnoverApproval;
            history.ConfinedSpaceEntryAuthorizationForm = permit.AdditionItemsRequired.ConfinedSpaceEntryAuthorizationForm;
            history.PreExcavationAuthorizationForm = permit.AdditionItemsRequired.PreExcavationAuthorizationForm;
            history.SupplementalJobSiteSignInForm = permit.AdditionItemsRequired.SupplementalJobSiteSignInForm;
            history.SystemEntryGasTestLogFrom = permit.AdditionItemsRequired.SystemEntryGasTestLogFrom;
            history.HeatStressMonitoringForm = permit.AdditionItemsRequired.HeatStressMonitoringForm;
            history.CriticalLiftApprovalForm = permit.AdditionItemsRequired.CriticalLiftApprovalForm;
            history.PjsrSecondSection = permit.AdditionItemsRequired.PjsrSecondSection;
            history.DeviationRequestForm = permit.AdditionItemsRequired.DeviationRequestForm;
            history.RoadClosureform = permit.AdditionItemsRequired.RoadClosureform;
            history.ConfinedSpaceEntryTrackingLog = permit.AdditionItemsRequired.ConfinedSpaceEntryTrackingLog;
            
            history.FlareLineChecklists = permit.AdditionItemsRequired.FlareLineChecklists;
            history.HotTurnoverApprovalForm = permit.AdditionItemsRequired.HotTurnoverApprovalForm;
            history.IndustrialHygieneAreaRealTimeSamplingForm = permit.AdditionItemsRequired.IndustrialHygieneAreaRealTimeSamplingForm;
            history.CraneSuspendedWorkPlatformChecklist = permit.AdditionItemsRequired.CraneSuspendedWorkPlatformChecklist;
            history.ConfinedSpaceEntryAuthorizationFormSecondSection
                = permit.AdditionItemsRequired.ConfinedSpaceEntryAuthorizationFormSecondSection;

            history.NASecondSection = permit.AdditionItemsRequired.NASecondSection;
        }

        private void AssignAttributes(WorkPermitHistory history)
        {
            history.IsConfinedSpaceEntry = permit.Attributes.IsConfinedSpaceEntry;
            history.IsInertConfinedSpaceEntry = permit.Attributes.IsInertConfinedSpaceEntry;
            history.IsLeadAbatement = permit.Attributes.IsLeadAbatement;
            history.IsBreathingAirOrSCBA = permit.Attributes.IsBreathingAirOrSCBA;
            history.IsElectricalWork = permit.Attributes.IsElectricalWork;
            history.IsVehicleEntry = permit.Attributes.IsVehicleEntry;
            history.IsHotTap = permit.Attributes.IsHotTap;
            history.IsBurnOrOpenFlame = permit.Attributes.IsBurnOrOpenFlame;
            history.IsSystemEntry = permit.Attributes.IsSystemEntry;
            history.IsCriticalLift = permit.Attributes.IsCriticalLift;
            history.IsExcavation = permit.Attributes.IsExcavation;
            history.IsAsbestos = permit.Attributes.IsAsbestos;
            history.IsRadiationRadiography = permit.Attributes.IsRadiationRadiography;
            history.IsFreshAir = permit.Attributes.IsFreshAir;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            history.IsRadiationSealed = permit.Attributes.IsRadiationSealed;
        }
    }
}