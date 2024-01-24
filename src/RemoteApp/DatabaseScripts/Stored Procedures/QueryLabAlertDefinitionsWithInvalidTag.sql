IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionsWithInvalidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionsWithInvalidTag
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionsWithInvalidTag
(
	@TagId int
)
AS

SELECT * FROM LabAlertDefinition 
WHERE TagID = @TagId
AND LabAlertDefinitionStatusId = 2
AND DELETED = 0
GO

GRANT EXEC ON QueryLabAlertDefinitionsWithInvalidTag TO PUBLIC
GO 