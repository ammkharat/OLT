IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionById')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverQuestionById
	END
GO

CREATE Procedure dbo.QueryShiftHandoverQuestionById
	(
	@Id bigint
	)
AS

SELECT * 
FROM ShiftHandoverQuestion 
WHERE [Id] = @Id 
GO

GRANT EXEC ON [QueryShiftHandoverQuestionById] TO PUBLIC
GO