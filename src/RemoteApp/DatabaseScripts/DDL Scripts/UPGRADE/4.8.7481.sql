ALTER TABLE [dbo].[ActionItemDefinitionHistory]
ADD  CONSTRAINT [FK_ActionItemDefinitionHistory_ActionItem]
FOREIGN KEY ([Id])
REFERENCES [dbo].[ActionItemDefinition] ( [Id] )
GO


GO

