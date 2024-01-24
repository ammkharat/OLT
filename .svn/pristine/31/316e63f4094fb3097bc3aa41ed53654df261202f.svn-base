IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertDefinitionHistoriesById
	END
GO

CREATE Procedure [dbo].QueryLabAlertDefinitionHistoriesById
	(
	@Id bigint
	)
AS
SELECT * FROM LabAlertDefinitionHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryLabAlertDefinitionHistoriesById] TO PUBLIC
GO