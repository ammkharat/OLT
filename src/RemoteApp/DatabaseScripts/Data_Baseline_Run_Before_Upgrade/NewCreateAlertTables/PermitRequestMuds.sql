IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[PermitRequestMuds](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
	[SourceId] [int] NOT NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[IsModified] [bit] NOT NULL,
	[SapDescription] [varchar](400) NULL,
	[SubOperationNumber] [varchar](4) NULL,
	[RequestedByGroupId] [bigint] NULL,
	[CompletionStatusId] [int] NOT NULL,
 CONSTRAINT [PK_PermitRequestMuds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--ALTER TABLE [dbo].[PermitRequestMuds]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMuds_CreatedByUser] FOREIGN KEY([CreatedByUserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[PermitRequestMuds] CHECK CONSTRAINT [FK_PermitRequestMuds_CreatedByUser]

--ALTER TABLE [dbo].[PermitRequestMuds]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMuds_LastImportedByUser] FOREIGN KEY([LastImportedByUserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[PermitRequestMuds] CHECK CONSTRAINT [FK_PermitRequestMuds_LastImportedByUser]

--ALTER TABLE [dbo].[PermitRequestMuds]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMuds_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[PermitRequestMuds] CHECK CONSTRAINT [FK_PermitRequestMuds_LastModifiedByUser]

--ALTER TABLE [dbo].[PermitRequestMuds]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestMuds_LastSubmittedByUser] FOREIGN KEY([LastSubmittedByUserId])
--REFERENCES [dbo].[User] ([Id])

--ALTER TABLE [dbo].[PermitRequestMuds] CHECK CONSTRAINT [FK_PermitRequestMuds_LastSubmittedByUser]


End


Alter table [dbo].[PermitRequestMuds] Alter Column RequestedByGroupId varchar(50) NULL 


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'NbTravail'
)
begin
Alter table [dbo].[PermitRequestMuds] Add NbTravail varchar(50) 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'FormationCheck'
)
begin
Alter table [dbo].[PermitRequestMuds] Add FormationCheck bit 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'NomsEnt'
)
begin
Alter table [dbo].[PermitRequestMuds] Add NomsEnt varchar(50) 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Surveilant'
)
begin
Alter table [dbo].[PermitRequestMuds] Add Surveilant varchar(50) 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Company_1'
)
begin
ALTER TABLE PermitRequestMuds ADD Company_1 varchar(50)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Company_2'
)
begin
ALTER TABLE PermitRequestMuds ADD Company_2 varchar(50)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'NomsEnt_1'
)
begin
ALTER TABLE PermitRequestMuds ADD NomsEnt_1 varchar(50)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'NomsEnt_2'
)
begin
ALTER TABLE PermitRequestMuds ADD NomsEnt_2 varchar(50) 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'NomsEnt_3'
)
begin
ALTER TABLE PermitRequestMuds ADD NomsEnt_3 varchar(50) 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'StartDateTime'
)
begin
Alter Table PermitRequestMuds ADD StartDateTime	datetime NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'EndDateTime'
)
begin
Alter Table PermitRequestMuds ADD EndDateTime	datetime NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Analyse_Attribute_CheckBox'
)
begin
Alter Table PermitRequestMuds ADD Analyse_Attribute_CheckBox	bit  NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Cadenassage_multiple_Attribute_CheckBox'
)
begin
Alter Table PermitRequestMuds ADD Cadenassage_multiple_Attribute_CheckBox	bit NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Cadenassage_simple_Attribute_CheckBox'
)
begin
Alter Table PermitRequestMuds ADD Cadenassage_simple_Attribute_CheckBox	bit NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Procédure_Attribute_CheckBox'
)
begin
Alter Table PermitRequestMuds ADD Procédure_Attribute_CheckBox	bit NULL
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMuds]') AND name = 'Espace_clos_Attribute_CheckBox'
)
begin
Alter Table PermitRequestMuds ADD Espace_clos_Attribute_CheckBox	bit NULL
end
Go


