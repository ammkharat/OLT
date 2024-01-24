ALTER TABLE [dbo].[LogDefinitionHistory]
ADD  CONSTRAINT [FK_LogDefinitionHistory_LogDefinition]
FOREIGN KEY ([Id])
REFERENCES [dbo].[LogDefinition] ( [Id] )
GO


GO

