IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionsWithValidTag')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionsWithValidTag
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionsWithValidTag
(
	@TagId int
)
AS

SELECT * FROM LabAlertDefinition 
WHERE TagID = @TagId
AND LabAlertDefinitionStatusId != 2
AND DELETED = 0
GO

GRANT EXEC ON QueryLabAlertDefinitionsWithValidTag TO PUBLIC
GO 