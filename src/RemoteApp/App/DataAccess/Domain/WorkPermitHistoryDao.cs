using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitHistoryDao : AbstractManagedDao, IWorkPermitHistoryDao
    {
        private const string QUERY_WORKPERMITHISTORIES_BYID = "QueryWorkPermitHistoriesById";
        private const string INSERT = "InsertWorkPermitHistory";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly IUserDao userDao;

        public WorkPermitHistoryDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<WorkPermitHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<WorkPermitHistory>(PopulateInstance , QUERY_WORKPERMITHISTORIES_BYID);
        }

        public void Insert(WorkPermitHistory workPermitHistory)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT;
            command.CommandType = CommandType.StoredProcedure;
            AddInsertParameters(workPermitHistory, command);
            command.ExecuteNonQuery();
        }
        
        private static ReflectionMapper CreateWorkPermitMapper()
        {
            return new ReflectionMapper()
                .Ignore("WorkPermitStatus", "WorkPermitStatusId")
                .Ignore("FunctionalLocation", "FunctionalLocationId")
                .Ignore("WorkAssignment", "WorkAssignmentId")
                .Ignore("WorkPermitType", "WorkPermitTypeId")
                .Ignore("WorkPermitClassification", "WorkPermitTypeClassificationId")
                .Ignore("Source", "SourceId")
                .Ignore("ProtectiveClothingTypeAcidClothingType", "SpecialProtectiveClothingTypeAcidClothingTypeID")
                .Ignore("LastModifiedBy", "LastModifiedUserId")
                .Ignore("ApprovedBy", "ApprovedByUserId")
                .Ignore("RespiratoryCartridgeType", "RespitoryProtectionRequirementsRespiratoryCartridgeTypeId")
                .IgnoreDatabaseField("PermitElectricalSwitching")
                .IgnoreDatabaseField("PermitEnergizedElectrical")
                .Map("SpecialPrecautionsOrConsiderations", "SpecialPrecautionsOrConsiderationsDescription")
                .Map("IsConfinedSpaceEntry", "PermitConfinedSpaceEntry")
                .Map("IsBreathingAirOrSCBA", "PermitBreathingAirOrSCBA")
                .Map("IsVehicleEntry", "PermitVehicleEntry")
                .Map("IsHotTap", "PermitHotTap")
                .Map("IsBurnOrOpenFlame", "PermitBurnOrOpenFlame")
                .Map("IsSystemEntry", "PermitSystemEntry")
                .Map("IsCriticalLift", "PermitCriticalLift")
                .Map("IsElectricalWork", "PermitElectricalWork")
                .Map("IsExcavation", "PermitExcavation")
                .Map("IsAsbestos", "PermitAsbestos")
                .Map("IsRadiationRadiography", "PermitRadiationRadiography")
                .Map("IsFreshAir", "PermitFreshAir")// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                .Map("Revalidation","Revalidation") //Added by ppanigrahi 
                .Map("IsRadiationSealed", "PermitRadiationSealed")
                .Map("IsAdditionalCSEAssessmentOrAuthorization", "AdditionalCSEAssessmentOrAuthorization")
                .Map("AdditionalCSEAssessmentOrAuthorizationDescription", "AdditionalCSEAssessmentOrAuthorizationDescription")
                .Map("IsAdditionalFlareEntry", "AdditionalFlareEntry")
                .Map("IsAdditionalCriticalLift", "AdditionalCriticalLift")
                .Map("AdditionalCriticalLiftDescription", "AdditionalCriticalLiftDescription")
                .Map("IsAdditionalExcavation", "AdditionalExcavation")
                .Map("AdditionalExcavationAdditional", "AdditionalExcavationAdditional")
                .Map("IsAdditionalHotTap", "AdditionalHotTap")
                .Map("IsAdditionalSpecialWasteDisposal", "AdditionalSpecialWasteDisposal")
                .Map("IsAdditionalBlankOrBlindLists", "AdditionalBlankOrBlindLists")
                .Map("IsAdditionalPJSROrSafetyPause", "AdditionalPJSROrSafetyPause")
                .Map("IsAdditionalAsbestosHandling", "AdditionalAsbestosHandling")
                .Map("AdditionalAsbestosHandlingDescription", "AdditionalAsbestosHandlingDescription")
                .Map("IsAdditionalRoadClosure", "AdditionalRoadClosure")
                .Map("IsAdditionalElectrical", "AdditionalElectrical")
                .Map("AdditionalElectricalDescription", "AdditionalElectricalDescription")
                .Map("IsAdditionalBurnOrOpenFlameAssessment", "AdditionalBurnOrOpenFlameAssessment")
                .Map("AdditionalBurnOrOpenFlameAssessmentDescription", "AdditionalBurnOrOpenFlameAssessmentDescription")
                .Map("IsAdditionalWaiverOrDeviation", "AdditionalWaiverOrDeviation")
                .Map("AdditionalWaiverOrDeviationDescription", "AdditionalWaiverOrDeviationDescription")
                .Map("IsAdditionalMSDS", "AdditionalMSDS")
                .Map("IsAdditionalRadiationApproval", "AdditionalRadiationApproval")
                .Map("IsAdditionalOnlineLeakRepairForm", "AdditionalOnlineLeakRepairForm")
                .Map("IsAdditionalEnergizedElectricalForm", "AdditionalIsEnergizedElectricalForm")
                .Map("IsAdditionalNotApplicable", "AdditionalIsNotApplicable")
                .Map("AdditionalOtherItemDescription", "AdditionalOtherFormsOrAssessmentsOrAuthorizations")
                .Map("ContactName", "ContactPersonnel")
                .Map("CraftOrTradeId", "CraftOrTradeID")
                .Map("JobStepsDescription", "JobStepDescription")
                .Map("ByRadio", "CommunicationByRadio")
                .Map("RadioChannel", "CommunicationRadioChannelOrBand")
                .Map("RadioColor", "CommunicationRadioColor")
                .Map("CommunicationDescription", "CommunicationByOtherDescription")
                .Map("IsCoauthorizationRequired", "CoAuthorizationRequired")

                .Map("IsControlRoomContacted", "ControlRoomContacted")  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                //.Map("Revalidation","Revalidation")
                .Map("CoauthorizationDescription", "CoAuthorizationDescription")
                .Map("IsAirTools", "ToolsAirTools")
                .Map("IsCraneOrCarrydeck", "ToolsCraneOrCarrydeck")
                .Map("IsHandTools", "ToolsHandTools")
                .Map("IsJackhammer", "ToolsJackhammer")
                .Map("IsVacuumTruck", "ToolsVacuumTruck")
                .Map("IsCementSaw", "ToolsCementSaw")
                .Map("IsElectricTools", "ToolsElectricTools")
                .Map("IsHeavyEquipment", "ToolsHeavyEquipment")
                .Map("IsLanda", "ToolsLanda")
                .Map("IsScaffolding", "ToolsScaffolding")
                .Map("IsVehicle", "ToolsVehicle")
                .Map("IsCompressor", "ToolsCompressor")
                .Map("IsForklift", "ToolsForklift")
                .Map("IsHepaVacuum", "ToolsHEPAVacuum")
                .Map("IsManlift", "ToolsManlift")
                .Map("IsTamper", "ToolsTamper")
                .Map("IsHotTapMachine", "ToolsHotTapMachine")
                .Map("IsPortLighting", "ToolsPortLighting")
                .Map("IsTorch", "ToolsTorch")
                .Map("IsWelder", "ToolsWelder")
                .Map("IsChemicals", "ToolsChemicals")
                .Map("OtherToolsDescription", "ToolsOtherToolsDescription")
                .Map("IsElectricalIsolationMethodNotApplicable", "ElectricIsolationMethodNotApplicable")
                .Map("IsElectricalIsolationMethodLOTO", "ElectricIsolationMethodLOTO")
                .Map("IsElectricalIsolationMethodWiring", "ElectricIsolationMethodWiring")
                .Map("IsTestBumpNotApplicable", "ElectricTestBumpNotApplicable")
                .Map("IsTestBump", "ElectricTestBump")
                .Map("NoElectricalTestBumpComments", "EquipmentNoElectricalTestBumpComments")
                .Map("IsStillContainsResidualNotApplicable", "EquipmentStillContainsResidualNotApplicable")
                .Map("IsStillContainsResidual", "EquipmentStillContainsResidual")
                .Map("StillContainsResidualComments", "EquipmentStillContainsResidualComments")
                .Map("IsLeakingValvesNotApplicable", "EquipmentLeakingValvesNotApplicable")
                .Map("IsLeakingValves", "EquipmentLeakingValves")
                .Map("LeakingValvesComments", "EquipmentLeakingValvesComments")
                .Map("IsOutOfService", "EquipmentIsOutOfService")
                .Map("EquipmentInServiceComments", "EquipmentInServiceComments")
                .Map("EquipmentInAsbestosHazardPresentComments", "EquipmentInAsbestosHazardPresentComments") // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                //.Map("EquipmentInHazardousEnergyIsolationComments", "EquipmentInHazardousEnergyIsolationComments") // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
               
                .Map("IsConditionNotApplicable", "EquipmentConditionNotApplicable")
                .Map("IsConditionDepressured", "EquipmentConditionDepressured")
                .Map("IsConditionDrained", "EquipmentConditionDrained")
                .Map("IsConditionCleaned", "EquipmentConditionCleaned")
                .Map("IsConditionPurgedCheckbox", "EquipmentConditionPurgedChecked") // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                .Map("IsConditionVentilated", "EquipmentConditionVentilated")
                .Map("IsConditionH20Washed", "EquipmentConditionH20Washed")
                .Map("IsConditionNeutralized", "EquipmentConditionNeutralized")
                .Map("IsConditionPurged", "EquipmentConditionPurged")
                .Map("ConditionPurgedDescription", "EquipmentConditionPurgedDescription")
                .Map("IsConditionPurgedN2", "EquipmentConditionPurgedN2")
                .Map("IsConditionPurgedSteamed", "EquipmentConditionPurgedSteamed")
                .Map("IsConditionPurgedAir", "EquipmentConditionPurgedAir")
                .Map("ConditionOtherDescription", "EquipmentConditionOtherDescription")
                .Map("IsPreviousContentsNotApplicable", "EquipmentPreviousContentsNotApplicable")
                .Map("IsPreviousContentsHydrocarbon", "EquipmentPreviousContentsHydrocarbon")
                .Map("IsPreviousContentsAcid", "EquipmentPreviousContentsAcid")
                .Map("IsPreviousContentsCaustic", "EquipmentPreviousContentsCaustic")
                .Map("IsPreviousContentsH2S", "EquipmentPreviousContentsH2S")
                .Map("PreviousContentsOtherDescription", "EquipmentPreviousContentsOtherDescription")
                .Map("IsAsbestosGasketsNotApplicable", "EquipmentAsbestosGasketsNotApplicable")
                .Map("IsAsbestosGaskets", "EquipmentAsbestosGaskets")
                .Map("IsIsolationMethodNotApplicable", "EquipmentIsolationMethodNotApplicable")
                .Map("IsIsolationMethodBlindedorBlanked", "EquipmentIsolationMethodBlindedorBlanked")
                .Map("IsIsolationMethodBlockedIn", "EquipmentIsolationMethodBlockedIn")
                .Map("IsIsolationMethodCarBer", "EquipmentIsolationMethodCarBer")
                .Map("IsIsolationMethodSeparation", "EquipmentIsolationMethodSeparation")
                .Map("IsIsolationMethodMudderPlugs", "EquipmentIsolationMethodMudderPlugs")
                .Map("IsIsolationMethodLOTO", "EquipmentIsolationMethodLOTO")
                .Map("IsolationMethodOtherDescription", "EquipmentIsolationMethodOtherDescription")
                .Map("FlowRequiredForJob", "JobSitePreparationFlowRequiredForJob")
                .Map("FlowRequiredForJobNotApplicable", "JobSitePreparationFlowRequiredForJobNotApplicable")
                .Map("FlowRequiredComments", "JobSitePreparationFlowRequiredComments")
                .Map("BondingOrGroundingRequiredNotApplicable",
                     "JobSitePreparationBondingOrGroundingRequiredNotApplicable")
                .Map("BondingOrGroundingRequired", "JobSitePreparationBondingOrGroundingRequired")
                .Map("BondingGroundingNotRequiredComments", "JobSitePreparationBondingGroundingNotRequiredComments")
                .Map("WeldingGroundWireInTestAreaNotApplicable",
                     "JobSitePreparationWeldingGroundWireInTestAreaNotApplicable")
                .Map("WeldingGroundWireInTestArea", "JobSitePreparationWeldingGroundWireInTestArea")
                .Map("WeldingGroundWireNotWithinGasTestAreaComments",
                     "JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments")
                .Map("CriticalConditionRemainJobSiteNotApplicable",
                     "JobSitePreparationCriticalConditionRemainJobSiteNotApplicable")

                     .Map("IsControlRoomContactedNotApplicable",        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                     "ControlRoomContactedNotApplicable")

                      .Map("IsControlRoomContactedOrNot",        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
                     "IsControlRoomContactedOrNot")


                     
                .Map("CriticalConditionRemainJobSite", "JobSitePreparationCriticalConditionRemainJobSite")
                .Map("CriticalConditionsComments", "JobSitePreparationCriticalConditionsComments")
                .Map("SurroundingConditionsAffectOrContaminatedNotApplicable",
                     "JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable")
                .Map("SurroundingConditionsAffectOrContaminated",
                     "JobSitePreparationSurroundingConditionsAffectOrContaminated")
                .Map("SurroundingConditionsAffectAreaComments",
                     "JobSitePreparationSurroundingConditionsAffectAreaComments")
                .Map("VestedBuddySystemInEffectNotApplicable",
                     "JobSitePreparationVestedBuddySystemInEffectNotApplicable")
                .Map("VestedBuddySystemInEffect", "JobSitePreparationVestedBuddySystemInEffect")
                .Map("PermitReceiverFieldOrEquipmentOrientationNotApplicable",
                     "JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable")
                .Map("PermitReceiverFieldOrEquipmentOrientation",
                     "JobSitePreparationPermitReceiverFieldOrEquipmentOrientation")
                .Map("PermitReceiverRequiresOrientationComments",
                     "JobSitePreparationPermitReceiverRequiresOrientationComments")
                .Map("SewerIsolationMethodNotApplicable", "JobSitePreparationSewerIsolationMethodNotApplicable")
                .Map("SewerIsolationMethodSealedOrCovered", "JobSitePreparationSewerIsolationMethodSealedOrCovered")
                .Map("SewerIsolationMethodPlugged", "JobSitePreparationSewerIsolationMethodPlugged")
                .Map("SewerIsolationMethodBlindedOrBlanked", "JobSitePreparationSewerIsolationMethodBlindedOrBlanked")
                .Map("SewerIsolationMethodOtherDescription", "JobSitePreparationSewerIsolationMethodOtherDescription")
                .Map("VentilationMethodNotApplicable", "JobSitePreparationVentilationMethodNotApplicable")
                .Map("VentilationMethodNaturalDraft", "JobSitePreparationVentilationMethodNaturalDraft")
                .Map("VentilationMethodLocalExhaust", "JobSitePreparationVentilationMethodLocalExhaust")
                .Map("VentilationMethodForced", "JobSitePreparationVentilationMethodForced")
                .Map("AreaPreparationNotApplicable", "JobSitePreparationAreaPreparationNotApplicable")
                .Map("AreaPreparationBarricade", "JobSitePreparationAreaPreparationBarricade")
                .Map("AreaPreparationNonEssentialEvac", "JobSitePreparationAreaPreparationNonEssentialEvac")
                .Map("AreaPreparationContainBurnOFWSource", "JobSitePreparationAreaPreparationContainBurnOFWSource")
                .Map("AreaPreparationPreopBoundaryRopeTape", "JobSitePreparationAreaPreparationPreopBoundaryRopeTape")
                .Map("AreaPreparationRadiationRope", "JobSitePreparationAreaPreparationRadiationRope")
                .Map("AreaPreparationOtherDescription", "JobSitePreparationAreaPreparationOtherDescription")
                .Map("LightingElectricalRequirementNotApplicable",
                     "JobSitePreparationLightingElectricalRequirementNotApplicable")
                .Map("LightingElectricalRequirementLowVoltage12V",
                     "JobSitePreparationLightingElectricalRequirementLowVoltage12V")
                .Map("LightingElectricalRequirement110VWithGFCI",
                     "JobSitePreparationLightingElectricalRequirement110VWithGFCI")
                .Map("LightingElectricalRequirementGeneratorLights",
                     "JobSitePreparationLightingElectricalRequirementGeneratorLights")
                .Map("LightingElectricalRequirementOtherDescription",
                     "JobSitePreparationLightingElectricalRequirementOtherDescription")
                .Map("SealedSourceIsolationNotApplicable", "RadiationSealedSourceIsolationNotApplicable")
                .Map("SealedSourceIsolationLOTO", "RadiationSealedSourceIsolationLOTO")
                .Map("SealedSourceIsolationOpen", "RadiationSealedSourceIsolationOpen")
                .Map("SealedSourceIsolationNumberOfSources", "RadiationSealedSourceIsolationNumberOfSources")
                .Map("GasTestFrequencyOrDuration", "GasTestFrequencyOrDuration")
                .Map("GasTestConstantMonitoringRequired", "GasTestConstantMonitoringRequired")
                .Map("GasTestForkliftNotUsed", "GasTestForkliftNotUsed")

                .Map("FireConfinedSpaceNotApplicable", "FireConfinedSpaceNotApplicable")
                .Map("TwentyABCorDryChemicalExtinguisher", "FireConfinedSpace20ABCorDryChemicalExtinguisher")
                .Map("C02Extinguisher", "FireConfinedSpaceC02Extinguisher")
                .Map("FireResistantTarp", "FireConfinedSpaceFireResistantTarp")
                .Map("SparkContainment", "FireConfinedSpaceSparkContainment")
                .Map("WaterHose", "FireConfinedSpaceWaterHose")
                .Map("SteamHose", "FireConfinedSpaceSteamHose")
                .Map("Watchmen", "FireConfinedSpaceWatchmen")
                .Map("HoleWatchNumber", "FireConfinedSpaceHoleWatchNumber")
                .Map("FireWatchNumber", "FireConfinedSpaceFireWatchNumber")
                .Map("SpotterNumber", "FireConfinedSpaceSpotterNumber")
                .Map("FireConfinedSpaceRequirementsOtherRequirementsDescription", "FireConfinedSpaceOtherDescription")

                .Map("AirCartorAirLine", "RespitoryProtectionRequirementsAirCartOrAirLine")
                .Map("SCBA", "RespitoryProtectionRequirementsSCBA")
                .Map("HalfFaceRespirator", "RespitoryProtectionRequirementsHalfFaceRespirator")
                .Map("FullFaceRespirator", "RespitoryProtectionRequirementsFullFaceRespirator")
                .Map("DustMask", "RespitoryProtectionRequirementsDustMask")
                .Map("AirHood", "RespitoryProtectionRequirementsAirHood")
                .Map("RespiratoryProtectionNotApplicable", "RespitoryProtectionRequirementsNotApplicable")
                .Map("RespiratoryProtectionRequirementsOtherDescription",
                     "RespitoryProtectionRequirementsOtherDescription")
                .Map("RespiratoryCartridgeTypeDescription", "RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription")
                .Map("EyeOrFaceProtectionNotApplicable", "SpecialEyeOrFaceProtectionNotApplicable")
                .Map("EyeOrFaceProtectionGoggles", "SpecialEyeOrFaceProtectionGoggles")
                .Map("EyeOrFaceProtectionFaceshield", "SpecialEyeOrFaceProtectionFaceshield")
                .Map("EyeOrFaceProtectionOtherDescription", "SpecialEyeOrFaceProtectionOtherDescription")

                .Map("ProtectiveClothingTypeNotApplicable", "SpecialProtectiveClothingTypeNotApplicable")
                .Map("ProtectiveClothingTypeRainCoat", "SpecialProtectiveClothingTypeRainCoat")
                .Map("ProtectiveClothingTypeRainPants", "SpecialProtectiveClothingTypeRainPants")
                .Map("ProtectiveClothingTypeAcidClothing", "SpecialProtectiveClothingTypeAcidClothing")
                .Map("ProtectiveClothingTypeCausticWear", "SpecialProtectiveClothingTypeCausticWear")
                .Map("ProtectiveClothingTypePaperCoveralls", "SpecialProtectiveClothingTypePaperCoveralls")
                .Map("ProtectiveClothingTypeTyvekSuit", "SpecialProtectiveClothingTypeTyvekSuit")
                .Map("ProtectiveClothingTypeKapplerSuit", "SpecialProtectiveClothingTypeKapplerSuit")
                .Map("ProtectiveClothingTypeElectricalFlashGear", "SpecialProtectiveClothingTypeElectricalFlashGear")
                .Map("ProtectiveClothingTypeCorrosiveClothing", "SpecialProtectiveClothingTypeCorrosiveClothing")
                .Map("ProtectiveClothingTypeOtherDescripton", "SpecialProtectiveClothingTypeOtherDescripton")

                .Map("ProtectiveFootwearNotApplicable", "SpecialProtectiveFootwearNotApplicable")
                .Map("ProtectiveFootwearChemicalImperviousBoots", "SpecialProtectiveFootwearChemicalImperviousBoots")
                .Map("ProtectiveFootwearToeGuard", "SpecialProtectiveFootwearToeGuard")
                .Map("ProtectiveFootwearMetatarsalGuard", "SpecialProtectiveFootwearMetatarsalGuard")

                .Map("ProtectiveFootwearOtherDescription", "SpecialProtectiveFootwearOtherDescription")

                .Map("HandProtectionNotApplicable", "SpecialHandProtectionNotApplicable")
                .Map("HandProtectionChemicalNeprene", "SpecialHandProtectionChemicalNeprene")
                .Map("HandProtectionNaturalRubber", "SpecialHandProtectionNaturalRubber")
                .Map("HandProtectionNitrile", "SpecialHandProtectionNitrile")
                .Map("HandProtectionPVC", "SpecialHandProtectionPVC")
                .Map("HandProtectionHighVoltage", "SpecialHandProtectionHighVoltage")
                .Map("HandProtectionWelding", "SpecialHandProtectionWelding")
                .Map("HandProtectionLeather", "SpecialHandProtectionLeather")
                .Map("HandProtectionChemicalGloves", "SpecialHandProtectionChemicalGloves")
                .Map("HandProtectionOtherDescription", "SpecialHandProtectionOtherDescription")

                .Map("RescueOrFallNotApplicable", "SpecialRescueOrFallNotApplicable")
                .Map("RescueOrFallBodyHarness", "SpecialRescueOrFallBodyHarness")
                .Map("RescueOrFallLifeline", "SpecialRescueOrFallLifeline")
                .Map("RescueOrFallYoYo", "SpecialRescueOrFallYoYo")
                .Map("RescueOrFallRescueDevice", "SpecialRescueOrFallRescueDevice")
                .Map("RescueOrFallOtherDescription", "SpecialRescueOrFallOtherDescription")

                .Map("FallOtherDescription", "SpecialFallOtherDescription")
                .Map("FallRestraint", "SpecialFallRestraint")
                .Map("FallSelfRetractingDevice", "SpecialFallSelfRetractingDevice")
                .Map("FallTieoffRequired", "SpecialFallTieoffRequired")

                .Map("IsInertConfinedSpaceEntry", "PermitInertConfinedSpaceEntry")
                .Map("IsLeadAbatement", "PermitLeadAbatement")

                .Map("IsHazardousEnergyIsolationRequiredNotApplicable", "EquipmentIsHazardousEnergyIsolationRequiredNotApplicable")
                .Map("IsHazardousEnergyIsolationRequired", "EquipmentIsHazardousEnergyIsolationRequired")
                .Ignore("EquipmentLockOutMethod", "EquipmentLockOutMethodId")
                .Map("EquipmentLockOutMethodComments", "EquipmentLockOutMethodComments")
                .Map("EnergyIsolationPlanNumber", "EquipmentEnergyIsolationPlanNumber")
                .Map("ConditionsOfEIPSatisfied", "EquipmentConditionsOfEIPSatisfied")
                .Map("ConditionsOfEIPNotSatisfiedComments", "EquipmentConditionsOfEIPNotSatisfiedComments")

                .Map("AsbestosHazardsConsideredNotApplicable", "AsbestosHazardsConsideredNotApplicable")
                .Map("AsbestosHazardsConsidered", "AsbestosHazardsConsidered")

                ;                
        }

        private static void AddInsertParameters(WorkPermitHistory history, SqlCommand command)
        {
            CreateWorkPermitMapper().SetCommandParameters(history, command);

            command.AddParameter("@WorkPermitStatusId", history.WorkPermitStatus.Id);
            command.AddParameter("@FunctionalLocationId", history.FunctionalLocation.Id);            
            command.AddParameter("@WorkPermitTypeId", history.WorkPermitType.Id);

            if (history.WorkAssignment == null || WorkAssignment.NoneWorkAssignment.Equals(history.WorkAssignment))
            {
                command.AddParameter("@WorkAssignmentId", null);
            }
            else
            {
                command.AddParameter("@WorkAssignmentId", history.WorkAssignment.Id);
            }            

            // TODO: JOE/TROY - We should make this field nullable instead because it don't apply to Sarnia.
            //   Added this IF statement to default to SPECIFIC (For Sarnia) as a temporary fix so I can check in.
            //   Also see: WorkPermitHistoryDao for the same problem.
            if (history.WorkPermitClassification != null)
            {
                command.AddParameter("@WorkPermitTypeClassificationId", history.WorkPermitClassification.Id);
            }
            else
            {
                command.AddParameter("@WorkPermitTypeClassificationId", WorkPermitTypeClassification.SPECIFIC.Id);
            }
            
            command.AddParameter("@SourceId", history.Source.Id);
            command.AddParameter("@LastModifiedUserId", history.LastModifiedBy.Id);
            command.AddParameter("@ApprovedByUserId", history.ApprovedBy == null ? null : history.ApprovedBy.Id);
            command.AddParameter("@SpecialProtectiveClothingTypeAcidClothingTypeID",
                                history.ProtectiveClothingTypeAcidClothingType == null ? null : history.ProtectiveClothingTypeAcidClothingType.Id);
            command.AddParameter("@RespitoryProtectionRequirementsRespiratoryCartridgeTypeId",
                history.RespiratoryCartridgeType == null ? null : history.RespiratoryCartridgeType.Id);


            if (history.EquipmentLockOutMethod != null)
            {
                command.AddParameter("@EquipmentLockOutMethodId", history.EquipmentLockOutMethod.Id);
            }
        }

        private WorkPermitHistory PopulateInstance(SqlDataReader reader)
        {
            var workPermitHistory = new WorkPermitHistory();

            CreateWorkPermitMapper().Populate(reader, workPermitHistory);

            long? approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            workPermitHistory.ApprovedBy = approvedByUserId.HasValue ? userDao.QueryById(approvedByUserId.Value) : null;

            workPermitHistory.WorkPermitStatus = WorkPermitStatus.Get(reader.Get<long>("WorkPermitStatusId"));
            workPermitHistory.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            if (workAssignmentId != null)
            {
                workPermitHistory.WorkAssignment = workAssignmentDao.QueryById(workAssignmentId.Value);
            }
                        
            workPermitHistory.WorkPermitType = WorkPermitType.Get(reader.Get<long>("WorkPermitTypeId"));
            workPermitHistory.WorkPermitClassification = WorkPermitTypeClassification.Get(reader.Get<long>("WorkPermitTypeClassificationId"));
            var sourceId = reader.Get<long>("SourceId");
            workPermitHistory.Source = DataSource.GetById(Convert.ToInt32(sourceId));

            long? specialClothingTypeId = reader.Get<long?>("SpecialProtectiveClothingTypeAcidClothingTypeID");
            if (specialClothingTypeId.HasValue)
            {
                workPermitHistory.ProtectiveClothingTypeAcidClothingType = AcidClothingType.Get(specialClothingTypeId.Value);
            }
            
            long? cartridgeTypeId = reader.Get<long?>("RespitoryProtectionRequirementsRespiratoryCartridgeTypeId");
            if (cartridgeTypeId.HasValue)
            {
                workPermitHistory.RespiratoryCartridgeType = WorkPermitRespiratoryCartridgeType.Get(cartridgeTypeId.Value);
            }

            long? lastModifiedUserId = reader.Get<long?>("LastModifiedUserId");
            workPermitHistory.LastModifiedBy = lastModifiedUserId.HasValue ? userDao.QueryById(lastModifiedUserId.Value) : null;

            long? equipmentLockOutMethodId = reader.Get<long?>("EquipmentLockOutMethodId");
            if (equipmentLockOutMethodId != null)
            {
                workPermitHistory.EquipmentLockOutMethod = WorkPermitLockOutMethodType.Get(equipmentLockOutMethodId.Value);
            }

            return workPermitHistory;
        }

        public List<WorkPermitSignHistory> GetBySignId(string id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", id);
           // command.AddParameter("@SiteId", SiteId);
            return command.QueryForListResult<WorkPermitSignHistory>(PopulateWorkPermitSign, "GETWORKPERMITSIGN_HISTORY");
            
        }

        public static WorkPermitSignHistory PopulateWorkPermitSign(SqlDataReader reader)
        {
            WorkPermitSignHistory objWorkPermitSign = new WorkPermitSignHistory();


            objWorkPermitSign.WorkPermitId = reader.Get<string>("WorkPermitId");

            objWorkPermitSign.PERMIT_ISSUER_NAME = Convert.ToString(reader.Get<string>("ISSUER_FNAME")) + " " + Convert.ToString(reader.Get<string>("ISSUER_LNAME"));

            objWorkPermitSign.PERMIT_ISSUER_BADGENUMBER = Convert.ToString(reader.Get<string>("ISSUER_BADGENUMBER"));

            objWorkPermitSign.PERMIT_ISSUER_SOURCE = Convert.ToString(reader.Get<string>("ISSUER_SOURCE"));


            objWorkPermitSign.NEXT_LEVEL_PERMITISSUER_NAME = Convert.ToString(reader.Get<string>("NEXT_LVL_ISSUER_FNAME")) + " " + Convert.ToString(reader.Get<string>("NEXT_LVL_ISSUER_LNAME")); ;
            objWorkPermitSign.NEXT_LEVEL_PERMITISSUER_BADGENUMBER = Convert.ToString(reader.Get<string>("NEXT_LVL_ISSUER_BADGENUMBER"));
            objWorkPermitSign.NEXT_LEVEL_PERMITISSUER_SOURCE = Convert.ToString(reader.Get<string>("NEXT_LVL_ISSUER_SOURCE"));


            objWorkPermitSign.PERMIT_RECEIVER_NAME = Convert.ToString(reader.Get<string>("PERMIT_RECEIVER_FNAME"))+ " "+Convert.ToString(reader.Get<string>("PERMIT_RECEIVER_LNAME"));
            objWorkPermitSign.PERMIT_RECEIVER_BADGENUMBER = Convert.ToString(reader.Get<string>("PERMIT_RECEIVER_BADGENUMBER"));
            objWorkPermitSign.PERMIT_RECEIVER_SOURCE = Convert.ToString(reader.Get<string>("PERMIT_RECEIVER_SOURCE"));



            objWorkPermitSign.CROSS_ZONE_AUTHORIZATION_NAME = Convert.ToString(reader.Get<string>("CROSS_ZONE_AUTHO_FNAME"))+" "+ Convert.ToString(reader.Get<string>("CROSS_ZONE_AUTHO_LNAME"));
            objWorkPermitSign.CROSS_ZONE_AUTHORIZATION_BADGENUMBER = Convert.ToString(reader.Get<string>("CROSS_ZONE_AUTHO_BADGENUMBER"));
            objWorkPermitSign.CROSS_ZONE_AUTHORIZATION_SOURCE = Convert.ToString(reader.Get<string>("CROSS_ZONE_AUTHO_SOURCE"));


            objWorkPermitSign.IMMIDIATE_AREA_NAME = Convert.ToString(reader.Get<string>("IMMIDIATE_FNAME"))+" "+Convert.ToString(reader.Get<string>("IMMIDIATE_LNAME"));
            objWorkPermitSign.IMMIDIATE_AREA_BADGENUMBER = Convert.ToString(reader.Get<string>("IMMIDIATE_BADGENUMBER"));
            objWorkPermitSign.IMMIDIATE_AREA_SOURCE = Convert.ToString(reader.Get<string>("IMMIDIATE_SOURCE"));

            objWorkPermitSign.CONFINED_SPACE_NAME = Convert.ToString(reader.Get<string>("CONFINED_FNAME"))+" "+Convert.ToString(reader.Get<string>("CONFINED_LNAME"));
            objWorkPermitSign.CONFINED_SPACE_BADGENUMBER = Convert.ToString(reader.Get<string>("CONFINED_BADGENUMBER"));
            objWorkPermitSign.CONFINED_SPACE_SOURCE = Convert.ToString(reader.Get<string>("CONFINED_SOURCE"));

            objWorkPermitSign.UpdatedBy = reader.Get<int>("UpdatedBy");

           // objWorkPermitSign.CreatedBy = reader.Get<int>("CreatedBy");
           // objWorkPermitSign.CreatedDate = Convert.ToString(reader.Get<DateTime>("CreatedDate"));
           // objWorkPermitSign.UpdatedDate = Convert.ToString(reader.Get<DateTime>("UpdatedDate"));
            IUserDao userDao = DaoRegistry.GetDao<IUserDao>();
            objWorkPermitSign.LastModifiedBy = objWorkPermitSign.UpdatedBy != null ? userDao.QueryById(objWorkPermitSign.UpdatedBy) : null;
            objWorkPermitSign.LastModifiedDate = reader.Get<DateTime>("UpdatedDate");

           // objWorkPermitSign.Id = Convert.ToInt64(reader.Get<int>("ID"));
            //objWorkPermitSign.SiteId =Convert.ToString(reader.Get<long?>("SiteId"));
            return objWorkPermitSign;
        }
    }
}
