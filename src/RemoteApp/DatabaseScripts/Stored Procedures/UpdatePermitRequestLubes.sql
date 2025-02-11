if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePermitRequestLubes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdatePermitRequestLubes]
GO

CREATE Procedure [dbo].[UpdatePermitRequestLubes]
(
	@Id bigint,
				
	@Company varchar(50) = NULL,
	
	@CompletionStatusId int,
	@IssuedToSuncor bit,
	@IssuedToCompany bit,
	@Trade varchar(50),
	@SAPWorkCentre varchar(50),
	@NumberOfWorkers int = NULL,
	@RequestedByGroupId bigint,
	@WorkPermitTypeId int,
	@IsVehicleEntry bit,
	@FunctionalLocationId bigint,
	@Location varchar(50),
	@Description varchar(max),
	@SapDescription varchar(max) = NULL,

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

	@HighEnergy tinyint,
    @CriticalLift tinyint,
    @Excavation tinyint,
    @EnergyControlPlan tinyint,
    @EquivalencyProc tinyint,
    @TestPneumatic tinyint,
    @LiveFlareWork tinyint,
    @EntryAndControlPlan tinyint,
	@EnergizedElectrical tinyint,
	
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
	@OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) = NULL,	

	@SpecificRequirementsSectionNotApplicableToJob bit,

	@AttendedAtAllTimes bit,
	@EyeProtection bit,
	@FallProtectionEquipment bit,
	@FullBodyHarnessRetrieval bit,
	@HearingProtection bit,
	@ProtectiveClothing bit,
	@Other1Checked bit,
	@Other1Value varchar(15) = NULL,

	@EquipmentBondedGrounded bit,
	@FireBlanket bit,
	@FireFightingEquipment bit,
	@FireWatch bit,
	@HydrantPermit bit,
	@WaterHose bit,
	@SteamHose bit,
	@Other2Checked bit,
	@Other2Value varchar(15) = NULL,

	@AirMover bit,
	@ContinuousGasMonitor bit,
	@DrowningProtection bit,
	@RespiratoryProtection bit,
	@Other3Checked bit,
	@Other3Value varchar(15) = NULL,

	@AdditionalLighting bit,
	@DesignateHotOrColdCutChecked bit,
	@DesignateHotOrColdCutValue varchar(6),
	@HoistingEquipment bit,
	@Ladder bit,
	@MotorizedEquipment bit,
	@Scaffold bit,
	@ReferToTipsProcedure bit,
	
	@GasDetectorBumpTested bit,
	
	@LastImportedByUserId bigint = NULL,
	@LastImportedDateTime datetime = NULL,
	@LastSubmittedByUserId bigint = NULL,
	@LastSubmittedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@IsModified bit
)
AS

UPDATE PermitRequestLubes SET 
	Company = @Company,	
	CompletionStatusId = @CompletionStatusId,
	IssuedToSuncor = @IssuedToSuncor,
	IssuedToCompany = @IssuedToCompany,
	Trade = @Trade,
	SAPWorkCentre = @SAPWorkCentre,
	NumberOfWorkers = @NumberOfWorkers,
	RequestedByGroupId = @RequestedByGroupId,
	WorkPermitTypeId = @WorkPermitTypeId,
	IsVehicleEntry = @IsVehicleEntry,
	FunctionalLocationId = @FunctionalLocationId,
	Location = @Location,
	Description = @Description,
	SapDescription = @SapDescription,
	ConfinedSpace = @ConfinedSpace,
	ConfinedSpaceClass = @ConfinedSpaceClass,
	RescuePlan = @RescuePlan,
	ConfinedSpaceSafetyWatchChecklist = @ConfinedSpaceSafetyWatchChecklist,
	SpecialWork = @SpecialWork,
	SpecialWorkType = @SpecialWorkType,
	RequestedStartDate = @RequestedStartDate,
	RequestedStartTimeDay = @RequestedStartTimeDay,
	RequestedStartTimeNight = @RequestedStartTimeNight,
	EndDate = @EndDate,
	WorkOrderNumber = @WorkOrderNumber,
	HighEnergy = @HighEnergy,
	CriticalLift = @CriticalLift,
	Excavation = @Excavation,
	EnergyControlPlan = @EnergyControlPlan,
	EquivalencyProc = @EquivalencyProc,
	TestPneumatic = @TestPneumatic,
	LiveFlareWork = @LiveFlareWork,
	EntryAndControlPlan = @EntryAndControlPlan,
	EnergizedElectrical = @EnergizedElectrical,
	HazardHydrocarbonGas = @HazardHydrocarbonGas,
	HazardHydrocarbonLiquid = @HazardHydrocarbonLiquid,
	HazardHydrogenSulphide = @HazardHydrogenSulphide,
	HazardInertGasAtmosphere = @HazardInertGasAtmosphere,
	HazardOxygenDeficiency = @HazardOxygenDeficiency,
	HazardRadioactiveSources = @HazardRadioactiveSources,
	HazardUndergroundOverheadHazards = @HazardUndergroundOverheadHazards,
	HazardDesignatedSubstance = @HazardDesignatedSubstance,
	OtherHazardsAndOrRequirements = @OtherHazardsAndOrRequirements,
	OtherAreasAndOrUnitsAffected = @OtherAreasAndOrUnitsAffected,
	OtherAreasAndOrUnitsAffectedArea = @OtherAreasAndOrUnitsAffectedArea,
	OtherAreasAndOrUnitsAffectedPersonNotified = @OtherAreasAndOrUnitsAffectedPersonNotified,
	SpecificRequirementsSectionNotApplicableToJob = @SpecificRequirementsSectionNotApplicableToJob,
	AttendedAtAllTimes = @AttendedAtAllTimes,
	EyeProtection = @EyeProtection,
	FallProtectionEquipment = @FallProtectionEquipment,
	FullBodyHarnessRetrieval = @FullBodyHarnessRetrieval,
	HearingProtection = @HearingProtection,
	ProtectiveClothing = @ProtectiveClothing,
	Other1Checked = @Other1Checked,
	Other1Value = @Other1Value,
	EquipmentBondedGrounded = @EquipmentBondedGrounded,
	FireBlanket = @FireBlanket,
	FireFightingEquipment = @FireFightingEquipment,
	FireWatch = @FireWatch,
	HydrantPermit = @HydrantPermit,
	WaterHose = @WaterHose,
	SteamHose = @SteamHose,
	Other2Checked = @Other2Checked,
	Other2Value = @Other2Value,
	AirMover = @AirMover,
	ContinuousGasMonitor = @ContinuousGasMonitor,
	DrowningProtection = @DrowningProtection,
	RespiratoryProtection = @RespiratoryProtection,
	Other3Checked = @Other3Checked,
	Other3Value = @Other3Value,
	AdditionalLighting = @AdditionalLighting,
	DesignateHotOrColdCutChecked = @DesignateHotOrColdCutChecked,
	DesignateHotOrColdCutValue = @DesignateHotOrColdCutValue,
	HoistingEquipment = @HoistingEquipment,
	Ladder = @Ladder,
	MotorizedEquipment = @MotorizedEquipment,
	Scaffold = @Scaffold,
	ReferToTipsProcedure = @ReferToTipsProcedure,
	GasDetectorBumpTested = @GasDetectorBumpTested,
	LastImportedByUserId = @LastImportedByUserId,
	LastImportedDateTime = @LastImportedDateTime,
	LastSubmittedByUserId = @LastSubmittedByUserId,
	LastSubmittedDateTime = @LastSubmittedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	IsModified = @IsModified
	WHERE
		Id = @Id;
		
GO		



GRANT EXEC ON UpdatePermitRequestLubes TO PUBLIC
GO