DECLARE @FLOC_ID BIGINT;
DECLARE @WP_ID BIGINT;

DECLARE @START_TIME AS DATETIME;
DECLARE @END_TIME AS DATETIME;

DECLARE @START_TIME2 AS DATETIME;
DECLARE @END_TIME2 AS DATETIME;

DECLARE @DIVISION AS VARCHAR(3);

SET @START_TIME = CONVERT(DATETIME, CONVERT(char(10), GetDate() + 1, 110) + ' 09:00:00.000');
SET @END_TIME = DATEADD(dd, 1, CONVERT(DATETIME, CONVERT(char(10), GetDate() + 1, 110) + ' 19:00:00.000'));

SET @START_TIME2 = CONVERT(DATETIME, CONVERT(char(10), GetDate() + 1, 110) + ' 10:00:00.000');
SET @END_TIME2 = DATEADD(dd, 1, CONVERT(DATETIME, CONVERT(char(10), GetDate() + 1, 110) + ' 20:00:00.000'));

DECLARE FLOC_ID_CURSOR CURSOR
FOR
  SELECT Id FROM FunctionalLocation
  WHERE 		
  (
			FullHierarchy like 'SR1-PLT2-%'
			or
			FullHierarchy like 'SR1-PLT3-%'
			or
			FullHierarchy like 'DN1-3003-%'
		)
		and [Level] = 3
		and (SiteId = 1 or SiteId = 2);

OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

WHILE (@@FETCH_STATUS <> -1)
BEGIN
   IF (@@FETCH_STATUS <> -2)
   BEGIN

select @DIVISION = COALESCE(fa.FullHierarchy, f.FullHierarchy)
		from
			FunctionalLocation f
			LEFT OUTER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 1
			LEFT OUTER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
		where
			f.Id = @FLOC_ID;

insert into [WorkPermit] (
  [WorkPermitStatusId],
 Version,
 [FunctionalLocationId],
 [SapOperationId],
 [PermitNumber],
 [WorkOrderNumber],
 [StartDateTime],
 [EndDateTime],
 [PermitValidDateTime],
 [WorkPermitTypeId],
 [WorkPermitTypeClassificationId],
 [WorkOrderDescription],
 [SpecialPrecautionsOrConsiderationsDescription],
 [PermitConfinedSpaceEntry],
 [PermitBreathingAirOrSCBA],
 [PermitElectricalSwitching],
 [PermitVehicleEntry],
 [PermitHotTap],
 [PermitBurnOrOpenFlame],
 [PermitSystemEntry],
 [PermitCriticalLift],
 [PermitEnergizedElectrical],
 [PermitExcavation],
 [PermitAsbestos],
 [PermitRadiationRadiography],
 [PermitRadiationSealed],
 [AdditionalCSEAssessmentOrAuthorization],
 [AdditionalFlareEntry],
 [AdditionalCriticalLift],
 [AdditionalExcavation],
 [AdditionalHotTap],
 [AdditionalSpecialWasteDisposal],
 [AdditionalBlankOrBlindLists],
 [AdditionalPJSROrSafetyPause],
 [AdditionalAsbestosHandling],
 [AdditionalRoadClosure],
 [AdditionalElectrical],
 [AdditionalBurnOrOpenFlameAssessment],
 [AdditionalWaiverOrDeviation],
 [AdditionalMSDS],
 [AdditionalRadiationApproval],
 [AdditionalOnlineLeakRepairForm],
 --[AdditionalLOTOLog],
 [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
 [ContactPersonnel],
 [ContractorCompanyName],
 [CraftOrTradeID],
 [CraftOrTradeOther],
 [JobStepDescription],
 [CommunicationByRadio],
 [CommunicationRadioChannelOrBand],
 [IsWorkPermitCommunicationNotApplicable],
 [CommunicationRadioColor],
 [CommunicationByOtherDescription],
 [CoAuthorizationRequired],
 [CoAuthorizationDescription],
 [ToolsAirTools],
 [ToolsCraneOrCarrydeck],
 [ToolsHandTools],
 [ToolsJackhammer],
 [ToolsVacuumTruck],
 [ToolsCementSaw],
 [ToolsElectricTools],
 [ToolsHeavyEquipment],
 [ToolsLanda],
 [ToolsScaffolding],
 [ToolsVehicle],
 [ToolsCompressor],
 [ToolsForklift],
 [ToolsHEPAVacuum],
 [ToolsManlift],
 [ToolsTamper],
 [ToolsHotTapMachine],
 [ToolsPortLighting],
 [ToolsTorch],
 [ToolsWelder],
 [ToolsOtherToolsDescription],
 [ElectricIsolationMethodNotApplicable],
 [ElectricIsolationMethodLOTO],
 [ElectricIsolationMethodWiring],
 [ElectricTestBumpNotApplicable],
 [ElectricTestBump],
 [EquipmentNoElectricalTestBumpComments],
 [EquipmentStillContainsResidualNotApplicable],
 [EquipmentStillContainsResidual],
 [EquipmentStillContainsResidualComments],
 [EquipmentLeakingValvesNotApplicable],
 [EquipmentLeakingValves],
 [EquipmentLeakingValvesComments],
 [EquipmentIsOutOfService],
 [EquipmentInServiceComments],
 [EquipmentConditionNotApplicable],
 [EquipmentConditionDepressured],
 [EquipmentConditionDrained],
 [EquipmentConditionCleaned],
 [EquipmentConditionVentilated],
 [EquipmentConditionH20Washed],
 [EquipmentConditionNeutralized],
 [EquipmentConditionPurged],
 [EquipmentConditionPurgedDescription],
 [EquipmentPreviousContentsNotApplicable],
 [EquipmentPreviousContentsHydrocarbon],
 [EquipmentPreviousContentsAcid],
 [EquipmentPreviousContentsCaustic],
 [EquipmentPreviousContentsH2S],
 [EquipmentPreviousContentsOtherDescription],
 [EquipmentIsolationMethodNotApplicable],
 [EquipmentIsolationMethodBlindedorBlanked],
 [EquipmentIsolationMethodBlockedIn],
 [EquipmentIsolationMethodSeparation],
 [EquipmentIsolationMethodMudderPlugs],
 [EquipmentIsolationMethodLOTO],
 [EquipmentIsolationMethodOtherDescription],
 [EquipmentVentilationMethodNotApplicable],
 [EquipmentVentilationMethodNaturalDraft],
 [EquipmentVentilationMethodLocalExhaust],
 [EquipmentVentilationMethodForced],
[JobSitePreparationFlowRequiredForJob],
 [JobSitePreparationFlowRequiredForJobNotApplicable],
 [JobSitePreparationFlowRequiredComments],
 [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
 [JobSitePreparationBondingOrGroundingRequired],
 [JobSitePreparationBondingGroundingNotRequiredComments],
 [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
 [JobSitePreparationWeldingGroundWireInTestArea],
 [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
 [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
 [JobSitePreparationCriticalConditionRemainJobSite],
 [JobSitePreparationCriticalConditionsComments],
 [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
 [JobSitePreparationSurroundingConditionsAffectOrContaminated],
 [JobSitePreparationSurroundingConditionsAffectAreaComments],
 [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
 [JobSitePreparationVestedBuddySystemInEffect],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
 [JobSitePreparationPermitReceiverRequiresOrientationComments],
 [JobSitePreparationSewerIsolationMethodNotApplicable],
 [JobSitePreparationSewerIsolationMethodSealedOrCovered],
 [JobSitePreparationSewerIsolationMethodPlugged],
 [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
 [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
 [JobSitePreparationAreaPreparationBarricade],
 [JobSitePreparationAreaPreparationNonEssentialEvac],
 [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
 [JobSitePreparationAreaPreparationOtherDescription],
-- [JobSitePreparationDocumentationSignageNotApplicable],
-- [JobSitePreparationDocumentationSignageBlankOrBlindList],
-- [JobSitePreparationDocumentationSignageCSEPermit],
-- [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
-- [JobSitePreparationDocumentationSignageRestrictedEntry],
-- [JobSitePreparationDocumentationSignageOtherDescription],
 [JobSitePreparationLightingElectricalRequirementNotApplicable],
 [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
 [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
 [JobSitePreparationLightingElectricalRequirementGeneratorLights],
 [JobSitePreparationLightingElectricalRequirementOtherDescription],
 [RadiationSealedSourceIsolationNotApplicable],
 [RadiationSealedSourceIsolationLOTO],
 [RadiationSealedSourceIsolationOpen],
 [RadiationSealedSourceIsolationNumberOfSources],
 [GasTestFrequencyOrDuration],
 [GasTestConstantMonitoringRequired],
 [GasTestTestTime],
 [FireConfinedSpace20ABCorDryChemicalExtinguisher],
 [FireConfinedSpaceC02Extinguisher],
 [FireConfinedSpaceFireResistantTarp],
 [FireConfinedSpaceSparkContainment],
 [FireConfinedSpaceWaterHose],
 [FireConfinedSpaceSteamHose],
 [FireConfinedSpaceWatchmen],
 [RespitoryProtectionRequirementsAirCartOrAirLine],
 [RespitoryProtectionRequirementsSCBA],
 [RespitoryProtectionRequirementsHalfFaceRespirator],
 [RespitoryProtectionRequirementsFullFaceRespirator],
 [RespitoryProtectionRequirementsDustMask],
 [RespitoryProtectionRequirementsAirHood],
 [RespitoryProtectionRequirementsOtherDescription],
 [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
 [SpecialEyeOrFaceProtectionGoggles],
 [SpecialEyeOrFaceProtectionFaceshield],
 [SpecialEyeOrFaceProtectionOtherDescription],
 [SpecialProtectiveClothingTypeRainCoat],
 [SpecialProtectiveClothingTypeRainPants],
 [SpecialProtectiveClothingTypeAcidClothing],
 [SpecialProtectiveClothingTypeAcidClothingTypeID],
 [SpecialProtectiveClothingTypeCausticWear],
 [SpecialProtectiveClothingTypeOtherDescripton],
 [SpecialProtectiveFootwearChemicalImperviousBoots],
 [SpecialProtectiveFootwearToeGuard],
 [SpecialProtectiveFootwearOtherDescription],
 [SpecialHandProtectionChemicalNeprene],
 [SpecialHandProtectionNaturalRubber],
 [SpecialHandProtectionNitrile],
 [SpecialHandProtectionPVC],
 [SpecialHandProtectionHighVoltage],
 [SpecialHandProtectionWelding],
 [SpecialHandProtectionLeather],
 [SpecialHandProtectionOtherDescription],
 [SpecialRescueOrFallBodyHarness],
 [SpecialRescueOrFallLifeline],
 [SpecialRescueOrFallYoYo],
 [SpecialRescueOrFallRescueDevice],
 [SpecialRescueOrFallOtherDescription],
 [SourceId],
 [CreatedByUserId],
 [IsOperations],
 [LastModifiedUserId],
 [LastModifiedDate],
 [Deleted],
 [StartAndOrEndTimesFinalized],
 EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
 AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
 ) 
values (
1,
'3.2',
@FLOC_ID,
null,
@DIVISION + '-0000000016',
'WON12345',
@START_TIME,
@END_TIME,
null,
1,
1,
 'Repair pump seal and bearings',
null,
0,
0,
0,
0,
0,
 0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
--0,
null,
'Mike MacNeil',
null,
23,
'It is no longer used.  Once CraftOrTrade Table is ',
'Install blanks',
1,
null,
1,
null,
null,
0,
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
null,
1,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
1,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
1,
0,
null,
1,
0,
0,
0,
null,
1,
0,
0,
0,
null,
--1,
--0,
--0,
--0,
--0,
--null,
1,
0,
0,
0,
null,
1,
0,
0,
null,
'',
0,
null,
1,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
null,
null,
0,
0,
null,
0,
0,
0,
null,
0,
null,
0,
0,
null,
0,
0,
0,
0,
0,
0,
0,
null,
0,
0,
0,
0,
null,
1,
1,
1, -- IsOperations
1,
@START_TIME,
0,
1,
1,
1,
null,
0,
0,
0,
0,
0,
0
);

select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE  -- Denver gas test elements
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END

insert into [WorkPermit] (
  [WorkPermitStatusId],
 Version,
 [FunctionalLocationId],
 [SapOperationId],
 [PermitNumber],
 [WorkOrderNumber],
 [StartDateTime],
 [EndDateTime],
 [PermitValidDateTime],
 [WorkPermitTypeId],
 [WorkPermitTypeClassificationId],
 [WorkOrderDescription],
 [SpecialPrecautionsOrConsiderationsDescription],
 [PermitConfinedSpaceEntry],
 [PermitBreathingAirOrSCBA],
 [PermitElectricalSwitching],
 [PermitVehicleEntry],
 [PermitHotTap],
 [PermitBurnOrOpenFlame],
 [PermitSystemEntry],
 [PermitCriticalLift],
 [PermitEnergizedElectrical],
 [PermitExcavation],
 [PermitAsbestos],
 [PermitRadiationRadiography],
 [PermitRadiationSealed],
 [AdditionalCSEAssessmentOrAuthorization],
 [AdditionalFlareEntry],
 [AdditionalCriticalLift],
 [AdditionalExcavation],
 [AdditionalHotTap],
 [AdditionalSpecialWasteDisposal],
 [AdditionalBlankOrBlindLists],
 [AdditionalPJSROrSafetyPause],
 [AdditionalAsbestosHandling],
 [AdditionalRoadClosure],
 [AdditionalElectrical],
 [AdditionalBurnOrOpenFlameAssessment],
 [AdditionalWaiverOrDeviation],
 [AdditionalMSDS],
 [AdditionalRadiationApproval],
 [AdditionalOnlineLeakRepairForm],
-- [AdditionalLOTOLog],
 [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
 [ContactPersonnel],
 [ContractorCompanyName],
 [CraftOrTradeID],
 [CraftOrTradeOther],
 [JobStepDescription],
 [CommunicationByRadio],
 [CommunicationRadioChannelOrBand],
 [IsWorkPermitCommunicationNotApplicable],
 [CommunicationRadioColor],
 [CommunicationByOtherDescription],
 [CoAuthorizationRequired],
 [CoAuthorizationDescription],
 [ToolsAirTools],
 [ToolsCraneOrCarrydeck],
 [ToolsHandTools],
 [ToolsJackhammer],
 [ToolsVacuumTruck],
 [ToolsCementSaw],
 [ToolsElectricTools],
 [ToolsHeavyEquipment],
 [ToolsLanda],
 [ToolsScaffolding],
 [ToolsVehicle],
 [ToolsCompressor],
 [ToolsForklift],
 [ToolsHEPAVacuum],
 [ToolsManlift],
 [ToolsTamper],
 [ToolsHotTapMachine],
 [ToolsPortLighting],
 [ToolsTorch],
 [ToolsWelder],
 [ToolsOtherToolsDescription],
 [ElectricIsolationMethodNotApplicable],
 [ElectricIsolationMethodLOTO],
 [ElectricIsolationMethodWiring],
 [ElectricTestBumpNotApplicable],
 [ElectricTestBump],
 [EquipmentNoElectricalTestBumpComments],
 [EquipmentStillContainsResidualNotApplicable],
 [EquipmentStillContainsResidual],
 [EquipmentStillContainsResidualComments],
 [EquipmentLeakingValvesNotApplicable],
 [EquipmentLeakingValves],
 [EquipmentLeakingValvesComments],
 [EquipmentIsOutOfService],
 [EquipmentInServiceComments],
 [EquipmentConditionNotApplicable],
 [EquipmentConditionDepressured],
 [EquipmentConditionDrained],
 [EquipmentConditionCleaned],
 [EquipmentConditionVentilated],
 [EquipmentConditionH20Washed],
 [EquipmentConditionNeutralized],
 [EquipmentConditionPurged],
 [EquipmentConditionPurgedDescription],
 [EquipmentPreviousContentsNotApplicable],
 [EquipmentPreviousContentsHydrocarbon],
 [EquipmentPreviousContentsAcid],
 [EquipmentPreviousContentsCaustic],
 [EquipmentPreviousContentsH2S],
 [EquipmentPreviousContentsOtherDescription],
 [EquipmentIsolationMethodNotApplicable],
 [EquipmentIsolationMethodBlindedorBlanked],
 [EquipmentIsolationMethodBlockedIn],
 [EquipmentIsolationMethodSeparation],
 [EquipmentIsolationMethodMudderPlugs],
 [EquipmentIsolationMethodLOTO],
 [EquipmentIsolationMethodOtherDescription],
 [EquipmentVentilationMethodNotApplicable],
 [EquipmentVentilationMethodNaturalDraft],
 [EquipmentVentilationMethodLocalExhaust],
 [EquipmentVentilationMethodForced],
[JobSitePreparationFlowRequiredForJob],
 [JobSitePreparationFlowRequiredForJobNotApplicable],
 [JobSitePreparationFlowRequiredComments],
 [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
 [JobSitePreparationBondingOrGroundingRequired],
 [JobSitePreparationBondingGroundingNotRequiredComments],
 [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
 [JobSitePreparationWeldingGroundWireInTestArea],
 [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
 [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
 [JobSitePreparationCriticalConditionRemainJobSite],
 [JobSitePreparationCriticalConditionsComments],
 [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
 [JobSitePreparationSurroundingConditionsAffectOrContaminated],
 [JobSitePreparationSurroundingConditionsAffectAreaComments],
 [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
 [JobSitePreparationVestedBuddySystemInEffect],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
 [JobSitePreparationPermitReceiverRequiresOrientationComments],
 [JobSitePreparationSewerIsolationMethodNotApplicable],
 [JobSitePreparationSewerIsolationMethodSealedOrCovered],
 [JobSitePreparationSewerIsolationMethodPlugged],
 [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
 [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
 [JobSitePreparationAreaPreparationBarricade],
 [JobSitePreparationAreaPreparationNonEssentialEvac],
 [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
 [JobSitePreparationAreaPreparationOtherDescription],
-- [JobSitePreparationDocumentationSignageNotApplicable],
-- [JobSitePreparationDocumentationSignageBlankOrBlindList],
-- [JobSitePreparationDocumentationSignageCSEPermit],
-- [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
-- [JobSitePreparationDocumentationSignageRestrictedEntry],
-- [JobSitePreparationDocumentationSignageOtherDescription],
 [JobSitePreparationLightingElectricalRequirementNotApplicable],
 [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
 [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
 [JobSitePreparationLightingElectricalRequirementGeneratorLights],
 [JobSitePreparationLightingElectricalRequirementOtherDescription],
 [RadiationSealedSourceIsolationNotApplicable],
 [RadiationSealedSourceIsolationLOTO],
 [RadiationSealedSourceIsolationOpen],
 [RadiationSealedSourceIsolationNumberOfSources],
 [GasTestFrequencyOrDuration],
 [GasTestConstantMonitoringRequired],
 [GasTestTestTime],
 [FireConfinedSpace20ABCorDryChemicalExtinguisher],
 [FireConfinedSpaceC02Extinguisher],
 [FireConfinedSpaceFireResistantTarp],
 [FireConfinedSpaceSparkContainment],
 [FireConfinedSpaceWaterHose],
 [FireConfinedSpaceSteamHose],
 [FireConfinedSpaceWatchmen],
 [RespitoryProtectionRequirementsAirCartOrAirLine],
 [RespitoryProtectionRequirementsSCBA],
 [RespitoryProtectionRequirementsHalfFaceRespirator],
 [RespitoryProtectionRequirementsFullFaceRespirator],
 [RespitoryProtectionRequirementsDustMask],
 [RespitoryProtectionRequirementsAirHood],
 [RespitoryProtectionRequirementsOtherDescription],
 [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
 [SpecialEyeOrFaceProtectionGoggles],
 [SpecialEyeOrFaceProtectionFaceshield],
 [SpecialEyeOrFaceProtectionOtherDescription],
 [SpecialProtectiveClothingTypeRainCoat],
 [SpecialProtectiveClothingTypeRainPants],
 [SpecialProtectiveClothingTypeAcidClothing],
 [SpecialProtectiveClothingTypeAcidClothingTypeID],
 [SpecialProtectiveClothingTypeCausticWear],
 [SpecialProtectiveClothingTypeOtherDescripton],
 [SpecialProtectiveFootwearChemicalImperviousBoots],
 [SpecialProtectiveFootwearToeGuard],
 [SpecialProtectiveFootwearOtherDescription],
 [SpecialHandProtectionChemicalNeprene],
 [SpecialHandProtectionNaturalRubber],
 [SpecialHandProtectionNitrile],
 [SpecialHandProtectionPVC],
 [SpecialHandProtectionHighVoltage],
 [SpecialHandProtectionWelding],
 [SpecialHandProtectionLeather],
 [SpecialHandProtectionOtherDescription],
 [SpecialRescueOrFallBodyHarness],
 [SpecialRescueOrFallLifeline],
 [SpecialRescueOrFallYoYo],
 [SpecialRescueOrFallRescueDevice],
 [SpecialRescueOrFallOtherDescription],
 [SourceId],
 [CreatedByUserId],
 [IsOperations],
 [LastModifiedUserId],
 [LastModifiedDate],
 [Deleted],
 [StartAndOrEndTimesFinalized],
 EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
 AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
) 
values (
5,
'3.2',
@FLOC_ID,
null,
@DIVISION + '-0000000017',
'WON12345',
@START_TIME,
@END_TIME,
null,
2,
1,
'Repair pump seal and bearings',
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
--0,
null,
'Joe Shlablotnik',
null,
18,
'It is no longer used.  Once CraftOrTrade Table is ',
'Repair pump seal and bearings',
1,
null,
1,
null,
null,
0,
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
null,
1,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
1,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
1,
0,
null,
1,
0,
0,
0,
null,
1,
0,
0,
0,
null,
--1,
--0,
--0,
--0,
--0,
--null,
1,
0,
0,
0,
null,
1,
0,
0,
null,
'',
0,
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
null,
null,
0,
0,
null,
0,
0,
0,
null,
0,
null,
0,
0,
null,
0,
0,
0,
0,
0,
0,
0,
null,
0,
0,
0,
0,
null,
1,
1,
1, -- IsOperations
1,
@START_TIME,
0,
1,
1,
1,
null,
0,
0,
0,
0,
0,
0
);


select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END


insert into [WorkPermit] (
[WorkPermitStatusId],
 Version,
 [FunctionalLocationId],
 [SapOperationId],
 [PermitNumber], 
 [WorkOrderNumber],
 [StartDateTime],
 [EndDateTime],
 [PermitValidDateTime],
 [WorkPermitTypeId],
 [WorkPermitTypeClassificationId],
 [WorkOrderDescription], 
 [SpecialPrecautionsOrConsiderationsDescription],
 [PermitConfinedSpaceEntry],
 [PermitBreathingAirOrSCBA],
 [PermitElectricalSwitching],
 [PermitVehicleEntry],
 [PermitHotTap],
 [PermitBurnOrOpenFlame],
 [PermitSystemEntry],
 [PermitCriticalLift],
 [PermitEnergizedElectrical],
 [PermitExcavation],
 [PermitAsbestos],
 [PermitRadiationRadiography],
 [PermitRadiationSealed],
 [AdditionalCSEAssessmentOrAuthorization],
 [AdditionalFlareEntry],
 [AdditionalCriticalLift],
 [AdditionalExcavation],
 [AdditionalHotTap],
 [AdditionalSpecialWasteDisposal],
 [AdditionalBlankOrBlindLists],
 [AdditionalPJSROrSafetyPause],
 [AdditionalAsbestosHandling],
 [AdditionalRoadClosure],
 [AdditionalElectrical],
 [AdditionalBurnOrOpenFlameAssessment],
 [AdditionalWaiverOrDeviation],
 [AdditionalMSDS],
 [AdditionalRadiationApproval],
 [AdditionalOnlineLeakRepairForm],
-- [AdditionalLOTOLog],
 [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
 [ContactPersonnel],
 [ContractorCompanyName],
 [CraftOrTradeID],
 [CraftOrTradeOther],
 [JobStepDescription], 
 [CommunicationByRadio],
 [CommunicationRadioChannelOrBand],
 [IsWorkPermitCommunicationNotApplicable],
 [CommunicationRadioColor],
 [CommunicationByOtherDescription],
 [CoAuthorizationRequired],
 [CoAuthorizationDescription],
 [ToolsAirTools],
 [ToolsCraneOrCarrydeck],
 [ToolsHandTools],
 [ToolsJackhammer],
 [ToolsVacuumTruck],
 [ToolsCementSaw],
 [ToolsElectricTools],
 [ToolsHeavyEquipment],
 [ToolsLanda],
 [ToolsScaffolding],
 [ToolsVehicle],
 [ToolsCompressor],
 [ToolsForklift],
 [ToolsHEPAVacuum],
 [ToolsManlift],
 [ToolsTamper],
 [ToolsHotTapMachine],
 [ToolsPortLighting],
 [ToolsTorch],
 [ToolsWelder],
 [ToolsOtherToolsDescription],
 [ElectricIsolationMethodNotApplicable],
 [ElectricIsolationMethodLOTO],
 [ElectricIsolationMethodWiring],
 [ElectricTestBumpNotApplicable],
 [ElectricTestBump],
 [EquipmentNoElectricalTestBumpComments],
 [EquipmentStillContainsResidualNotApplicable],
 [EquipmentStillContainsResidual],
 [EquipmentStillContainsResidualComments],
 [EquipmentLeakingValvesNotApplicable],
 [EquipmentLeakingValves],
 [EquipmentLeakingValvesComments],
 [EquipmentIsOutOfService],
 [EquipmentInServiceComments],
 [EquipmentConditionNotApplicable],
 [EquipmentConditionDepressured],
 [EquipmentConditionDrained],
 [EquipmentConditionCleaned],
 [EquipmentConditionVentilated],
 [EquipmentConditionH20Washed],
 [EquipmentConditionNeutralized],
 [EquipmentConditionPurged],
 [EquipmentConditionPurgedDescription],
 [EquipmentPreviousContentsNotApplicable],
 [EquipmentPreviousContentsHydrocarbon],
 [EquipmentPreviousContentsAcid],
 [EquipmentPreviousContentsCaustic],
 [EquipmentPreviousContentsH2S],
 [EquipmentPreviousContentsOtherDescription],
 [EquipmentIsolationMethodNotApplicable],
 [EquipmentIsolationMethodBlindedorBlanked],
 [EquipmentIsolationMethodBlockedIn],
 [EquipmentIsolationMethodSeparation],
 [EquipmentIsolationMethodMudderPlugs],
 [EquipmentIsolationMethodLOTO],
 [EquipmentIsolationMethodOtherDescription],
 [EquipmentVentilationMethodNotApplicable],
 [EquipmentVentilationMethodNaturalDraft],
 [EquipmentVentilationMethodLocalExhaust],
 [EquipmentVentilationMethodForced],
[JobSitePreparationFlowRequiredForJob],
 [JobSitePreparationFlowRequiredForJobNotApplicable],
 [JobSitePreparationFlowRequiredComments],
 [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
 [JobSitePreparationBondingOrGroundingRequired],
 [JobSitePreparationBondingGroundingNotRequiredComments],
 [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
 [JobSitePreparationWeldingGroundWireInTestArea],
 [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
 [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
 [JobSitePreparationCriticalConditionRemainJobSite],
 [JobSitePreparationCriticalConditionsComments],
 [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
 [JobSitePreparationSurroundingConditionsAffectOrContaminated],
 [JobSitePreparationSurroundingConditionsAffectAreaComments],
 [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
 [JobSitePreparationVestedBuddySystemInEffect],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
 [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
 [JobSitePreparationPermitReceiverRequiresOrientationComments],
 [JobSitePreparationSewerIsolationMethodNotApplicable],
 [JobSitePreparationSewerIsolationMethodSealedOrCovered],
 [JobSitePreparationSewerIsolationMethodPlugged],
 [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
 [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
 [JobSitePreparationAreaPreparationBarricade],
 [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
 [JobSitePreparationAreaPreparationOtherDescription],
-- [JobSitePreparationDocumentationSignageNotApplicable],
-- [JobSitePreparationDocumentationSignageBlankOrBlindList],
-- [JobSitePreparationDocumentationSignageCSEPermit],
-- [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
-- [JobSitePreparationDocumentationSignageRestrictedEntry],
-- [JobSitePreparationDocumentationSignageOtherDescription],
 [JobSitePreparationLightingElectricalRequirementNotApplicable],
 [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
 [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
 [JobSitePreparationLightingElectricalRequirementGeneratorLights],
 [JobSitePreparationLightingElectricalRequirementOtherDescription],
 [RadiationSealedSourceIsolationNotApplicable],
 [RadiationSealedSourceIsolationLOTO],
 [RadiationSealedSourceIsolationOpen],
 [RadiationSealedSourceIsolationNumberOfSources],
 [GasTestFrequencyOrDuration],
 [GasTestConstantMonitoringRequired],
 [GasTestTestTime],
 [FireConfinedSpace20ABCorDryChemicalExtinguisher],
 [FireConfinedSpaceC02Extinguisher],
 [FireConfinedSpaceFireResistantTarp],
 [FireConfinedSpaceSparkContainment],
 [FireConfinedSpaceWaterHose],
 [FireConfinedSpaceSteamHose],
 [FireConfinedSpaceWatchmen],
 [FireConfinedSpaceOtherDescription],
 [RespitoryProtectionRequirementsAirCartOrAirLine],
 [RespitoryProtectionRequirementsSCBA],
 [RespitoryProtectionRequirementsHalfFaceRespirator],
 [RespitoryProtectionRequirementsFullFaceRespirator],
 [RespitoryProtectionRequirementsDustMask],
 [RespitoryProtectionRequirementsAirHood],
 [RespitoryProtectionRequirementsOtherDescription],
 [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
 [SpecialEyeOrFaceProtectionGoggles],
 [SpecialEyeOrFaceProtectionFaceshield],
 [SpecialEyeOrFaceProtectionOtherDescription],
 [SpecialProtectiveClothingTypeRainCoat],
 [SpecialProtectiveClothingTypeRainPants],
 [SpecialProtectiveClothingTypeAcidClothing],
 [SpecialProtectiveClothingTypeAcidClothingTypeID],
 [SpecialProtectiveClothingTypeCausticWear],
 [SpecialProtectiveClothingTypeOtherDescripton],
 [SpecialProtectiveFootwearChemicalImperviousBoots],
 [SpecialProtectiveFootwearToeGuard],
 [SpecialProtectiveFootwearOtherDescription],
 [SpecialHandProtectionChemicalNeprene],
 [SpecialHandProtectionNaturalRubber],
 [SpecialHandProtectionNitrile],
 [SpecialHandProtectionPVC],
 [SpecialHandProtectionHighVoltage],
 [SpecialHandProtectionWelding],
 [SpecialHandProtectionLeather],
 [SpecialHandProtectionOtherDescription],
 [SpecialRescueOrFallBodyHarness],
 [SpecialRescueOrFallLifeline],
 [SpecialRescueOrFallYoYo],
 [SpecialRescueOrFallRescueDevice],
 [SpecialRescueOrFallOtherDescription],
 [SourceId],
 [CreatedByUserId],
 [IsOperations],
 [LastModifiedUserId],
 [LastModifiedDate],
 [Deleted],
 [StartAndOrEndTimesFinalized],
 EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
 AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
) 
values (
1,
'3.2',
@FLOC_ID,
null,
@DIVISION + '-0000000018',
'WON12345',
@START_TIME2,
@END_TIME2,
null,
2,
2,
'Repair pump seal and bearings',
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
--0,
null,
'Mike MacNeil',
null,
15,
'It is no longer used.  Once CraftOrTrade Table is ',
'Remove insulation',
1,
null,
1,
null,
null,
0,
null,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
null,
1,
0,
0,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
0,
null,
1,
0,
0,
0,
0,
1,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
null,
1,
0,
1,
0,
null,
1,
0,
0,
0,
null,
1,
0,
0,
0,
null,
--1,
--0,
--0,
--0,
--0,
--null,
1,
0,
0,
0,
null,
1,
0,
0,
null,
'',
0,
null,
0,
0,
0,
0,
0,
0,
0,
null,
0,
0,
0,
0,
0,
0,
null,
null,
0,
0,
null,
0,
0,
0,
null,
0,
null,
0,
0,
null,
0,
0,
0,
0,
0,
0,
0,
null,
0,
0,
0,
0,
null,
0,
1,
1, -- IsOperations
1,
@START_TIME2,
0,
1,
1,
1,
null,
0,
0,
0,
0,
0,
0
);

select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
END
    

END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;
GO

--
-- Additional work permits requested by the training ladies
--
DECLARE @FLOC_ID BIGINT;
DECLARE @WP_ID BIGINT;

DECLARE @START_TIME AS DATETIME;
DECLARE @END_TIME AS DATETIME;

DECLARE @START_TIME2 AS DATETIME;
DECLARE @END_TIME2 AS DATETIME;

DECLARE @DIVISION AS VARCHAR(3);

SET @START_TIME = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' 23:00:00.000');
SET @END_TIME = DATEADD(dd, 1, CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' 00:00:00.000'));

SET @START_TIME2 = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' 17:00:00.000');
SET @END_TIME2 = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' 18:00:00.000');

DECLARE FLOC_ID_CURSOR CURSOR
FOR
  SELECT Id FROM FunctionalLocation
  WHERE 
  (
			FullHierarchy like 'SR1-PLT2-%'
			or
			FullHierarchy like 'SR1-PLT3-%'
			or
			FullHierarchy like 'DN1-3003-%'
		)
		and [Level] = 3
		and (SiteId = 1 or SiteId = 2);
OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

WHILE (@@FETCH_STATUS <> -1)
BEGIN
   IF (@@FETCH_STATUS <> -2)
   BEGIN
   
select @DIVISION = COALESCE(fa.FullHierarchy, f.FullHierarchy)
		from
			FunctionalLocation f
			LEFT OUTER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 1
			LEFT OUTER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
		where
			f.Id = @FLOC_ID;

insert into WorkPermit (
  [WorkPermitStatusId],
  Version,
  [CoAuthorizationDescription],
  [ToolsAirTools],
  [ToolsCraneOrCarrydeck],
  [ToolsHandTools],
  [ToolsJackhammer],
  [ToolsVacuumTruck],
  [ToolsCementSaw],
  [ToolsElectricTools],
  [ToolsHeavyEquipment],
  [ToolsLanda],
  [ToolsScaffolding],
  [ToolsVehicle],
  [ToolsCompressor],
  [ToolsForklift],
  [ToolsHEPAVacuum],
  [ToolsManlift],
  [ToolsTamper],
  [ToolsHotTapMachine],
  [ToolsPortLighting],
  [ToolsTorch],
  [ToolsWelder],
  [ToolsOtherToolsDescription],
  [ElectricIsolationMethodNotApplicable],
  [ElectricIsolationMethodLOTO],
  [ElectricIsolationMethodWiring],
  [ElectricTestBumpNotApplicable],
  [ElectricTestBump],
  [EquipmentNoElectricalTestBumpComments],
  [EquipmentStillContainsResidualNotApplicable],
  [EquipmentStillContainsResidual],
  [EquipmentStillContainsResidualComments],
  [EquipmentLeakingValvesNotApplicable],
  [EquipmentLeakingValves],
  [EquipmentLeakingValvesComments],
  [EquipmentIsOutOfService],
  [EquipmentInServiceComments],
  [EquipmentConditionNotApplicable],
  [EquipmentConditionDepressured],
  [EquipmentConditionDrained],
  [EquipmentConditionCleaned],
  [EquipmentConditionVentilated],
  [EquipmentConditionH20Washed],
  [EquipmentConditionNeutralized],
  [EquipmentConditionPurged],
  [EquipmentConditionPurgedDescription],
  [EquipmentPreviousContentsNotApplicable],
  [EquipmentPreviousContentsHydrocarbon],
  [EquipmentPreviousContentsAcid],
  [EquipmentPreviousContentsCaustic],
  [EquipmentPreviousContentsH2S],
  [EquipmentPreviousContentsOtherDescription],
  [EquipmentIsolationMethodNotApplicable],
  [EquipmentIsolationMethodBlindedorBlanked],
  [EquipmentIsolationMethodBlockedIn],
  [EquipmentIsolationMethodSeparation],
  [EquipmentIsolationMethodMudderPlugs],
  [EquipmentIsolationMethodLOTO],
  [EquipmentIsolationMethodOtherDescription],
  [EquipmentVentilationMethodNotApplicable],
  [EquipmentVentilationMethodNaturalDraft],
  [EquipmentVentilationMethodLocalExhaust],
  [EquipmentVentilationMethodForced],
  [JobSitePreparationFlowRequiredForJob],
  [JobSitePreparationFlowRequiredForJobNotApplicable],
  [JobSitePreparationFlowRequiredComments],
  [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
  [JobSitePreparationBondingOrGroundingRequired],
  [JobSitePreparationBondingGroundingNotRequiredComments],
  [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
  [JobSitePreparationWeldingGroundWireInTestArea],
  [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
  [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
  [JobSitePreparationCriticalConditionRemainJobSite],
  [JobSitePreparationCriticalConditionsComments],
  [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
  [JobSitePreparationSurroundingConditionsAffectOrContaminated],
  [JobSitePreparationSurroundingConditionsAffectAreaComments],
  [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
  [JobSitePreparationVestedBuddySystemInEffect],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
  [JobSitePreparationPermitReceiverRequiresOrientationComments],
  [JobSitePreparationSewerIsolationMethodNotApplicable],
  [JobSitePreparationSewerIsolationMethodSealedOrCovered],
  [JobSitePreparationSewerIsolationMethodPlugged],
  [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
  [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
  [JobSitePreparationAreaPreparationBarricade],
  [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
  [JobSitePreparationAreaPreparationOtherDescription],
--  [JobSitePreparationDocumentationSignageNotApplicable],
--  [JobSitePreparationDocumentationSignageBlankOrBlindList],
--  [JobSitePreparationDocumentationSignageCSEPermit],
--  [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
--  [JobSitePreparationDocumentationSignageRestrictedEntry],
--  [JobSitePreparationDocumentationSignageOtherDescription],
  [JobSitePreparationLightingElectricalRequirementNotApplicable],
  [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
  [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
  [JobSitePreparationLightingElectricalRequirementGeneratorLights],
  [JobSitePreparationLightingElectricalRequirementOtherDescription],
  [RadiationSealedSourceIsolationNotApplicable],
  [RadiationSealedSourceIsolationLOTO],
  [RadiationSealedSourceIsolationOpen],
  [RadiationSealedSourceIsolationNumberOfSources],
  [GasTestFrequencyOrDuration],
  [GasTestConstantMonitoringRequired],
  [GasTestTestTime],
  [FireConfinedSpace20ABCorDryChemicalExtinguisher],
  [FireConfinedSpaceC02Extinguisher],
  [FireConfinedSpaceFireResistantTarp],
  [FireConfinedSpaceSparkContainment],
  [FireConfinedSpaceWaterHose],
  [FireConfinedSpaceSteamHose],
  [FireConfinedSpaceWatchmen],
  [FireConfinedSpaceOtherDescription],
  [RespitoryProtectionRequirementsAirCartOrAirLine],
  [RespitoryProtectionRequirementsSCBA],
  [RespitoryProtectionRequirementsHalfFaceRespirator],
  [RespitoryProtectionRequirementsFullFaceRespirator],
  [RespitoryProtectionRequirementsDustMask],
  [RespitoryProtectionRequirementsAirHood],
  [RespitoryProtectionRequirementsOtherDescription],
  [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
  [SpecialEyeOrFaceProtectionGoggles],
  [SpecialEyeOrFaceProtectionFaceshield],
  [SpecialEyeOrFaceProtectionOtherDescription],
  [SpecialProtectiveClothingTypeRainCoat],
  [SpecialProtectiveClothingTypeRainPants],
  [SpecialProtectiveClothingTypeAcidClothing],
  [SpecialProtectiveClothingTypeAcidClothingTypeID],
  [SpecialProtectiveClothingTypeCausticWear],
  [SpecialProtectiveClothingTypeOtherDescripton],
  [SpecialProtectiveFootwearChemicalImperviousBoots],
  [SpecialProtectiveFootwearToeGuard],
  [SpecialProtectiveFootwearOtherDescription],
  [SpecialHandProtectionChemicalNeprene],
  [SpecialHandProtectionNaturalRubber],
  [SpecialHandProtectionNitrile],
  [SpecialHandProtectionPVC],
  [SpecialHandProtectionHighVoltage],
  [SpecialHandProtectionWelding],
  [SpecialHandProtectionLeather],
  [SpecialHandProtectionOtherDescription],
  [SpecialRescueOrFallBodyHarness],
  [SpecialRescueOrFallLifeline],
  [SpecialRescueOrFallYoYo],
  [SpecialRescueOrFallRescueDevice],
  [SpecialRescueOrFallOtherDescription],
  [SourceId],
  [CreatedByUserId],
  [IsOperations],
  [LastModifiedUserId],
  [LastModifiedDate],
  [ApprovedByUserId],
  [Deleted],
  [FunctionalLocationId],
  [SapOperationId],
  [PermitNumber],
  [WorkOrderNumber],
  [StartDateTime],
  [EndDateTime],
  [PermitValidDateTime],
  [WorkPermitTypeId],
  [WorkPermitTypeClassificationId],
  [WorkOrderDescription],
  [SpecialPrecautionsOrConsiderationsDescription],
  [PermitConfinedSpaceEntry],
  [PermitBreathingAirOrSCBA],
  [PermitElectricalSwitching],
  [PermitVehicleEntry],
  [PermitHotTap],
  [PermitBurnOrOpenFlame],
  [PermitSystemEntry],
  [PermitCriticalLift],
  [PermitEnergizedElectrical],
  [PermitExcavation],
  [PermitAsbestos],
  [PermitRadiationRadiography],
  [PermitRadiationSealed],
  [AdditionalCSEAssessmentOrAuthorization],
  [AdditionalFlareEntry],
  [AdditionalCriticalLift],
  [AdditionalExcavation],
  [AdditionalHotTap],
  [AdditionalSpecialWasteDisposal],
  [AdditionalBlankOrBlindLists],
  [AdditionalPJSROrSafetyPause],
  [AdditionalAsbestosHandling],
  [AdditionalRoadClosure],
  [AdditionalElectrical],
  [AdditionalBurnOrOpenFlameAssessment],
  [AdditionalWaiverOrDeviation],
  [AdditionalMSDS],
  [AdditionalRadiationApproval],
  [AdditionalOnlineLeakRepairForm],
  [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
  [ContactPersonnel],
  [ContractorCompanyName],
  [CraftOrTradeID],
  [CraftOrTradeOther],
  [JobStepDescription],
  [CommunicationByRadio],
  [CommunicationRadioChannelOrBand],
  [IsWorkPermitCommunicationNotApplicable],
  [CommunicationRadioColor],
  [CommunicationByOtherDescription],
  [CoAuthorizationRequired],
  [StartAndOrEndTimesFinalized],
  EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
  AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
)
values (
  1,   -- WorkPermitStatusId
  '3.2',
  NULL,   -- CoAuthorizationDescription
  0,   -- ToolsAirTools
  0,   -- ToolsCraneOrCarrydeck
  0,   -- ToolsHandTools
  0,   -- ToolsJackhammer
  0,   -- ToolsVacuumTruck
  0,   -- ToolsCementSaw
  0,   -- ToolsElectricTools
  0,   -- ToolsHeavyEquipment
  0,   -- ToolsLanda
  0,   -- ToolsScaffolding
  0,   -- ToolsVehicle
  0,   -- ToolsCompressor
  0,   -- ToolsForklift
  0,   -- ToolsHEPAVacuum
  0,   -- ToolsManlift
  0,   -- ToolsTamper
  0,   -- ToolsHotTapMachine
  0,   -- ToolsPortLighting
  0,   -- ToolsTorch
  0,   -- ToolsWelder
  NULL,   -- ToolsOtherToolsDescription
  1,   -- ElectricIsolationMethodNotApplicable
  0,   -- ElectricIsolationMethodLOTO
  0,   -- ElectricIsolationMethodWiring
  1,   -- ElectricTestBumpNotApplicable
  0,   -- ElectricTestBump
  NULL,   -- EquipmentNoElectricalTestBumpComments
  1,   -- EquipmentStillContainsResidualNotApplicable
  0,   -- EquipmentStillContainsResidual
  NULL,   -- EquipmentStillContainsResidualComments
  1,   -- EquipmentLeakingValvesNotApplicable
  0,   -- EquipmentLeakingValves
  NULL,   -- EquipmentLeakingValvesComments
  1,   -- EquipmentIsOutOfService
  NULL,   -- EquipmentInServiceComments
  1,   -- EquipmentConditionNotApplicable
  0,   -- EquipmentConditionDepressured
  0,   -- EquipmentConditionDrained
  0,   -- EquipmentConditionCleaned
  0,   -- EquipmentConditionVentilated
  0,   -- EquipmentConditionH20Washed
  0,   -- EquipmentConditionNeutralized
  0,   -- EquipmentConditionPurged
  NULL,   -- EquipmentConditionPurgedDescription
  1,   -- EquipmentPreviousContentsNotApplicable
  0,   -- EquipmentPreviousContentsHydrocarbon
  0,   -- EquipmentPreviousContentsAcid
  0,   -- EquipmentPreviousContentsCaustic
  0,   -- EquipmentPreviousContentsH2S
  NULL,   -- EquipmentPreviousContentsOtherDescription
  1,   -- EquipmentIsolationMethodNotApplicable
  0,   -- EquipmentIsolationMethodBlindedorBlanked
  0,   -- EquipmentIsolationMethodBlockedIn
  0,   -- EquipmentIsolationMethodSeparation
  0,   -- EquipmentIsolationMethodMudderPlugs
  0,   -- EquipmentIsolationMethodLOTO
  NULL,   -- EquipmentIsolationMethodOtherDescription
  1,   -- EquipmentVentilationMethodNotApplicable
  0,   -- EquipmentVentilationMethodNaturalDraft
  0,   -- EquipmentVentilationMethodLocalExhaust
  0,   -- EquipmentVentilationMethodForced
  0,   -- JobSitePreparationFlowRequiredForJob
  1,   -- JobSitePreparationFlowRequiredForJobNotApplicable
  NULL,   -- JobSitePreparationFlowRequiredComments
  1,   -- JobSitePreparationBondingOrGroundingRequiredNotApplicable
  0,   -- JobSitePreparationBondingOrGroundingRequired
  NULL,   -- JobSitePreparationBondingGroundingNotRequiredComments
  1,   -- JobSitePreparationWeldingGroundWireInTestAreaNotApplicable
  0,   -- JobSitePreparationWeldingGroundWireInTestArea
  NULL,   -- JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments
  1,   -- JobSitePreparationCriticalConditionRemainJobSiteNotApplicable
  0,   -- JobSitePreparationCriticalConditionRemainJobSite
  NULL,   -- JobSitePreparationCriticalConditionsComments
  1,   -- JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable
  0,   -- JobSitePreparationSurroundingConditionsAffectOrContaminated
  NULL,   -- JobSitePreparationSurroundingConditionsAffectAreaComments
  1,   -- JobSitePreparationVestedBuddySystemInEffectNotApplicable
  0,   -- JobSitePreparationVestedBuddySystemInEffect
  1,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable
  0,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientation
  NULL,   -- JobSitePreparationPermitReceiverRequiresOrientationComments
  1,   -- JobSitePreparationSewerIsolationMethodNotApplicable
  0,   -- JobSitePreparationSewerIsolationMethodSealedOrCovered
  0,   -- JobSitePreparationSewerIsolationMethodPlugged
  0,   -- JobSitePreparationSewerIsolationMethodBlindedOrBlanked
  NULL,   -- JobSitePreparationSewerIsolationMethodOtherDescription
  1,   -- JobSitePreparationAreaPreparationNotApplicable
  0,   -- JobSitePreparationAreaPreparationBarricade
  0,   -- JobSitePreparationAreaPreparationNonEssentialEvac
  0,   -- JobSitePreparationAreaPreparationPreopBoundaryRopeTape
  NULL,   -- JobSitePreparationAreaPreparationOtherDescription
--  1,   -- JobSitePreparationDocumentationSignageNotApplicable
--  0,   -- JobSitePreparationDocumentationSignageBlankOrBlindList
--  0,   -- JobSitePreparationDocumentationSignageCSEPermit
--  0,   -- JobSitePreparationDocumentationSignageVesselPreparedForOpening
--  0,   -- JobSitePreparationDocumentationSignageRestrictedEntry
--  NULL,   -- JobSitePreparationDocumentationSignageOtherDescription
  1,   -- JobSitePreparationLightingElectricalRequirementNotApplicable
  0,   -- JobSitePreparationLightingElectricalRequirementLowVoltage12V
  0,   -- JobSitePreparationLightingElectricalRequirement110VWithGFCI
  0,   -- JobSitePreparationLightingElectricalRequirementGeneratorLights
  NULL,   -- JobSitePreparationLightingElectricalRequirementOtherDescription
  1,   -- RadiationSealedSourceIsolationNotApplicable
  0,   -- RadiationSealedSourceIsolationLOTO
  0,   -- RadiationSealedSourceIsolationOpen
  NULL,   -- RadiationSealedSourceIsolationNumberOfSources
  '',   -- GasTestFrequencyOrDuration
  0,   -- GasTestConstantMonitoringRequired
  NULL,   -- GasTestTestTime
  0,   -- FireConfinedSpace20ABCorDryChemicalExtinguisher
  0,   -- FireConfinedSpaceC02Extinguisher
  0,   -- FireConfinedSpaceFireResistantTarp
  0,   -- FireConfinedSpaceSparkContainment
  0,   -- FireConfinedSpaceWaterHose
  0,   -- FireConfinedSpaceSteamHose
  0,   -- FireConfinedSpaceWatchmen
  NULL,   -- FireConfinedSpaceOtherDescription
  0,   -- RespitoryProtectionRequirementsAirCartOrAirLine
  0,   -- RespitoryProtectionRequirementsSCBA
  0,   -- RespitoryProtectionRequirementsHalfFaceRespirator
  0,   -- RespitoryProtectionRequirementsFullFaceRespirator
  0,   -- RespitoryProtectionRequirementsDustMask
  0,   -- RespitoryProtectionRequirementsAirHood
  NULL,   -- RespitoryProtectionRequirementsOtherDescription
  NULL,   -- RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription
  0,   -- SpecialEyeOrFaceProtectionGoggles
  0,   -- SpecialEyeOrFaceProtectionFaceshield
  NULL,   -- SpecialEyeOrFaceProtectionOtherDescription
  0,   -- SpecialProtectiveClothingTypeRainCoat
  0,   -- SpecialProtectiveClothingTypeRainPants
  0,   -- SpecialProtectiveClothingTypeAcidClothing
  NULL,   -- SpecialProtectiveClothingTypeAcidClothingTypeID
  0,   -- SpecialProtectiveClothingTypeCausticWear
  NULL,   -- SpecialProtectiveClothingTypeOtherDescripton
  0,   -- SpecialProtectiveFootwearChemicalImperviousBoots
  0,   -- SpecialProtectiveFootwearToeGuard
  NULL,   -- SpecialProtectiveFootwearOtherDescription
  0,   -- SpecialHandProtectionChemicalNeprene
  0,   -- SpecialHandProtectionNaturalRubber
  0,   -- SpecialHandProtectionNitrile
  0,   -- SpecialHandProtectionPVC
  0,   -- SpecialHandProtectionHighVoltage
  0,   -- SpecialHandProtectionWelding
  0,   -- SpecialHandProtectionLeather
  NULL,   -- SpecialHandProtectionOtherDescription
  0,   -- SpecialRescueOrFallBodyHarness
  0,   -- SpecialRescueOrFallLifeline
  0,   -- SpecialRescueOrFallYoYo
  0,   -- SpecialRescueOrFallRescueDevice
  NULL,   -- SpecialRescueOrFallOtherDescription
  0,   -- SourceId
  1,   -- CreatedByUserId
  1,   -- IsOperations
  1,   -- LastModifiedUserId
  @START_TIME,  -- LastModifiedDate
  NULL,   -- ApprovedByUserId
  0,   -- Deleted
  @FLOC_ID,   -- FunctionalLocationId
  NULL,   -- SapOperationId
  @DIVISION + '-0000000076',   -- PermitNumber
  'WON59785',   -- WorkOrderNumber
  @START_TIME,  -- StartDateTime
  @END_TIME,  -- EndDateTime
  NULL,   -- PermitValidDateTime
  2,   -- WorkPermitTypeId
  1,   -- WorkPermitTypeClassificationId
  'Repair pump seal and bearings',   -- WorkOrderDescription
  NULL,   -- SpecialPrecautionsOrConsiderationsDescription
  0,   -- PermitConfinedSpaceEntry
  0,   -- PermitBreathingAirOrSCBA
  0,   -- PermitElectricalSwitching
  0,   -- PermitVehicleEntry
  0,   -- PermitHotTap
  0,   -- PermitBurnOrOpenFlame
  0,   -- PermitSystemEntry
  0,   -- PermitCriticalLift
  0,   -- PermitEnergizedElectrical
  0,   -- PermitExcavation
  0,   -- PermitAsbestos
  0,   -- PermitRadiationRadiography
  0,   -- PermitRadiationSealed
  0,   -- AdditionalCSEAssessmentOrAuthorization
  0,   -- AdditionalFlareEntry
  0,   -- AdditionalCriticalLift
  0,   -- AdditionalExcavation
  0,   -- AdditionalHotTap
  0,   -- AdditionalSpecialWasteDisposal
  0,   -- AdditionalBlankOrBlindLists
  0,   -- AdditionalPJSROrSafetyPause
  0,   -- AdditionalAsbestosHandling
  0,   -- AdditionalRoadClosure
  0,   -- AdditionalElectrical
  0,   -- AdditionalBurnOrOpenFlameAssessment
  0,   -- AdditionalWaiverOrDeviation
  0,   -- AdditionalMSDS
  0,   -- AdditionalRadiationApproval
  0,   -- AdditionalOnlineLeakRepairForm
  NULL,   -- AdditionalOtherFormsOrAssessmentsOrAuthorizations
  NULL,   -- ContactPersonnel
  NULL,   -- ContractorCompanyName
  23,   -- CraftOrTradeID
  'It is no longer used.  Once CraftOrTrade Table is ',   -- CraftOrTradeOther
  'Install blanks',   -- JobStepDescription
  1,   -- CommunicationByRadio
  NULL,   -- CommunicationRadioChannelOrBand
  1,   -- IsWorkPermitCommunicationNotApplicable
  NULL,   -- CommunicationRadioColor
  NULL,   -- CommunicationByOtherDescription
  0,   -- CoAuthorizationRequired
  1,    -- StartAndOrEndTimesFinalized
  1,
  1,
null,
0,
0,
0,
0,
0,
0
);

select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END

insert into WorkPermit (
  [WorkPermitStatusId],
  Version,
  [CoAuthorizationDescription],
  [ToolsAirTools],
  [ToolsCraneOrCarrydeck],
  [ToolsHandTools],
  [ToolsJackhammer],
  [ToolsVacuumTruck],
  [ToolsCementSaw],
  [ToolsElectricTools],
  [ToolsHeavyEquipment],
  [ToolsLanda],
  [ToolsScaffolding],
  [ToolsVehicle],
  [ToolsCompressor],
  [ToolsForklift],
  [ToolsHEPAVacuum],
  [ToolsManlift],
  [ToolsTamper],
  [ToolsHotTapMachine],
  [ToolsPortLighting],
  [ToolsTorch],
  [ToolsWelder],
  [ToolsOtherToolsDescription],
  [ElectricIsolationMethodNotApplicable],
  [ElectricIsolationMethodLOTO],
  [ElectricIsolationMethodWiring],
  [ElectricTestBumpNotApplicable],
  [ElectricTestBump],
  [EquipmentNoElectricalTestBumpComments],
  [EquipmentStillContainsResidualNotApplicable],
  [EquipmentStillContainsResidual],
  [EquipmentStillContainsResidualComments],
  [EquipmentLeakingValvesNotApplicable],
  [EquipmentLeakingValves],
  [EquipmentLeakingValvesComments],
  [EquipmentIsOutOfService],
  [EquipmentInServiceComments],
  [EquipmentConditionNotApplicable],
  [EquipmentConditionDepressured],
  [EquipmentConditionDrained],
  [EquipmentConditionCleaned],
  [EquipmentConditionVentilated],
  [EquipmentConditionH20Washed],
  [EquipmentConditionNeutralized],
  [EquipmentConditionPurged],
  [EquipmentConditionPurgedDescription],
  [EquipmentPreviousContentsNotApplicable],
  [EquipmentPreviousContentsHydrocarbon],
  [EquipmentPreviousContentsAcid],
  [EquipmentPreviousContentsCaustic],
  [EquipmentPreviousContentsH2S],
  [EquipmentPreviousContentsOtherDescription],
  [EquipmentIsolationMethodNotApplicable],
  [EquipmentIsolationMethodBlindedorBlanked],
  [EquipmentIsolationMethodBlockedIn],
  [EquipmentIsolationMethodSeparation],
  [EquipmentIsolationMethodMudderPlugs],
  [EquipmentIsolationMethodLOTO],
  [EquipmentIsolationMethodOtherDescription],
  [EquipmentVentilationMethodNotApplicable],
  [EquipmentVentilationMethodNaturalDraft],
  [EquipmentVentilationMethodLocalExhaust],
  [EquipmentVentilationMethodForced],
  [JobSitePreparationFlowRequiredForJob],
  [JobSitePreparationFlowRequiredForJobNotApplicable],
  [JobSitePreparationFlowRequiredComments],
  [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
  [JobSitePreparationBondingOrGroundingRequired],
  [JobSitePreparationBondingGroundingNotRequiredComments],
  [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
  [JobSitePreparationWeldingGroundWireInTestArea],
  [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
  [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
  [JobSitePreparationCriticalConditionRemainJobSite],
  [JobSitePreparationCriticalConditionsComments],
  [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
  [JobSitePreparationSurroundingConditionsAffectOrContaminated],
  [JobSitePreparationSurroundingConditionsAffectAreaComments],
  [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
  [JobSitePreparationVestedBuddySystemInEffect],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
  [JobSitePreparationPermitReceiverRequiresOrientationComments],
  [JobSitePreparationSewerIsolationMethodNotApplicable],
  [JobSitePreparationSewerIsolationMethodSealedOrCovered],
  [JobSitePreparationSewerIsolationMethodPlugged],
  [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
  [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
  [JobSitePreparationAreaPreparationBarricade],
  [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
  [JobSitePreparationAreaPreparationOtherDescription],
--  [JobSitePreparationDocumentationSignageNotApplicable],
--  [JobSitePreparationDocumentationSignageBlankOrBlindList],
--  [JobSitePreparationDocumentationSignageCSEPermit],
--  [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
--  [JobSitePreparationDocumentationSignageRestrictedEntry],
--  [JobSitePreparationDocumentationSignageOtherDescription],
  [JobSitePreparationLightingElectricalRequirementNotApplicable],
  [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
  [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
  [JobSitePreparationLightingElectricalRequirementGeneratorLights],
  [JobSitePreparationLightingElectricalRequirementOtherDescription],
  [RadiationSealedSourceIsolationNotApplicable],
  [RadiationSealedSourceIsolationLOTO],
  [RadiationSealedSourceIsolationOpen],
  [RadiationSealedSourceIsolationNumberOfSources],
  [GasTestFrequencyOrDuration],
  [GasTestConstantMonitoringRequired],
  [GasTestTestTime],
  [FireConfinedSpace20ABCorDryChemicalExtinguisher],
  [FireConfinedSpaceC02Extinguisher],
  [FireConfinedSpaceFireResistantTarp],
  [FireConfinedSpaceSparkContainment],
  [FireConfinedSpaceWaterHose],
  [FireConfinedSpaceSteamHose],
  [FireConfinedSpaceWatchmen],
  [FireConfinedSpaceOtherDescription],
  [RespitoryProtectionRequirementsAirCartOrAirLine],
  [RespitoryProtectionRequirementsSCBA],
  [RespitoryProtectionRequirementsHalfFaceRespirator],
  [RespitoryProtectionRequirementsFullFaceRespirator],
  [RespitoryProtectionRequirementsDustMask],
  [RespitoryProtectionRequirementsAirHood],
  [RespitoryProtectionRequirementsOtherDescription],
  [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
  [SpecialEyeOrFaceProtectionGoggles],
  [SpecialEyeOrFaceProtectionFaceshield],
  [SpecialEyeOrFaceProtectionOtherDescription],
  [SpecialProtectiveClothingTypeRainCoat],
  [SpecialProtectiveClothingTypeRainPants],
  [SpecialProtectiveClothingTypeAcidClothing],
  [SpecialProtectiveClothingTypeAcidClothingTypeID],
  [SpecialProtectiveClothingTypeCausticWear],
  [SpecialProtectiveClothingTypeOtherDescripton],
  [SpecialProtectiveFootwearChemicalImperviousBoots],
  [SpecialProtectiveFootwearToeGuard],
  [SpecialProtectiveFootwearOtherDescription],
  [SpecialHandProtectionChemicalNeprene],
  [SpecialHandProtectionNaturalRubber],
  [SpecialHandProtectionNitrile],
  [SpecialHandProtectionPVC],
  [SpecialHandProtectionHighVoltage],
  [SpecialHandProtectionWelding],
  [SpecialHandProtectionLeather],
  [SpecialHandProtectionOtherDescription],
  [SpecialRescueOrFallBodyHarness],
  [SpecialRescueOrFallLifeline],
  [SpecialRescueOrFallYoYo],
  [SpecialRescueOrFallRescueDevice],
  [SpecialRescueOrFallOtherDescription],
  [SourceId],
  [CreatedByUserId],
  [IsOperations],
  [LastModifiedUserId],
  [LastModifiedDate],
  [ApprovedByUserId],
  [Deleted],
  [FunctionalLocationId],
  [SapOperationId],
  [PermitNumber],
  [WorkOrderNumber],
  [StartDateTime],
  [EndDateTime],
  [PermitValidDateTime],
  [WorkPermitTypeId],
  [WorkPermitTypeClassificationId],
  [WorkOrderDescription],
  [SpecialPrecautionsOrConsiderationsDescription],
  [PermitConfinedSpaceEntry],
  [PermitBreathingAirOrSCBA],
  [PermitElectricalSwitching],
  [PermitVehicleEntry],
  [PermitHotTap],
  [PermitBurnOrOpenFlame],
  [PermitSystemEntry],
  [PermitCriticalLift],
  [PermitEnergizedElectrical],
  [PermitExcavation],
  [PermitAsbestos],
  [PermitRadiationRadiography],
  [PermitRadiationSealed],
  [AdditionalCSEAssessmentOrAuthorization],
  [AdditionalFlareEntry],
  [AdditionalCriticalLift],
  [AdditionalExcavation],
  [AdditionalHotTap],
  [AdditionalSpecialWasteDisposal],
  [AdditionalBlankOrBlindLists],
  [AdditionalPJSROrSafetyPause],
  [AdditionalAsbestosHandling],
  [AdditionalRoadClosure],
  [AdditionalElectrical],
  [AdditionalBurnOrOpenFlameAssessment],
  [AdditionalWaiverOrDeviation],
  [AdditionalMSDS],
  [AdditionalRadiationApproval],
  [AdditionalOnlineLeakRepairForm],
  [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
  [ContactPersonnel],
  [ContractorCompanyName],
  [CraftOrTradeID],
  [CraftOrTradeOther],
  [JobStepDescription],
  [CommunicationByRadio],
  [CommunicationRadioChannelOrBand],
  [IsWorkPermitCommunicationNotApplicable],
  [CommunicationRadioColor],
  [CommunicationByOtherDescription],
  [CoAuthorizationRequired],
  [StartAndOrEndTimesFinalized],
  EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
  AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
)
values (
  1,   -- WorkPermitStatusId
  '3.2',
  NULL,   -- CoAuthorizationDescription
  0,   -- ToolsAirTools
  0,   -- ToolsCraneOrCarrydeck
  0,   -- ToolsHandTools
  0,   -- ToolsJackhammer
  0,   -- ToolsVacuumTruck
  0,   -- ToolsCementSaw
  0,   -- ToolsElectricTools
  0,   -- ToolsHeavyEquipment
  0,   -- ToolsLanda
  0,   -- ToolsScaffolding
  0,   -- ToolsVehicle
  0,   -- ToolsCompressor
  0,   -- ToolsForklift
  0,   -- ToolsHEPAVacuum
  0,   -- ToolsManlift
  0,   -- ToolsTamper
  0,   -- ToolsHotTapMachine
  0,   -- ToolsPortLighting
  0,   -- ToolsTorch
  0,   -- ToolsWelder
  NULL,   -- ToolsOtherToolsDescription
  1,   -- ElectricIsolationMethodNotApplicable
  0,   -- ElectricIsolationMethodLOTO
  0,   -- ElectricIsolationMethodWiring
  1,   -- ElectricTestBumpNotApplicable
  0,   -- ElectricTestBump
  NULL,   -- EquipmentNoElectricalTestBumpComments
  1,   -- EquipmentStillContainsResidualNotApplicable
  0,   -- EquipmentStillContainsResidual
  NULL,   -- EquipmentStillContainsResidualComments
  1,   -- EquipmentLeakingValvesNotApplicable
  0,   -- EquipmentLeakingValves
  NULL,   -- EquipmentLeakingValvesComments
  1,   -- EquipmentIsOutOfService
  NULL,   -- EquipmentInServiceComments
  1,   -- EquipmentConditionNotApplicable
  0,   -- EquipmentConditionDepressured
  0,   -- EquipmentConditionDrained
  0,   -- EquipmentConditionCleaned
  0,   -- EquipmentConditionVentilated
  0,   -- EquipmentConditionH20Washed
  0,   -- EquipmentConditionNeutralized
  0,   -- EquipmentConditionPurged
  NULL,   -- EquipmentConditionPurgedDescription
  1,   -- EquipmentPreviousContentsNotApplicable
  0,   -- EquipmentPreviousContentsHydrocarbon
  0,   -- EquipmentPreviousContentsAcid
  0,   -- EquipmentPreviousContentsCaustic
  0,   -- EquipmentPreviousContentsH2S
  NULL,   -- EquipmentPreviousContentsOtherDescription
  1,   -- EquipmentIsolationMethodNotApplicable
  0,   -- EquipmentIsolationMethodBlindedorBlanked
  0,   -- EquipmentIsolationMethodBlockedIn
  0,   -- EquipmentIsolationMethodSeparation
  0,   -- EquipmentIsolationMethodMudderPlugs
  0,   -- EquipmentIsolationMethodLOTO
  NULL,   -- EquipmentIsolationMethodOtherDescription
  1,   -- EquipmentVentilationMethodNotApplicable
  0,   -- EquipmentVentilationMethodNaturalDraft
  0,   -- EquipmentVentilationMethodLocalExhaust
  0,   -- EquipmentVentilationMethodForced
  0,   -- JobSitePreparationFlowRequiredForJob
  1,   -- JobSitePreparationFlowRequiredForJobNotApplicable
  NULL,   -- JobSitePreparationFlowRequiredComments
  1,   -- JobSitePreparationBondingOrGroundingRequiredNotApplicable
  0,   -- JobSitePreparationBondingOrGroundingRequired
  NULL,   -- JobSitePreparationBondingGroundingNotRequiredComments
  1,   -- JobSitePreparationWeldingGroundWireInTestAreaNotApplicable
  0,   -- JobSitePreparationWeldingGroundWireInTestArea
  NULL,   -- JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments
  1,   -- JobSitePreparationCriticalConditionRemainJobSiteNotApplicable
  0,   -- JobSitePreparationCriticalConditionRemainJobSite
  NULL,   -- JobSitePreparationCriticalConditionsComments
  1,   -- JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable
  0,   -- JobSitePreparationSurroundingConditionsAffectOrContaminated
  NULL,   -- JobSitePreparationSurroundingConditionsAffectAreaComments
  1,   -- JobSitePreparationVestedBuddySystemInEffectNotApplicable
  0,   -- JobSitePreparationVestedBuddySystemInEffect
  1,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable
  0,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientation
  NULL,   -- JobSitePreparationPermitReceiverRequiresOrientationComments
  1,   -- JobSitePreparationSewerIsolationMethodNotApplicable
  0,   -- JobSitePreparationSewerIsolationMethodSealedOrCovered
  0,   -- JobSitePreparationSewerIsolationMethodPlugged
  0,   -- JobSitePreparationSewerIsolationMethodBlindedOrBlanked
  NULL,   -- JobSitePreparationSewerIsolationMethodOtherDescription
  1,   -- JobSitePreparationAreaPreparationNotApplicable
  0,   -- JobSitePreparationAreaPreparationBarricade
  0,   -- JobSitePreparationAreaPreparationNonEssentialEvac
  0,   -- JobSitePreparationAreaPreparationPreopBoundaryRopeTape
  NULL,   -- JobSitePreparationAreaPreparationOtherDescription
--  1,   -- JobSitePreparationDocumentationSignageNotApplicable
--  0,   -- JobSitePreparationDocumentationSignageBlankOrBlindList
--  0,   -- JobSitePreparationDocumentationSignageCSEPermit
--  0,   -- JobSitePreparationDocumentationSignageVesselPreparedForOpening
--  0,   -- JobSitePreparationDocumentationSignageRestrictedEntry
--  NULL,   -- JobSitePreparationDocumentationSignageOtherDescription
  1,   -- JobSitePreparationLightingElectricalRequirementNotApplicable
  0,   -- JobSitePreparationLightingElectricalRequirementLowVoltage12V
  0,   -- JobSitePreparationLightingElectricalRequirement110VWithGFCI
  0,   -- JobSitePreparationLightingElectricalRequirementGeneratorLights
  NULL,   -- JobSitePreparationLightingElectricalRequirementOtherDescription
  1,   -- RadiationSealedSourceIsolationNotApplicable
  0,   -- RadiationSealedSourceIsolationLOTO
  0,   -- RadiationSealedSourceIsolationOpen
  NULL,   -- RadiationSealedSourceIsolationNumberOfSources
  '',   -- GasTestFrequencyOrDuration
  0,   -- GasTestConstantMonitoringRequired
  NULL,   -- GasTestTestTime
  0,   -- FireConfinedSpace20ABCorDryChemicalExtinguisher
  0,   -- FireConfinedSpaceC02Extinguisher
  0,   -- FireConfinedSpaceFireResistantTarp
  0,   -- FireConfinedSpaceSparkContainment
  0,   -- FireConfinedSpaceWaterHose
  0,   -- FireConfinedSpaceSteamHose
  0,   -- FireConfinedSpaceWatchmen
  NULL,   -- FireConfinedSpaceOtherDescription
  0,   -- RespitoryProtectionRequirementsAirCartOrAirLine
  0,   -- RespitoryProtectionRequirementsSCBA
  0,   -- RespitoryProtectionRequirementsHalfFaceRespirator
  0,   -- RespitoryProtectionRequirementsFullFaceRespirator
  0,   -- RespitoryProtectionRequirementsDustMask
  0,   -- RespitoryProtectionRequirementsAirHood
  NULL,   -- RespitoryProtectionRequirementsOtherDescription
  NULL,   -- RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription
  0,   -- SpecialEyeOrFaceProtectionGoggles
  0,   -- SpecialEyeOrFaceProtectionFaceshield
  NULL,   -- SpecialEyeOrFaceProtectionOtherDescription
  0,   -- SpecialProtectiveClothingTypeRainCoat
  0,   -- SpecialProtectiveClothingTypeRainPants
  0,   -- SpecialProtectiveClothingTypeAcidClothing
  NULL,   -- SpecialProtectiveClothingTypeAcidClothingTypeID
  0,   -- SpecialProtectiveClothingTypeCausticWear
  NULL,   -- SpecialProtectiveClothingTypeOtherDescripton
  0,   -- SpecialProtectiveFootwearChemicalImperviousBoots
  0,   -- SpecialProtectiveFootwearToeGuard
  NULL,   -- SpecialProtectiveFootwearOtherDescription
  0,   -- SpecialHandProtectionChemicalNeprene
  0,   -- SpecialHandProtectionNaturalRubber
  0,   -- SpecialHandProtectionNitrile
  0,   -- SpecialHandProtectionPVC
  0,   -- SpecialHandProtectionHighVoltage
  0,   -- SpecialHandProtectionWelding
  0,   -- SpecialHandProtectionLeather
  NULL,   -- SpecialHandProtectionOtherDescription
  0,   -- SpecialRescueOrFallBodyHarness
  0,   -- SpecialRescueOrFallLifeline
  0,   -- SpecialRescueOrFallYoYo
  0,   -- SpecialRescueOrFallRescueDevice
  NULL,   -- SpecialRescueOrFallOtherDescription
  0,   -- SourceId
  1,   -- CreatedByUserId
  1,   -- IsOperations
  1,   -- LastModifiedUserId
  @START_TIME2,  -- LastModifiedDate
  NULL,   -- ApprovedByUserId
  0,   -- Deleted
  @FLOC_ID,   -- FunctionalLocationId
  NULL,   -- SapOperationId
  @DIVISION + '-0000000113',   -- PermitNumber
  'WON38715',   -- WorkOrderNumber
  @START_TIME2,  -- StartDateTime
  @END_TIME2,  -- EndDateTime
  NULL,   -- PermitValidDateTime
  2,   -- WorkPermitTypeId
  1,   -- WorkPermitTypeClassificationId
  'Remove insulation',   -- WorkOrderDescription
  NULL,   -- SpecialPrecautionsOrConsiderationsDescription
  0,   -- PermitConfinedSpaceEntry
  0,   -- PermitBreathingAirOrSCBA
  0,   -- PermitElectricalSwitching
  0,   -- PermitVehicleEntry
  0,   -- PermitHotTap
  0,   -- PermitBurnOrOpenFlame
  0,   -- PermitSystemEntry
  0,   -- PermitCriticalLift
  0,   -- PermitEnergizedElectrical
  0,   -- PermitExcavation
  0,   -- PermitAsbestos
  0,   -- PermitRadiationRadiography
  0,   -- PermitRadiationSealed
  0,   -- AdditionalCSEAssessmentOrAuthorization
  0,   -- AdditionalFlareEntry
  0,   -- AdditionalCriticalLift
  0,   -- AdditionalExcavation
  0,   -- AdditionalHotTap
  0,   -- AdditionalSpecialWasteDisposal
  0,   -- AdditionalBlankOrBlindLists
  0,   -- AdditionalPJSROrSafetyPause
  0,   -- AdditionalAsbestosHandling
  0,   -- AdditionalRoadClosure
  0,   -- AdditionalElectrical
  0,   -- AdditionalBurnOrOpenFlameAssessment
  0,   -- AdditionalWaiverOrDeviation
  0,   -- AdditionalMSDS
  0,   -- AdditionalRadiationApproval
  0,   -- AdditionalOnlineLeakRepairForm
  NULL,   -- AdditionalOtherFormsOrAssessmentsOrAuthorizations
  NULL,   -- ContactPersonnel
  NULL,   -- ContractorCompanyName
  1,   -- CraftOrTradeID
  'It is no longer used.  Once CraftOrTrade Table is ',   -- CraftOrTradeOther
  'Remove insulation',   -- JobStepDescription
  1,   -- CommunicationByRadio
  NULL,   -- CommunicationRadioChannelOrBand
  1,   -- IsWorkPermitCommunicationNotApplicable
  NULL,   -- CommunicationRadioColor
  NULL,   -- CommunicationByOtherDescription
  0,   -- CoAuthorizationRequired
  1,    -- StartAndOrEndTimesFinalized
  1,
  1,
null,
0,
0,
0,
0,
0,
0
);


select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END

--  
-- Archived and Old Data
--

END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;
GO


--
-- Additional work permits requested by the training ladies
--

DECLARE @FLOC_ID BIGINT;
DECLARE @WP_ID BIGINT;
DECLARE @ARCHIVED_STATUS_ID BIGINT;
DECLARE @COMPLETED_STATUS_ID BIGINT;

DECLARE @START_7_DAYS_AGO AS DATETIME;
DECLARE @END_7_DAYS_AGO AS DATETIME;

DECLARE @START_31_DAYS_AGO AS DATETIME;
DECLARE @END_31_DAYS_AGO AS DATETIME;

DECLARE @DIVISION AS VARCHAR(3);

SET @START_7_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 7, 110) + ' 17:00:00.000');
SET @END_7_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 7, 110) + ' 18:00:00.000');

SET @START_31_DAYS_AGO = CONVERT(DATETIME, CONVERT(char(10), GetDate() - 31, 110) + ' 10:00:00.000');
SET @END_31_DAYS_AGO = DATEADD(dd, 1, CONVERT(DATETIME, CONVERT(char(10), GetDate() - 31, 110) + ' 20:00:00.000'));

SELECT @ARCHIVED_STATUS_ID = 6;
SELECT @COMPLETED_STATUS_ID = 3;

DECLARE FLOC_ID_CURSOR CURSOR
FOR
  SELECT Id FROM FunctionalLocation
  WHERE    		
  (
			FullHierarchy like 'SR1-PLT2-%'
			or
			FullHierarchy like 'SR1-PLT3-%'
			or
			FullHierarchy like 'DN1-3003-%'
		)
		and [Level] = 3
		and (SiteId = 1 or SiteId = 2);

OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

WHILE (@@FETCH_STATUS <> -1)
BEGIN
   IF (@@FETCH_STATUS <> -2)
   BEGIN

select @DIVISION = COALESCE(fa.FullHierarchy, f.FullHierarchy)
		from
			FunctionalLocation f
			LEFT OUTER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 1
			LEFT OUTER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
		where
			f.Id = @FLOC_ID;

insert into WorkPermit (
  [WorkPermitStatusId],
  Version,
  [CoAuthorizationDescription],
  [ToolsAirTools],
  [ToolsCraneOrCarrydeck],
  [ToolsHandTools],
  [ToolsJackhammer],
  [ToolsVacuumTruck],
  [ToolsCementSaw],
  [ToolsElectricTools],
  [ToolsHeavyEquipment],
  [ToolsLanda],
  [ToolsScaffolding],
  [ToolsVehicle],
  [ToolsCompressor],
  [ToolsForklift],
  [ToolsHEPAVacuum],
  [ToolsManlift],
  [ToolsTamper],
  [ToolsHotTapMachine],
  [ToolsPortLighting],
  [ToolsTorch],
  [ToolsWelder],
  [ToolsOtherToolsDescription],
  [ElectricIsolationMethodNotApplicable],
  [ElectricIsolationMethodLOTO],
  [ElectricIsolationMethodWiring],
  [ElectricTestBumpNotApplicable],
  [ElectricTestBump],
  [EquipmentNoElectricalTestBumpComments],
  [EquipmentStillContainsResidualNotApplicable],
  [EquipmentStillContainsResidual],
  [EquipmentStillContainsResidualComments],
  [EquipmentLeakingValvesNotApplicable],
  [EquipmentLeakingValves],
  [EquipmentLeakingValvesComments],
  [EquipmentIsOutOfService],
  [EquipmentInServiceComments],
  [EquipmentConditionNotApplicable],
  [EquipmentConditionDepressured],
  [EquipmentConditionDrained],
  [EquipmentConditionCleaned],
  [EquipmentConditionVentilated],
  [EquipmentConditionH20Washed],
  [EquipmentConditionNeutralized],
  [EquipmentConditionPurged],
  [EquipmentConditionPurgedDescription],
  [EquipmentPreviousContentsNotApplicable],
  [EquipmentPreviousContentsHydrocarbon],
  [EquipmentPreviousContentsAcid],
  [EquipmentPreviousContentsCaustic],
  [EquipmentPreviousContentsH2S],
  [EquipmentPreviousContentsOtherDescription],
  [EquipmentIsolationMethodNotApplicable],
  [EquipmentIsolationMethodBlindedorBlanked],
  [EquipmentIsolationMethodBlockedIn],
  [EquipmentIsolationMethodSeparation],
  [EquipmentIsolationMethodMudderPlugs],
  [EquipmentIsolationMethodLOTO],
  [EquipmentIsolationMethodOtherDescription],
  [EquipmentVentilationMethodNotApplicable],
  [EquipmentVentilationMethodNaturalDraft],
  [EquipmentVentilationMethodLocalExhaust],
  [EquipmentVentilationMethodForced],
  [JobSitePreparationFlowRequiredForJob],
  [JobSitePreparationFlowRequiredForJobNotApplicable],
  [JobSitePreparationFlowRequiredComments],
  [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
  [JobSitePreparationBondingOrGroundingRequired],
  [JobSitePreparationBondingGroundingNotRequiredComments],
  [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
  [JobSitePreparationWeldingGroundWireInTestArea],
  [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
  [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
  [JobSitePreparationCriticalConditionRemainJobSite],
  [JobSitePreparationCriticalConditionsComments],
  [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
  [JobSitePreparationSurroundingConditionsAffectOrContaminated],
  [JobSitePreparationSurroundingConditionsAffectAreaComments],
  [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
  [JobSitePreparationVestedBuddySystemInEffect],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
  [JobSitePreparationPermitReceiverRequiresOrientationComments],
  [JobSitePreparationSewerIsolationMethodNotApplicable],
  [JobSitePreparationSewerIsolationMethodSealedOrCovered],
  [JobSitePreparationSewerIsolationMethodPlugged],
  [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
  [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
  [JobSitePreparationAreaPreparationBarricade],
  [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
  [JobSitePreparationAreaPreparationOtherDescription],
--  [JobSitePreparationDocumentationSignageNotApplicable],
--  [JobSitePreparationDocumentationSignageBlankOrBlindList],
--  [JobSitePreparationDocumentationSignageCSEPermit],
--  [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
--  [JobSitePreparationDocumentationSignageRestrictedEntry],
--  [JobSitePreparationDocumentationSignageOtherDescription],
  [JobSitePreparationLightingElectricalRequirementNotApplicable],
  [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
  [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
  [JobSitePreparationLightingElectricalRequirementGeneratorLights],
  [JobSitePreparationLightingElectricalRequirementOtherDescription],
  [RadiationSealedSourceIsolationNotApplicable],
  [RadiationSealedSourceIsolationLOTO],
  [RadiationSealedSourceIsolationOpen],
  [RadiationSealedSourceIsolationNumberOfSources],
  [GasTestFrequencyOrDuration],
  [GasTestConstantMonitoringRequired],
  [GasTestTestTime],
  [FireConfinedSpace20ABCorDryChemicalExtinguisher],
  [FireConfinedSpaceC02Extinguisher],
  [FireConfinedSpaceFireResistantTarp],
  [FireConfinedSpaceSparkContainment],
  [FireConfinedSpaceWaterHose],
  [FireConfinedSpaceSteamHose],
  [FireConfinedSpaceWatchmen],
  [FireConfinedSpaceOtherDescription],
  [RespitoryProtectionRequirementsAirCartOrAirLine],
  [RespitoryProtectionRequirementsSCBA],
  [RespitoryProtectionRequirementsHalfFaceRespirator],
  [RespitoryProtectionRequirementsFullFaceRespirator],
  [RespitoryProtectionRequirementsDustMask],
  [RespitoryProtectionRequirementsAirHood],
  [RespitoryProtectionRequirementsOtherDescription],
  [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
  [SpecialEyeOrFaceProtectionGoggles],
  [SpecialEyeOrFaceProtectionFaceshield],
  [SpecialEyeOrFaceProtectionOtherDescription],
  [SpecialProtectiveClothingTypeRainCoat],
  [SpecialProtectiveClothingTypeRainPants],
  [SpecialProtectiveClothingTypeAcidClothing],
  [SpecialProtectiveClothingTypeAcidClothingTypeID],
  [SpecialProtectiveClothingTypeCausticWear],
  [SpecialProtectiveClothingTypeOtherDescripton],
  [SpecialProtectiveFootwearChemicalImperviousBoots],
  [SpecialProtectiveFootwearToeGuard],
  [SpecialProtectiveFootwearOtherDescription],
  [SpecialHandProtectionChemicalNeprene],
  [SpecialHandProtectionNaturalRubber],
  [SpecialHandProtectionNitrile],
  [SpecialHandProtectionPVC],
  [SpecialHandProtectionHighVoltage],
  [SpecialHandProtectionWelding],
  [SpecialHandProtectionLeather],
  [SpecialHandProtectionOtherDescription],
  [SpecialRescueOrFallBodyHarness],
  [SpecialRescueOrFallLifeline],
  [SpecialRescueOrFallYoYo],
  [SpecialRescueOrFallRescueDevice],
  [SpecialRescueOrFallOtherDescription],
  [SourceId],
  [CreatedByUserId],
  [IsOperations],
  [LastModifiedUserId],
  [LastModifiedDate],
  [ApprovedByUserId],
  [Deleted],
  [FunctionalLocationId],
  [SapOperationId],
  [PermitNumber],
  [WorkOrderNumber],
  [StartDateTime],
  [EndDateTime],
  [PermitValidDateTime],
  [WorkPermitTypeId],
  [WorkPermitTypeClassificationId],
  [WorkOrderDescription],
  [SpecialPrecautionsOrConsiderationsDescription],
  [PermitConfinedSpaceEntry],
  [PermitBreathingAirOrSCBA],
  [PermitElectricalSwitching],
  [PermitVehicleEntry],
  [PermitHotTap],
  [PermitBurnOrOpenFlame],
  [PermitSystemEntry],
  [PermitCriticalLift],
  [PermitEnergizedElectrical],
  [PermitExcavation],
  [PermitAsbestos],
  [PermitRadiationRadiography],
  [PermitRadiationSealed],
  [AdditionalCSEAssessmentOrAuthorization],
  [AdditionalFlareEntry],
  [AdditionalCriticalLift],
  [AdditionalExcavation],
  [AdditionalHotTap],
  [AdditionalSpecialWasteDisposal],
  [AdditionalBlankOrBlindLists],
  [AdditionalPJSROrSafetyPause],
  [AdditionalAsbestosHandling],
  [AdditionalRoadClosure],
  [AdditionalElectrical],
  [AdditionalBurnOrOpenFlameAssessment],
  [AdditionalWaiverOrDeviation],
  [AdditionalMSDS],
  [AdditionalRadiationApproval],
  [AdditionalOnlineLeakRepairForm],
  [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
  [ContactPersonnel],
  [ContractorCompanyName],
  [CraftOrTradeID],
  [CraftOrTradeOther],
  [JobStepDescription],
  [CommunicationByRadio],
  [CommunicationRadioChannelOrBand],
  [IsWorkPermitCommunicationNotApplicable],
  [CommunicationRadioColor],
  [CommunicationByOtherDescription],
  [CoAuthorizationRequired],
  [StartAndOrEndTimesFinalized],
  EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
  AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable

)
values (
  @ARCHIVED_STATUS_ID,   -- WorkPermitStatusId
  '3.2',
  NULL,   -- CoAuthorizationDescription
  0,   -- ToolsAirTools
  0,   -- ToolsCraneOrCarrydeck
  0,   -- ToolsHandTools
  0,   -- ToolsJackhammer
  0,   -- ToolsVacuumTruck
  0,   -- ToolsCementSaw
  0,   -- ToolsElectricTools
  0,   -- ToolsHeavyEquipment
  0,   -- ToolsLanda
  0,   -- ToolsScaffolding
  0,   -- ToolsVehicle
  0,   -- ToolsCompressor
  0,   -- ToolsForklift
  0,   -- ToolsHEPAVacuum
  0,   -- ToolsManlift
  0,   -- ToolsTamper
  0,   -- ToolsHotTapMachine
  0,   -- ToolsPortLighting
  0,   -- ToolsTorch
  0,   -- ToolsWelder
  NULL,   -- ToolsOtherToolsDescription
  1,   -- ElectricIsolationMethodNotApplicable
  0,   -- ElectricIsolationMethodLOTO
  0,   -- ElectricIsolationMethodWiring
  1,   -- ElectricTestBumpNotApplicable
  0,   -- ElectricTestBump
  NULL,   -- EquipmentNoElectricalTestBumpComments
  1,   -- EquipmentStillContainsResidualNotApplicable
  0,   -- EquipmentStillContainsResidual
  NULL,   -- EquipmentStillContainsResidualComments
  1,   -- EquipmentLeakingValvesNotApplicable
  0,   -- EquipmentLeakingValves
  NULL,   -- EquipmentLeakingValvesComments
  1,   -- EquipmentIsOutOfService
  NULL,   -- EquipmentInServiceComments
  1,   -- EquipmentConditionNotApplicable
  0,   -- EquipmentConditionDepressured
  0,   -- EquipmentConditionDrained
  0,   -- EquipmentConditionCleaned
  0,   -- EquipmentConditionVentilated
  0,   -- EquipmentConditionH20Washed
  0,   -- EquipmentConditionNeutralized
  0,   -- EquipmentConditionPurged
  NULL,   -- EquipmentConditionPurgedDescription
  1,   -- EquipmentPreviousContentsNotApplicable
  0,   -- EquipmentPreviousContentsHydrocarbon
  0,   -- EquipmentPreviousContentsAcid
  0,   -- EquipmentPreviousContentsCaustic
  0,   -- EquipmentPreviousContentsH2S
  NULL,   -- EquipmentPreviousContentsOtherDescription
  1,   -- EquipmentIsolationMethodNotApplicable
  0,   -- EquipmentIsolationMethodBlindedorBlanked
  0,   -- EquipmentIsolationMethodBlockedIn
  0,   -- EquipmentIsolationMethodSeparation
  0,   -- EquipmentIsolationMethodMudderPlugs
  0,   -- EquipmentIsolationMethodLOTO
  NULL,-- EquipmentIsolationMethodOtherDescription
  1,  -- EquipmentVentilationMethodNotApplicable
  0,   -- EquipmentVentilationMethodNaturalDraft
  0,   -- EquipmentVentilationMethodLocalExhaust
  0,   -- EquipmentVentilationMethodForced
  0,   -- JobSitePreparationFlowRequiredForJob
  1,   -- JobSitePreparationFlowRequiredForJobNotApplicable
  NULL,   -- JobSitePreparationFlowRequiredComments
  1,   -- JobSitePreparationBondingOrGroundingRequiredNotApplicable
  0,   -- JobSitePreparationBondingOrGroundingRequired
  NULL,   -- JobSitePreparationBondingGroundingNotRequiredComments
  1,   -- JobSitePreparationWeldingGroundWireInTestAreaNotApplicable
  0,   -- JobSitePreparationWeldingGroundWireInTestArea
  NULL,   -- JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments
  1,   -- JobSitePreparationCriticalConditionRemainJobSiteNotApplicable
  0,   -- JobSitePreparationCriticalConditionRemainJobSite
  NULL,   -- JobSitePreparationCriticalConditionsComments
  1,   -- JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable
  0,   -- JobSitePreparationSurroundingConditionsAffectOrContaminated
  NULL,   -- JobSitePreparationSurroundingConditionsAffectAreaComments
  1,   -- JobSitePreparationVestedBuddySystemInEffectNotApplicable
  0,   -- JobSitePreparationVestedBuddySystemInEffect
  1,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable
  0,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientation
  NULL,   -- JobSitePreparationPermitReceiverRequiresOrientationComments
  1,   -- JobSitePreparationSewerIsolationMethodNotApplicable
  0,   -- JobSitePreparationSewerIsolationMethodSealedOrCovered
  0,   -- JobSitePreparationSewerIsolationMethodPlugged
  0,   -- JobSitePreparationSewerIsolationMethodBlindedOrBlanked
  NULL,   -- JobSitePreparationSewerIsolationMethodOtherDescription
  1,   -- JobSitePreparationAreaPreparationNotApplicable
  0,   -- JobSitePreparationAreaPreparationBarricade
  0,   -- JobSitePreparationAreaPreparationNonEssentialEvac
  0,   -- JobSitePreparationAreaPreparationPreopBoundaryRopeTape
  NULL,   -- JobSitePreparationAreaPreparationOtherDescription
--  1,   -- JobSitePreparationDocumentationSignageNotApplicable
--  0,   -- JobSitePreparationDocumentationSignageBlankOrBlindList
--  0,   -- JobSitePreparationDocumentationSignageCSEPermit
--  0,   -- JobSitePreparationDocumentationSignageVesselPreparedForOpening
--  0,   -- JobSitePreparationDocumentationSignageRestrictedEntry
--  NULL,   -- JobSitePreparationDocumentationSignageOtherDescription
  1,   -- JobSitePreparationLightingElectricalRequirementNotApplicable
  0,   -- JobSitePreparationLightingElectricalRequirementLowVoltage12V
  0,   -- JobSitePreparationLightingElectricalRequirement110VWithGFCI
  0,   -- JobSitePreparationLightingElectricalRequirementGeneratorLights
  NULL,   -- JobSitePreparationLightingElectricalRequirementOtherDescription
  1,   -- RadiationSealedSourceIsolationNotApplicable
  0,   -- RadiationSealedSourceIsolationLOTO
  0,   -- RadiationSealedSourceIsolationOpen
  NULL,   -- RadiationSealedSourceIsolationNumberOfSources
  '',   -- GasTestFrequencyOrDuration
  0,   -- GasTestConstantMonitoringRequired
  NULL,   -- GasTestTestTime
  0,   -- FireConfinedSpace20ABCorDryChemicalExtinguisher
  0,   -- FireConfinedSpaceC02Extinguisher
  0,   -- FireConfinedSpaceFireResistantTarp
  0,   -- FireConfinedSpaceSparkContainment
  0,   -- FireConfinedSpaceWaterHose
  0,   -- FireConfinedSpaceSteamHose
  0,   -- FireConfinedSpaceWatchmen
  NULL,   -- FireConfinedSpaceOtherDescription
  0,   -- RespitoryProtectionRequirementsAirCartOrAirLine
  0,   -- RespitoryProtectionRequirementsSCBA
  0,   -- RespitoryProtectionRequirementsHalfFaceRespirator
  0,   -- RespitoryProtectionRequirementsFullFaceRespirator
  0,   -- RespitoryProtectionRequirementsDustMask
  0,   -- RespitoryProtectionRequirementsAirHood
  NULL,   -- RespitoryProtectionRequirementsOtherDescription
  NULL,   -- RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription
  0,   -- SpecialEyeOrFaceProtectionGoggles
  0,   -- SpecialEyeOrFaceProtectionFaceshield
  NULL,   -- SpecialEyeOrFaceProtectionOtherDescription
  0,   -- SpecialProtectiveClothingTypeRainCoat
  0,   -- SpecialProtectiveClothingTypeRainPants
  0,   -- SpecialProtectiveClothingTypeAcidClothing
  NULL,   -- SpecialProtectiveClothingTypeAcidClothingTypeID
  0,   -- SpecialProtectiveClothingTypeCausticWear
  NULL,   -- SpecialProtectiveClothingTypeOtherDescripton
  0,   -- SpecialProtectiveFootwearChemicalImperviousBoots
  0,   -- SpecialProtectiveFootwearToeGuard
  NULL,   -- SpecialProtectiveFootwearOtherDescription
  0,   -- SpecialHandProtectionChemicalNeprene
  0,   -- SpecialHandProtectionNaturalRubber
  0,   -- SpecialHandProtectionNitrile
  0,   -- SpecialHandProtectionPVC
  0,   -- SpecialHandProtectionHighVoltage
  0,   -- SpecialHandProtectionWelding
  0,   -- SpecialHandProtectionLeather
  NULL,   -- SpecialHandProtectionOtherDescription
  0,   -- SpecialRescueOrFallBodyHarness
  0,   -- SpecialRescueOrFallLifeline
  0,   -- SpecialRescueOrFallYoYo
  0,   -- SpecialRescueOrFallRescueDevice
  NULL,   -- SpecialRescueOrFallOtherDescription
  0,   -- SourceId
  1,   -- CreatedByUserId
  1,   -- IsOperations
  1,   -- LastModifiedUserId
  @END_31_DAYS_AGO,  -- LastModifiedDate
  6,   -- ApprovedByUserId
  0,   -- Deleted
  @FLOC_ID,   -- FunctionalLocationId
  NULL,   -- SapOperationId
  @DIVISION + '-0000000114',   -- PermitNumber
  'WON38716',   -- WorkOrderNumber
  @START_31_DAYS_AGO,  -- StartDateTime
  @END_31_DAYS_AGO,  -- EndDateTime
  NULL,   -- PermitValidDateTime
  2,   -- WorkPermitTypeId
  1,   -- WorkPermitTypeClassificationId
  'Archived work permit',   -- WorkOrderDescription
  NULL,   -- SpecialPrecautionsOrConsiderationsDescription
  0,   -- PermitConfinedSpaceEntry
  0,   -- PermitBreathingAirOrSCBA
  0,   -- PermitElectricalSwitching
  0,   -- PermitVehicleEntry
  0,   -- PermitHotTap
  0,   -- PermitBurnOrOpenFlame
  0,   -- PermitSystemEntry
  0,   -- PermitCriticalLift
  0,   -- PermitEnergizedElectrical
  0,   -- PermitExcavation
  0,   -- PermitAsbestos
  0,   -- PermitRadiationRadiography
  0,   -- PermitRadiationSealed
  0,   -- AdditionalCSEAssessmentOrAuthorization
  0,   -- AdditionalFlareEntry
  0,   -- AdditionalCriticalLift
  0,   -- AdditionalExcavation
  0,   -- AdditionalHotTap
  0,   -- AdditionalSpecialWasteDisposal
  0,   -- AdditionalBlankOrBlindLists
  0,   -- AdditionalPJSROrSafetyPause
  0,   -- AdditionalAsbestosHandling
  0,   -- AdditionalRoadClosure
  0,   -- AdditionalElectrical
  0,   -- AdditionalBurnOrOpenFlameAssessment
  0,   -- AdditionalWaiverOrDeviation
  0,   -- AdditionalMSDS
  0,   -- AdditionalRadiationApproval
  0,   -- AdditionalOnlineLeakRepairForm
  NULL,   -- AdditionalOtherFormsOrAssessmentsOrAuthorizations
  NULL,   -- ContactPersonnel
  NULL,   -- ContractorCompanyName
  1,   -- CraftOrTradeID
  'It is no longer used.  Once CraftOrTrade Table is ',   -- CraftOrTradeOther
  'Remove insulation',   -- JobStepDescription
  1,   -- CommunicationByRadio
  NULL,   -- CommunicationRadioChannelOrBand
  1,   -- IsWorkPermitCommunicationNotApplicable
  NULL,   -- CommunicationRadioColor
  NULL,   -- CommunicationByOtherDescription
  0,   -- CoAuthorizationRequired
  1,    -- StartAndOrEndTimesFinalized
  1,
  1,
null,
0,
0,
0,
0,
0,
0
);
  
select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END


insert into WorkPermit (
  [WorkPermitStatusId],
  Version,
  [CoAuthorizationDescription],
  [ToolsAirTools],
  [ToolsCraneOrCarrydeck],
  [ToolsHandTools],
  [ToolsJackhammer],
  [ToolsVacuumTruck],
  [ToolsCementSaw],
  [ToolsElectricTools],
  [ToolsHeavyEquipment],
  [ToolsLanda],
  [ToolsScaffolding],
  [ToolsVehicle],
  [ToolsCompressor],
  [ToolsForklift],
  [ToolsHEPAVacuum],
  [ToolsManlift],
  [ToolsTamper],
  [ToolsHotTapMachine],
  [ToolsPortLighting],
  [ToolsTorch],
  [ToolsWelder],
  [ToolsOtherToolsDescription],
  [ElectricIsolationMethodNotApplicable],
  [ElectricIsolationMethodLOTO],
  [ElectricIsolationMethodWiring],
  [ElectricTestBumpNotApplicable],
  [ElectricTestBump],
  [EquipmentNoElectricalTestBumpComments],
  [EquipmentStillContainsResidualNotApplicable],
  [EquipmentStillContainsResidual],
  [EquipmentStillContainsResidualComments],
  [EquipmentLeakingValvesNotApplicable],
  [EquipmentLeakingValves],
  [EquipmentLeakingValvesComments],
  [EquipmentIsOutOfService],
  [EquipmentInServiceComments],
  [EquipmentConditionNotApplicable],
  [EquipmentConditionDepressured],
  [EquipmentConditionDrained],
  [EquipmentConditionCleaned],
  [EquipmentConditionVentilated],
  [EquipmentConditionH20Washed],
  [EquipmentConditionNeutralized],
  [EquipmentConditionPurged],
  [EquipmentConditionPurgedDescription],
  [EquipmentPreviousContentsNotApplicable],
  [EquipmentPreviousContentsHydrocarbon],
  [EquipmentPreviousContentsAcid],
  [EquipmentPreviousContentsCaustic],
  [EquipmentPreviousContentsH2S],
  [EquipmentPreviousContentsOtherDescription],
  [EquipmentIsolationMethodNotApplicable],
  [EquipmentIsolationMethodBlindedorBlanked],
  [EquipmentIsolationMethodBlockedIn],
  [EquipmentIsolationMethodSeparation],
  [EquipmentIsolationMethodMudderPlugs],
  [EquipmentIsolationMethodLOTO],
  [EquipmentIsolationMethodOtherDescription],
  [EquipmentVentilationMethodNotApplicable],
  [EquipmentVentilationMethodNaturalDraft],
  [EquipmentVentilationMethodLocalExhaust],
  [EquipmentVentilationMethodForced],
  [JobSitePreparationFlowRequiredForJob],
  [JobSitePreparationFlowRequiredForJobNotApplicable],
  [JobSitePreparationFlowRequiredComments],
  [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
  [JobSitePreparationBondingOrGroundingRequired],
  [JobSitePreparationBondingGroundingNotRequiredComments],
  [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
  [JobSitePreparationWeldingGroundWireInTestArea],
  [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
  [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
  [JobSitePreparationCriticalConditionRemainJobSite],
  [JobSitePreparationCriticalConditionsComments],
  [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
  [JobSitePreparationSurroundingConditionsAffectOrContaminated],
  [JobSitePreparationSurroundingConditionsAffectAreaComments],
  [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
  [JobSitePreparationVestedBuddySystemInEffect],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
  [JobSitePreparationPermitReceiverRequiresOrientationComments],
  [JobSitePreparationSewerIsolationMethodNotApplicable],
  [JobSitePreparationSewerIsolationMethodSealedOrCovered],
  [JobSitePreparationSewerIsolationMethodPlugged],
  [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
  [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
  [JobSitePreparationAreaPreparationBarricade],
  [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
  [JobSitePreparationAreaPreparationOtherDescription],
--  [JobSitePreparationDocumentationSignageNotApplicable],
--  [JobSitePreparationDocumentationSignageBlankOrBlindList],
--  [JobSitePreparationDocumentationSignageCSEPermit],
--  [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
--  [JobSitePreparationDocumentationSignageRestrictedEntry],
--  [JobSitePreparationDocumentationSignageOtherDescription],
  [JobSitePreparationLightingElectricalRequirementNotApplicable],
  [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
  [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
  [JobSitePreparationLightingElectricalRequirementGeneratorLights],
  [JobSitePreparationLightingElectricalRequirementOtherDescription],
  [RadiationSealedSourceIsolationNotApplicable],
  [RadiationSealedSourceIsolationLOTO],
  [RadiationSealedSourceIsolationOpen],
  [RadiationSealedSourceIsolationNumberOfSources],
  [GasTestFrequencyOrDuration],
  [GasTestConstantMonitoringRequired],
  [GasTestTestTime],
  [FireConfinedSpace20ABCorDryChemicalExtinguisher],
  [FireConfinedSpaceC02Extinguisher],
  [FireConfinedSpaceFireResistantTarp],
  [FireConfinedSpaceSparkContainment],
  [FireConfinedSpaceWaterHose],
  [FireConfinedSpaceSteamHose],
  [FireConfinedSpaceWatchmen],
  [FireConfinedSpaceOtherDescription],
  [RespitoryProtectionRequirementsAirCartOrAirLine],
  [RespitoryProtectionRequirementsSCBA],
  [RespitoryProtectionRequirementsHalfFaceRespirator],
  [RespitoryProtectionRequirementsFullFaceRespirator],
  [RespitoryProtectionRequirementsDustMask],
  [RespitoryProtectionRequirementsAirHood],
  [RespitoryProtectionRequirementsOtherDescription],
  [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
  [SpecialEyeOrFaceProtectionGoggles],
  [SpecialEyeOrFaceProtectionFaceshield],
  [SpecialEyeOrFaceProtectionOtherDescription],
  [SpecialProtectiveClothingTypeRainCoat],
  [SpecialProtectiveClothingTypeRainPants],
  [SpecialProtectiveClothingTypeAcidClothing],
  [SpecialProtectiveClothingTypeAcidClothingTypeID],
  [SpecialProtectiveClothingTypeCausticWear],
  [SpecialProtectiveClothingTypeOtherDescripton],
  [SpecialProtectiveFootwearChemicalImperviousBoots],
  [SpecialProtectiveFootwearToeGuard],
  [SpecialProtectiveFootwearOtherDescription],
  [SpecialHandProtectionChemicalNeprene],
  [SpecialHandProtectionNaturalRubber],
  [SpecialHandProtectionNitrile],
  [SpecialHandProtectionPVC],
  [SpecialHandProtectionHighVoltage],
  [SpecialHandProtectionWelding],
  [SpecialHandProtectionLeather],
  [SpecialHandProtectionOtherDescription],
  [SpecialRescueOrFallBodyHarness],
  [SpecialRescueOrFallLifeline],
  [SpecialRescueOrFallYoYo],
  [SpecialRescueOrFallRescueDevice],
  [SpecialRescueOrFallOtherDescription],
  [SourceId],
  [CreatedByUserId],
  [IsOperations],
  [LastModifiedUserId],
  [LastModifiedDate],
  [ApprovedByUserId],
  [Deleted],
  [FunctionalLocationId],
  [SapOperationId],
  [PermitNumber],
  [WorkOrderNumber],
  [StartDateTime],
  [EndDateTime],
  [PermitValidDateTime],
  [WorkPermitTypeId],
  [WorkPermitTypeClassificationId],
  [WorkOrderDescription],
  [SpecialPrecautionsOrConsiderationsDescription],
  [PermitConfinedSpaceEntry],
  [PermitBreathingAirOrSCBA],
  [PermitElectricalSwitching],
  [PermitVehicleEntry],
  [PermitHotTap],
  [PermitBurnOrOpenFlame],
  [PermitSystemEntry],
  [PermitCriticalLift],
  [PermitEnergizedElectrical],
  [PermitExcavation],
  [PermitAsbestos],
  [PermitRadiationRadiography],
  [PermitRadiationSealed],
  [AdditionalCSEAssessmentOrAuthorization],
  [AdditionalFlareEntry],
  [AdditionalCriticalLift],
  [AdditionalExcavation],
  [AdditionalHotTap],
  [AdditionalSpecialWasteDisposal],
  [AdditionalBlankOrBlindLists],
  [AdditionalPJSROrSafetyPause],
  [AdditionalAsbestosHandling],
  [AdditionalRoadClosure],
  [AdditionalElectrical],
  [AdditionalBurnOrOpenFlameAssessment],
  [AdditionalWaiverOrDeviation],
  [AdditionalMSDS],
  [AdditionalRadiationApproval],
  [AdditionalOnlineLeakRepairForm],
  [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
  [ContactPersonnel],
  [ContractorCompanyName],
  [CraftOrTradeID],
  [CraftOrTradeOther],
  [JobStepDescription],
  [CommunicationByRadio],
  [CommunicationRadioChannelOrBand],
  [IsWorkPermitCommunicationNotApplicable],
  [CommunicationRadioColor],
  [CommunicationByOtherDescription],
  [CoAuthorizationRequired],
  [StartAndOrEndTimesFinalized],
  EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
  AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable
)
values (
  @COMPLETED_STATUS_ID,   -- WorkPermitStatusId
  '3.2',
  NULL,   -- CoAuthorizationDescription
  0,   -- ToolsAirTools
  0,   -- ToolsCraneOrCarrydeck
  0,   -- ToolsHandTools
  0,   -- ToolsJackhammer
  0,   -- ToolsVacuumTruck
  0,   -- ToolsCementSaw
  0,   -- ToolsElectricTools
  0,   -- ToolsHeavyEquipment
  0,   -- ToolsLanda
  0,   -- ToolsScaffolding
  0,   -- ToolsVehicle
  0,   -- ToolsCompressor
  0,   -- ToolsForklift
  0,   -- ToolsHEPAVacuum
  0,   -- ToolsManlift
  0,   -- ToolsTamper
  0,   -- ToolsHotTapMachine
  0,   -- ToolsPortLighting
  0,   -- ToolsTorch
  0,   -- ToolsWelder
  NULL,   -- ToolsOtherToolsDescription
  1,   -- ElectricIsolationMethodNotApplicable
  0,   -- ElectricIsolationMethodLOTO
  0,   -- ElectricIsolationMethodWiring
  1,   -- ElectricTestBumpNotApplicable
  0,   -- ElectricTestBump
  NULL,   -- EquipmentNoElectricalTestBumpComments
  1,   -- EquipmentStillContainsResidualNotApplicable
  0,   -- EquipmentStillContainsResidual
  NULL,   -- EquipmentStillContainsResidualComments
  1,   -- EquipmentLeakingValvesNotApplicable
  0,   -- EquipmentLeakingValves
  NULL,   -- EquipmentLeakingValvesComments
  1,   -- EquipmentIsOutOfService
  NULL,   -- EquipmentInServiceComments
  1,   -- EquipmentConditionNotApplicable
  0,   -- EquipmentConditionDepressured
  0,   -- EquipmentConditionDrained
  0,   -- EquipmentConditionCleaned
  0,   -- EquipmentConditionVentilated
  0,   -- EquipmentConditionH20Washed
  0,   -- EquipmentConditionNeutralized
  0,   -- EquipmentConditionPurged
  NULL,   -- EquipmentConditionPurgedDescription
  1,   -- EquipmentPreviousContentsNotApplicable
  0,   -- EquipmentPreviousContentsHydrocarbon
  0,   -- EquipmentPreviousContentsAcid
  0,   -- EquipmentPreviousContentsCaustic
  0,   -- EquipmentPreviousContentsH2S
  NULL,   -- EquipmentPreviousContentsOtherDescription
  1,   -- EquipmentIsolationMethodNotApplicable
  0,   -- EquipmentIsolationMethodBlindedorBlanked
  0,   -- EquipmentIsolationMethodBlockedIn
  0,   -- EquipmentIsolationMethodSeparation
  0,   -- EquipmentIsolationMethodMudderPlugs
  0,   -- EquipmentIsolationMethodLOTO
  NULL,   -- EquipmentIsolationMethodOtherDescription
  1,   -- EquipmentVentilationMethodNotApplicable
  0,   -- EquipmentVentilationMethodNaturalDraft
  0,   -- EquipmentVentilationMethodLocalExhaust
  0,   -- EquipmentVentilationMethodForced
  0,   -- JobSitePreparationFlowRequiredForJob
  1,   -- JobSitePreparationFlowRequiredForJobNotApplicable
  NULL,   -- JobSitePreparationFlowRequiredComments
  1,   -- JobSitePreparationBondingOrGroundingRequiredNotApplicable
  0,   -- JobSitePreparationBondingOrGroundingRequired
  NULL,   -- JobSitePreparationBondingGroundingNotRequiredComments
  1,   -- JobSitePreparationWeldingGroundWireInTestAreaNotApplicable
  0,   -- JobSitePreparationWeldingGroundWireInTestArea
  NULL,   -- JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments
  1,   -- JobSitePreparationCriticalConditionRemainJobSiteNotApplicable
  0,   -- JobSitePreparationCriticalConditionRemainJobSite
  NULL,   -- JobSitePreparationCriticalConditionsComments
  1,   -- JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable
  0,   -- JobSitePreparationSurroundingConditionsAffectOrContaminated
  NULL,   -- JobSitePreparationSurroundingConditionsAffectAreaComments
  1,   -- JobSitePreparationVestedBuddySystemInEffectNotApplicable
  0,   -- JobSitePreparationVestedBuddySystemInEffect
  1,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable
  0,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientation
  NULL,   -- JobSitePreparationPermitReceiverRequiresOrientationComments
  1,   -- JobSitePreparationSewerIsolationMethodNotApplicable
  0,   -- JobSitePreparationSewerIsolationMethodSealedOrCovered
  0,   -- JobSitePreparationSewerIsolationMethodPlugged
  0,   -- JobSitePreparationSewerIsolationMethodBlindedOrBlanked
  NULL,   -- JobSitePreparationSewerIsolationMethodOtherDescription
  1,   -- JobSitePreparationAreaPreparationNotApplicable
  0,   -- JobSitePreparationAreaPreparationBarricade
  0,   -- JobSitePreparationAreaPreparationNonEssentialEvac
  0,   -- JobSitePreparationAreaPreparationPreopBoundaryRopeTape
  NULL,   -- JobSitePreparationAreaPreparationOtherDescription
--  1,   -- JobSitePreparationDocumentationSignageNotApplicable
--  0,   -- JobSitePreparationDocumentationSignageBlankOrBlindList
--  0,   -- JobSitePreparationDocumentationSignageCSEPermit
--  0,   -- JobSitePreparationDocumentationSignageVesselPreparedForOpening
--  0,   -- JobSitePreparationDocumentationSignageRestrictedEntry
--  NULL,   -- JobSitePreparationDocumentationSignageOtherDescription
  1,   -- JobSitePreparationLightingElectricalRequirementNotApplicable
  0,   -- JobSitePreparationLightingElectricalRequirementLowVoltage12V
  0,   -- JobSitePreparationLightingElectricalRequirement110VWithGFCI
  0,   -- JobSitePreparationLightingElectricalRequirementGeneratorLights
  NULL,   -- JobSitePreparationLightingElectricalRequirementOtherDescription
  1,   -- RadiationSealedSourceIsolationNotApplicable
  0,   -- RadiationSealedSourceIsolationLOTO
  0,   -- RadiationSealedSourceIsolationOpen
  NULL,   -- RadiationSealedSourceIsolationNumberOfSources
  '',   -- GasTestFrequencyOrDuration
  0,   -- GasTestConstantMonitoringRequired
  NULL,   -- GasTestTestTime
  0,   -- FireConfinedSpace20ABCorDryChemicalExtinguisher
  0,   -- FireConfinedSpaceC02Extinguisher
  0,   -- FireConfinedSpaceFireResistantTarp
  0,   -- FireConfinedSpaceSparkContainment
  0,   -- FireConfinedSpaceWaterHose
  0,   -- FireConfinedSpaceSteamHose
  0,   -- FireConfinedSpaceWatchmen
  NULL,   -- FireConfinedSpaceOtherDescription
  0,   -- RespitoryProtectionRequirementsAirCartOrAirLine
  0,   -- RespitoryProtectionRequirementsSCBA
  0,   -- RespitoryProtectionRequirementsHalfFaceRespirator
  0,   -- RespitoryProtectionRequirementsFullFaceRespirator
  0,   -- RespitoryProtectionRequirementsDustMask
  0,   -- RespitoryProtectionRequirementsAirHood
  NULL,   -- RespitoryProtectionRequirementsOtherDescription
  NULL,   -- RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription
  0,   -- SpecialEyeOrFaceProtectionGoggles
  0,   -- SpecialEyeOrFaceProtectionFaceshield
  NULL,   -- SpecialEyeOrFaceProtectionOtherDescription
  0,   -- SpecialProtectiveClothingTypeRainCoat
  0,   -- SpecialProtectiveClothingTypeRainPants
  0,   -- SpecialProtectiveClothingTypeAcidClothing
  NULL,   -- SpecialProtectiveClothingTypeAcidClothingTypeID
  0,   -- SpecialProtectiveClothingTypeCausticWear
  NULL,   -- SpecialProtectiveClothingTypeOtherDescripton
  0,   -- SpecialProtectiveFootwearChemicalImperviousBoots
  0,   -- SpecialProtectiveFootwearToeGuard
  NULL,   -- SpecialProtectiveFootwearOtherDescription
  0,   -- SpecialHandProtectionChemicalNeprene
  0,   -- SpecialHandProtectionNaturalRubber
  0,   -- SpecialHandProtectionNitrile
  0,   -- SpecialHandProtectionPVC
  0,   -- SpecialHandProtectionHighVoltage
  0,   -- SpecialHandProtectionWelding
  0,   -- SpecialHandProtectionLeather
  NULL,   -- SpecialHandProtectionOtherDescription
  0,   -- SpecialRescueOrFallBodyHarness
  0,   -- SpecialRescueOrFallLifeline
  0,   -- SpecialRescueOrFallYoYo
  0,   -- SpecialRescueOrFallRescueDevice
  NULL,   -- SpecialRescueOrFallOtherDescription
  0,   -- SourceId
  1,   -- CreatedByUserId
  1,   -- IsOperations
  1,   -- LastModifiedUserId
  @END_7_DAYS_AGO,  -- LastModifiedDate
  6,   -- ApprovedByUserId
  0,   -- Deleted
  @FLOC_ID,   -- FunctionalLocationId
  NULL,   -- SapOperationId
  @DIVISION + '-0000000115',   -- PermitNumber
  'WON38717',   -- WorkOrderNumber
  @START_7_DAYS_AGO,  -- StartDateTime
  @END_7_DAYS_AGO,  -- EndDateTime
  NULL,   -- PermitValidDateTime
  2,   -- WorkPermitTypeId
  1,   -- WorkPermitTypeClassificationId
  'Completed work permit',   -- WorkOrderDescription
  NULL,   -- SpecialPrecautionsOrConsiderationsDescription
  0,   -- PermitConfinedSpaceEntry
  0,   -- PermitBreathingAirOrSCBA
  0,   -- PermitElectricalSwitching
  0,   -- PermitVehicleEntry
  0,   -- PermitHotTap
  0,   -- PermitBurnOrOpenFlame
  0,   -- PermitSystemEntry
  0,   -- PermitCriticalLift
  0,   -- PermitEnergizedElectrical
  0,   -- PermitExcavation
  0,   -- PermitAsbestos
  0,   -- PermitRadiationRadiography
  0,   -- PermitRadiationSealed
  0,   -- AdditionalCSEAssessmentOrAuthorization
  0,   -- AdditionalFlareEntry
  0,   -- AdditionalCriticalLift
  0,   -- AdditionalExcavation
  0,   -- AdditionalHotTap
  0,   -- AdditionalSpecialWasteDisposal
  0,   -- AdditionalBlankOrBlindLists
  0,   -- AdditionalPJSROrSafetyPause
  0,   -- AdditionalAsbestosHandling
  0,   -- AdditionalRoadClosure
  0,   -- AdditionalElectrical
  0,   -- AdditionalBurnOrOpenFlameAssessment
  0,   -- AdditionalWaiverOrDeviation
  0,   -- AdditionalMSDS
  0,   -- AdditionalRadiationApproval
  0,   -- AdditionalOnlineLeakRepairForm
  NULL,   -- AdditionalOtherFormsOrAssessmentsOrAuthorizations
  NULL,   -- ContactPersonnel
  NULL,   -- ContractorCompanyName
  1,   -- CraftOrTradeID
  'It is no longer used.  Once CraftOrTrade Table is ',   -- CraftOrTradeOther
  'Remove insulation',   -- JobStepDescription
  1,   -- CommunicationByRadio
  NULL,   -- CommunicationRadioChannelOrBand
  1,   -- IsWorkPermitCommunicationNotApplicable
  NULL,   -- CommunicationRadioColor
  NULL,   -- CommunicationByOtherDescription
  0,   -- CoAuthorizationRequired
  1,    -- StartAndOrEndTimesFinalized
  1,
  1,
null,
0,
0,
0,
0,
0,
0
);
  
select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END



END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;
GO


--
-- Additional work permits from SAP
--
DECLARE @FLOC_ID BIGINT;
DECLARE @WP_ID BIGINT;

DECLARE @SAP_START_DATE AS DATETIME;
DECLARE @SAP_END_DATE AS DATETIME;
DECLARE @LAST_MODIFIED_TIME AS DATETIME;

DECLARE @DIVISION AS VARCHAR(3);

SET @SAP_START_DATE = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110));
SET @SAP_END_DATE = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110));
SET @LAST_MODIFIED_TIME = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' 07:00:00.000');

DECLARE FLOC_ID_CURSOR CURSOR
FOR
  SELECT Id FROM FunctionalLocation
  WHERE    		
  (
			FullHierarchy like 'SR1-PLT2-%'
			or
			FullHierarchy like 'SR1-PLT3-%'
			or
			FullHierarchy like 'DN1-3003-%'
		)
		and [Level] = 3
		and (SiteId = 1 or SiteId = 2);

OPEN FLOC_ID_CURSOR;

FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;

WHILE (@@FETCH_STATUS <> -1)
BEGIN
   IF (@@FETCH_STATUS <> -2)
   BEGIN
   
select @DIVISION = COALESCE(fa.FullHierarchy, f.FullHierarchy)
		from
			FunctionalLocation f
			LEFT OUTER JOIN FunctionalLocationAncestor a on a.Id = f.Id and a.AncestorLevel = 1
			LEFT OUTER JOIN FunctionalLocation fa on fa.Id = a.AncestorId
		where
			f.Id = @FLOC_ID;

insert into WorkPermit (
  [WorkPermitStatusId],
  Version,
  [CoAuthorizationDescription],
  [ToolsAirTools],
  [ToolsCraneOrCarrydeck],
  [ToolsHandTools],
  [ToolsJackhammer],
  [ToolsVacuumTruck],
  [ToolsCementSaw],
  [ToolsElectricTools],
  [ToolsHeavyEquipment],
  [ToolsLanda],
  [ToolsScaffolding],
  [ToolsVehicle],
  [ToolsCompressor],
  [ToolsForklift],
  [ToolsHEPAVacuum],
  [ToolsManlift],
  [ToolsTamper],
  [ToolsHotTapMachine],
  [ToolsPortLighting],
  [ToolsTorch],
  [ToolsWelder],
  [ToolsOtherToolsDescription],
  [ElectricIsolationMethodNotApplicable],
  [ElectricIsolationMethodLOTO],
  [ElectricIsolationMethodWiring],
  [ElectricTestBumpNotApplicable],
  [ElectricTestBump],
  [EquipmentNoElectricalTestBumpComments],
  [EquipmentStillContainsResidualNotApplicable],
  [EquipmentStillContainsResidual],
  [EquipmentStillContainsResidualComments],
  [EquipmentLeakingValvesNotApplicable],
  [EquipmentLeakingValves],
  [EquipmentLeakingValvesComments],
  [EquipmentIsOutOfService],
  [EquipmentInServiceComments],
  [EquipmentConditionNotApplicable],
  [EquipmentConditionDepressured],
  [EquipmentConditionDrained],
  [EquipmentConditionCleaned],
  [EquipmentConditionVentilated],
  [EquipmentConditionH20Washed],
  [EquipmentConditionNeutralized],
  [EquipmentConditionPurged],
  [EquipmentConditionPurgedDescription],
  [EquipmentPreviousContentsNotApplicable],
  [EquipmentPreviousContentsHydrocarbon],
  [EquipmentPreviousContentsAcid],
  [EquipmentPreviousContentsCaustic],
  [EquipmentPreviousContentsH2S],
  [EquipmentPreviousContentsOtherDescription],
  [EquipmentIsolationMethodNotApplicable],
  [EquipmentIsolationMethodBlindedorBlanked],
  [EquipmentIsolationMethodBlockedIn],
  [EquipmentIsolationMethodSeparation],
  [EquipmentIsolationMethodMudderPlugs],
  [EquipmentIsolationMethodLOTO],
  [EquipmentIsolationMethodOtherDescription],
  [EquipmentVentilationMethodNotApplicable],
  [EquipmentVentilationMethodNaturalDraft],
  [EquipmentVentilationMethodLocalExhaust],
  [EquipmentVentilationMethodForced],
  [JobSitePreparationFlowRequiredForJob],
  [JobSitePreparationFlowRequiredForJobNotApplicable],
  [JobSitePreparationFlowRequiredComments],
  [JobSitePreparationBondingOrGroundingRequiredNotApplicable],
  [JobSitePreparationBondingOrGroundingRequired],
  [JobSitePreparationBondingGroundingNotRequiredComments],
  [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable],
  [JobSitePreparationWeldingGroundWireInTestArea],
  [JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments],
  [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable],
  [JobSitePreparationCriticalConditionRemainJobSite],
  [JobSitePreparationCriticalConditionsComments],
  [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable],
  [JobSitePreparationSurroundingConditionsAffectOrContaminated],
  [JobSitePreparationSurroundingConditionsAffectAreaComments],
  [JobSitePreparationVestedBuddySystemInEffectNotApplicable],
  [JobSitePreparationVestedBuddySystemInEffect],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable],
  [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation],
  [JobSitePreparationPermitReceiverRequiresOrientationComments],
  [JobSitePreparationSewerIsolationMethodNotApplicable],
  [JobSitePreparationSewerIsolationMethodSealedOrCovered],
  [JobSitePreparationSewerIsolationMethodPlugged],
  [JobSitePreparationSewerIsolationMethodBlindedOrBlanked],
  [JobSitePreparationSewerIsolationMethodOtherDescription],
  [JobSitePreparationAreaPreparationNotApplicable],
  [JobSitePreparationAreaPreparationBarricade],
  [JobSitePreparationAreaPreparationNonEssentialEvac],
  [JobSitePreparationAreaPreparationPreopBoundaryRopeTape],
  [JobSitePreparationAreaPreparationOtherDescription],
--  [JobSitePreparationDocumentationSignageNotApplicable],
--  [JobSitePreparationDocumentationSignageBlankOrBlindList],
--  [JobSitePreparationDocumentationSignageCSEPermit],
--  [JobSitePreparationDocumentationSignageVesselPreparedForOpening],
--  [JobSitePreparationDocumentationSignageRestrictedEntry],
--  [JobSitePreparationDocumentationSignageOtherDescription],
  [JobSitePreparationLightingElectricalRequirementNotApplicable],
  [JobSitePreparationLightingElectricalRequirementLowVoltage12V],
  [JobSitePreparationLightingElectricalRequirement110VWithGFCI],
  [JobSitePreparationLightingElectricalRequirementGeneratorLights],
  [JobSitePreparationLightingElectricalRequirementOtherDescription],
  [RadiationSealedSourceIsolationNotApplicable],
  [RadiationSealedSourceIsolationLOTO],
  [RadiationSealedSourceIsolationOpen],
  [RadiationSealedSourceIsolationNumberOfSources],
  [GasTestFrequencyOrDuration],
  [GasTestConstantMonitoringRequired],
  [GasTestTestTime],
  [FireConfinedSpace20ABCorDryChemicalExtinguisher],
  [FireConfinedSpaceC02Extinguisher],
  [FireConfinedSpaceFireResistantTarp],
  [FireConfinedSpaceSparkContainment],
  [FireConfinedSpaceWaterHose],
  [FireConfinedSpaceSteamHose],
  [FireConfinedSpaceWatchmen],
  [FireConfinedSpaceOtherDescription],
  [RespitoryProtectionRequirementsAirCartOrAirLine],
  [RespitoryProtectionRequirementsSCBA],
  [RespitoryProtectionRequirementsHalfFaceRespirator],
  [RespitoryProtectionRequirementsFullFaceRespirator],
  [RespitoryProtectionRequirementsDustMask],
  [RespitoryProtectionRequirementsAirHood],
  [RespitoryProtectionRequirementsOtherDescription],
  [RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription],
  [SpecialEyeOrFaceProtectionGoggles],
  [SpecialEyeOrFaceProtectionFaceshield],
  [SpecialEyeOrFaceProtectionOtherDescription],
  [SpecialProtectiveClothingTypeRainCoat],
  [SpecialProtectiveClothingTypeRainPants],
  [SpecialProtectiveClothingTypeAcidClothing],
  [SpecialProtectiveClothingTypeAcidClothingTypeID],
  [SpecialProtectiveClothingTypeCausticWear],
  [SpecialProtectiveClothingTypeOtherDescripton],
  [SpecialProtectiveFootwearChemicalImperviousBoots],
  [SpecialProtectiveFootwearToeGuard],
  [SpecialProtectiveFootwearOtherDescription],
  [SpecialHandProtectionChemicalNeprene],
  [SpecialHandProtectionNaturalRubber],
  [SpecialHandProtectionNitrile],
  [SpecialHandProtectionPVC],
  [SpecialHandProtectionHighVoltage],
  [SpecialHandProtectionWelding],
  [SpecialHandProtectionLeather],
  [SpecialHandProtectionOtherDescription],
  [SpecialRescueOrFallBodyHarness],
  [SpecialRescueOrFallLifeline],
  [SpecialRescueOrFallYoYo],
  [SpecialRescueOrFallRescueDevice],
  [SpecialRescueOrFallOtherDescription],
  [SourceId],
  [CreatedByUserId],
  [IsOperations],
  [LastModifiedUserId],
  [LastModifiedDate],
  [ApprovedByUserId],
  [Deleted],
  [FunctionalLocationId],
  [SapOperationId],
  [PermitNumber],
  [WorkOrderNumber],
  [StartDateTime],
  [EndDateTime],
  [PermitValidDateTime],
  [WorkPermitTypeId],
  [WorkPermitTypeClassificationId],
  [WorkOrderDescription],
  [SpecialPrecautionsOrConsiderationsDescription],
  [PermitConfinedSpaceEntry],
  [PermitBreathingAirOrSCBA],
  [PermitElectricalSwitching],
  [PermitVehicleEntry],
  [PermitHotTap],
  [PermitBurnOrOpenFlame],
  [PermitSystemEntry],
  [PermitCriticalLift],
  [PermitEnergizedElectrical],
  [PermitExcavation],
  [PermitAsbestos],
  [PermitRadiationRadiography],
  [PermitRadiationSealed],
  [AdditionalCSEAssessmentOrAuthorization],
  [AdditionalFlareEntry],
  [AdditionalCriticalLift],
  [AdditionalExcavation],
  [AdditionalHotTap],
  [AdditionalSpecialWasteDisposal],
  [AdditionalBlankOrBlindLists],
  [AdditionalPJSROrSafetyPause],
  [AdditionalAsbestosHandling],
  [AdditionalRoadClosure],
  [AdditionalElectrical],
  [AdditionalBurnOrOpenFlameAssessment],
  [AdditionalWaiverOrDeviation],
  [AdditionalMSDS],
  [AdditionalRadiationApproval],
  [AdditionalOnlineLeakRepairForm],
  [AdditionalOtherFormsOrAssessmentsOrAuthorizations],
  [ContactPersonnel],
  [ContractorCompanyName],
  [CraftOrTradeID],
  [CraftOrTradeOther],
  [JobStepDescription],
  [CommunicationByRadio],
  [CommunicationRadioChannelOrBand],
  [IsWorkPermitCommunicationNotApplicable],
  [CommunicationRadioColor],
  [CommunicationByOtherDescription],
  [CoAuthorizationRequired],
  [StartAndOrEndTimesFinalized],
  EquipmentIsHazardousEnergyIsolationRequiredNotApplicable,
  AsbestosHazardsConsideredNotApplicable,
 SpecialFallOtherDescription,
 SpecialFallRestraint,
 SpecialFallSelfRetractingDevice,
 SpecialFallTieoffRequired,
 GasTestForkliftNotUsed,
 AdditionalIsEnergizedElectricalForm,
 AdditionalIsNotApplicable

)
values (
  1,   -- WorkPermitStatusId
  '3.2',
  NULL,   -- CoAuthorizationDescription
  0,   -- ToolsAirTools
  0,   -- ToolsCraneOrCarrydeck
  0,   -- ToolsHandTools
  0,   -- ToolsJackhammer
  0,   -- ToolsVacuumTruck
  0,   -- ToolsCementSaw
  0,   -- ToolsElectricTools
  0,   -- ToolsHeavyEquipment
  0,   -- ToolsLanda
  0,   -- ToolsScaffolding
  0,   -- ToolsVehicle
  0,   -- ToolsCompressor
  0,   -- ToolsForklift
  0,   -- ToolsHEPAVacuum
  0,   -- ToolsManlift
  0,   -- ToolsTamper
  0,   -- ToolsHotTapMachine
  0,   -- ToolsPortLighting
  0,   -- ToolsTorch
  0,   -- ToolsWelder
  NULL,   -- ToolsOtherToolsDescription
  1,   -- ElectricIsolationMethodNotApplicable
  0,   -- ElectricIsolationMethodLOTO
  0,   -- ElectricIsolationMethodWiring
  1,   -- ElectricTestBumpNotApplicable
  0,   -- ElectricTestBump
  NULL,   -- EquipmentNoElectricalTestBumpComments
  1,   -- EquipmentStillContainsResidualNotApplicable
  0,   -- EquipmentStillContainsResidual
  NULL,   -- EquipmentStillContainsResidualComments
  1,   -- EquipmentLeakingValvesNotApplicable
  0,   -- EquipmentLeakingValves
  NULL,   -- EquipmentLeakingValvesComments
  1,   -- EquipmentIsOutOfService
  NULL,   -- EquipmentInServiceComments
  1,   -- EquipmentConditionNotApplicable
  0,   -- EquipmentConditionDepressured
  0,   -- EquipmentConditionDrained
  0,   -- EquipmentConditionCleaned
  0,   -- EquipmentConditionVentilated
  0,   -- EquipmentConditionH20Washed
  0,   -- EquipmentConditionNeutralized
  0,   -- EquipmentConditionPurged
  NULL,   -- EquipmentConditionPurgedDescription
  1,   -- EquipmentPreviousContentsNotApplicable
  0,   -- EquipmentPreviousContentsHydrocarbon
  0,   -- EquipmentPreviousContentsAcid
  0,   -- EquipmentPreviousContentsCaustic
  0,   -- EquipmentPreviousContentsH2S
  NULL,   -- EquipmentPreviousContentsOtherDescription
  1,   -- EquipmentIsolationMethodNotApplicable
  0,   -- EquipmentIsolationMethodBlindedorBlanked
  0,   -- EquipmentIsolationMethodBlockedIn
  0,   -- EquipmentIsolationMethodSeparation
  0,   -- EquipmentIsolationMethodMudderPlugs
  0,   -- EquipmentIsolationMethodLOTO
  NULL,   -- EquipmentIsolationMethodOtherDescription
  1,   -- EquipmentVentilationMethodNotApplicable
  0,   -- EquipmentVentilationMethodNaturalDraft
  0,   -- EquipmentVentilationMethodLocalExhaust
  0,   -- EquipmentVentilationMethodForced
  0,   -- JobSitePreparationFlowRequiredForJob
  1,   -- JobSitePreparationFlowRequiredForJobNotApplicable
  NULL,   -- JobSitePreparationFlowRequiredComments
  1,   -- JobSitePreparationBondingOrGroundingRequiredNotApplicable
  0,   -- JobSitePreparationBondingOrGroundingRequired
  NULL,   -- JobSitePreparationBondingGroundingNotRequiredComments
  1,   -- JobSitePreparationWeldingGroundWireInTestAreaNotApplicable
  0,   -- JobSitePreparationWeldingGroundWireInTestArea
  NULL,   -- JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments
  1,   -- JobSitePreparationCriticalConditionRemainJobSiteNotApplicable
  0,   -- JobSitePreparationCriticalConditionRemainJobSite
  NULL,   -- JobSitePreparationCriticalConditionsComments
  1,   -- JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable
  0,   -- JobSitePreparationSurroundingConditionsAffectOrContaminated
  NULL,   -- JobSitePreparationSurroundingConditionsAffectAreaComments
  1,   -- JobSitePreparationVestedBuddySystemInEffectNotApplicable
  0,   -- JobSitePreparationVestedBuddySystemInEffect
  1,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable
  0,   -- JobSitePreparationPermitReceiverFieldOrEquipmentOrientation
  NULL,   -- JobSitePreparationPermitReceiverRequiresOrientationComments
  1,   -- JobSitePreparationSewerIsolationMethodNotApplicable
  0,   -- JobSitePreparationSewerIsolationMethodSealedOrCovered
  0,   -- JobSitePreparationSewerIsolationMethodPlugged
  0,   -- JobSitePreparationSewerIsolationMethodBlindedOrBlanked
  NULL,   -- JobSitePreparationSewerIsolationMethodOtherDescription
  1,   -- JobSitePreparationAreaPreparationNotApplicable
  0,   -- JobSitePreparationAreaPreparationBarricade
  0,   -- JobSitePreparationAreaPreparationNonEssentialEvac
  0,   -- JobSitePreparationAreaPreparationPreopBoundaryRopeTape
  NULL,   -- JobSitePreparationAreaPreparationOtherDescription
--  1,   -- JobSitePreparationDocumentationSignageNotApplicable
--  0,   -- JobSitePreparationDocumentationSignageBlankOrBlindList
--  0,   -- JobSitePreparationDocumentationSignageCSEPermit
--  0,   -- JobSitePreparationDocumentationSignageVesselPreparedForOpening
--  0,   -- JobSitePreparationDocumentationSignageRestrictedEntry
--  NULL,   -- JobSitePreparationDocumentationSignageOtherDescription
  1,   -- JobSitePreparationLightingElectricalRequirementNotApplicable
  0,   -- JobSitePreparationLightingElectricalRequirementLowVoltage12V
  0,   -- JobSitePreparationLightingElectricalRequirement110VWithGFCI
  0,   -- JobSitePreparationLightingElectricalRequirementGeneratorLights
  NULL,   -- JobSitePreparationLightingElectricalRequirementOtherDescription
  1,   -- RadiationSealedSourceIsolationNotApplicable
  0,   -- RadiationSealedSourceIsolationLOTO
  0,   -- RadiationSealedSourceIsolationOpen
  NULL,   -- RadiationSealedSourceIsolationNumberOfSources
  '',   -- GasTestFrequencyOrDuration
  0,   -- GasTestConstantMonitoringRequired
  NULL,   -- GasTestTestTime
  0,   -- FireConfinedSpace20ABCorDryChemicalExtinguisher
  0,   -- FireConfinedSpaceC02Extinguisher
  0,   -- FireConfinedSpaceFireResistantTarp
  0,   -- FireConfinedSpaceSparkContainment
  0,   -- FireConfinedSpaceWaterHose
  0,   -- FireConfinedSpaceSteamHose
  0,   -- FireConfinedSpaceWatchmen
  NULL,   -- FireConfinedSpaceOtherDescription
  0,   -- RespitoryProtectionRequirementsAirCartOrAirLine
  0,   -- RespitoryProtectionRequirementsSCBA
  0,   -- RespitoryProtectionRequirementsHalfFaceRespirator
  0,   -- RespitoryProtectionRequirementsFullFaceRespirator
  0,   -- RespitoryProtectionRequirementsDustMask
  0,   -- RespitoryProtectionRequirementsAirHood
  NULL,   -- RespitoryProtectionRequirementsOtherDescription
  NULL,   -- RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription
  0,   -- SpecialEyeOrFaceProtectionGoggles
  0,   -- SpecialEyeOrFaceProtectionFaceshield
  NULL,   -- SpecialEyeOrFaceProtectionOtherDescription
  0,   -- SpecialProtectiveClothingTypeRainCoat
  0,   -- SpecialProtectiveClothingTypeRainPants
  0,   -- SpecialProtectiveClothingTypeAcidClothing
  NULL,   -- SpecialProtectiveClothingTypeAcidClothingTypeID
  0,   -- SpecialProtectiveClothingTypeCausticWear
  NULL,   -- SpecialProtectiveClothingTypeOtherDescripton
  0,   -- SpecialProtectiveFootwearChemicalImperviousBoots
  0,   -- SpecialProtectiveFootwearToeGuard
  NULL,   -- SpecialProtectiveFootwearOtherDescription
  0,   -- SpecialHandProtectionChemicalNeprene
  0,   -- SpecialHandProtectionNaturalRubber
  0,   -- SpecialHandProtectionNitrile
  0,   -- SpecialHandProtectionPVC
  0,   -- SpecialHandProtectionHighVoltage
  0,   -- SpecialHandProtectionWelding
  0,   -- SpecialHandProtectionLeather
  NULL,   -- SpecialHandProtectionOtherDescription
  0,   -- SpecialRescueOrFallBodyHarness
  0,   -- SpecialRescueOrFallLifeline
  0,   -- SpecialRescueOrFallYoYo
  0,   -- SpecialRescueOrFallRescueDevice
  NULL,   -- SpecialRescueOrFallOtherDescription
  1,   -- SourceId: SAP
  1,   -- CreatedByUserId
  1,   -- IsOperations
  1,   -- LastModifiedUserId
  @LAST_MODIFIED_TIME,  -- LastModifiedDate
  NULL,   -- ApprovedByUserId
  0,   -- Deleted
  @FLOC_ID,   -- FunctionalLocationId
  NULL,   -- SapOperationId
  @DIVISION + '-0001110076',   -- PermitNumber
  'WON96969',   -- WorkOrderNumber
  @SAP_START_DATE,  -- StartDateTime
  @SAP_END_DATE,  -- EndDateTime
  NULL,   -- PermitValidDateTime
  2,   -- WorkPermitTypeId
  1,   -- WorkPermitTypeClassificationId
  'Repair pump seal and bearings',   -- WorkOrderDescription
  NULL,   -- SpecialPrecautionsOrConsiderationsDescription
  0,   -- PermitConfinedSpaceEntry
  0,   -- PermitBreathingAirOrSCBA
  0,   -- PermitElectricalSwitching
  0,   -- PermitVehicleEntry
  0,   -- PermitHotTap
  0,   -- PermitBurnOrOpenFlame
  0,   -- PermitSystemEntry
  0,   -- PermitCriticalLift
  0,   -- PermitEnergizedElectrical
  0,   -- PermitExcavation
  0,   -- PermitAsbestos
  0,   -- PermitRadiationRadiography
  0,   -- PermitRadiationSealed
  0,   -- AdditionalCSEAssessmentOrAuthorization
  0,   -- AdditionalFlareEntry
  0,   -- AdditionalCriticalLift
  0,   -- AdditionalExcavation
  0,   -- AdditionalHotTap
  0,   -- AdditionalSpecialWasteDisposal
  0,   -- AdditionalBlankOrBlindLists
  0,   -- AdditionalPJSROrSafetyPause
  0,   -- AdditionalAsbestosHandling
  0,   -- AdditionalRoadClosure
  0,   -- AdditionalElectrical
  0,   -- AdditionalBurnOrOpenFlameAssessment
  0,   -- AdditionalWaiverOrDeviation
  0,   -- AdditionalMSDS
  0,   -- AdditionalRadiationApproval
  0,   -- AdditionalOnlineLeakRepairForm
  NULL,   -- AdditionalOtherFormsOrAssessmentsOrAuthorizations
  NULL,   -- ContactPersonnel
  NULL,   -- ContractorCompanyName
  23,   -- CraftOrTradeID
  'It is no longer used.  Once CraftOrTrade Table is ',   -- CraftOrTradeOther
  'Install blanks',   -- JobStepDescription
  1,   -- CommunicationByRadio
  NULL,   -- CommunicationRadioChannelOrBand
  1,   -- IsWorkPermitCommunicationNotApplicable
  NULL,   -- CommunicationRadioColor
  NULL,   -- CommunicationByOtherDescription
  0,   -- CoAuthorizationRequired
  1,    -- StartAndOrEndTimesFinalized
  1,
  1,
null,
0,
0,
0,
0,
0,
0
);
  
select @WP_ID = max(Id) from WorkPermit;

IF (@DIVISION = 'SR1')
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,1,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,2,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,3,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,4,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,5,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,6,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,7,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,8,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,9,0,NULL);
END
ELSE
BEGIN
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,229,1,90);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,230,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,231,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,232,0,NULL);
	insert into WorkPermitGasTestElementInfo (WorkPermitId, GasTestElementInfoId, RequiredTest, FirstTestResult)
		values(@WP_ID,233,0,NULL);
END

END;
   FETCH NEXT FROM FLOC_ID_CURSOR INTO @FLOC_ID;
END;

CLOSE FLOC_ID_CURSOR;
DEALLOCATE FLOC_ID_CURSOR;
GO