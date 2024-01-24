alter table LogCustomFieldEntry alter column CustomFieldName varchar(40) not null;

GO

alter table LogCustomFieldEntryHistory alter column LogCustomFieldName varchar(40) not null;

GO

sp_RENAME 'LogCustomFieldEntryHistory.LogCustomFieldName', 'CustomFieldName', 'COLUMN'

GO



GO
