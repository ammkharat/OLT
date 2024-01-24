IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryParentTargetDefinitionsByChildTargetDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryParentTargetDefinitionsByChildTargetDefinitionId
	END
GO

CREATE Procedure [dbo].QueryParentTargetDefinitionsByChildTargetDefinitionId
	(
		@ChildTargetDefinitionId bigint
	)

AS
SELECT 
	[ParentTargetDefinitionId], [TargetDefinition].[Name]
FROM
	[TargetDefinitionAssociation], [TargetDefinition]
WHERE
	[TargetDefinition].[Id] = [TargetDefinitionAssociation].[ParentTargetDefinitionId]
	AND
	[ChildTargetDefinitionId] = @ChildTargetDefinitionId
GO

GRANT EXEC ON QueryParentTargetDefinitionsByChildTargetDefinitionId TO PUBLIC
GO