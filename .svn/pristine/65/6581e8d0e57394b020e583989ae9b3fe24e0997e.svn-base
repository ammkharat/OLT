

alter table [dbo].DocumentLink add FormGN24Id bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_FormGN24] FOREIGN KEY([FormGN24Id])
REFERENCES [dbo].[FormGN24] ([Id])
go

alter table FormGN24History add DocumentLinks varchar(max) null;




GO

