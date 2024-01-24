alter table [dbo].DocumentLink add DirectiveId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_Directive] FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])



GO

