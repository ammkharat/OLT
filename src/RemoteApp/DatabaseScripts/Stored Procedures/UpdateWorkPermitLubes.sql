if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateWorkPermitLubes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateWorkPermitLubes]
GO

CREATE Procedure [dbo].[UpdateWorkPermitLubes]
(
	@Id bigint,
	@PermitNumber bigint Output,				
	
	@ShouldCreatePermitNumber bit,
	
	@WorkPermitStatus int,
	@IssuedDateTime datetime = NULL,
	@IssuedByUserId bigint = NULL,
	@IssuedToSuncor bit,
	@IssuedToCompany bit,
	@Company varchar(50) = NULL,
	@Trade varchar(50),
	@NumberOfWorkers int = NULL,
	@RequestedByGroupId bigint,
	
	@WorkPermitTypeId int,
	@IsVehicleEntry bit,
	@FunctionalLocationId bigint,
	@Location varchar(50),
	
	@ConfinedSpace bit,
	@ConfinedSpaceClass varchar(50),
	@RescuePlan bit,
	@ConfinedSpaceSafetyWatchChecklist bit,
	
	@SpecialWork bit,
	@SpecialWorkType varchar(50),
	@HazardousWorkApproverAdvised bit,
	@AdditionalFollowupRequired bit,
	
	@StartDateTime datetime,
	@ExpireDateTime datetime,
	
	@WorkOrderNumber varchar(12) = NULL,
	@OperationNumber varchar(max) = NULL,
	@SubOperationNumber varchar(max) = NULL,
	
	@HighEnergy tinyint,
    @CriticalLift tinyint,
    @Excavation tinyint,
    @EnergyControlPlanFormRequirement tinyint,
    @EquivalencyProc tinyint,
    @TestPneumatic tinyint,
    @LiveFlareWork tinyint,
    @EntryAndControlPlan tinyint,
	@EnergizedElectrical tinyint,
	
	@TaskDescription varchar(max) = NULL,
	
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
	
	@WorkPreparationsCompletedSectionNotApplicableToJob bit,
	@ProductNormallyInPipingEquipment varchar(50) = NULL,
	
	@DepressuredDrained bit = NULL,
	@WaterWashed bit = NULL,
	@ChemicallyWashed bit = NULL,
	@Steamed bit = NULL,
	@Purged bit = NULL,
	@Disconnected bit = NULL,
	@DepressuredAndVented bit = NULL,
	@Ventilated bit = NULL,
	@Blanked bit = NULL,
	@DrainsCovered bit = NULL,
	@AreaBarricated bit = NULL,
	@EnergySourcesLockedOutTaggedOut bit = NULL,
	@EnergyControlPlan varchar(50) = NULL,
	@LockBoxNumber varchar(50) = NULL,
	@OtherPreparations varchar(50) = NULL,
	
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
	@AtmosphericGasTestRequired bit,
	
	@UsePreviousPermitAnswered bit,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime	
)
AS

IF @ShouldCreatePermitNumber = 1
	BEGIN
		EXEC @PermitNumber = GetNewSeqVal_WorkPermitLubesPermitNumberSequence
	END
ELSE
	BEGIN
		SET @PermitNumber = (select PermitNumber from WorkPermitLubes WHERE Id = @Id)
	END

	
UPDATE WorkPermitLubes SET 
	PermitNumber = @PermitNumber,			
	WorkPermitStatus = @WorkPermitStatus,
	IssuedDateTime = @IssuedDateTime,
	IssuedByUserId = @IssuedByUserId,
	IssuedToSuncor = @IssuedToSuncor,
	IssuedToCompany = @IssuedToCompany,
	Company = @Company,
	Trade = @Trade,
	NumberOfWorkers = @NumberOfWorkers,
	RequestedByGroupId = @RequestedByGroupId,
	
	WorkPermitTypeId = @WorkPermitTypeId,
	IsVehicleEntry = @IsVehicleEntry,
	FunctionalLocationId = @FunctionalLocationId,
	Location = @Location,
	
	ConfinedSpace = @ConfinedSpace,
	ConfinedSpaceClass = @ConfinedSpaceClass,
	RescuePlan = @RescuePlan,
	ConfinedSpaceSafetyWatchChecklist = @ConfinedSpaceSafetyWatchChecklist,
	
	SpecialWork = @SpecialWork,
	SpecialWorkType = @SpecialWorkType,
	HazardousWorkApproverAdvised = @HazardousWorkApproverAdvised,
	AdditionalFollowupRequired = @AdditionalFollowupRequired,
	
	StartDateTime = @StartDateTime,
	ExpireDateTime = @ExpireDateTime,
	
	WorkOrderNumber = @WorkOrderNumber,
	OperationNumber = @OperationNumber,
	SubOperationNumber = @SubOperationNumber,
	
	HighEnergy = @HighEnergy,
    CriticalLift = @CriticalLift,
    Excavation = @Excavation,
    EnergyControlPlanFormRequirement = @EnergyControlPlanFormRequirement,
    EquivalencyProc = @EquivalencyProc,
    TestPneumatic = @TestPneumatic,
    LiveFlareWork = @LiveFlareWork,
    EntryAndControlPlan = @EntryAndControlPlan,
	EnergizedElectrical = @EnergizedElectrical,
	
	TaskDescription = @TaskDescription,
	
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
	
	WorkPreparationsCompletedSectionNotApplicableToJob = @WorkPreparationsCompletedSectionNotApplicableToJob,
	ProductNormallyInPipingEquipment = @ProductNormallyInPipingEquipment,
	
	DepressuredDrained = @DepressuredDrained,
	WaterWashed = @WaterWashed,
	ChemicallyWashed = @ChemicallyWashed,
	Steamed = @Steamed,
	Purged = @Purged,
	Disconnected = @Disconnected,
	DepressuredAndVented = @DepressuredAndVented,
	Ventilated = @Ventilated,
	Blanked = @Blanked,
	DrainsCovered = @DrainsCovered,
	AreaBarricated = @AreaBarricated,
	EnergySourcesLockedOutTaggedOut = @EnergySourcesLockedOutTaggedOut,
	EnergyControlPlan = @EnergyControlPlan,
	LockBoxNumber = @LockBoxNumber,
	OtherPreparations = @OtherPreparations,
	
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
	AtmosphericGasTestRequired = @AtmosphericGasTestRequired,

	UsePreviousPermitAnswered = @UsePreviousPermitAnswered,
	
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime	
	WHERE
		Id = @Id;
		
GRANT EXEC ON UpdateWorkPermitLubes TO PUBLIC
GO