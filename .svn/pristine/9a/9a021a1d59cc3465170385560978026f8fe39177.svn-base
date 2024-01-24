CREATE TABLE [dbo].[LogCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[LogId] bigint NOT NULL,
	[CustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100),
	[DisplayOrder] int NOT NULL
	CONSTRAINT [PK_LogCustomFieldEntry] PRIMARY KEY ([Id] ASC)
)

GO

ALTER TABLE [dbo].[LogCustomFieldEntry]
ADD CONSTRAINT [FK_LogCustomFieldEntry_Log]
FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])

GO

CREATE TABLE [dbo].[LogCustomFieldEntryHistory](
	[LogHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[LogCustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100)
)

GO

ALTER TABLE [LogCustomFieldEntryHistory]
ADD CONSTRAINT [FK_LogCustomFieldEntryHistory_LogHistory] 
FOREIGN KEY([LogHistoryId])
REFERENCES [LogHistory] ([LogHistoryId])

GO

GO
