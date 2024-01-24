alter table [dbo].WorkPermitLubes add RequestedByUserId bigint null;
GO
ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_RequestedByUserId] FOREIGN KEY([RequestedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_CreatedByUserId] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitLubes] WITH CHECK ADD CONSTRAINT [FK_WorkPermitLubes_LastModifiedByUserId] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO





GO

CREATE TABLE [dbo].[WorkPermitLubesHistory](
	[Id] [bigint] NOT NULL,
			
	[PermitNumber] bigint NULL, 
	
	[DocumentLinks] varchar(max) NULL,
	
	[IssuedToSuncor] bit NOT NULL,
	[IssuedToCompany] bit NOT NULL,
	[Company] varchar(50) NULL,
	[Trade] varchar(50) NOT NULL,
	[NumberOfWorkers] int NULL,
	[RequestedByGroup] varchar(50) NULL,
	
	[WorkPermitTypeId] int NOT NULL,
	[FunctionalLocation] varchar(200) NOT NULL,
	[Location] varchar(50) NOT NULL,
	[WorkPermitStatus] int NOT NULL,
	
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
	              
	DepressuredDrained varchar(10),
	WaterWashed varchar(10),   
	Steamed varchar(10),   
	Purged varchar(10),   
	Disconnected varchar(10),   
	DepressuredAndVented varchar(10),   
	Ventilated varchar(10),   
	Blanked varchar(10),   
	DrainsCovered varchar(10),   
	AreaBarricated varchar(10),   
	EnergySourcesLockedOutTaggedOut varchar(10),   
	
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
		
	HighEnergy tinyint not null,
	CriticalLift tinyint not null,
	Excavation tinyint not null,
	EnergyControlPlanFormRequirement tinyint not null,
	EquivalencyProc tinyint not null,
	TestPneumatic tinyint not null,
	LiveFlareWork tinyint not null,
	EntryAndControlPlan tinyint not null,	
						
	[LastModifiedByUserId] bigint NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL
	
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IDX_WorkPermitLubesHistory]
ON [dbo].[WorkPermitLubesHistory]
([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WorkPermitLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubesHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitLubesHistory] CHECK CONSTRAINT [FK_WorkPermitLubesHistory_LastModifiedByUser]






GO

