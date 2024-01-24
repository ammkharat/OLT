IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverAnswersByQuestionnaireId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverAnswersByQuestionnaireId
	END
GO

CREATE Procedure dbo.QueryShiftHandoverAnswersByQuestionnaireId
	(
	@QuestionnaireId bigint
	)
AS
SELECT 
	* 
FROM 
	ShiftHandoverAnswer 
WHERE ShiftHandoverQuestionnaireId = @QuestionnaireId 
GO

GRANT EXEC ON [QueryShiftHandoverAnswersByQuestionnaireId] TO PUBLIC
GO