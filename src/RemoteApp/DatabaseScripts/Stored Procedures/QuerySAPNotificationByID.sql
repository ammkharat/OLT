IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySAPNotificationByID')
	BEGIN
		DROP PROCEDURE [dbo].QuerySAPNotificationByID
	END
GO

CREATE Procedure [dbo].QuerySAPNotificationByID
	(
		@id int
	)
AS

SELECT
	*
FROM
	SAPNotification
WHERE 
	ID=@id
GO

GRANT EXEC ON [QuerySAPNotificationByID] TO PUBLIC
GO