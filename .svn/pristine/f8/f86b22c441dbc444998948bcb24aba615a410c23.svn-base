IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogCustomFieldEntryHistoriesByHistoryId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySummaryLogCustomFieldEntryHistoriesByHistoryId
	END
GO

CREATE Procedure [dbo].QuerySummaryLogCustomFieldEntryHistoriesByHistoryId
	(
	@SummaryLogHistoryId bigint
	)
AS

SELECT * 
FROM SummaryLogCustomFieldEntryHistory
WHERE SummaryLogHistoryId = @SummaryLogHistoryId 
GO

GRANT EXEC ON QuerySummaryLogCustomFieldEntryHistoriesByHistoryId TO PUBLIC
GO