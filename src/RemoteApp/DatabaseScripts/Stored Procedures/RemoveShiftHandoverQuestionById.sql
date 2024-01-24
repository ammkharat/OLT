  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveShiftHandoverQuestionById')
	BEGIN
		DROP  Procedure  RemoveShiftHandoverQuestionById
	END

GO

CREATE Procedure dbo.RemoveShiftHandoverQuestionById
	(	
	@Id bigint
	)
AS

update ShiftHandoverQuestion
set Deleted = 1, IsCurrentQuestionVersion = 0
WHERE Id = @Id

RETURN

GO    