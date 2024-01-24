 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogLastCreatedByUserId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySummaryLogLastCreatedByUserId
	END
GO

CREATE Procedure [dbo].QuerySummaryLogLastCreatedByUserId

	(
		@UserId bigint
	)

AS

SELECT
	top(1) sl.*
FROM
	[SummaryLog] sl
WHERE
	sl.CreatedByUserId = @UserId and
	sl.Deleted = 0
ORDER BY
	sl.CreatedDateTime DESC
GO

GRANT EXEC ON QuerySummaryLogLastCreatedByUserId TO PUBLIC
GO