ALTER TABLE [ActionItem]  
ADD  CONSTRAINT [FK_ActionItem_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [FunctionalLocation] ([Id])
GO

GO
