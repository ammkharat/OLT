
ALTER TABLE [dbo].LogDefinition
ADD LogType tinyint NULL
GO

update [dbo].LogDefinition
set LogType = 1   -- Standard
GO

ALTER TABLE [dbo].LogDefinition
ALTER COLUMN LogType tinyint NOT NULL
GO



GO
