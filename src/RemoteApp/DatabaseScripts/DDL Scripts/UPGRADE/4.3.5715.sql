
--- Create sequence for permit number

create table [dbo].WorkPermitEdmontonPermitNumberSequence
(
      SeqID bigint identity(600000,1) primary key,
      SeqVal varchar(1)
)
GO

--- Main table

CREATE TABLE [dbo].[WorkPermitEdmonton](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PermitNumber] [bigint] NULL,

	[WorkPermitStatusId] [int] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[SourceId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](20) NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Description] [varchar](400) NOT NULL,	
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	
	[IssuedToId] [int] NOT NULL,   --- Suncor vs. Contractor
	[Company] [varchar](100) NULL,
	[Trade] [varchar](100) NULL,
	[NumberOfWorkers] [int] NULL,
	
	[RescuePlanFormNumber] [varchar](40) NULL,
	[FormNumber] [varchar](40) NULL,
	[ClassOfClothing] [varchar](30) NULL,
	[CardNumber] [varchar](10) NULL,
	[Class] [varchar](10) NULL,
	
	[VehicleEntry] [bit] NOT NULL,
	[VehicleEntryNumber] [varchar](10) NULL,
	[VehicleEntryType] [varchar](20) NULL,
	
	[SpecialWork] [bit] NOT NULL,
	[SpecialWorkType] [varchar](30) NULL,
	[SpecialWorkFormNumber] [varchar](30) NULL,
	
	[EquipmentName] [varchar](100) NULL,
	[EquipmentNumber] [varchar](20) NULL,
	[HazardsAndOrRequirements] [varchar](400) NULL,
	
	[OtherAreasAndOrUnitsAffected] [bit] NOT NULL,
	[AreaAffected] [varchar](40) NULL,
	[PersonNotified] [varchar](40) NULL,
	
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitEdmonton] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


--- Constraints and indices for main table

ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_Floc] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [FK_WorkPermitEdmonton_Floc]
GO

ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [WorkPermitEdmonton_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [WorkPermitEdmonton_CreatedByUser]

ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [WorkPermitEdmonton_ModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[WorkPermitEdmonton] CHECK CONSTRAINT [WorkPermitEdmonton_ModifiedByUser]

CREATE NONCLUSTERED INDEX [IDX_WorkPermitEdmonton_DTO]
ON [dbo].[WorkPermitEdmonton]
([StartDateTime] , [EndDateTime] , [FunctionalLocationId] , [Deleted])
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


--- Request details

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

go






GO



insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8   -- Edmonton
where re.Name in ('Create Permit', 'View Permit')
and r.Name in ('Supervisor', 'Operator')



GO

