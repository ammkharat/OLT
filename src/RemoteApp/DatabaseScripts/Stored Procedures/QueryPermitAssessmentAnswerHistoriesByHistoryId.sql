IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitAssessmentAnswerHistoriesByHistoryId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitAssessmentAnswerHistoriesByHistoryId
	END
GO

CREATE Procedure [dbo].QueryPermitAssessmentAnswerHistoriesByHistoryId
(
	@PermitAssessmentHistoryId bigint
)
AS

SELECT 
	PermitAssessmentAnswerHistory.*, PermitAssessmentAnswer.[QuestionText]
FROM 
	PermitAssessmentAnswerHistory
	INNER JOIN PermitAssessmentAnswer ON PermitAssessmentAnswer.Id = PermitAssessmentAnswerHistory.PermitAssessmentAnswerId
WHERE 
	PermitAssessmentHistoryId=@PermitAssessmentHistoryId 
order by 
	[Id], PermitAssessmentAnswerHistory.PermitAssessmentAnswerId
GO

GRANT EXEC ON [QueryPermitAssessmentAnswerHistoriesByHistoryId] TO PUBLIC
GO