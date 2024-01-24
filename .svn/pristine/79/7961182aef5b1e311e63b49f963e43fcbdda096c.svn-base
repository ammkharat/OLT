

CREATE TABLE [dbo].[SummaryLogCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[SummaryLogId] bigint NOT NULL,
	[SummaryLogCustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100),
	[DisplayOrder] int NOT NULL
	
	CONSTRAINT [PK_SummaryLogCustomFieldEntry] PRIMARY KEY ([Id] ASC)
)

GO

ALTER TABLE [dbo].[SummaryLogCustomFieldEntry]
ADD CONSTRAINT [FK_SummaryLogCustomFieldEntry_SummaryLog]
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO

CREATE TABLE [dbo].[SummaryLogCustomFieldEntryHistory](
	[SummaryLogHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[SummaryLogCustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100)
)

GO

ALTER TABLE [SummaryLogCustomFieldEntryHistory]
ADD CONSTRAINT [FK_SummaryLogCustomFieldEntryHistory_SummaryLogHistory] 
FOREIGN KEY([SummaryLogHistoryId])
REFERENCES [SummaryLogHistory] ([SummaryLogHistoryId])

GO
