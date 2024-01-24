alter table [dbo].DocumentLink add FormGN75AId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN75A] FOREIGN KEY([FormGN75AId])
REFERENCES [dbo].[FormGN75A] ([Id])



GO

