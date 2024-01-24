ALTER TABLE [dbo].[LogHistory]
ADD  CONSTRAINT [FK_LogHistory_Log]
FOREIGN KEY ([Id])
REFERENCES [dbo].[Log] ( [Id] )
GO


GO

