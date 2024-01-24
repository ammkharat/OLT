IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertResponsesByTargetAlertId')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertResponsesByTargetAlertId
	END
GO

CREATE Procedure [dbo].QueryTargetAlertResponsesByTargetAlertId
	(
		@TargetAlertId bigint
	)
AS

SELECT
    response.*
FROM
	TargetAlertResponse response
WHERE
    response.TargetAlertId = @TargetAlertId
GO

GRANT EXEC ON QueryTargetAlertResponsesByTargetAlertId TO PUBLIC
GO  