ALTER TABLE TargetDefinitionReadWriteTagConfiguration
	ADD TargetDefinitionId BIGINT NULL
GO

UPDATE TargetDefinitionReadWriteTagConfiguration
SET TargetDefinitionId = TargetDefinition.[id]
FROM TargetDefinition
WHERE TargetDefinition.TargetDefinitionReadWriteTagConfigurationId = TargetDefinitionReadWriteTagConfiguration.[id]
GO

-- Add a default ReadWrite Tag Configuration for all the TargetDefinitions that don't have one yet.
DECLARE @TargetDefinitionId BIGINT

DECLARE TargetDefIdCursor CURSOR FOR
  Select td.Id From TargetDefinition td
  Where NOT Exists (Select * From TargetDefinitionReadWriteTagConfiguration where TargetDefinitionId = td.Id)
OPEN TargetDefIdCursor

FETCH NEXT From TargetDefIdCursor INTO @TargetDefinitionId

WHILE (@@FETCH_STATUS = 0)
BEGIN
  INSERT INTO dbo.TargetDefinitionReadWriteTagConfiguration 
    (MaxDirectionId, MinDirectionId, TargetDirectionId, GapUnitValueDirectionId, TargetDefinitionId)
    VALUES(0,0,0,0,@TargetDefinitionId)
    FETCH NEXT FROM TargetDefIdCursor INTO @TargetDefinitionId
END

CLOSE TargetDefIdCursor
DEALLOCATE TargetDefIdCursor
  
ALTER TABLE TargetDefinitionReadWriteTagConfiguration
	ALTER COLUMN TargetDefinitionId BIGINT NOT NULL
GO

ALTER TABLE [dbo].[TargetDefinitionReadWriteTagConfiguration]
ADD CONSTRAINT [FK_TargetDefinitionReadWriteTagConfiguration_TargetDefId]
FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])
GO

ALTER TABLE [dbo].TargetDefinition
	DROP CONSTRAINT FK_TargetDefinition_TargetDefinitionReadWriteTagConfiguration
ALTER TABLE [dbo].TargetDefinition
	DROP COLUMN TargetDefinitionReadWriteTagConfigurationId


GO
