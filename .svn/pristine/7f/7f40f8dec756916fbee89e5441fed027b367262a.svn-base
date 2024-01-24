IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestFortHills]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[PermitRequestFortHills](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[GroupId] [bigint] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[EquipmentNo] [int] NULL,
	[Craft] [varchar](25) NULL,
	[CrewSize] [int] NULL,
	[JobCoordinator] [varchar](25) NULL,
	[CoOrdContactNumber] [varchar](10) NULL,
	[EmergencyAssemblyArea] [varchar](25) NULL,
	[EmergencyMeetingPoint] [varchar](25) NULL,
	[EmergencyContactNumber] [varchar](10) NULL,
	[Locknumber] [varchar](10) NULL,
	[IsolationNumber] [varchar](10) NULL,
	[TaskDescription] [varchar](max) NULL,
	[SAPDescription] [varchar](max) NULL,
	[FlameResistantWorkWear] [bit] NOT NULL,
	[ChemicalSuit] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[SuppliedBreathingAir] [bit] NOT NULL,
	[AirMover] [bit] NOT NULL,
	[PersonalFlotationDevice] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[Other1] [varchar](30) NULL,
	[MonoGoggles] [bit] NOT NULL,
	[ConfinedSpaceMoniter] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[SparkContainment] [bit] NOT NULL,
	[BottleWatch] [bit] NOT NULL,
	[StandbyPerson] [bit] NOT NULL,
	[WorkingAlone] [bit] NOT NULL,
	[SafetyGloves] [bit] NOT NULL,
	[Other2] [varchar](30) NULL,
	[FaceShield] [bit] NOT NULL,
	[FallProtection] [bit] NOT NULL,
	[ChargedFireHouse] [bit] NOT NULL,
	[CoveredSewer] [bit] NOT NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[SingalPerson] [bit] NOT NULL,
	[CommunicationDevice] [bit] NOT NULL,
	[ReflectiveStrips] [bit] NOT NULL,
	[Other3] [varchar](30) NULL,
	[HazardsAndOrRequirements] [varchar](max) NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[GoundDisturbance] [bit] NOT NULL,
	[FireProtectionAuthorization] [bit] NOT NULL,
	[CriticalOrSeriousLifts] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[IndustrialRadiography] [bit] NOT NULL,
	[ElectricalEncroachment] [bit] NOT NULL,
	[MSDS] [bit] NOT NULL,
	[OthersPartE] [varchar](30) NULL,
	[MechanicallyIsolated] [bit] NOT NULL,
	[BlindedOrBlanked] [bit] NOT NULL,
	[DoubleBlockedandBled] [bit] NOT NULL,
	[DrainedAndDepressurised] [bit] NOT NULL,
	[PurgedorNeutralised] [bit] NOT NULL,
	[ElectricallyIsolated] [bit] NOT NULL,
	[TestBumped] [bit] NOT NULL,
	[NuclearSource] [bit] NOT NULL,
	[ReceiverStafingRequirements] [bit] NOT NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[SAPWorkCentre] [varchar](40) NULL,
	[DoNotMerge] [bit] NOT NULL,
	[CompletionStatusId] [int] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsModified] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedEndDate] [datetime] NULL,
	[LockBoxnumberChecked] [bit] NULL,
	[PartEWorkSectionNotApplicable] [bit] NOT NULL,
	[PartDWorkSectionNotApplicable] [bit] NOT NULL,
	[PartCWorkSectionNotApplicable] [bit] NOT NULL,
 CONSTRAINT [PK_PermitRequestFortHills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

--GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_CreatedByUser] FOREIGN KEY([CreatedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_CreatedByUser]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
--REFERENCES [dbo].[FunctionalLocation] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_FunctionalLocation]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_LastImportedByUser]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_LastModifiedByUser]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_LastSubmittedByUser]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHills_WorkPermitFortHillsGroup] FOREIGN KEY([GroupId])
--REFERENCES [dbo].[WorkPermitFortHillsGroup] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHills] CHECK CONSTRAINT [FK_PermitRequestFortHills_WorkPermitFortHillsGroup]
--GO

END