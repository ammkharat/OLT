ALTER TABLE CustomField
  ALTER COLUMN TypeId tinyINT NOT NULL;
GO

ALTER TABLE LogCustomFieldEntry
    ALTER COLUMN TypeId tinyint NOT NULL;
GO
    
ALTER TABLE SummaryLogCustomFieldEntry
    ALTER COLUMN TypeId tinyint NOT NULL;
GO

ALTER TABLE LogDefinitionCustomFieldEntry
    ALTER COLUMN TypeId tinyint NOT NULL;
GO
	
ALTER TABLE CustomField
  ADD PHDLinkTypeId tinyint NULL;
GO

ALTER TABLE LogCustomFieldEntry
  ADD PHDLinkTypeId tinyint NULL;
GO

ALTER TABLE SummaryLogCustomFieldEntry
  ADD PHDLinkTypeId tinyint NULL;
GO
  
ALTER TABLE LogDefinitionCustomFieldEntry
  ADD PHDLinkTypeId tinyint NULL;
GO

UPDATE CustomField 
  SET PHDLinkTypeId = 0 WHERE TagId IS NULL
UPDATE CustomField 
  SET PHDLinkTypeId = 1 WHERE TagId IS NOT NULL  
GO

UPDATE e
  SET e.PHDLinkTypeId = 0 
FROM LogCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NULL

UPDATE e
  SET e.PHDLinkTypeId = 1 
FROM LogCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NOT NULL
GO

UPDATE e
  SET e.PHDLinkTypeId = 0 
FROM SummaryLogCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NULL

UPDATE e
  SET e.PHDLinkTypeId = 1 
FROM SummaryLogCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NOT NULL
GO

UPDATE e
  SET e.PHDLinkTypeId = 0 
FROM LogDefinitionCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NULL

UPDATE e
  SET e.PHDLinkTypeId = 1 
FROM LogDefinitionCustomFieldEntry e
  INNER JOIN CustomField cf ON cf.Id = e.CustomFieldId
WHERE cf.TagId IS NOT NULL
GO

ALTER TABLE CustomField
  ALTER COLUMN PHDLinkTypeId tinyint NOT NULL;
GO

ALTER TABLE LogCustomFieldEntry
  ALTER COLUMN PHDLinkTypeId tinyint NOT NULL;
GO

ALTER TABLE SummaryLogCustomFieldEntry
  ALTER COLUMN PHDLinkTypeId tinyint NOT NULL;
GO  

ALTER TABLE LogDefinitionCustomFieldEntry
  ALTER COLUMN PHDLinkTypeId tinyint NOT NULL;
GO  

ALTER TABLE [dbo].[LogDefinitionCustomFieldEntry] 
ADD  CONSTRAINT [FK_LogDefinitionCustomFieldEntry_CustomField]
FOREIGN KEY ([CustomFieldId])
REFERENCES [dbo].[CustomField] ( [Id] )
GO


GO

