drop table PermitRequestEdmontonPermitAttributeAssociation

alter table WorkPermitEdmonton drop FK_WorkPermitEdmonton_PermitRequest;
-- alter table PermitRequestEdmontonPermitAttributeAssociation drop FK_PermitRequestEdmontonPermitAttributeAssociation_PermitRequestEdmonton;

drop table PermitRequestEdmonton;


GO

CREATE TABLE [dbo].PermitRequestEdmonton (
	Id bigint IDENTITY(100,1) NOT NULL,	
	[EndDate] datetime NOT NULL,
	[WorkOrderNumber] varchar(25) NULL,
	[OperationNumber] varchar(4) NULL,
	[SubOperationNumber] varchar(4) NULL,
	[TaskDescription] varchar(500) NOT NULL,
	[SAPDescription] varchar(500) NULL,
	[Company] varchar(50) NULL,
	[DataSourceId] int NOT NULL,
	[LastImportedByUserId] bigint NULL, 
	[LastImportedDateTime] datetime NULL,
	[LastSubmittedByUserId] bigint NULL,
	[LastSubmittedDateTime] datetime NULL,
	[CreatedByUserId] bigint NOT NULL,
	[CreatedDateTime] datetime NOT NULL,
	[LastModifiedByUserId] bigint NOT NULL,
	[LastModifiedDateTime] datetime NOT NULL,
	[IsComplete] bit NOT NULL,
	[IsModified] bit NOT NULL,
	
	[IssuedToId] int NOT NULL,	
	[Occupation] varchar(50) NOT NULL,
	[NumberOfWorkers] int NULL,
	[WorkPermitTypeId] int NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[Location] varchar(55) NOT NULL,
	
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](25) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	
	[RescuePlanFormNumber] [varchar](25) NULL,
	[VehicleEntryLicenseNumber] [varchar](25) NULL,
	[VehicleEntryType] [varchar](25) NULL,
	[SpecialWorkFormNumber] [varchar](25) NULL,
	[SpecialWorkType] [varchar](25) NULL,
	[GN59FormNumber] [varchar](25) NULL,
	[GN75FormNumber] [varchar](25) NULL,
	[GN1FormNumber] [varchar](25) NULL,
	[GN7FormNumber] [varchar](25) NULL,
	[BT1FormNumber] [varchar](25) NULL,
	[OtherTypeOfWork] [varchar](25) NULL,
	[OtherTypeOfWorkFormNumber] [varchar](25) NULL,	
	
	[RequestedStartDate] datetime NOT NULL,
	[RequestedStartTimeDay] datetime NULL,
	[RequestedStartTimeNight] datetime NULL,
	
	[HazardsAndOrRequirements] [varchar](500) NULL,
	
	[OtherAreasAndOrUnitsAffectedArea] [varchar](25) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](25) NULL,
	
	[WorkersMinimumSafetyRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SystemHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	[Other1] [bit] NOT NULL,
	[Other1Value] [varchar](25) NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2] [bit] NOT NULL,
	[Other2Value] [varchar](25) NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[WorkersMonitorNumber] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	[Other3] [bit] NULL,
	[Other3Value] [varchar](25) NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[Radio] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	[Other4] [bit] NOT NULL,
	[Other4Value] [varchar](25) NULL,
		
	[Deleted] bit NOT NULL,
	
CONSTRAINT PK_PermitRequestEdmonton PRIMARY KEY CLUSTERED 
(
	Id ASC
)
)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_FunctionalLocation FOREIGN KEY(FunctionalLocationId)
REFERENCES FunctionalLocation (Id)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_CreatedByUser FOREIGN KEY(CreatedByUserId)
REFERENCES [User] (Id)
GO

ALTER TABLE PermitRequestEdmonton
ADD CONSTRAINT FK_PermitRequestEdmonton_LastModifiedByUser FOREIGN KEY(LastModifiedByUserId)
REFERENCES [User] (Id)
GO


CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmonton] ON [dbo].[PermitRequestEdmonton] 
(
	[FunctionalLocationId] ASC,
	[RequestedStartDate] ASC,
	[EndDate] ASC,
	[Deleted] ASC
);

GO

alter table PermitRequestEdmonton
ADD  CONSTRAINT FK_PermitRequestEdmonton_LastImportedByUser
FOREIGN KEY(LastImportedByUserId)
REFERENCES [User] ([Id]);

alter table PermitRequestEdmonton
ADD  CONSTRAINT FK_PermitRequestEdmonton_LastSubmittedByUser
FOREIGN KEY(LastSubmittedByUserId)
REFERENCES [User] ([Id]);

-- adding back in the foreign keys that were dropped above
ALTER TABLE [dbo].[WorkPermitEdmonton] ADD CONSTRAINT [FK_WorkPermitEdmonton_PermitRequest]
FOREIGN KEY ([PermitRequestId]) REFERENCES [dbo].[PermitRequestEdmonton] ( [Id] );







GO

