CREATE TABLE [dbo].[LogDefinitionCustomFieldEntry](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[LogDefinitionId] bigint NOT NULL,
	[CustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100),
	[DisplayOrder] int NOT NULL
	CONSTRAINT [PK_LogDefinitionCustomFieldEntry] PRIMARY KEY ([Id] ASC)
)

GO

ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry]
ADD CONSTRAINT [FK_LogDefinitionCustomFieldEntry_LogDefinition]
FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])

GO

CREATE TABLE [dbo].[LogDefinitionCustomFieldEntryHistory](
	[LogDefinitionHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[CustomFieldName] varchar(20) NOT NULL,
	[FieldEntry] varchar(100)
)

GO

ALTER TABLE [LogDefinitionCustomFieldEntryHistory]
ADD CONSTRAINT [FK_LogDefinitionCustomFieldEntryHistory_LogDefinitionHistory] 
FOREIGN KEY([LogDefinitionHistoryId])
REFERENCES [LogDefinitionHistory] ([LogDefinitionHistoryId])

GO

GO
