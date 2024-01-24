IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionById
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionById
(
	@id int
)
AS

SELECT * FROM LabAlertDefinition 
WHERE ID=@id
GO

GRANT EXEC ON QueryLabAlertDefinitionById TO PUBLIC
GO