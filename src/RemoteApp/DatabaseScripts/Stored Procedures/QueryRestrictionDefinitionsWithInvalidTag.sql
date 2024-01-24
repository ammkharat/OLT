IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionsWithInvalidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionDefinitionsWithInvalidTag
	END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionsWithInvalidTag
(
	@TagId int
)
AS

SELECT * 
FROM 
	RestrictionDefinition 
	WHERE (MeasurementTagID = @TagId or ProductionTargetTagID = @TagId)
	AND RestrictionDefinitionStatusId = 2
	AND DELETED = 0
GO

GRANT EXEC ON QueryRestrictionDefinitionsWithInvalidTag TO PUBLIC
GO 