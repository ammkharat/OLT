IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeviationAlertById')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeviationAlertById
	END
GO

CREATE Procedure [dbo].QueryDeviationAlertById
(
    @id int
)
AS

SELECT *
FROM
    DeviationAlert
WHERE
    ID = @id
GO

GRANT EXEC ON [QueryDeviationAlertById] TO PUBLIC
GO