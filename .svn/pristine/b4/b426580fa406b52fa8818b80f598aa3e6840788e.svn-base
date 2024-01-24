
alter table CustomFieldGroup add OriginCustomFieldGroupId bigint null;
go

update CustomFieldGroup set OriginCustomFieldGroupId = Id;
go

ALTER TABLE [dbo].CustomFieldGroup  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldGroup_OriginCustomFieldGroup] FOREIGN KEY([OriginCustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
GO



GO

