

alter table [dbo].DocumentLink add WorkPermitEdmontonId bigint null
alter table [dbo].DocumentLink add PermitRequestEdmontonId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitEdmonton] FOREIGN KEY([WorkPermitEdmontonId])
REFERENCES [dbo].[WorkPermitEdmonton] ([Id])
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestEdmonton] FOREIGN KEY([PermitRequestEdmontonId])
REFERENCES [dbo].[PermitRequestEdmonton] ([Id])
go



GO

