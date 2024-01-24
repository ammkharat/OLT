IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAssociatedTargetDefinitions')
	BEGIN
		DROP PROCEDURE [dbo].[QueryAssociatedTargetDefinitions]
	END
GO

CREATE Procedure [dbo].[QueryAssociatedTargetDefinitions]
	(
		@ParentTargetDefinitionId bigint
	)
AS

SELECT 
	ChildTargetDefinitionId
FROM
	TargetDefinitionAssociation
WHERE
	ParentTargetDefinitionId = @ParentTargetDefinitionId
GO

GRANT EXEC ON QueryAssociatedTargetDefinitions TO PUBLIC
GO