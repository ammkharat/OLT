CREATE TABLE [dbo].[PermitRequestEdmontonWorkOrderSource](    
    [PermitRequestEdmontonId] [bigint] NOT NULL,
    [WorkOrderNumber] [varchar](25) NULL,  
    [OperationNumber] [varchar](4) NULL,  
    [SubOperationNumber] [varchar](4) NULL 
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[PermitRequestEdmontonWorkOrderSource]  
WITH CHECK ADD CONSTRAINT [FK_PermitRequestEdmontonWorkOrderSource_PermitRequestEdmonton] 
FOREIGN KEY([PermitRequestEdmontonId]) REFERENCES [dbo].[PermitRequestEdmonton] ([Id])  
GO  
  
insert into PermitRequestEdmontonWorkOrderSource (PermitRequestEdmontonId, WorkOrderNumber, OperationNumber, SubOperationNumber) 
select Id, WorkOrderNumber, OperationNumber, SubOperationNumber from PermitRequestEdmonton;

GO

drop index PermitRequestEdmonton.IDX_PermitRequestEdmonton_Covering_SAP_Data;
GO

alter table dbo.PermitRequestEdmonton drop column WorkOrderNumber;
alter table dbo.PermitRequestEdmonton drop column OperationNumber;
alter table dbo.PermitRequestEdmonton drop column SubOperationNumber;
GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmontonSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestEdmontonWorkOrderSource]
(
	[WorkOrderNumber], [OperationNumber], [SubOperationNumber] 
)
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO





GO

/****** Object:  Table [dbo].[PermitRequestEdmonton]    Script Date: 01/15/2013 16:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermitRequestEdmontonRawImportData](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[WorkOrderNumber] varchar(25) NOT NULL,
	[OperationNumber] varchar(4) NOT NULL,
	[SubOperationNumber] varchar(4) NULL,
	[EndDate] [datetime] NOT NULL,
	[TaskDescription] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	
	[Company] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,	
	[LastSubmittedDateTime] [datetime] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,	
	[IsModified] [bit] NOT NULL,
	[Occupation] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	-- [AlkylationEntryClassOfClothing] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	-- [FlarePitEntryType] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	-- [ConfinedSpaceCardNumber] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	-- [ConfinedSpaceClass] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	-- [RescuePlanFormNumber] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	--[VehicleEntryType] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	-- [SpecialWorkFormNumber] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SpecialWorkType] [int] NULL,
	[RequestedStartDate] [datetime] NOT NULL,
	[RequestedStartTimeDay] [datetime] NULL,
	[RequestedStartTimeNight] [datetime] NULL,
	-- [HazardsAndOrRequirements] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	
	[FaceShield] [bit] NOT NULL,
	[Goggles] [bit] NOT NULL,
	[RubberBoots] [bit] NOT NULL,
	[RubberGloves] [bit] NOT NULL,
	[RubberSuit] [bit] NOT NULL,
	[SafetyHarnessLifeline] [bit] NOT NULL,
	[HighVoltagePPE] [bit] NOT NULL,
	-- [Other1] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EquipmentGrounded] [bit] NOT NULL,
	[FireBlanket] [bit] NOT NULL,
	[FireExtinguisher] [bit] NOT NULL,
	[FireMonitorManned] [bit] NOT NULL,
	[FireWatch] [bit] NOT NULL,
	[SewersDrainsCovered] [bit] NOT NULL,
	[SteamHose] [bit] NOT NULL,
	-- [Other2] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AirPurifyingRespirator] [bit] NOT NULL,
	[BreathingAirApparatus] [bit] NOT NULL,
	[DustMask] [bit] NOT NULL,
	[LifeSupportSystem] [bit] NOT NULL,
	[SafetyWatch] [bit] NOT NULL,
	[ContinuousGasMonitor] [bit] NOT NULL,
	[BumpTestMonitorPriorToUse] [bit] NOT NULL,
	-- [Other3] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AirMover] [bit] NOT NULL,
	[BarriersSigns] [bit] NOT NULL,
	[AirHorn] [bit] NOT NULL,
	[MechVentilationComfortOnly] [bit] NOT NULL,
	[AsbestosMMCPrecautions] [bit] NOT NULL,
	-- [Other4] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	-- [VehicleEntryTotal] [int] NULL,
	[AlkylationEntry] [bit] NOT NULL,
	[FlarePitEntry] [bit] NOT NULL,
	[ConfinedSpace] [bit] NOT NULL,
	[RescuePlan] [bit] NOT NULL,
	[VehicleEntry] [bit] NOT NULL,
	[SpecialWork] [bit] NOT NULL,
	[GN59] [bit] NOT NULL,
	[GN7] [bit] NOT NULL,
	[GN6] [int] NOT NULL,
	[GN11] [int] NOT NULL,
	[GN24] [int] NOT NULL,
	[GN27] [int] NOT NULL,
	[GN75] [int] NOT NULL,
	[WorkersMonitorNumber] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RadioChannelNumber] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RadioChannel] [bit] NOT NULL,
	[WorkersMonitor] [bit] NOT NULL,
 CONSTRAINT [PK_PermitRequestEdmontonRawImportData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PermitRequestEdmontonRawImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonRawImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonRawImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonRawImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestEdmontonRawImportData]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmontonRawImportData_WorkPermitEdmontonGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])


GO

