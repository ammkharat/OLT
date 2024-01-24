using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class WorkPermitSnapshotTakerTest
    {
        private WorkPermitSnapshotTaker snapshotTaker;
        
        [Test]
        public void CreateSnapshotShouldTakeASnapshotAndAllTheFieldsShouldMatchUpCorrectly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();
            permit.Id = 5;
            permit.DocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            
            snapshotTaker = new WorkPermitSnapshotTaker(permit);

            WorkPermitHistory history = snapshotTaker.CreateWorkPermitHistorySnapshot();
            
            Assert.IsNotNull(history);

            Assert.AreEqual(permit.Id, history.Id);
            Assert.AreEqual(permit.LastModifiedBy, history.LastModifiedBy);
            Assert.AreEqual(permit.ApprovedBy, history.ApprovedBy);
            Assert.AreEqual(permit.LastModifiedDate, history.LastModifiedDate);
                        
            Assert.AreEqual("Title for document (http:\\URL for Document), Another Title for document (http:\\Another URL for Document)", history.DocumentLinks);
                        
            Assert.AreEqual(permit.PermitNumber, history.PermitNumber);
            Assert.AreEqual(permit.PermitValidDateTime, history.PermitValidDateTime);
            Assert.AreEqual(permit.WorkPermitType, history.WorkPermitType);
            Assert.AreEqual(permit.WorkPermitTypeClassification, history.WorkPermitClassification);
            Assert.AreEqual(permit.WorkPermitStatus, history.WorkPermitStatus);
            Assert.AreEqual(permit.SpecialPrecautionsOrConsiderations, history.SpecialPrecautionsOrConsiderations);
            Assert.AreEqual(permit.IsCoauthorizationRequired, history.IsCoauthorizationRequired);
            Assert.AreEqual(permit.CoauthorizationDescription, history.CoauthorizationDescription);
            Assert.AreEqual(permit.Source, history.Source);
            Assert.AreEqual(permit.SapOperationId, history.SapOperationId);
            
            Assert.AreEqual(permit.Attributes.IsConfinedSpaceEntry, history.IsConfinedSpaceEntry);
            Assert.AreEqual(permit.Attributes.IsInertConfinedSpaceEntry, history.IsInertConfinedSpaceEntry);
            Assert.AreEqual(permit.Attributes.IsLeadAbatement, history.IsLeadAbatement);
            Assert.AreEqual(permit.Attributes.IsBreathingAirOrSCBA, history.IsBreathingAirOrSCBA);
            Assert.AreEqual(permit.Attributes.IsElectricalWork, history.IsElectricalWork);
            Assert.AreEqual(permit.Attributes.IsVehicleEntry, history.IsVehicleEntry);
            Assert.AreEqual(permit.Attributes.IsHotTap, history.IsHotTap);
            Assert.AreEqual(permit.Attributes.IsBurnOrOpenFlame, history.IsBurnOrOpenFlame);
            Assert.AreEqual(permit.Attributes.IsSystemEntry, history.IsSystemEntry);
            Assert.AreEqual(permit.Attributes.IsCriticalLift, history.IsCriticalLift);
            Assert.AreEqual(permit.Attributes.IsExcavation, history.IsExcavation);
            Assert.AreEqual(permit.Attributes.IsAsbestos, history.IsAsbestos);
            Assert.AreEqual(permit.Attributes.IsRadiationRadiography, history.IsRadiationRadiography);
            Assert.AreEqual(permit.Attributes.IsRadiationSealed, history.IsRadiationSealed);
            
            Assert.AreEqual(permit.AdditionItemsRequired.IsCSEAssessmentOrAuthorization, history.IsAdditionalCSEAssessmentOrAuthorization);
            Assert.AreEqual(permit.AdditionItemsRequired.CSEAssessmentOrAuthorizationDescription, history.AdditionalCSEAssessmentOrAuthorizationDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsFlareEntry, history.IsAdditionalFlareEntry);
            Assert.AreEqual(permit.AdditionItemsRequired.IsCriticalLift, history.IsAdditionalCriticalLift);
            Assert.AreEqual(permit.AdditionItemsRequired.CriticalLiftDescription, history.AdditionalCriticalLiftDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsExcavation, history.IsAdditionalExcavation);
            Assert.AreEqual(permit.AdditionItemsRequired.ExcavationDescription, history.AdditionalExcavationDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsHotTap, history.IsAdditionalHotTap);
            Assert.AreEqual(permit.AdditionItemsRequired.IsSpecialWasteDisposal, history.IsAdditionalSpecialWasteDisposal);
            Assert.AreEqual(permit.AdditionItemsRequired.IsBlankOrBlindLists, history.IsAdditionalBlankOrBlindLists);
            Assert.AreEqual(permit.AdditionItemsRequired.IsPJSROrSafetyPause, history.IsAdditionalPJSROrSafetyPause);
            Assert.AreEqual(permit.AdditionItemsRequired.IsAsbestosHandling, history.IsAdditionalAsbestosHandling);
            Assert.AreEqual(permit.AdditionItemsRequired.IsRoadClosure, history.IsAdditionalRoadClosure);
            Assert.AreEqual(permit.AdditionItemsRequired.IsElectrical, history.IsAdditionalElectrical);
            Assert.AreEqual(permit.AdditionItemsRequired.ElectricalDescription, history.AdditionalElectricalDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsBurnOrOpenFlameAssessment, history.IsAdditionalBurnOrOpenFlameAssessment);
            Assert.AreEqual(permit.AdditionItemsRequired.BurnOrOpenFlameAssessmentDescription, history.AdditionalBurnOrOpenFlameAssessmentDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsWaiverOrDeviation, history.IsAdditionalWaiverOrDeviation);
            Assert.AreEqual(permit.AdditionItemsRequired.WaiverOrDeviationDescription, history.AdditionalWaiverOrDeviationDescription);
            Assert.AreEqual(permit.AdditionItemsRequired.IsMSDS, history.IsAdditionalMSDS);
            Assert.AreEqual(permit.AdditionItemsRequired.IsRadiationApproval, history.IsAdditionalRadiationApproval);
            Assert.AreEqual(permit.AdditionItemsRequired.IsOnlineLeakRepairForm, history.IsAdditionalOnlineLeakRepairForm);
            Assert.AreEqual(permit.AdditionItemsRequired.IsEnergizedElectricalForm, history.IsAdditionalEnergizedElectricalForm);
            Assert.AreEqual(permit.AdditionItemsRequired.OtherItemDescription, history.AdditionalOtherItemDescription);
                                     
            Assert.AreEqual(permit.Specifics.FunctionalLocation, history.FunctionalLocation);
            Assert.AreEqual(permit.Specifics.WorkOrderNumber, history.WorkOrderNumber);
            Assert.AreEqual(permit.Specifics.StartDateTime, history.StartDateTime);
            Assert.AreEqual(permit.Specifics.EndDateTime, history.EndDateTime);             
            Assert.AreEqual(permit.Specifics.WorkOrderDescription, history.WorkOrderDescription);
            Assert.AreEqual(permit.Specifics.JobStepDescription, history.JobStepsDescription);
            Assert.AreEqual(permit.Specifics.ContactName, history.ContactName);
            Assert.AreEqual(permit.Specifics.ContractorCompanyName, history.ContractorCompanyName);
            
            Assert.AreEqual((long) 1, history.CraftOrTradeId);
            Assert.IsNull(history.CraftOrTradeOther);
            
            Assert.AreEqual(permit.Specifics.Communication.RadioChannel, history.RadioChannel);
            Assert.AreEqual(permit.Specifics.Communication.RadioColor, history.RadioColor);
            Assert.AreEqual(permit.Specifics.Communication.Description, history.CommunicationDescription);
            Assert.AreEqual(permit.Specifics.Communication.IsWorkPermitCommunicationNotApplicable, history.IsWorkPermitCommunicationNotApplicable);
            Assert.AreEqual(permit.Specifics.Communication.ByRadio, history.ByRadio);
                        
            Assert.AreEqual(permit.Tools.IsAirTools, history.IsAirTools);
            Assert.AreEqual(permit.Tools.IsCraneOrCarrydeck, history.IsCraneOrCarrydeck);
            Assert.AreEqual(permit.Tools.IsHandTools, history.IsHandTools);
            Assert.AreEqual(permit.Tools.IsJackhammer, history.IsJackhammer);
            Assert.AreEqual(permit.Tools.IsVacuumTruck, history.IsVacuumTruck);
            Assert.AreEqual(permit.Tools.IsCementSaw, history.IsCementSaw);
            Assert.AreEqual(permit.Tools.IsElectricTools, history.IsElectricTools);
            Assert.AreEqual(permit.Tools.IsHeavyEquipment, history.IsHeavyEquipment);
            Assert.AreEqual(permit.Tools.IsLanda, history.IsLanda);
            Assert.AreEqual(permit.Tools.IsScaffolding, history.IsScaffolding);
            Assert.AreEqual(permit.Tools.IsVehicle, history.IsVehicle);
            Assert.AreEqual(permit.Tools.IsCompressor, history.IsCompressor);
            Assert.AreEqual(permit.Tools.IsForklift, history.IsForklift);
            Assert.AreEqual(permit.Tools.IsHEPAVacuum, history.IsHepaVacuum);
            Assert.AreEqual(permit.Tools.IsManlift, history.IsManlift);
            Assert.AreEqual(permit.Tools.IsTamper, history.IsTamper);
            Assert.AreEqual(permit.Tools.IsHotTapMachine, history.IsHotTapMachine);
            Assert.AreEqual(permit.Tools.IsPortLighting, history.IsPortLighting);
            Assert.AreEqual(permit.Tools.IsTorch, history.IsTorch);
            Assert.AreEqual(permit.Tools.IsWelder, history.IsWelder);
            Assert.AreEqual(permit.Tools.IsChemicals, history.IsChemicals);
            Assert.AreEqual(permit.Tools.OtherToolsDescription, history.OtherToolsDescription);
                        
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsElectricalIsolationMethodNotApplicable, history.IsElectricalIsolationMethodNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsElectricalIsolationMethodLOTO, history.IsElectricalIsolationMethodLOTO);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsElectricalIsolationMethodWiring, history.IsElectricalIsolationMethodWiring);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsTestBumpNotApplicable, history.IsTestBumpNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsTestBump, history.IsTestBump);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsStillContainsResidualNotApplicable, history.IsStillContainsResidualNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsStillContainsResidual, history.IsStillContainsResidual);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsLeakingValvesNotApplicable, history.IsLeakingValvesNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsLeakingValves, history.IsLeakingValves);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsOutOfService, history.IsOutOfService);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionNotApplicable, history.IsConditionNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionDepressured, history.IsConditionDepressured);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionDrained, history.IsConditionDrained);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionCleaned, history.IsConditionCleaned);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionVentilated, history.IsConditionVentilated);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionH20Washed, history.IsConditionH20Washed);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionNeutralized, history.IsConditionNeutralized);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionPurged, history.IsConditionPurged);
            Assert.AreEqual(permit.EquipmentPreparationCondition.ConditionPurgedDescription, history.ConditionPurgedDescription);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionPurgedN2, history.IsConditionPurgedN2);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionPurgedSteamed, history.IsConditionPurgedSteamed);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsConditionPurgedAir, history.IsConditionPurgedAir);
            Assert.AreEqual(permit.EquipmentPreparationCondition.ConditionOtherDescription, history.ConditionOtherDescription);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsPreviousContentsNotApplicable, history.IsPreviousContentsNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsPreviousContentsHydrocarbon, history.IsPreviousContentsHydrocarbon);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsPreviousContentsAcid, history.IsPreviousContentsAcid);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsPreviousContentsCaustic, history.IsPreviousContentsCaustic);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsPreviousContentsH2S, history.IsPreviousContentsH2S);
            Assert.AreEqual(permit.EquipmentPreparationCondition.PreviousContentsOtherDescription, history.PreviousContentsOtherDescription);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsAsbestosGasketsNotApplicable, history.IsAsbestosGasketsNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsAsbestosGaskets, history.IsAsbestosGaskets);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodNotApplicable, history.IsIsolationMethodNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodBlindedorBlanked, history.IsIsolationMethodBlindedorBlanked);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodSeparation, history.IsIsolationMethodSeparation);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodMudderPlugs, history.IsIsolationMethodMudderPlugs);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodBlockedIn, history.IsIsolationMethodBlockedIn);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodCarBer, history.IsIsolationMethodCarBer);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsIsolationMethodLOTO, history.IsIsolationMethodLOTO);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsolationMethodOtherDescription, history.IsolationMethodOtherDescription);
            Assert.AreEqual(permit.EquipmentPreparationCondition.InServiceComments, history.EquipmentInServiceComments);
            Assert.AreEqual(permit.EquipmentPreparationCondition.LeakingValvesComments, history.LeakingValvesComments);
            Assert.AreEqual(permit.EquipmentPreparationCondition.StillContainsResidualComments, history.StillContainsResidualComments);
            Assert.AreEqual(permit.EquipmentPreparationCondition.NoElectricalTestBumpComments, history.NoElectricalTestBumpComments);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsVentilationMethodNotApplicable, history.VentilationMethodNotApplicable);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsVentilationMethodNaturalDraft, history.VentilationMethodNaturalDraft);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsVentilationMethodLocalExhaust, history.VentilationMethodLocalExhaust);
            Assert.AreEqual(permit.EquipmentPreparationCondition.IsVentilationMethodForced, history.VentilationMethodForced);
            
            Assert.AreEqual(permit.JobWorksitePreparation.IsFlowRequiredForJobNotApplicable, history.FlowRequiredForJobNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsFlowRequiredForJob, history.FlowRequiredForJob);
            Assert.AreEqual(permit.JobWorksitePreparation.IsBondingOrGroundingRequiredNotApplicable, history.BondingOrGroundingRequiredNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsBondingOrGroundingRequired, history.BondingOrGroundingRequired);
            Assert.AreEqual(permit.JobWorksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable, history.WeldingGroundWireInTestAreaNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsWeldingGroundWireInTestArea, history.WeldingGroundWireInTestArea);
            Assert.AreEqual(permit.JobWorksitePreparation.IsCriticalConditionRemainJobSiteNotApplicable, history.CriticalConditionRemainJobSiteNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsCriticalConditionRemainJobSite, history.CriticalConditionRemainJobSite);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable, history.SurroundingConditionsAffectOrContaminatedNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated, history.SurroundingConditionsAffectOrContaminated);
            Assert.AreEqual(permit.JobWorksitePreparation.IsVestedBuddySystemInEffectNotApplicable, history.VestedBuddySystemInEffectNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsVestedBuddySystemInEffect, history.VestedBuddySystemInEffect);
            Assert.AreEqual(permit.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable, history.PermitReceiverFieldOrEquipmentOrientationNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation, history.PermitReceiverFieldOrEquipmentOrientation);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSewerIsolationMethodNotApplicable, history.SewerIsolationMethodNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSewerIsolationMethodSealedOrCovered, history.SewerIsolationMethodSealedOrCovered);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSewerIsolationMethodPlugged, history.SewerIsolationMethodPlugged);
            Assert.AreEqual(permit.JobWorksitePreparation.IsSewerIsolationMethodBlindedOrBlanked, history.SewerIsolationMethodBlindedOrBlanked);
            Assert.AreEqual(permit.JobWorksitePreparation.SewerIsolationMethodOtherDescription, history.SewerIsolationMethodOtherDescription);
           
            Assert.AreEqual(permit.JobWorksitePreparation.IsAreaPreparationNotApplicable, history.AreaPreparationNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsAreaPreparationBarricade, history.AreaPreparationBarricade);
            Assert.AreEqual(permit.JobWorksitePreparation.IsAreaPreparationNonEssentialEvac, history.AreaPreparationNonEssentialEvac);
            Assert.AreEqual(permit.JobWorksitePreparation.IsAreaPreparationBoundaryRopeTape, history.AreaPreparationPreopBoundaryRopeTape);
            Assert.AreEqual(permit.JobWorksitePreparation.IsAreaPreparationRadiationRope, history.AreaPreparationRadiationRope);
            Assert.AreEqual(permit.JobWorksitePreparation.AreaPreparationOtherDescription, history.AreaPreparationOtherDescription);
            Assert.AreEqual(permit.JobWorksitePreparation.IsLightingElectricalRequirementNotApplicable, history.LightingElectricalRequirementNotApplicable);
            Assert.AreEqual(permit.JobWorksitePreparation.IsLightingElectricalRequirementLowVoltage12V, history.LightingElectricalRequirementLowVoltage12V);
            Assert.AreEqual(permit.JobWorksitePreparation.IsLightingElectricalRequirement110VWithGFCI, history.LightingElectricalRequirement110VWithGFCI);
            Assert.AreEqual(permit.JobWorksitePreparation.IsLightingElectricalRequirementGeneratorLights, history.LightingElectricalRequirementGeneratorLights);
            Assert.AreEqual(permit.JobWorksitePreparation.LightingElectricalRequirementOtherDescription, history.LightingElectricalRequirementOtherDescription);
            Assert.AreEqual(permit.JobWorksitePreparation.PermitReceiverRequiresOrientationComments, history.PermitReceiverRequiresOrientationComments);
            Assert.AreEqual(permit.JobWorksitePreparation.SurroundingConditionsAffectAreaComments, history.SurroundingConditionsAffectAreaComments);
            Assert.AreEqual(permit.JobWorksitePreparation.CriticalConditionsComments, history.CriticalConditionsComments);
            Assert.AreEqual(permit.JobWorksitePreparation.WeldingGroundWireNotWithinGasTestAreaComments, history.WeldingGroundWireNotWithinGasTestAreaComments);
            Assert.AreEqual(permit.JobWorksitePreparation.BondingGroundingNotRequiredComments, history.BondingGroundingNotRequiredComments);
            Assert.AreEqual(permit.JobWorksitePreparation.FlowRequiredComments, history.FlowRequiredComments);
                                                   
            Assert.AreEqual(permit.RadiationInformation.IsSealedSourceIsolationNotApplicable, history.SealedSourceIsolationNotApplicable);
            Assert.AreEqual(permit.RadiationInformation.IsSealedSourceIsolationLOTO, history.SealedSourceIsolationLOTO);
            Assert.AreEqual(permit.RadiationInformation.IsSealedSourceIsolationOpen, history.SealedSourceIsolationOpen);
            Assert.AreEqual(permit.RadiationInformation.SealedSourceIsolationNumberOfSources, history.SealedSourceIsolationNumberOfSources);            

            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsNotApplicable, history.FireConfinedSpaceNotApplicable);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsTwentyABCorDryChemicalExtinguisher, history.TwentyABCorDryChemicalExtinguisher);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsC02Extinguisher, history.C02Extinguisher);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsFireResistantTarp, history.FireResistantTarp);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsWatchmen, history.Watchmen);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.OtherDescription, history.FireConfinedSpaceRequirementsOtherRequirementsDescription);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsSparkContainment, history.SparkContainment);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsSteamHose, history.SteamHose);
            Assert.AreEqual(permit.FireConfinedSpaceRequirements.IsWaterHose, history.WaterHose);

            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsNotApplicable, history.RespiratoryProtectionNotApplicable);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsAirCartorAirLine, history.AirCartorAirLine);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsDustMask, history.DustMask);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsSCBA, history.SCBA);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsAirHood, history.AirHood);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsHalfFaceRespirator, history.HalfFaceRespirator);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.IsFullFaceRespirator, history.FullFaceRespirator);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.OtherDescription, history.RespiratoryProtectionRequirementsOtherDescription);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.CartridgeTypeDescription, history.RespiratoryCartridgeTypeDescription);
            Assert.AreEqual(permit.RespiratoryProtectionRequirements.CartridgeType, history.RespiratoryCartridgeType);

            Assert.AreEqual(permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionNotApplicable, history.EyeOrFaceProtectionNotApplicable);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionGoggles, history.EyeOrFaceProtectionGoggles);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield, history.EyeOrFaceProtectionFaceshield);
            Assert.AreEqual(permit.SpecialProtectionRequirements.EyeOrFaceProtectionOtherDescription, history.EyeOrFaceProtectionOtherDescription);

            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeNotApplicable, history.ProtectiveClothingTypeNotApplicable);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainCoat, history.ProtectiveClothingTypeRainCoat);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeRainPants, history.ProtectiveClothingTypeRainPants);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeAcidClothing, history.ProtectiveClothingTypeAcidClothing);
            Assert.AreEqual(permit.SpecialProtectionRequirements.ProtectiveClothingTypeAcidClothingType, history.ProtectiveClothingTypeAcidClothingType);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeCausticWear, history.ProtectiveClothingTypeCausticWear);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypePaperCoveralls, history.ProtectiveClothingTypePaperCoveralls);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeTyvekSuit, history.ProtectiveClothingTypeTyvekSuit);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeKapplerSuit, history.ProtectiveClothingTypeKapplerSuit);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeElectricalFlashGear, history.ProtectiveClothingTypeElectricalFlashGear);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveClothingTypeCorrosiveClothing, history.ProtectiveClothingTypeCorrosiveClothing);
            Assert.AreEqual(permit.SpecialProtectionRequirements.ProtectiveClothingTypeOtherDescription, history.ProtectiveClothingTypeOtherDescripton);

            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveFootwearNotApplicable, history.ProtectiveFootwearNotApplicable);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveFootwearChemicalImperviousBoots, history.ProtectiveFootwearChemicalImperviousBoots);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveFootwearToeGuard, history.ProtectiveFootwearToeGuard);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsProtectiveFootwearMetatarsalGuard, history.ProtectiveFootwearMetatarsalGuard);
            Assert.AreEqual(permit.SpecialProtectionRequirements.ProtectiveFootwearOtherDescription, history.ProtectiveFootwearOtherDescription);

            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionNotApplicable, history.HandProtectionNotApplicable);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionChemicalNeoprene, history.HandProtectionChemicalNeprene);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionNaturalRubber, history.HandProtectionNaturalRubber);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionNitrile, history.HandProtectionNitrile);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionPVC, history.HandProtectionPVC);            
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionHighVoltage, history.HandProtectionHighVoltage);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionWelding, history.HandProtectionWelding);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionLeather, history.HandProtectionLeather);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsHandProtectionChemicalGloves, history.HandProtectionChemicalGloves);
            Assert.AreEqual(permit.SpecialProtectionRequirements.HandProtectionOtherDescription, history.HandProtectionOtherDescription);

            Assert.AreEqual(permit.SpecialProtectionRequirements.IsRescueOrFallNotApplicable, history.RescueOrFallNotApplicable);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsRescueOrFallBodyHarness, history.RescueOrFallBodyHarness);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsRescueOrFallLifeline, history.RescueOrFallLifeline);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsRescueOrFallYoYo, history.RescueOrFallYoYo);
            Assert.AreEqual(permit.SpecialProtectionRequirements.IsRescueOrFallRescueDevice, history.RescueOrFallRescueDevice);
            Assert.AreEqual(permit.SpecialProtectionRequirements.RescueOrFallOtherDescription, history.RescueOrFallOtherDescription);

            Assert.AreEqual(permit.GasTests.FrequencyOrDuration, history.GasTestFrequencyOrDuration);
            Assert.AreEqual(permit.GasTests.ConstantMonitoringRequired, history.GasTestConstantMonitoringRequired);
            Assert.AreEqual(permit.GasTests.ForkliftNotUsed, history.GasTestForkliftNotUsed);
                                    
            Assert.AreEqual(new Time(16, 34), history.GasTestTestTime);
            List<GasTestElement> gasTestElements = permit.GasTests.Elements;
            Assert.AreEqual(gasTestElements.AsString(gasTestElement => gasTestElement.ToHistoryString()), history.GasTestElements);
        }

        [Test]
        public void CreateSnapshotShouldRenderGasTestElementDetails()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            GasTestElement gasTestElementData = GasTestElementFixture.CreateGasTestElementWithImmediateConfinedAndSystemEntryData();
            permit.GasTests.Elements = 
                new List<GasTestElement>{gasTestElementData};
            snapshotTaker = new WorkPermitSnapshotTaker(permit);
            WorkPermitHistory history = snapshotTaker.CreateWorkPermitHistorySnapshot();

            List<GasTestElement> gasTestElements = permit.GasTests.Elements;
            Assert.AreEqual(gasTestElements.AsString(gasTestElement => gasTestElement.ToHistoryString()), history.GasTestElements);
            Assert.AreEqual(
                string.Format(
                    "Immediate/Work Area Required: True, First Immediate/WorkArea Result: {0}, CS Required: True, First CS Result: {1}, SE N/A: False, First SE Result: {2}",
                    gasTestElementData.ImmediateAreaTestResult,
                    gasTestElementData.ConfinedSpaceTestResult,
                    gasTestElementData.SystemEntryTestResult),
                history.GasTestElements);
        }

        [Test]
        public void CreateSnapshotShouldTakeSnapshotOfNullGasTestTime()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();
            permit.GasTests.ImmediateAreaTestTime = null;

            snapshotTaker = new WorkPermitSnapshotTaker(permit);
            WorkPermitHistory history = snapshotTaker.CreateWorkPermitHistorySnapshot();
            Assert.IsNull(history.GasTestTestTime);
        }

        [Test]
        public void CreateSnapshotShouldSnapshotEndTimeFinalizedFlag()
        {
            WorkPermit permit = CreatePermitWithEndTimeFinalized(true);
            WorkPermitHistory history = new WorkPermitSnapshotTaker(permit).CreateWorkPermitHistorySnapshot();
            Assert.IsTrue(history.StartAndOrEndTimesFinalized);

            permit = CreatePermitWithEndTimeFinalized(false);
            history = new WorkPermitSnapshotTaker(permit).CreateWorkPermitHistorySnapshot();
            Assert.IsFalse(history.StartAndOrEndTimesFinalized);
        }

        private WorkPermit CreatePermitWithEndTimeFinalized(bool endTimeFinalized)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.StartAndOrEndTimesFinalized = endTimeFinalized;
            return permit;
        }
    }
}
