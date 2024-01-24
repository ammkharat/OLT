IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestFortHillsSAPImportData]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[PermitRequestFortHillsSAPImportData](
	[Id] [bigint] IDENTITY(100,1) NOT FOR REPLICATION NOT NULL,
	[WorkOrderNumber] [varchar](25) NOT NULL,
	[OperationNumber] [varchar](4) NOT NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[EndDate] [datetime] NOT NULL,
	[TaskDescription] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedEndDateTime] [datetime] NOT NULL,
	[RevalidationDateTime] [datetime] NOT NULL,
	[ExtensionDateTime] [datetime] NOT NULL,
	[GroupId] [bigint] NULL,
	[FlameResistantWorkWear] [bit] NOT NULL,
	[ChemicalSuit] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[SuppliedBreathingAir] [bit] NOT NULL,
	[AirMover] [bit] NOT NULL,
	[PersonalFlotationDevice] [bit] NOT NULL,
	[HearingProtection] [bit] NOT NULL,
	[Other1] [varchar](1) NULL,
	[MonoGoggles] [bit] NOT NULL,
	[ConfinedSpaceMoniter] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[SparkContainment] [bit] NOT NULL,
	[BottleWatch] [bit] NOT NULL,
	[StandbyPerson] [bit] NOT NULL,
	[WorkingAlone] [bit] NOT NULL,
	[SafetyGloves] [bit] NOT NULL,
	[Other2] [varchar](1) NULL,
	[FaceShield] [bit] NOT NULL,
	[FallProtection] [bit] NOT NULL,
	[ChargedFireHouse] [bit] NOT NULL,
	[CoveredSewer] [bit] NOT NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[SingalPerson] [bit] NOT NULL,
	[CommunicationDevice] [bit] NOT NULL,
	[ReflectiveStrips] [bit] NOT NULL,
	[Other3] [varchar](1) NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[ConfinedSpaceClass] [varchar](25) NULL,
	[GroundDisturbance] [bit] NOT NULL,
	[FireProtectionAuthorization] [bit] NOT NULL,
	[CriticalOrSeriousLifts] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[IndustrialRadiography] [bit] NOT NULL,
	[ElectricalEncroachment] [bit] NOT NULL,
	[MSDS] [bit] NOT NULL,
	[OthersPartE] [varchar](1) NULL,
	[MechanicallyIsolated] [bit] NOT NULL,
	[BlindedOrBlanked] [bit] NOT NULL,
	[DoubleBlockedandBled] [bit] NOT NULL,
	[DrainedAndDepressurised] [bit] NOT NULL,
	[PurgedorNeutralised] [bit] NOT NULL,
	[ElectricallyIsolated] [bit] NOT NULL,
	[TestBumped] [bit] NOT NULL,
	[NuclearSource] [bit] NOT NULL,
	[ReceiverStafingRequirements] [bit] NOT NULL,
	[SAPWorkCentre] [varchar](40) NOT NULL,
	[BatchId] [bigint] NOT NULL,
	[BatchItemCreatedAt] [datetime] NOT NULL,
	[DoNotMerge] [bit] NOT NULL,
	[PriorityId] [int] NOT NULL,
 CONSTRAINT [PK_PermitRequestFortHillsRawImportData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHillsRawImportData_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
--REFERENCES [dbo].[FunctionalLocation] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsSAPImportData] CHECK CONSTRAINT [FK_PermitRequestFortHillsRawImportData_FunctionalLocation]
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsSAPImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHillsRawImportData_WorkPermitFortHillsGroup] FOREIGN KEY([GroupId])
--REFERENCES [dbo].[WorkPermitFortHillsGroup] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsSAPImportData] CHECK CONSTRAINT [FK_PermitRequestFortHillsRawImportData_WorkPermitFortHillsGroup]
--GO
END
