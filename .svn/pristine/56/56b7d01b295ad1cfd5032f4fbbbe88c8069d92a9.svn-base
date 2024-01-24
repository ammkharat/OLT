create table [dbo].WorkPermitLubesPermitNumberSequence
(
      SeqID bigint identity(600000,1) primary key,
      SeqVal varchar(1)
)
GO

CREATE TABLE [dbo].[WorkPermitLubes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PermitRequestId] bigint NULL,
	[DataSourceId] int NOT NULL,
	[CreatedDateTime] datetime NOT NULL,
	[CreatedByUserId] bigint NOT NULL,
	[PermitNumber] bigint NULL, 
	
	[IssuedToSuncor] bit NOT NULL,
	[IssuedToCompany] bit NOT NULL,
	[Company] varchar(50) NULL,
	[Trade] varchar(50) NOT NULL,
	[NumberOfWorkers] int NULL,
	[RequestedByGroup] varchar(50) NULL, -- NULL?
	
	[WorkPermitTypeId] int NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[Location] varchar(50) NOT NULL,
	
	[ConfinedSpace] bit NOT NULL,
	[ConfinedSpaceClass] varchar(50) NULL,
	[RescuePlan] bit NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] bit NOT NULL,
	
	[SpecialWork] bit NOT NULL,
	[SpecialWorkType] varchar(50) NULL,
	[HazardousWorkApproverAdvised] bit NOT NULL,
	[AdditionalFollowupRequired] bit NOT NULL,
	
	[StartDateTime] datetime NOT NULL,	
	[ExpireDateTime] datetime NOT NULL,

	[WorkOrderNumber] varchar(12) NULL,
	[OperationNumber] varchar(4) NULL,
	[SubOperationNumber] varchar(4) NULL,
	
	[TaskDescription] varchar(500),	
	
	HazardHydrocarbonGas bit NOT NULL,
	HazardHydrocarbonLiquid bit NOT NULL,
	HazardHydrogenSulphide bit NOT NULL,
	HazardInertGasAtmosphere bit NOT NULL,
	HazardOxygenDeficiency bit NOT NULL,
	HazardRadioactiveSources bit NOT NULL,
	HazardUndergroundOverheadHazards bit NOT NULL,
	HazardDesignatedSubstance bit NOT NULL,

	[OtherHazardsAndOrRequirements] varchar(500),	
	
	OtherAreasAndOrUnitsAffected bit NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] varchar(50),	
	[OtherAreasAndOrUnitsAffectedPersonNotified] varchar(30),	
	
	WorkPreparationsCompletedSectionNotApplicableToJob bit NOT NULL,
	ProductNormallyInPipingEquipment varchar(50),	
	              
	DepressuredDrained bit NULL,   
	WaterWashed bit NULL,   
	Steamed bit NULL,   
	Purged bit NULL,   
	Disconnected bit NULL,   
	DepressuredAndVented bit NULL,   
	Ventilated bit NULL,   
	Blanked bit NULL,   
	DrainsCovered bit NULL,   
	AreaBarricated bit NULL,   
	EnergySourcesLockedOutTaggedOut bit NULL,   
	EnergyControlPlan varchar(15),	
	LockBoxNumber varchar(15),	
	OtherPreparations varchar(15),	

	 SpecificRequirementsSectionNotApplicableToJob bit NOT NULL,
	 AttendedAtAllTimes bit NOT NULL,
	 EyeProtection bit NOT NULL,
	 FallProtectionEquipment bit NOT NULL,
	 FullBodyHarnessRetrieval bit NOT NULL,
	 HearingProtection bit NOT NULL,
	 ProtectiveClothing bit NOT NULL,
	 Other1Checked bit NOT NULL,
	 Other1Value varchar(15),	

	 EquipmentBondedGrounded bit NOT NULL,
	 FireBlanket bit NOT NULL,
	 FireFightingEquipment bit NOT NULL,
	 FireWatch bit NOT NULL,
	 HydrantPermit bit NOT NULL,
	 WaterHose bit NOT NULL,
	 SteamHose bit NOT NULL,
	 Other2Checked bit NOT NULL,
     Other2Value varchar(15),	

	AirMover bit NOT NULL,
	ContinuousGasMonitor bit NOT NULL,
	DrowningProtection bit NOT NULL,
	RespiratoryProtection bit NOT NULL,
	Other3Checked bit NOT NULL,
	Other3Value varchar(15),	
 
	AdditionalLighting bit NOT NULL,
	DesignateHotOrColdCutChecked bit NOT NULL,
	DesignateHotOrColdCutValue varchar(6),	
	HoistingEquipment bit NOT NULL,
	Ladder bit NOT NULL,
	MotorizedEquipment bit NOT NULL,
	Scaffold bit NOT NULL,
	ReferToTipsProcedure bit NOT NULL,
	
	
	[LastModifiedByUserId] bigint NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL,
	[Deleted] bit NOT NULL
	
 CONSTRAINT [PK_WorkPermitLubes] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]





GO

