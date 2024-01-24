
DROP TABLE [dbo].[PermitRequestEdmontonHistory];
go

CREATE TABLE [dbo].[PermitRequestEdmontonHistory] (
	[Id] bigint NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[TaskDescription] [varchar](500) NOT NULL,
	[SAPDescription] [varchar](500) NULL,
	[Company] [varchar](50) NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](55) NOT NULL,
	[AlkylationEntryClassOfClothing] [varchar](25) NULL,
	[FlarePitEntryType] [varchar](25) NULL,
	[ConfinedSpaceCardNumber] [varchar](25) NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[RescuePlanFormNumber] [varchar](25) NULL,
	[VehicleEntryType] [varchar](25) NULL,
	[SpecialWorkFormNumber] [varchar](25) NULL,
	[SpecialWorkType] [varchar](25) NULL,
	[GN59FormNumber] [varchar](25) NULL,
	[GN7FormNumber] [varchar](25) NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
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
	[IssuedToSuncor] [bit] NOT NULL,
	[Group] [varchar](50) NOT NULL,
	[VehicleEntryTotal] [int] NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[GN6] [bit] NOT NULL,
	[GN11] [bit] NOT NULL,
	[GN24] [bit] NOT NULL,
	[GN27] [bit] NOT NULL,
	[GN75] [bit] NOT NULL,
	[BT1] [bit] NOT NULL
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmontonHistory]
ON [dbo].[PermitRequestEdmontonHistory]
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
)
ON [PRIMARY];

GO


ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastModifiedByUser]
GO


ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastImportedByUser]
GO


ALTER TABLE [dbo].[PermitRequestEdmontonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] CHECK CONSTRAINT [FK_PermitRequestEdmontonHistory_LastSubmittedByUser]
GO









GO

