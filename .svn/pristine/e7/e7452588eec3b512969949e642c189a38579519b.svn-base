IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireCokerCardConfigurationByQuestionnaireId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireCokerCardConfigurationByQuestionnaireId
	END
GO

CREATE Procedure dbo.QueryShiftHandoverQuestionnaireCokerCardConfigurationByQuestionnaireId
	(
	@ShiftHandoverQuestionnaireId bigint
	)
AS

SELECT * 
FROM 
	ShiftHandoverQuestionnaireCokerCardConfiguration
WHERE 
	ShiftHandoverQuestionnaireId=@ShiftHandoverQuestionnaireId
GO

GRANT EXEC ON QueryShiftHandoverQuestionnaireCokerCardConfigurationByQuestionnaireId TO PUBLIC
GO