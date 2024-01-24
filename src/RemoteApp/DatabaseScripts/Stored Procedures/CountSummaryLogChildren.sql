IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountSummaryLogChildren')
	BEGIN
		DROP PROCEDURE [dbo].CountSummaryLogChildren
	END
GO

CREATE Procedure [dbo].[CountSummaryLogChildren]
(
    @SummaryLogId bigint
)
AS

SELECT count(*)
FROM 
	[SummaryLog] l
WHERE
  ReplyToLogId = @SummaryLogId
  and
  Deleted = 0
GO

GRANT EXEC ON [dbo].[CountSummaryLogChildren] TO PUBLIC
GO