IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionCustomFieldEntryHistoriesByHistoryId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionCustomFieldEntryHistoriesByHistoryId
	END

GO

CREATE Procedure [dbo].QueryLogDefinitionCustomFieldEntryHistoriesByHistoryId
	(
	@LogDefinitionHistoryId bigint
	)
AS

SELECT * 
FROM LogDefinitionCustomFieldEntryHistory
WHERE LogDefinitionHistoryId = @LogDefinitionHistoryId 
GO

GRANT EXEC ON QueryLogDefinitionCustomFieldEntryHistoriesByHistoryId TO PUBLIC
GO