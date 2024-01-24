IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByShiftHandoverQuestionnaireId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByShiftHandoverQuestionnaireId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationsByShiftHandoverQuestionnaireId
	(
	@ShiftHandoverQuestionnaireId bigint
	)
AS

SELECT fl.* 
FROM 
	ShiftHandoverQuestionnaireFunctionalLocation qfl
	INNER JOIN FunctionalLocation fl
		ON qfl.FunctionalLocationId = fl.Id
WHERE qfl.ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireId 
GO

GRANT EXEC ON [QueryFunctionalLocationsByShiftHandoverQuestionnaireId] TO PUBLIC
GO