
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionCustomFieldGroup]') 
         AND name = 'AutoPopulate'
)
BEGIN
ALTER TABLE ActionItemDefinitionCustomFieldGroup ADD AutoPopulate BIT NOT NULL DEFAULT '0'
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionCustomFieldGroup]') 
         AND name = 'Reading'
)
BEGIN
ALTER TABLE ActionItemDefinitionCustomFieldGroup ADD Reading BIT NOT NULL DEFAULT '0'
END


