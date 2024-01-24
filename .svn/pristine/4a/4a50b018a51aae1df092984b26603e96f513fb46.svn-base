IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireById')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireById
	END
GO

CREATE Procedure dbo.QueryShiftHandoverQuestionnaireById
	(
	@Id bigint
	)
AS
SELECT * FROM ShiftHandoverQuestionnaire WHERE Id=@Id 
GO

GRANT EXEC ON QueryShiftHandoverQuestionnaireById TO PUBLIC
GO