IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitFortHills]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[WorkPermitFortHills](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PermitRequestId] [bigint] NULL,
	[WorkPermitStatusId] [int] NOT NULL,
	[DataSourceId] [int] NOT NULL,
	[Company] [varchar](50) NULL,
	[Occupation] [varchar](50) NULL,
	[NumberOfWorkers] [int] NULL,
	[WorkPermitTypeId] [int] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,
	[Location] [varchar](50) NULL,
	[RequestedStartDateTime] [datetime] NOT NULL,
	[IssuedDateTime] [datetime] NULL,
	[ExpiredDateTime] [datetime] NULL,
	[PermitNumber] [bigint] NULL,
	[WorkOrderNumber] [varchar](25) NULL,
	[OperationNumber] [varchar](max) NULL,
	[SubOperationNumber] [varchar](max) NULL,
	[TaskDescription] [varchar](max) NULL,
	[HazardsAndOrRequirements] [varchar](2000) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IssuedToSuncor] [bit] NOT NULL,
	[IssuedToCompany] [bit] NOT NULL,
	[GroupId] [bigint] NULL,
	[IssuedByUserId] [bigint] NULL,
	[PermitRequestCreatedByUserId] [bigint] NULL,
	[PriorityId] [int] NOT NULL,
	[LockBoxnumberChecked] [bit] NULL,
	[PartCWorkSectionNotApplicable] [bit] NULL,
	[PartDWorkSectionNotApplicable] [bit] NULL,
	[PartEWorkSectionNotApplicable] [bit] NULL,
	[PartFWorkSectionNotApplicable] [bit] NULL,
	[PartGWorkSectionNotApplicable] [bit] NULL,
 CONSTRAINT [PK_WorkPermitFortHills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]


--GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_CreatedByUser] FOREIGN KEY([CreatedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_CreatedByUser]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
--REFERENCES [dbo].[FunctionalLocation] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_FunctionalLocation]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_IssuedByUser] FOREIGN KEY([IssuedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_IssuedByUser]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_LastModifiedByUser]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_PermitRequest] FOREIGN KEY([PermitRequestId])
--REFERENCES [dbo].[PermitRequestFortHills] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_PermitRequest]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_PermitRequestCreatedByUser] FOREIGN KEY([PermitRequestCreatedByUserId])
--REFERENCES [dbo].[User] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_PermitRequestCreatedByUser]
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitFortHills_WorkPermitFortHillsGroup] FOREIGN KEY([GroupId])
--REFERENCES [dbo].[WorkPermitFortHillsGroup] ([Id])
--GO

--ALTER TABLE [dbo].[WorkPermitFortHills] CHECK CONSTRAINT [FK_WorkPermitFortHills_WorkPermitFortHillsGroup]
--GO

END

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitFortHills]') AND name = 'ClonedFormDetailFortHills'
)
begin
ALTER TABLE WorkPermitFortHills ADD ClonedFormDetailFortHills varchar(100)
end
Go