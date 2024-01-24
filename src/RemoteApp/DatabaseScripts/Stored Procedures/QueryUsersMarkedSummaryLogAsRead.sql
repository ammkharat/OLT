IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUsersMarkedSummaryLogAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUsersMarkedSummaryLogAsRead
	END
GO

CREATE Procedure [dbo].[QueryUsersMarkedSummaryLogAsRead]
(
	@SummaryLogId bigint
)
AS

SELECT 
	Firstname, 
	Lastname, 
	Username, 
	[DateTime]
FROM 
	[SummaryLogRead]
	INNER JOIN [User]
		ON SummaryLogRead.UserId = [User].Id
WHERE
	SummaryLogId = @SummaryLogId
ORDER BY
	DateTime DESC
GO

GRANT EXEC ON [QueryUsersMarkedSummaryLogAsRead] TO PUBLIC
GO