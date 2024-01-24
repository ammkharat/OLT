IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertById')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertById
	END
GO

CREATE Procedure [dbo].QueryTargetAlertById
(
    @id int
)
AS

SELECT *
FROM
    TargetAlert
WHERE
    ID = @id
GO

GRANT EXEC ON QueryTargetAlertById TO PUBLIC
GO