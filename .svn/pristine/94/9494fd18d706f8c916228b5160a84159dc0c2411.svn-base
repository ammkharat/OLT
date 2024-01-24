IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUsersMarkedDirectiveAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUsersMarkedDirectiveAsRead
	END
GO

CREATE Procedure [dbo].[QueryUsersMarkedDirectiveAsRead]
(
	@DirectiveId bigint
)
AS

SELECT 
	Firstname, 
	Lastname, 
	Username, 
	[DateTime]
FROM 
	[DirectiveRead]
	INNER JOIN [User] ON DirectiveRead.UserId = [User].Id
WHERE
	DirectiveId = @DirectiveId
ORDER BY
	DateTime DESC
GO

GRANT EXEC ON [QueryUsersMarkedDirectiveAsRead] TO PUBLIC
GO