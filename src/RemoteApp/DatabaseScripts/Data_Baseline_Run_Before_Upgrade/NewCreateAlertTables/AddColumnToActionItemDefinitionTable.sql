
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinition]') 
         AND name = 'CustomFieldsGroupID'
)
BEGIN
ALTER TABLE ActionItemDefinition ADD CustomFieldsGroupID BigInt NULL 
END