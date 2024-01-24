IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedLogAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserMarkedLogAsRead
	END
GO

CREATE Procedure [dbo].[QueryUserMarkedLogAsRead]
(
	@LogId bigint,
	@UserId bigint
)
AS

SELECT *
	FROM [LogRead]
WHERE
	LogId = @LogId AND
	UserId = @UserId
GO

GRANT EXEC ON [QueryUserMarkedLogAsRead] TO PUBLIC
GO 