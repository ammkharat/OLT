IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsWithInvalidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetDefinitionsWithInvalidTag
	END
GO

CREATE Procedure [dbo].QueryTargetDefinitionsWithInvalidTag
(
	@TagId int
)
AS

SELECT * 
FROM 
	TargetDefinition 
WHERE 
	TagId = @TagId
	AND TargetDefinitionStatusId = 5
	AND DELETED = 0
GO

GRANT EXEC ON QueryTargetDefinitionsWithInvalidTag TO PUBLIC
GO 