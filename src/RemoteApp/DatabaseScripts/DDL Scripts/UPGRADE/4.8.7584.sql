

alter table CustomField add OriginCustomFieldId bigint null;
go

update CustomField set OriginCustomFieldId = Id;
go

ALTER TABLE [dbo].[CustomField]  WITH CHECK ADD  CONSTRAINT [FK_CustomField_OriginCustomField] FOREIGN KEY([OriginCustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
go





GO

