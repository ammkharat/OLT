
alter table [dbo].DocumentLink add WorkPermitMontrealId bigint null
alter table [dbo].DocumentLink add PermitRequestMontrealId bigint null
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_WorkPermitMontreal] FOREIGN KEY([WorkPermitMontrealId])
REFERENCES [dbo].[WorkPermitMontreal] ([Id])
go

ALTER TABLE [dbo].[DocumentLink]  WITH CHECK ADD  CONSTRAINT [FK_DocumentLink_PermitRequestMontreal] FOREIGN KEY([PermitRequestMontrealId])
REFERENCES [dbo].[PermitRequestMontreal] ([Id])
go

alter table [dbo].WorkPermitMontrealHistory add DocumentLinks varchar(max) null;
alter table [dbo].PermitRequestMontrealHistory add DocumentLinks varchar(max) null;
go



GO

