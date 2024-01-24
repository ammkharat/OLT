IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionsWithValidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionDefinitionsWithValidTag
	END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionsWithValidTag
(
	@TagId int
)
AS

SELECT * 
FROM 
	RestrictionDefinition 
WHERE 
	(MeasurementTagID = @TagId or ProductionTargetTagID = @TagId)
	AND RestrictionDefinitionStatusId != 2
	AND DELETED = 0
GO

GRANT EXEC ON QueryRestrictionDefinitionsWithValidTag TO PUBLIC
GO 