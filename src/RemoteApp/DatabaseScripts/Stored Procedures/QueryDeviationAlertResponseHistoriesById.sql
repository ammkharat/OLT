IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertResponseHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertResponseHistoriesById
	END
GO

CREATE Procedure [dbo].QueryDeviationAlertResponseHistoriesById
	(
	@Id bigint
	)
AS

SELECT 
	* 
FROM 
	DeviationAlertResponseHistory 
WHERE 
	Id=@Id 
ORDER BY 
	LastModifiedDateTime
GO

GRANT EXEC ON [QueryDeviationAlertResponseHistoriesById] TO PUBLIC
GO