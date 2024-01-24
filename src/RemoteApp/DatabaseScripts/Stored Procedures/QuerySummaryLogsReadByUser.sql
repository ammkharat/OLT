IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogsReadByUser')
	BEGIN
		DROP PROCEDURE [dbo].QuerySummaryLogsReadByUser
	END
GO

CREATE Procedure [dbo].[QuerySummaryLogsReadByUser]
(
	@UserId bigint,
	@SummaryLogIds varchar(MAX)
)
AS

SELECT * FROM [SummaryLogRead]
WHERE
	UserId = @UserId
	AND
	EXISTS (SELECT Id FROM IDSplitter(@SummaryLogIds) WHERE Id = SummaryLogId)

GO
GRANT EXEC ON [QuerySummaryLogsReadByUser] TO PUBLIC
GO