IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsHistory]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[PermitRequestMudsHistory](
	[Id] [bigint] NOT NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[WorkOrderNumber] [varchar](12) NULL,
	[Trade] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[Company] [varchar](50) NULL,
	[Supervisor] [varchar](100) NULL,
	[ExcavationNumber] [varchar](50) NULL,
	[LastImportedByUserId] [bigint] NULL,
	[LastImportedDateTime] [datetime] NULL,
	[LastSubmittedByUserId] [bigint] NULL,
	[LastSubmittedDateTime] [datetime] NULL,
	[Attributes] [varchar](max) NULL,
	[SapDescription] [varchar](400) NULL,
	[FunctionalLocations] [varchar](max) NOT NULL,
	[DocumentLinks] [varchar](max) NULL,
	[RequestedByGroup] [varchar](100) NULL,
	[CompletionStatusId] [int] NOT NULL,
	[SourceId] [int] NOT NULL
) ON [PRIMARY]


End

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsHistory]') AND name = 'Company_1'
)
begin
ALTER TABLE PermitRequestMudsHistory ADD Company_1 varchar(50)
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsHistory]') AND name = 'Company_2'
)
begin
ALTER TABLE PermitRequestMudsHistory ADD Company_2 varchar(50)
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsHistory]') AND name = 'StartDateTime'
)
begin
Alter Table PermitRequestMudsHistory ADD StartDateTime	datetime NULL
end
Go


IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestMudsHistory]') AND name = 'EndDateTime'
)
begin
Alter Table PermitRequestMudsHistory ADD EndDateTime	datetime NULL
end
Go


