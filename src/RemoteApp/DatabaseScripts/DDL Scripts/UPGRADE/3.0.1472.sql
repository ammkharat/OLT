CREATE TABLE [dbo].[SummaryLogRead](
	[SummaryLogId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateTime] [datetime] NOT NULL,
CONSTRAINT [PK_SummaryLogRead] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC,
	[UserId] ASC
))

GO

ALTER TABLE [dbo].[SummaryLogRead] ADD CONSTRAINT [FK_SummaryLogRead_SummaryLog] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO

ALTER TABLE [dbo].[SummaryLogRead] ADD CONSTRAINT [FK_SummaryLogRead_User] 
FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])

GO

CREATE TABLE [dbo].[SummaryLogHistory](
	[SummaryLogHistoryId] [bigint] IDENTITY(100,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[FunctionalLocations] [varchar](max),
	[Comments] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EHSFollowup] [bit] NOT NULL,
	[InspectionFollowUp] [bit] NOT NULL,
	[ProcessControlFollowUp] [bit] NOT NULL,
	[OperationsFollowUp] [bit] NOT NULL,
	[SupervisionFollowUp] [bit] NOT NULL,
	[OtherFollowUp] [bit] NOT NULL,
	[LastModifiedUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LiveLinkDocumentLinks] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FutureLogReferenceCriteria] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL

	CONSTRAINT [PK_SummaryLogHistory] PRIMARY KEY ([SummaryLogHistoryId] ASC)
)


CREATE INDEX [IDX_SummaryLogHistory_Id] 
ON [dbo].[SummaryLogHistory] 
(
	[Id] ASC
)

GO
