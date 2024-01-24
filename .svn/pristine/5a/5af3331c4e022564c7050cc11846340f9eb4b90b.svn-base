

alter table FormTemplate add CreatedByUserId bigint null
alter table FormTemplate add CreatedDateTime datetime null
go

update FormTemplate set CreatedByUserId = -1
update FormTemplate set CreatedDateTime = '2012-10-01 12:00'
go

alter table FormTemplate alter column CreatedByUserId bigint not null
alter table FormTemplate alter column CreatedDateTime datetime not null
go

ALTER TABLE [dbo].[FormTemplate]  WITH CHECK ADD  CONSTRAINT [FK_FormTemplate_CreatedByUser] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO




GO

