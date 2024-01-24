IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySAPNotificationByNotificationNumber')
	BEGIN
		DROP PROCEDURE [dbo].QuerySAPNotificationByNotificationNumber
	END
GO

CREATE Procedure [dbo].QuerySAPNotificationByNotificationNumber
	(
		@NotificationNumber  char(12)
	)
AS

SELECT
	*
FROM
	SAPNotification
WHERE 
	NotificationNumber=@NotificationNumber
GO

GRANT EXEC ON [QuerySAPNotificationByNotificationNumber] TO PUBLIC
GO