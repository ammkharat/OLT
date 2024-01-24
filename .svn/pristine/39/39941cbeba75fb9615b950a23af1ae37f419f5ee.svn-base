IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionItemDefinitionTargetDefinitionAssociation')
BEGIN
    DROP  Procedure  RemoveActionItemDefinitionTargetDefinitionAssociation
END

GO

CREATE Procedure [dbo].RemoveActionItemDefinitionTargetDefinitionAssociation
    (
        @ActionItemDefinitionId bigint
    )
AS

DELETE
FROM
    ActionItemDefinitionTargetDefinition
WHERE
    ActionItemDefinitionTargetDefinition.ActionItemDefinitionId = @ActionItemDefinitionId

GO

GRANT EXEC ON RemoveActionItemDefinitionTargetDefinitionAssociation TO PUBLIC

GO