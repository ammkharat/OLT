CREATE TABLE dbo.LabAlertDefinitionState (
  LabAlertDefinitionId  bigint NOT NULL,
  RetryCount integer NOT NULL, 
  CONSTRAINT [PK_LabAlertDefinitionState] PRIMARY KEY ([LabAlertDefinitionId] ASC)
)
  
ALTER TABLE [dbo].[LabAlertDefinitionState]
ADD CONSTRAINT [FK_LabAlertDefinitionState_LabAlertDefinition] 
FOREIGN KEY([LabAlertDefinitionId])
REFERENCES [dbo].[LabAlertDefinition] ([Id])

GO
