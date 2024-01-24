

ALTER TABLE [dbo].[WorkPermitEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitEdmonton_AreaLabel] FOREIGN KEY([AreaLabelId])
REFERENCES [dbo].[AreaLabel] ([Id])

GO

ALTER TABLE [dbo].[PermitRequestEdmonton]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestEdmonton_AreaLabel] FOREIGN KEY([AreaLabelId])
REFERENCES [dbo].[AreaLabel] ([Id])

GO




GO

