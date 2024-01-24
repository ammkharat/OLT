drop table FormGN1History;
GO

CREATE TABLE [dbo].[FormGN1History](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FunctionalLocation] varchar(max) NOT NULL,
	[Location] varchar(128) NOT NULL,
	[CSELevel] varchar(5) NOT NULL,
	[JobDescription] varchar(256) NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,	
	[PlanningWorksheetPlainTextContent] nvarchar(max) NULL,
	[RescuePlanPlainTextContent] nvarchar(max) NULL,
	[TradeChecklists] varchar(max) NULL,
	[PlanningWorksheetApprovals] varchar(max) NULL,	
	[RescuePlanApprovals] varchar(max) NULL,
	[TradeChecklistApprovals] varchar(max) NULL,
	[DocumentLinks] varchar(max) NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NULL,
	[ApprovedDateTime] [datetime] NULL	
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FormGN1History]  WITH CHECK ADD  CONSTRAINT [FK_FormGN1History_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormGN1History] CHECK CONSTRAINT [FK_FormGN1History_LastModifiedByUser]
GO


GO

