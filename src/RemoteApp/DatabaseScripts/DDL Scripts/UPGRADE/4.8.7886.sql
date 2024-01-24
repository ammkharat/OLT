ALTER TABLE [dbo].[PermitRequestLubes]  WITH CHECK ADD CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO
ALTER TABLE [dbo].[PermitRequestLubes] CHECK CONSTRAINT [FK_PermitRequestLubes_FunctionalLocation]



GO

