
CREATE TABLE dbo.TargetDefinitionState (
  TargetDefinitionId  bigint NOT NULL,
  ExceedingBoundaries bit NOT NULL,
  LastSuccessfulTagAccess datetime NULL,
  CONSTRAINT [PK_TargetDefinitionState] PRIMARY KEY ([TargetDefinitionId] ASC)
)
  
ALTER TABLE [dbo].[TargetDefinitionState]
ADD CONSTRAINT [FK_TargetDefinition_Id] 
FOREIGN KEY([TargetDefinitionId])
REFERENCES [dbo].[TargetDefinition] ([Id])


INSERT INTO dbo.TargetDefinitionState (
  TargetDefinitionId, 
  ExceedingBoundaries, 
  LastSuccessfulTagAccess)
  (SELECT Id, ExceedingBoundaries, LastSuccessfulTagAccess FROM dbo.TargetDefinition)
GO  

ALTER TABLE dbo.TargetDefinition 
DROP COLUMN ExceedingBoundaries
GO

ALTER TABLE dbo.TargetDefinition 
DROP COLUMN LastSuccessfulTagAccess
GO

GO
