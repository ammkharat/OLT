if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestLubesHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertPermitRequestLubesHistory]
GO

CREATE Procedure [dbo].[InsertPermitRequestLubesHistory]
(
	@Id bigint,
	@CompletionStatusId int,
	@DocumentLinks varchar(max) = NULL,
	
	@IssuedToSuncor bit,
	@IssuedToCompany bit,
	@Company varchar(50) = NULL,
	@Trade varchar(50),
	@NumberOfWorkers int = NULL,
	@RequestedByGroup varchar(50) = NULL,
	@WorkPermitTypeId int,
	@IsVehicleEntry bit,
	
	@FunctionalLocation varchar(200),
	@Location varchar(50),
	
	@ConfinedSpace bit,
	@ConfinedSpaceClass varchar(50),
	@RescuePlan bit,
	@ConfinedSpaceSafetyWatchChecklist bit,	
	@SpecialWork bit,
	@SpecialWorkType varchar(50),
	
	@RequestedStartDate datetime,
	@RequestedStartTimeDay datetime = NULL,
	@RequestedStartTimeNight datetime = NULL,
	@EndDate datetime,
	
	@WorkOrderNumber varchar(12) = NULL,
	@OperationNumber varchar(max) = NULL,
	@SubOperationNumber varchar(max) = NULL,
	
	@HighEnergy tinyint,
    @CriticalLift tinyint,
    @Excavation tinyint,
    @EnergyControlPlan tinyint,
    @EquivalencyProc tinyint,
    @TestPneumatic tinyint,
    @LiveFlareWork tinyint,
    @EntryAndControlPlan tinyint,
	@EnergizedElectrical tinyint,
	
	@Description varchar(max) = NULL,
	@SapDescription varchar(max) = NULL,
	
	@HazardHydrocarbonGas bit,
	@HazardHydrocarbonLiquid bit,
	@HazardHydrogenSulphide bit,
	@HazardInertGasAtmosphere bit,
	@HazardOxygenDeficiency bit,
	@HazardRadioactiveSources bit,
	@HazardUndergroundOverheadHazards bit,
	@HazardDesignatedSubstance bit,
	
	@OtherHazardsAndOrRequirements varchar(max) = NULL,
	
	@OtherAreasAndOrUnitsAffected bit,
	@OtherAreasAndOrUnitsAffectedArea varchar(50) = NULL,
	@OtherAreasAndOrUnitsAffectedPersonNotified varchar(50) = NULL,
	
	@SpecificRequirementsSectionNotApplicableToJob bit,
	@AttendedAtAllTimes bit,
	@EyeProtection bit,
	@FallProtectionEquipment bit,
	@FullBodyHarnessRetrieval bit,
	@HearingProtection bit,
	@ProtectiveClothing bit,
	@Other1Checked bit,
	@Other1Value varchar(50) = NULL,

	@EquipmentBondedGrounded bit,
	@FireBlanket bit,
	@FireFightingEquipment bit,
	@FireWatch bit,
	@HydrantPermit bit,
	@WaterHose bit,
	@SteamHose bit,
	@Other2Checked bit,
	@Other2Value varchar(50) = NULL,

	@AirMover bit,
	@ContinuousGasMonitor bit,
	@DrowningProtection bit,
	@RespiratoryProtection bit,
	@Other3Checked bit,
	@Other3Value varchar(50) = NULL,

	@AdditionalLighting bit,
	@DesignateHotOrColdCutChecked bit,
	@DesignateHotOrColdCutValue varchar(50),
	@HoistingEquipment bit,
	@Ladder bit,
	@MotorizedEquipment bit,
	@Scaffold bit,
	@ReferToTipsProcedure bit,
	
	@GasDetectorBumpTested bit,

	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@LastImportedByUserId bigint = NULL,
	@LastImportedDateTime datetime = NULL,
	@LastSubmittedByUserId bigint = NULL,
	@LastSubmittedDateTime datetime = NULL
)
AS

INSERT INTO PermitRequestLubesHistory
(	
	Id,
	CompletionStatusId,
	DocumentLinks,
	IssuedToSuncor,
	IssuedToCompany,
	Company,
	Trade,
	NumberOfWorkers,
	RequestedByGroup,
	WorkPermitTypeId,
	IsVehicleEntry,
	FunctionalLocation,
	Location,	
	ConfinedSpace,
	ConfinedSpaceClass,
	RescuePlan,
	ConfinedSpaceSafetyWatchChecklist,
	SpecialWork,
	SpecialWorkType,
	RequestedStartDate,
	RequestedStartTimeDay,
	RequestedStartTimeNight,
	EndDate,
	WorkOrderNumber,
	OperationNumber,
	SubOperationNumber,
	HighEnergy,
    CriticalLift,
    Excavation,
    EnergyControlPlan,
    EquivalencyProc,
    TestPneumatic,
    LiveFlareWork,
    EntryAndControlPlan,
	EnergizedElectrical,
	Description,
	SapDescription,
	HazardHydrocarbonGas,
	HazardHydrocarbonLiquid,
	HazardHydrogenSulphide,
	HazardInertGasAtmosphere,
	HazardOxygenDeficiency,
	HazardRadioactiveSources,
	HazardUndergroundOverheadHazards,
	HazardDesignatedSubstance,
	OtherHazardsAndOrRequirements,		
	OtherAreasAndOrUnitsAffected,
	OtherAreasAndOrUnitsAffectedArea,	
	OtherAreasAndOrUnitsAffectedPersonNotified,
	SpecificRequirementsSectionNotApplicableToJob,
	AttendedAtAllTimes,
	EyeProtection,
	FallProtectionEquipment,
	FullBodyHarnessRetrieval,
	HearingProtection,
	ProtectiveClothing,
	Other1Checked,
	Other1Value,	
	EquipmentBondedGrounded,
	FireBlanket,
	FireFightingEquipment,
	FireWatch,
	HydrantPermit,
	WaterHose,
	SteamHose,
	Other2Checked,
	Other2Value,	
	AirMover,
	ContinuousGasMonitor,
	DrowningProtection,
	RespiratoryProtection,
	Other3Checked,
	Other3Value,	 
	AdditionalLighting,
	DesignateHotOrColdCutChecked,
	DesignateHotOrColdCutValue,	
	HoistingEquipment,
	Ladder,
	MotorizedEquipment,
	Scaffold,
	ReferToTipsProcedure,
	GasDetectorBumpTested,
	LastModifiedByUserId,
	LastModifiedDateTime,
	LastImportedByUserId,
	LastImportedDateTime,
	LastSubmittedByUserId,
	LastSubmittedDateTime
)
VALUES
(	
	@Id,	
	@CompletionStatusId,
	@DocumentLinks,
	@IssuedToSuncor,
	@IssuedToCompany,
	@Company,
	@Trade,
	@NumberOfWorkers,
	@RequestedByGroup,
	@WorkPermitTypeId,
	@IsVehicleEntry,
	@FunctionalLocation,
	@Location,	
	@ConfinedSpace,
	@ConfinedSpaceClass,
	@RescuePlan,
	@ConfinedSpaceSafetyWatchChecklist,
	@SpecialWork,
	@SpecialWorkType,
	@RequestedStartDate,
	@RequestedStartTimeDay,
	@RequestedStartTimeNight,
	@EndDate,
	@WorkOrderNumber,
	@OperationNumber,
	@SubOperationNumber,
	@HighEnergy,
    @CriticalLift,
    @Excavation,
    @EnergyControlPlan,
    @EquivalencyProc,
    @TestPneumatic,
    @LiveFlareWork,
    @EntryAndControlPlan,
	@EnergizedElectrical,
	@Description,
	@SapDescription,	
	@HazardHydrocarbonGas,
	@HazardHydrocarbonLiquid,
	@HazardHydrogenSulphide,
	@HazardInertGasAtmosphere,
	@HazardOxygenDeficiency,
	@HazardRadioactiveSources,
	@HazardUndergroundOverheadHazards,
	@HazardDesignatedSubstance,
	@OtherHazardsAndOrRequirements,		
	@OtherAreasAndOrUnitsAffected,
	@OtherAreasAndOrUnitsAffectedArea,	
	@OtherAreasAndOrUnitsAffectedPersonNotified,
	@SpecificRequirementsSectionNotApplicableToJob,
	@AttendedAtAllTimes,
	@EyeProtection,
	@FallProtectionEquipment,
	@FullBodyHarnessRetrieval,
	@HearingProtection,
	@ProtectiveClothing,
	@Other1Checked,
	@Other1Value,	
	@EquipmentBondedGrounded,
	@FireBlanket,
	@FireFightingEquipment,
	@FireWatch,
	@HydrantPermit,
	@WaterHose,
	@SteamHose,
	@Other2Checked,
	@Other2Value,	
	@AirMover,
	@ContinuousGasMonitor,
	@DrowningProtection,
	@RespiratoryProtection,
	@Other3Checked,
	@Other3Value,	 
	@AdditionalLighting,
	@DesignateHotOrColdCutChecked,
	@DesignateHotOrColdCutValue,	
	@HoistingEquipment,
	@Ladder,
	@MotorizedEquipment,
	@Scaffold,
	@ReferToTipsProcedure,
	@GasDetectorBumpTested,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@LastImportedByUserId,
	@LastImportedDateTime,
	@LastSubmittedByUserId,
	@LastSubmittedDateTime
)



