IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLinkedActionItemDefinitionCount')
    BEGIN
        DROP PROCEDURE [dbo].QueryLinkedActionItemDefinitionCount
    END
GO

CREATE Procedure dbo.QueryLinkedActionItemDefinitionCount
(
    @id bigint
)
AS
    SELECT
        COUNT(*) 
    FROM
        ActionItemDefinitionTargetDefinition actionItemDefinitionTargetDefinition,
        ActionItemDefinition actionItemDefinition
    WHERE
        actionItemDefinitionTargetDefinition.TargetDefinitionId = @id AND
        actionItemDefinition.Id = actionItemDefinitionTargetDefinition.ActionItemDefinitionId AND
        actionItemDefinition.Deleted = 0
GO

GRANT EXEC ON QueryLinkedActionItemDefinitionCount TO PUBLIC
GO