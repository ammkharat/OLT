IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUsersMarkedLogAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUsersMarkedLogAsRead
	END
GO

CREATE Procedure [dbo].[QueryUsersMarkedLogAsRead]
(
	@LogId bigint
)
AS

SELECT 
	Firstname, 
	Lastname, 
	Username, 
	[DateTime]
FROM 
	[LogRead]
	INNER JOIN [User] ON LogRead.UserId = [User].Id
WHERE
	LogId = @LogId
ORDER BY
	DateTime DESC
GO

GRANT EXEC ON [QueryUsersMarkedLogAsRead] TO PUBLIC
GO