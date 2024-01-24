IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsWithValidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionsWithValidTag
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionsWithValidTag
(
	@TagId int
)
AS

SELECT * 
FROM 
	TargetDefinition 
WHERE 
	TagId = @TagId
	AND TargetDefinitionStatusId != 5
	AND DELETED = 0
GO

GRANT EXEC ON QueryTargetDefinitionsWithValidTag TO PUBLIC
GO 