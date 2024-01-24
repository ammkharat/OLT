IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertResponseById')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertResponseById
	END
GO

CREATE Procedure [dbo].QueryDeviationAlertResponseById
(
    @id int
)
AS

SELECT *
FROM
    DeviationAlertResponse
WHERE
    ID = @id
GO

GRANT EXEC ON [QueryDeviationAlertResponseById] TO PUBLIC
GO