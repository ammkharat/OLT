IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedSummaryLogAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserMarkedSummaryLogAsRead
	END
GO

CREATE Procedure [dbo].[QueryUserMarkedSummaryLogAsRead]
(
	@SummaryLogId bigint,
	@UserId bigint
)
AS

SELECT * 
FROM 
	[SummaryLogRead]
WHERE
	SummaryLogId = @SummaryLogId AND
	UserId = @UserId
GO

GRANT EXEC ON [QueryUserMarkedSummaryLogAsRead] TO PUBLIC
GO 