drop table WorkPermitEdmontonRequestDetails;
drop table WorkPermitEdmonton;

CREATE TABLE [dbo].[WorkPermitEdmonton](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PermitRequestId] bigint NULL,
	[WorkPermitStatusId] int NOT NULL,
	[DataSourceId] int NOT NULL,
	[IssuedToId] int NOT NULL,
	[Company] varchar(50) NULL,
	[Occupation] varchar(50) NOT NULL,
	[NumberOfWorkers] int NULL,
	[WorkPermitTypeId] int NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[Location] varchar(55) NOT NULL,
	[RequestedStartDateTime] datetime NOT NULL,
	[IssuedDateTime] datetime NOT NULL,
	[ExpiredDateTime] datetime NOT NULL,
	[PermitNumber] bigint NULL, 
	[WorkOrderNumber] varchar(25) NULL,
	[OperationNumber] varchar(4) NULL,
	[SubOperationNumber] varchar(4) NULL,
	[TaskDescription] varchar(500),
	[SAPDescription] varchar(500),
	[SAPOperationLongText] varchar(500),
	[HazardsAndOrRequirements] varchar(500),	
	[CreatedDateTime] datetime NOT NULL,
	[CreatedByUserId] bigint NOT NULL,
	[RequestedByUserId] bigint NULL,
	[LastModifiedByUserId] bigint NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL,
	[Deleted] bit NOT NULL,

 CONSTRAINT [PK_WorkPermitEdmonton] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_PermitRequest]
FOREIGN KEY ([PermitRequestId])
REFERENCES [dbo].[PermitRequestEdmonton] ( [Id] )

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_FunctionalLocation]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_CreatedByUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] )

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_RequestedByUser]
FOREIGN KEY ([RequestedByUserId])
REFERENCES [dbo].[User] ( [Id] )

GO

ALTER TABLE [dbo].[WorkPermitEdmonton]
ADD  CONSTRAINT [FK_WorkPermitEdmonton_LastModifiedByUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )

GO



GO


CREATE TABLE [dbo].[WorkPermitEdmontonDetails](
	[WorkPermitEdmontonId] [bigint] NOT NULL,
	[AlkylationEntry] bit NOT NULL,
	[ClassOfClothing] varchar(50) NULL,
	[ConfinedSpace] bit NOT NULL,
	[CardNumber] varchar(50) NULL,
	[Class] varchar(50) NULL, 
	[SpecialWork] bit NOT NULL,
	[SpecialWorkFormNumber] varchar(25) NULL,
	[SpecialWorkType] varchar(25) NULL,
	[VehicleEntry] bit NOT NULL,
	[VehicleEntryLicenseNumber] varchar(25) NULL,
	[VehicleEntryType] varchar(25) NULL,
	[RescuePlan] bit NOT NULL,
	[RescuePlanFormNumber] varchar(25) NULL,
	[GN59] bit NOT NULL,
	[GN59FormNumber] varchar(25) NULL,
	[GN75] bit NOT NULL,
	[GN75FormNumber] varchar(25) NULL,
	[GN1] bit NOT NULL,
	[GN1FormNumber] varchar(25) NULL,
	[GN7] bit NOT NULL,
	[GN7FormNumber] varchar(25) NULL,
	[BT1] bit NOT NULL,
	[BT1FormNumber] varchar(25) NULL,
	[GN11] bit NOT NULL,
	[GN11FormNumber] varchar(25) NULL,
	[StatusOfPipingEquipmentSectionNotApplicableToJob] bit NOT NULL,
	[ProductNormallyInPipingEquipment] varchar(50) NULL,
	[IsolationValvesLocked] bit NULL,
	[DepressuredDrained] bit NULL,
	[Ventilated] bit NULL,
	[Purged] bit NULL,
	[BlindedAndTagged] bit NULL,
	[DoubleBlockAndBleed] bit NULL,
	[ElectricalLockout] bit NULL,
	[MechanicalLockout] bit NULL,
	[BlindSchematicAvailable] bit NULL,
	[ZeroEnergyFormNumber] varchar(100) NULL,
	[LockBoxNumber] varchar(100) NULL,
	[JobsiteEquipmentInspected] bit NOT NULL,
	[ConfinedSpaceWorkSectionNotApplicableToJob] bit NOT NULL,
	[QuestionOneResponse] bit NOT NULL,
	[QuestionTwoResponse] bit NULL,
	[QuestionTwoAResponse] bit NOT NULL,
	[QuestionTwoBResponse] bit NOT NULL,
	[QuestionThreeResponse] bit NOT NULL,
	[QuestionFourResponse] bit NULL,
	[GasTestsSectionNotApplicableToJob] bit NOT NULL,
	[OperatorGasDetectorNumber] varchar(50) NULL,
	[GasTestDataLine1CombustibleGas] varchar(25) NULL,
	[GasTestDataLine1Oxygen] varchar(25) NULL,
	[GasTestDataLine1ToxicGas] varchar(25) NULL,
	[GasTestDataLine1Time] datetime NULL,
	[GasTestDataLine2CombustibleGas] varchar(25) NULL,
	[GasTestDataLine2Oxygen] varchar(25) NULL,
	[GasTestDataLine2ToxicGas] varchar(25) NULL,
	[GasTestDataLine2Time] datetime NULL,
	[GasTestDataLine3CombustibleGas] varchar(25) NULL,
	[GasTestDataLine3Oxygen] varchar(25) NULL,
	[GasTestDataLine3ToxicGas] varchar(25) NULL,
	[GasTestDataLine3Time] datetime NULL,
	[GasTestDataLine4CombustibleGas] varchar(25) NULL,
	[GasTestDataLine4Oxygen] varchar(25) NULL,
	[GasTestDataLine4ToxicGas] varchar(25) NULL,
	[GasTestDataLine4Time] datetime NULL,
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] bit NOT NULL,
	[FaceShield] bit NOT NULL,
	[Goggles] bit NOT NULL,
	[RubberBoots] bit NOT NULL,
	[RubberGloves] bit NOT NULL,
	[RubberSuit] bit NOT NULL,
	[SystemHarnessLifeline] bit NOT NULL,
	[HighVoltagePPE] bit NOT NULL,
	[Other1] bit NOT NULL,
	[Other1Value] varchar(25) NULL,
	[EquipmentGrounded] bit NOT NULL,
	[FireBlanket] bit NOT NULL,
	[FireExtinguisher] bit NOT NULL,
	[FireMonitorManned] bit NOT NULL,
	[FireWatch] bit NOT NULL,
	[SewersDrainsCovered] bit NOT NULL,
	[SteamHose] bit NOT NULL,
	[Other2] bit NOT NULL,
	[Other2Value] varchar(25) NULL,
	[AirPurifyingRespirator] bit NOT NULL,
	[BreathingAirApparatus] bit NOT NULL,
	[DustMask] bit NOT NULL,
	[LifeSupportSystem] bit NOT NULL,
	[SafetyWatch] bit NOT NULL,
	[ContinuousGasMonitor] bit NOT NULL,
	[WorkersMonitorNumber] bit NOT NULL,
	[BumpTestMonitorPriorToUse] bit NOT NULL,
	[Other3] bit NULL,
	[Other3Value] varchar(25) NULL,
	[AirMover] bit NOT NULL,
	[BarriersSigns] bit NOT NULL,
	[Radio] bit NOT NULL,
	[AirHorn] bit NOT NULL,
	[MechVentilationComfortOnly] bit NOT NULL,
	[AsbestosMMCPrecautions] bit NOT NULL,
	[Other4] bit NOT NULL,
	[Other4Value] varchar(25) NULL,
	
CONSTRAINT [PK_WorkPermitEdmontonDetails] PRIMARY KEY CLUSTERED
(
	[WorkPermitEdmontonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

GO

ALTER TABLE [dbo].[WorkPermitEdmontonDetails]
ADD  CONSTRAINT [FK_WorkPermitEdmontonDetails_Id]
FOREIGN KEY ([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ( [Id] )

-- Request Details

CREATE TABLE [dbo].[WorkPermitEdmontonRequestDetails] (
	[Id] bigint NOT NULL,
	RequestedDateTime datetime null,
	RequestedByUserId bigint null,
	Supervisor varchar(100) null
CONSTRAINT [PK_WorkPermitEdmontonRequestDetails]
PRIMARY KEY CLUSTERED ([Id] ) ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[WorkPermitEdmontonRequestDetails]
ADD  CONSTRAINT [FK_WorkPermitEdmontonRequestDetails_Id]
FOREIGN KEY ([Id])
REFERENCES [dbo].[WorkPermitEdmonton] ( [Id] )
GO

alter table WorkPermitEdmontonRequestDetails
ADD  CONSTRAINT FK_WorkPermitEdmontonRequestDetails_RequestedByUser
FOREIGN KEY(RequestedByUserId)
REFERENCES [User] ([Id]);


GO

