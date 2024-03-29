IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[WorkPermitMuds](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[TemplateId] [int] NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NULL,
	[Description] [varchar](400) NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[SourceId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[PermitRequestId] [bigint] NULL,
	[RequestedByGroupId] [bigint] NULL,
	[IssuedDateTime] [datetime] NULL,
	[UsePreviousPermitAnswered] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitMuds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]


--ALTER TABLE [dbo].[WorkPermitMuds]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitMuds_WorkPermitMudsGroup] FOREIGN KEY([RequestedByGroupId])
--REFERENCES [dbo].[WorkPermitMudsGroup] ([Id])

--ALTER TABLE [dbo].[WorkPermitMuds] CHECK CONSTRAINT [FK_WorkPermitMuds_WorkPermitMudsGroup]



End

Alter table [dbo].[WorkPermitMuds] Alter Column RequestedByGroupId varchar(50) NULL 



IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') 
         AND name = 'Company'
)
begin
alter table [dbo].[WorkPermitMuds] Add Company varchar(100) 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'NbTravail'
)
begin
Alter table [dbo].[WorkPermitMuds] Add NbTravail varchar(50) 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'FormationCheck'
)
begin
Alter table [dbo].[WorkPermitMuds] Add FormationCheck bit 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'NomsEnt'
)
begin
Alter table [dbo].[WorkPermitMuds] Add NomsEnt varchar(50) 
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'Surveilant'
)
begin
Alter table [dbo].[WorkPermitMuds] Add Surveilant varchar(50) 
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'Company_1'
)
begin
ALTER TABLE WorkPermitMuds ADD Company_1 varchar(100)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'Company_2'
)
begin
ALTER TABLE WorkPermitMuds ADD Company_2 varchar(100)
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'NomsEnt_1'
)
begin
ALTER TABLE WorkPermitMuds ADD NomsEnt_1 varchar(100)
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'NomsEnt_2'
)
begin
ALTER TABLE WorkPermitMuds ADD NomsEnt_2 varchar(100)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'NomsEnt_3'
)
begin
ALTER TABLE WorkPermitMuds ADD NomsEnt_3 varchar(100)
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'ClonedFormDetailMuds'
)
begin
ALTER TABLE WorkPermitMuds ADD ClonedFormDetailMuds varchar(100)
end
Go



IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') 
         AND name = 'GasTestFirstResultTime'
)
begin
ALTER TABLE dbo.WorkPermitMuds Add GasTestFirstResultTime datetime
end


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') 
         AND name = 'GasTestSecondResultTime'
)
begin
ALTER TABLE dbo.WorkPermitMuds Add GasTestSecondResultTime datetime
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') 
         AND name = 'GasTestThirdResultTime'
)
begin
ALTER TABLE dbo.WorkPermitMuds Add GasTestThirdResultTime datetime
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') 
         AND name = 'GasTestFourthResultTime'
)
begin
ALTER TABLE dbo.WorkPermitMuds Add GasTestFourthResultTime datetime
end


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'WorkPermitCloseComments'
)
begin
ALTER TABLE WorkPermitMuds ADD WorkPermitCloseComments varchar(500) DEFAULT NULL
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'WorkpermitClosedById'
)
begin
ALTER TABLE WorkPermitMuds ADD WorkpermitClosedById bigint DEFAULT NULL
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'ActionItemCloseById'
)
begin
ALTER TABLE WorkPermitMuds ADD  ActionItemCloseById bigint DEFAULT NULL
end


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'PermitCloseDateTime'
)
begin
ALTER TABLE WorkPermitMuds ADD  PermitCloseDateTime DateTime DEFAULT NULL
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'ActionItemCloseDateTime'
)
begin
ALTER TABLE WorkPermitMuds ADD  ActionItemCloseDateTime DateTime DEFAULT NULL
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'ActionItemCheckboxchecked'
)
begin
ALTER TABLE WorkPermitMuds ADD  ActionItemCheckboxchecked bit DEFAULT NULL
end




IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'FeSValue'
)
begin
ALTER TABLE WorkPermitMuds ADD  FeSValue bit DEFAULT NULL
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'MudsAnswerTextBox'
)
begin
ALTER TABLE WorkPermitMuds ADD  MudsAnswerTextBox varchar(max)
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMuds]') AND name = 'MudsQuestionlabel'
)
begin
ALTER TABLE WorkPermitMuds ADD  MudsQuestionlabel varchar(max)
end








