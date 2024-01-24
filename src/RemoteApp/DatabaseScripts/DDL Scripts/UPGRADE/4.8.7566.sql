

alter table CustomFieldGroup add Deleted bit null;
go

update CustomFieldGroup set Deleted = 0;
go

alter table CustomFieldGroup alter column Deleted bit not null;
go


CREATE TABLE [dbo].[CustomFieldCustomFieldGroup] (
	[CustomFieldId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_CustomFieldCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[CustomFieldId] ASC,
	[CustomFieldGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomFieldCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomField] FOREIGN KEY ([CustomFieldId])
REFERENCES [dbo].[CustomField] ([Id])
GO

ALTER TABLE [dbo].[CustomFieldCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_CustomFieldCustomFieldGroup_CustomFieldGroup] FOREIGN KEY ([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
go

insert into CustomFieldCustomFieldGroup (CustomFieldId, CustomFieldGroupId)
select cf.Id, cf.CustomFieldGroupId
from CustomField cf
go

ALTER TABLE [dbo].[CustomField] DROP CONSTRAINT [FK_SummaryLogCustomField_SummaryLogCustomFieldGroup]
DROP INDEX [IDX_CustomField_GroupId] ON [dbo].[CustomField]
go
alter table CustomField drop column CustomFieldGroupId;
go

















GO

