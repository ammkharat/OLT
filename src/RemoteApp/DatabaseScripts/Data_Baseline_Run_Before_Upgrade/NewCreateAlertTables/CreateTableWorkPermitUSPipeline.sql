
/****** Object:  Table [dbo].[WorkPermitUSPipeline]    Script Date: 14/2/2019 3:50:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WorkPermitUSPipeline') 
BEGIN


CREATE TABLE [dbo].[WorkPermitUSPipeline](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitStatusId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[SapOperationId] [bigint] NULL,
	[PermitNumber] [varchar](50) NULL,
	[WorkOrderNumber] [varchar](50) NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[PermitValidDateTime] [datetime] NULL,
	[WorkPermitTypeId] [bigint] NOT NULL,
	[WorkPermitTypeClassificationId] [bigint] NULL,
	[WorkOrderDescription] [varchar](max) NULL,
	[SpecialPrecautionsOrConsiderationsDescription] [varchar](max) NULL,
	[PermitConfinedSpaceEntry] [bit] NOT NULL,
	[PermitBreathingAirOrSCBA] [bit] NOT NULL,
	[PermitElectricalSwitching] [bit] NOT NULL,
	[PermitVehicleEntry] [bit] NOT NULL,
	[PermitHotTap] [bit] NOT NULL,
	[PermitBurnOrOpenFlame] [bit] NOT NULL,
	[PermitSystemEntry] [bit] NOT NULL,
	[PermitCriticalLift] [bit] NOT NULL,
	[PermitEnergizedElectrical] [bit] NOT NULL,
	[PermitExcavation] [bit] NOT NULL,
	[PermitAsbestos] [bit] NOT NULL,
	[PermitRadiationRadiography] [bit] NOT NULL,
	[PermitRadiationSealed] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorization] [bit] NOT NULL,
	[AdditionalFlareEntry] [bit] NOT NULL,
	[AdditionalCriticalLift] [bit] NOT NULL,
	[AdditionalExcavation] [bit] NOT NULL,
	[AdditionalHotTap] [bit] NOT NULL,
	[AdditionalSpecialWasteDisposal] [bit] NOT NULL,
	[AdditionalBlankOrBlindLists] [bit] NOT NULL,
	[AdditionalPJSROrSafetyPause] [bit] NOT NULL,
	[AdditionalAsbestosHandling] [bit] NOT NULL,
	[AdditionalRoadClosure] [bit] NOT NULL,
	[AdditionalElectrical] [bit] NOT NULL,
	[AdditionalBurnOrOpenFlameAssessment] [bit] NOT NULL,
	[AdditionalWaiverOrDeviation] [bit] NOT NULL,
	[AdditionalMSDS] [bit] NOT NULL,
	[AdditionalOtherFormsOrAssessmentsOrAuthorizations] [varchar](50) NULL,
	[ContactPersonnel] [varchar](50) NULL,
	[ContractorCompanyName] [varchar](50) NULL,
	[CraftOrTradeID] [bigint] NULL,
	[CraftOrTradeOther] [varchar](50) NULL,
	[JobStepDescription] [varchar](max) NULL,
	[CommunicationByRadio] [bit] NULL,
	[CommunicationRadioChannelOrBand] [varchar](20) NULL,
	[IsWorkPermitCommunicationNotApplicable] [bit] NOT NULL,
	[CommunicationRadioColor] [varchar](20) NULL,
	[CommunicationByOtherDescription] [varchar](50) NULL,
	[CoAuthorizationRequired] [bit] NULL,
	[CoAuthorizationDescription] [varchar](50) NULL,
	[ToolsAirTools] [bit] NOT NULL,
	[ToolsCraneOrCarrydeck] [bit] NOT NULL,
	[ToolsHandTools] [bit] NOT NULL,
	[ToolsJackhammer] [bit] NOT NULL,
	[ToolsVacuumTruck] [bit] NOT NULL,
	[ToolsCementSaw] [bit] NOT NULL,
	[ToolsElectricTools] [bit] NOT NULL,
	[ToolsHeavyEquipment] [bit] NOT NULL,
	[ToolsLanda] [bit] NOT NULL,
	[ToolsScaffolding] [bit] NOT NULL,
	[ToolsVehicle] [bit] NOT NULL,
	[ToolsCompressor] [bit] NOT NULL,
	[ToolsForklift] [bit] NOT NULL,
	[ToolsHEPAVacuum] [bit] NOT NULL,
	[ToolsManlift] [bit] NOT NULL,
	[ToolsTamper] [bit] NOT NULL,
	[ToolsHotTapMachine] [bit] NOT NULL,
	[ToolsPortLighting] [bit] NOT NULL,
	[ToolsTorch] [bit] NOT NULL,
	[ToolsWelder] [bit] NOT NULL,
	[ToolsOtherToolsDescription] [varchar](50) NULL,
	[ElectricIsolationMethodNotApplicable] [bit] NOT NULL,
	[ElectricIsolationMethodLOTO] [bit] NOT NULL,
	[ElectricIsolationMethodWiring] [bit] NOT NULL,
	[ElectricTestBumpNotApplicable] [bit] NOT NULL,
	[ElectricTestBump] [bit] NULL,
	[EquipmentNoElectricalTestBumpComments] [varchar](400) NULL,
	[EquipmentStillContainsResidualNotApplicable] [bit] NOT NULL,
	[EquipmentStillContainsResidual] [bit] NULL,
	[EquipmentStillContainsResidualComments] [varchar](400) NULL,
	[EquipmentLeakingValvesNotApplicable] [bit] NOT NULL,
	[EquipmentLeakingValves] [bit] NULL,
	[EquipmentLeakingValvesComments] [varchar](400) NULL,
	[EquipmentIsOutOfService] [bit] NULL,
	[EquipmentInServiceComments] [varchar](400) NULL,
	[EquipmentConditionNotApplicable] [bit] NOT NULL,
	[EquipmentConditionDepressured] [bit] NOT NULL,
	[EquipmentConditionDrained] [bit] NOT NULL,
	[EquipmentConditionCleaned] [bit] NOT NULL,
	[EquipmentConditionVentilated] [bit] NOT NULL,
	[EquipmentConditionH20Washed] [bit] NOT NULL,
	[EquipmentConditionNeutralized] [bit] NOT NULL,
	[EquipmentConditionPurged] [bit] NOT NULL,
	[EquipmentConditionPurgedDescription] [varchar](50) NULL,
	[EquipmentPreviousContentsNotApplicable] [bit] NOT NULL,
	[EquipmentPreviousContentsHydrocarbon] [bit] NOT NULL,
	[EquipmentPreviousContentsAcid] [bit] NOT NULL,
	[EquipmentPreviousContentsCaustic] [bit] NOT NULL,
	[EquipmentPreviousContentsH2S] [bit] NOT NULL,
	[EquipmentPreviousContentsOtherDescription] [varchar](50) NULL,
	[EquipmentIsolationMethodNotApplicable] [bit] NOT NULL,
	[EquipmentIsolationMethodBlindedorBlanked] [bit] NOT NULL,
	[EquipmentIsolationMethodBlockedIn] [bit] NOT NULL,
	[EquipmentIsolationMethodSeparation] [bit] NOT NULL,
	[EquipmentIsolationMethodMudderPlugs] [bit] NOT NULL,
	[EquipmentIsolationMethodLOTO] [bit] NOT NULL,
	[EquipmentIsolationMethodOtherDescription] [varchar](50) NULL,
	[JobSitePreparationFlowRequiredForJob] [bit] NULL,
	[JobSitePreparationFlowRequiredForJobNotApplicable] [bit] NOT NULL,
	[JobSitePreparationFlowRequiredComments] [varchar](400) NULL,
	[JobSitePreparationBondingOrGroundingRequiredNotApplicable] [bit] NOT NULL,
	[JobSitePreparationBondingOrGroundingRequired] [bit] NULL,
	[JobSitePreparationBondingGroundingNotRequiredComments] [varchar](400) NULL,
	[JobSitePreparationWeldingGroundWireInTestAreaNotApplicable] [bit] NOT NULL,
	[JobSitePreparationWeldingGroundWireInTestArea] [bit] NULL,
	[JobSitePreparationWeldingGroundWireNotWithinGasTestAreaComments] [varchar](400) NULL,
	[JobSitePreparationCriticalConditionRemainJobSiteNotApplicable] [bit] NOT NULL,
	[JobSitePreparationCriticalConditionRemainJobSite] [bit] NULL,
	[JobSitePreparationCriticalConditionsComments] [varchar](400) NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSurroundingConditionsAffectOrContaminated] [bit] NULL,
	[JobSitePreparationSurroundingConditionsAffectAreaComments] [varchar](400) NULL,
	[JobSitePreparationVestedBuddySystemInEffectNotApplicable] [bit] NOT NULL,
	[JobSitePreparationVestedBuddySystemInEffect] [bit] NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationPermitReceiverFieldOrEquipmentOrientation] [bit] NULL,
	[JobSitePreparationPermitReceiverRequiresOrientationComments] [varchar](400) NULL,
	[JobSitePreparationSewerIsolationMethodNotApplicable] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodSealedOrCovered] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodPlugged] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodBlindedOrBlanked] [bit] NOT NULL,
	[JobSitePreparationSewerIsolationMethodOtherDescription] [varchar](50) NULL,
	[EquipmentVentilationMethodNotApplicable] [bit] NOT NULL,
	[EquipmentVentilationMethodNaturalDraft] [bit] NOT NULL,
	[EquipmentVentilationMethodLocalExhaust] [bit] NOT NULL,
	[EquipmentVentilationMethodForced] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNotApplicable] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationBarricade] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationNonEssentialEvac] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationPreopBoundaryRopeTape] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationOtherDescription] [varchar](50) NULL,
	[JobSitePreparationLightingElectricalRequirementNotApplicable] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementLowVoltage12V] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirement110VWithGFCI] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementGeneratorLights] [bit] NOT NULL,
	[JobSitePreparationLightingElectricalRequirementOtherDescription] [varchar](50) NULL,
	[RadiationSealedSourceIsolationNotApplicable] [bit] NOT NULL,
	[RadiationSealedSourceIsolationLOTO] [bit] NOT NULL,
	[RadiationSealedSourceIsolationOpen] [bit] NOT NULL,
	[RadiationSealedSourceIsolationNumberOfSources] [int] NULL,
	[GasTestFrequencyOrDuration] [varchar](50) NULL,
	[GasTestConstantMonitoringRequired] [bit] NOT NULL,
	[FireConfinedSpace20ABCorDryChemicalExtinguisher] [bit] NOT NULL,
	[FireConfinedSpaceC02Extinguisher] [bit] NOT NULL,
	[FireConfinedSpaceFireResistantTarp] [bit] NOT NULL,
	[FireConfinedSpaceSparkContainment] [bit] NOT NULL,
	[FireConfinedSpaceWaterHose] [bit] NOT NULL,
	[FireConfinedSpaceSteamHose] [bit] NOT NULL,
	[FireConfinedSpaceWatchmen] [bit] NOT NULL,
	[FireConfinedSpaceOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsAirCartOrAirLine] [bit] NOT NULL,
	[RespitoryProtectionRequirementsSCBA] [bit] NOT NULL,
	[RespitoryProtectionRequirementsHalfFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsFullFaceRespirator] [bit] NOT NULL,
	[RespitoryProtectionRequirementsDustMask] [bit] NOT NULL,
	[RespitoryProtectionRequirementsAirHood] [bit] NOT NULL,
	[RespitoryProtectionRequirementsOtherDescription] [varchar](50) NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeDescription] [varchar](50) NULL,
	[SpecialEyeOrFaceProtectionGoggles] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionFaceshield] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionOtherDescription] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeRainCoat] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeRainPants] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothing] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeAcidClothingTypeID] [int] NULL,
	[SpecialProtectiveClothingTypeCausticWear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeOtherDescripton] [varchar](50) NULL,
	[SpecialProtectiveFootwearChemicalImperviousBoots] [bit] NOT NULL,
	[SpecialProtectiveFootwearToeGuard] [bit] NOT NULL,
	[SpecialProtectiveFootwearOtherDescription] [varchar](50) NULL,
	[SpecialHandProtectionChemicalNeprene] [bit] NOT NULL,
	[SpecialHandProtectionNaturalRubber] [bit] NOT NULL,
	[SpecialHandProtectionNitrile] [bit] NOT NULL,
	[SpecialHandProtectionPVC] [bit] NOT NULL,
	[SpecialHandProtectionHighVoltage] [bit] NOT NULL,
	[SpecialHandProtectionWelding] [bit] NOT NULL,
	[SpecialHandProtectionLeather] [bit] NOT NULL,
	[SpecialHandProtectionOtherDescription] [varchar](50) NULL,
	[SpecialRescueOrFallBodyHarness] [bit] NOT NULL,
	[SpecialRescueOrFallLifeline] [bit] NOT NULL,
	[SpecialRescueOrFallYoYo] [bit] NOT NULL,
	[SpecialRescueOrFallRescueDevice] [bit] NOT NULL,
	[SpecialRescueOrFallOtherDescription] [varchar](50) NULL,
	[SourceId] [int] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[Deleted] [bit] NOT NULL,
	[PermitInertConfinedSpaceEntry] [bit] NOT NULL,
	[PermitLeadAbatement] [bit] NOT NULL,
	[RespitoryProtectionRequirementsNotApplicable] [bit] NOT NULL,
	[SpecialEyeOrFaceProtectionNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeNotApplicable] [bit] NOT NULL,
	[SpecialProtectiveFootwearNotApplicable] [bit] NOT NULL,
	[SpecialHandProtectionNotApplicable] [bit] NOT NULL,
	[SpecialRescueOrFallNotApplicable] [bit] NOT NULL,
	[FireConfinedSpaceNotApplicable] [bit] NOT NULL,
	[StartAndOrEndTimesFinalized] [bit] NOT NULL,
	[PermitElectricalWork] [bit] NOT NULL,
	[SpecialProtectiveFootwearMetatarsalGuard] [bit] NOT NULL,
	[SpecialProtectiveClothingTypePaperCoveralls] [bit] NOT NULL,
	[EquipmentConditionOtherDescription] [varchar](50) NULL,
	[EquipmentConditionPurgedN2] [bit] NOT NULL,
	[EquipmentConditionPurgedSteamed] [bit] NOT NULL,
	[EquipmentConditionPurgedAir] [bit] NOT NULL,
	[AdditionalCSEAssessmentOrAuthorizationDescription] [varchar](50) NULL,
	[AdditionalBurnOrOpenFlameAssessmentDescription] [varchar](50) NULL,
	[AdditionalElectricalDescription] [varchar](50) NULL,
	[AdditionalAsbestosHandlingDescription] [varchar](50) NULL,
	[AdditionalCriticalLiftDescription] [varchar](50) NULL,
	[AdditionalWaiverOrDeviationDescription] [varchar](50) NULL,
	[AdditionalExcavationDescription] [varchar](50) NULL,
	[EquipmentAsbestosGasketsNotApplicable] [bit] NOT NULL,
	[EquipmentAsbestosGaskets] [bit] NULL,
	[EquipmentIsolationMethodCarBer] [bit] NOT NULL,
	[AdditionalRadiationApproval] [bit] NOT NULL,
	[AdditionalOnlineLeakRepairForm] [bit] NOT NULL,
	[FireConfinedSpaceHoleWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceFireWatchNumber] [varchar](50) NULL,
	[FireConfinedSpaceSpotterNumber] [varchar](50) NULL,
	[SpecialProtectiveClothingTypeTyvekSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeKapplerSuit] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeElectricalFlashGear] [bit] NOT NULL,
	[SpecialProtectiveClothingTypeCorrosiveClothing] [bit] NOT NULL,
	[SpecialHandProtectionChemicalGloves] [bit] NOT NULL,
	[RespitoryProtectionRequirementsRespiratoryCartridgeTypeId] [bigint] NULL,
	[ToolsChemicals] [bit] NOT NULL,
	[JobSitePreparationAreaPreparationRadiationRope] [bit] NOT NULL,
	[Version] [varchar](10) NOT NULL,
	[WorkAssignmentId] [bigint] NULL,
	[EquipmentIsHazardousEnergyIsolationRequiredNotApplicable] [bit] NOT NULL,
	[EquipmentIsHazardousEnergyIsolationRequired] [bit] NULL,
	[EquipmentLockOutMethodId] [bigint] NULL,
	[EquipmentLockOutMethodComments] [varchar](600) NULL,
	[EquipmentEnergyIsolationPlanNumber] [varchar](100) NULL,
	[EquipmentConditionsOfEIPSatisfied] [bit] NULL,
	[EquipmentConditionsOfEIPNotSatisfiedComments] [varchar](400) NULL,
	[AsbestosHazardsConsideredNotApplicable] [bit] NOT NULL,
	[AsbestosHazardsConsidered] [bit] NULL,
	[GasTestTestTime] [datetime] NULL,
	[GasTestSystemEntryTestTime] [datetime] NULL,
	[GasTestConfinedSpaceTestTime] [datetime] NULL,
	[IsOperations] [bit] NOT NULL,
	[SpecialFallOtherDescription] [varchar](50) NULL,
	[SpecialFallRestraint] [bit] NOT NULL,
	[SpecialFallSelfRetractingDevice] [bit] NOT NULL,
	[SpecialFallTieoffRequired] [bit] NULL,
	[GasTestForkliftNotUsed] [bit] NOT NULL,
	[AdditionalIsEnergizedElectricalForm] [bit] NOT NULL,
	[AdditionalIsNotApplicable] [bit] NOT NULL,
	[StartTimeNotApplicable] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitUSPipeline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitConfinedSpaceEntry]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitBreathingAirOrSCBA]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitElectricalSwitching]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitVehicleEntry]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitHotTap]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitBurnOrOpenFlame]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitSystemEntry]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitCriticalLift]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitEnergizedElectrical]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitExcavation]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitAsbestos]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitRadiationRadiography]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitRadiationSealed]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalCSEAssessmentOrAuthorization]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalFlareEntry]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalCriticalLift]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalExcavation]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalHotTap]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalSpecialWasteDisposal]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalBlankOrBlindLists]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalPJSROrSafetyPause]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalAsbestosHandling]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalRoadClosure]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalElectrical]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalBurnOrOpenFlameAssessment]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalWaiverOrDeviation]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [AdditionalMSDS]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((1)) FOR [CommunicationByRadio]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [IsWorkPermitCommunicationNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [CoAuthorizationRequired]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsAirTools]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsCraneOrCarrydeck]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsHandTools]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsJackhammer]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsVacuumTruck]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsCementSaw]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsElectricTools]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsHeavyEquipment]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsLanda]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsScaffolding]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsVehicle]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsCompressor]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsForklift]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsHEPAVacuum]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsManlift]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsTamper]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsHotTapMachine]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsPortLighting]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsTorch]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ToolsWelder]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ElectricIsolationMethodNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ElectricIsolationMethodLOTO]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ElectricIsolationMethodWiring]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ElectricTestBumpNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [ElectricTestBump]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentStillContainsResidualNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentStillContainsResidual]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentLeakingValvesNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentLeakingValves]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsOutOfService]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionDepressured]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionDrained]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionCleaned]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionVentilated]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionH20Washed]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionNeutralized]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurged]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentPreviousContentsNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentPreviousContentsHydrocarbon]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentPreviousContentsAcid]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentPreviousContentsCaustic]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentPreviousContentsH2S]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodBlindedorBlanked]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodBlockedIn]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodSeparation]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodMudderPlugs]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodLOTO]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationFlowRequiredForJob]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationFlowRequiredForJobNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationBondingOrGroundingRequiredNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationBondingOrGroundingRequired]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationWeldingGroundWireInTestAreaNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationWeldingGroundWireInTestArea]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationCriticalConditionRemainJobSiteNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationCriticalConditionRemainJobSite]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminatedNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSurroundingConditionsAffectOrContaminated]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationVestedBuddySystemInEffectNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationVestedBuddySystemInEffect]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientationNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationPermitReceiverFieldOrEquipmentOrientation]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSewerIsolationMethodNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSewerIsolationMethodSealedOrCovered]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSewerIsolationMethodPlugged]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationSewerIsolationMethodBlindedOrBlanked]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentVentilationMethodNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentVentilationMethodNaturalDraft]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentVentilationMethodLocalExhaust]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentVentilationMethodForced]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationBarricade]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationNonEssentialEvac]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationPreopBoundaryRopeTape]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationLightingElectricalRequirementNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationLightingElectricalRequirementLowVoltage12V]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationLightingElectricalRequirement110VWithGFCI]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [JobSitePreparationLightingElectricalRequirementGeneratorLights]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RadiationSealedSourceIsolationNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RadiationSealedSourceIsolationLOTO]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RadiationSealedSourceIsolationOpen]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [GasTestConstantMonitoringRequired]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpace20ABCorDryChemicalExtinguisher]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceC02Extinguisher]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceFireResistantTarp]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceSparkContainment]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceWaterHose]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceSteamHose]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [FireConfinedSpaceWatchmen]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsAirCartOrAirLine]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsSCBA]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsHalfFaceRespirator]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsFullFaceRespirator]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsDustMask]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsAirHood]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialEyeOrFaceProtectionGoggles]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialEyeOrFaceProtectionFaceshield]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeRainCoat]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeRainPants]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeAcidClothing]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeCausticWear]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveFootwearChemicalImperviousBoots]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveFootwearToeGuard]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionChemicalNeprene]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionNaturalRubber]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionNitrile]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionPVC]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionHighVoltage]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionWelding]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialHandProtectionLeather]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialRescueOrFallBodyHarness]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialRescueOrFallLifeline]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialRescueOrFallYoYo]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialRescueOrFallRescueDevice]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SourceId]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [Deleted]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitInertConfinedSpaceEntry]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitLeadAbatement]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_RespitoryProtectionRequirementsNotApplicable]  DEFAULT ((0)) FOR [RespitoryProtectionRequirementsNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialEyeOrFaceProtectionNotApplicable]  DEFAULT ((0)) FOR [SpecialEyeOrFaceProtectionNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveClothingTypeNotApplicable]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveFootwearNotApplicable]  DEFAULT ((0)) FOR [SpecialProtectiveFootwearNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialHandProtectionNotApplicable]  DEFAULT ((0)) FOR [SpecialHandProtectionNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialRescueOrFallNotApplicable]  DEFAULT ((0)) FOR [SpecialRescueOrFallNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_FireConfinedSpaceNotApplicable]  DEFAULT ((0)) FOR [FireConfinedSpaceNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [PermitElectricalWork]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveFootwearMetatarsalGuard]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypePaperCoveralls]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedN2]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedSteamed]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentConditionPurgedAir]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentAsbestosGasketsNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [EquipmentIsolationMethodCarBer]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_AdditionalRadiationApproval]  DEFAULT ((0)) FOR [AdditionalRadiationApproval]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_AdditionalOnlineLeakRepairForm]  DEFAULT ((0)) FOR [AdditionalOnlineLeakRepairForm]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveClothingTypeTyvekSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeTyvekSuit]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveClothingTypeKapplerSuit]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeKapplerSuit]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveClothingTypeElectricalFlashGear]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeElectricalFlashGear]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialProtectiveClothingTypeCorrosiveClothing]  DEFAULT ((0)) FOR [SpecialProtectiveClothingTypeCorrosiveClothing]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_SpecialHandProtectionChemicalGloves]  DEFAULT ((0)) FOR [SpecialHandProtectionChemicalGloves]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_ToolsChemicals]  DEFAULT ((0)) FOR [ToolsChemicals]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  CONSTRAINT [DF_WorkPermitUSPipeline_JobSitePreparationAreaPreparationRadiationRope]  DEFAULT ((0)) FOR [JobSitePreparationAreaPreparationRadiationRope]


ALTER TABLE [dbo].[WorkPermitUSPipeline] ADD  DEFAULT ((0)) FOR [StartTimeNotApplicable]


ALTER TABLE [dbo].[WorkPermitUSPipeline]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitUSPipeline_ApprovedByUserId] FOREIGN KEY([ApprovedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[WorkPermitUSPipeline] CHECK CONSTRAINT [FK_WorkPermitUSPipeline_ApprovedByUserId]


ALTER TABLE [dbo].[WorkPermitUSPipeline]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitUSPipeline_CraftOrTrade] FOREIGN KEY([CraftOrTradeID])
REFERENCES [dbo].[CraftOrTrade] ([Id])


ALTER TABLE [dbo].[WorkPermitUSPipeline] CHECK CONSTRAINT [FK_WorkPermitUSPipeline_CraftOrTrade]


ALTER TABLE [dbo].[WorkPermitUSPipeline]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitUSPipeline_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[WorkPermitUSPipeline] CHECK CONSTRAINT [FK_WorkPermitUSPipeline_CreatedByUserId]


ALTER TABLE [dbo].[WorkPermitUSPipeline]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitUSPipeline_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])


ALTER TABLE [dbo].[WorkPermitUSPipeline] CHECK CONSTRAINT [FK_WorkPermitUSPipeline_FunctionalLocation]


ALTER TABLE [dbo].[WorkPermitUSPipeline]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitUSPipeline_LastModifiedUserId] FOREIGN KEY([LastModifiedUserId])
REFERENCES [dbo].[User] ([Id])


ALTER TABLE [dbo].[WorkPermitUSPipeline] CHECK CONSTRAINT [FK_WorkPermitUSPipeline_LastModifiedUserId]

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitUSPipeline]') 
         AND name = 'ExtensionEnable'
)
BEGIN
ALTER TABLE WorkPermitUSPipeline ADD ExtensionEnable bit DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitUSPipeline]') 
         AND name = 'RevalidationEnable'
)
BEGIN
ALTER TABLE WorkPermitUSPipeline ADD RevalidationEnable bit DEFAULT NULL
END


END
