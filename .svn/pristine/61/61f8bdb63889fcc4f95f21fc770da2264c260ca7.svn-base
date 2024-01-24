ALTER TABLE [dbo].DocumentLink ADD FormGN7Id bigint SPARSE NULL
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormGN7] FOREIGN KEY([FormGN7Id])
REFERENCES [dbo].[FormGN7] ([Id])
GO

ALTER TABLE [dbo].DocumentLink ADD FormOP14Id bigint SPARSE NULL
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormOP14] FOREIGN KEY([FormOP14Id])
REFERENCES [dbo].[FormOP14] ([Id])
GO

ALTER TABLE [dbo].DocumentLink ADD FormGN59Id bigint SPARSE NULL
GO

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormGN59] FOREIGN KEY([FormGN59Id])
REFERENCES [dbo].[FormGN59] ([Id])
GO

ALTER TABLE [dbo].[FormGN7History] ADD [DocumentLinks] varchar(max);
GO

ALTER TABLE [dbo].[FormOP14History] ADD [DocumentLinks] varchar(max);
GO

ALTER TABLE [dbo].[FormGN59History] ADD [DocumentLinks] varchar(max);
GO


GO

