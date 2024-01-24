alter table FormGN1 add PlanningWorksheetPlainTextContent varchar(max) null;
GO

alter table FormGN1 add RescuePlanPlainTextContent varchar(max) null;
GO

alter table [dbo].DocumentLink add FormGN1Id bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD CONSTRAINT [FK_DocumentLink_FormGN1] FOREIGN KEY([FormGN1Id])
REFERENCES [dbo].[FormGN1] ([Id])



GO




GO

