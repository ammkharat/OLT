
CREATE TABLE [dbo].[PermitRequestLubesHistory] (
	[Id] [bigint] NOT NULL,
	[CompletionStatusId] [int] NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Trade] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[RequestedByGroup] [varchar](50) NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocation] [varchar](200) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](50) NULL,
	[RescuePlan] [bit] NOT NULL,
	[ConfinedSpaceSafetyWatchChecklist] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](50) NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[Description] [varchar](500) NULL,
	[SapDescription] [varchar](500) NULL,
	[HazardHydrocarbonGas] [bit] NOT NULL,
	[HazardHydrocarbonLiquid] [bit] NOT NULL,
	[HazardHydrogenSulphide] [bit] NOT NULL,
	[HazardInertGasAtmosphere] [bit] NOT NULL,
	[HazardOxygenDeficiency] [bit] NOT NULL,
	[HazardRadioactiveSources] [bit] NOT NULL,
	[HazardUndergroundOverheadHazards] [bit] NOT NULL,
	[HazardDesignatedSubstance] [bit] NOT NULL,
	[OtherHazardsAndOrRequirements] [varchar](500) NULL,
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[OtherAreasAndOrUnitsAffectedArea] [varchar](50) NULL,
	[OtherAreasAndOrUnitsAffectedPersonNotified] [varchar](30) NULL,
	[SpecificRequirementsSectionNotApplicableToJob] [bit] NOT NULL,
	[AttendedAtAllTimes] [bit] NOT NULL,
	[EyeProtection] [bit] NOT NULL,
	[FallProtectionEquipment] [bit] NOT NULL,
	[FullBodyHarnessRetrieval] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[ProtectiveClothing] [bit] NOT NULL,
	[Other1Checked] [bit] NOT NULL,
	[Other1Value] [varchar](15) NULL,
	[EquipmentBondedGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireFightingEquipment] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[HydrantPermit] [bit] NOT NULL,
	[WaterHose] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	[Other2Checked] [bit] NOT NULL,
	[Other2Value] [varchar](15) NULL,
	[AirMover] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[DrowningProtection] [bit] NOT NULL,
	[RespiratoryProtection] [bit] NOT NULL,
	[Other3Checked] [bit] NOT NULL,
	[Other3Value] [varchar](15) NULL,
	[AdditionalLighting] [bit] NOT NULL,
	[DesignateHotOrColdCutChecked] [bit] NOT NULL,
	[DesignateHotOrColdCutValue] [varchar](6) NULL,
	[HoistingEquipment] [bit] NOT NULL,
	[Ladder] [bit] NOT NULL,
	[MotorizedEquipment] [bit] NOT NULL,
	[Scaffold] [bit] NOT NULL,
	[ReferToTipsProcedure] [bit] NOT NULL,
	[HighEnergy] [tinyint] NOT NULL,
	[CriticalLift] [tinyint] NOT NULL,
	[Excavation] [tinyint] NOT NULL,
	[EnergyControlPlan] [tinyint] NOT NULL,
	[EquivalencyProc] [tinyint] NOT NULL,
	[TestPneumatic] [tinyint] NOT NULL,
	[LiveFlareWork] [tinyint] NOT NULL,
	[EntryAndControlPlan] [tinyint] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastModifiedByUser]
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastImportedByUser]
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestLubesHistory_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[PermitRequestLubesHistory] CHECK CONSTRAINT [FK_PermitRequestLubesHistory_LastSubmittedByUser]
GO




GO

