IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteShiftHandoverQuestionnaireSummaryLogAssocationsForSummaryLog')
	BEGIN
		DROP PROCEDURE [dbo].DeleteShiftHandoverQuestionnaireSummaryLogAssocationsForSummaryLog
	END
GO

CREATE Procedure [dbo].DeleteShiftHandoverQuestionnaireSummaryLogAssocationsForSummaryLog
	(
		@SummaryLogId BIGINT
	)
AS

DELETE FROM ShiftHandoverQuestionnaireSummaryLog 
WHERE
	SummaryLogId = @SummaryLogId
GO

GRANT EXEC ON DeleteShiftHandoverQuestionnaireSummaryLogAssocationsForSummaryLog TO PUBLIC
GO