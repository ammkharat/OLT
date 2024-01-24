IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverAnswerHistoriesByHistoryId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverAnswerHistoriesByHistoryId
	END
GO

CREATE Procedure [dbo].QueryShiftHandoverAnswerHistoriesByHistoryId
	(
	@ShiftHandoverQuestionnaireHistoryId bigint
	)
AS

SELECT 
	ShiftHandoverAnswerHistory.*, ShiftHandoverQuestion.[Text] as [QuestionText]
FROM 
	ShiftHandoverAnswerHistory
	INNER JOIN ShiftHandoverQuestion ON ShiftHandoverQuestion.Id = ShiftHandoverAnswerHistory.ShiftHandoverQuestionId
WHERE 
	ShiftHandoverQuestionnaireHistoryId=@ShiftHandoverQuestionnaireHistoryId 
order by 
	Id
GO

GRANT EXEC ON [QueryShiftHandoverAnswerHistoriesByHistoryId] TO PUBLIC
GO