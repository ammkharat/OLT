IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogCustomFieldEntryHistoriesByHistoryId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogCustomFieldEntryHistoriesByHistoryId
	END
GO

CREATE Procedure [dbo].QueryLogCustomFieldEntryHistoriesByHistoryId
	(
	@LogHistoryId bigint
	)
AS

SELECT * 
FROM 
	LogCustomFieldEntryHistory
WHERE 
	LogHistoryId = @LogHistoryId 
GO

GRANT EXEC ON QueryLogCustomFieldEntryHistoriesByHistoryId TO PUBLIC
GO 
