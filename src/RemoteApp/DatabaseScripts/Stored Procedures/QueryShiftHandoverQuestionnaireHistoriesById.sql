IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionnaireHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverQuestionnaireHistoriesById
	END
GO

CREATE Procedure [dbo].QueryShiftHandoverQuestionnaireHistoriesById
	(
	@Id bigint
	)
AS

SELECT * 
FROM 
	ShiftHandoverQuestionnaireHistory 
WHERE 
	Id=@Id 
ORDER BY 
	LastModifiedDateTime
GO

GRANT EXEC ON QueryShiftHandoverQuestionnaireHistoriesById TO PUBLIC
GO