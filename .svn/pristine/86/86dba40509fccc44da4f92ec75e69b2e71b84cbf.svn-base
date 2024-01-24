IF EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[LogCustomFieldEntry]') AND name = 'CustomFieldName'
)
begin
 ALTER TABLE LogCustomFieldEntry ALTER COLUMN CustomFieldName varchar(100);
end
Go

IF EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[LogDefinitionCustomFieldEntry]') AND name = 'CustomFieldName'
)
begin
 ALTER TABLE LogDefinitionCustomFieldEntry ALTER COLUMN CustomFieldName varchar(100);
end
Go


 


