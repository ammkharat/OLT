  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveExistingUserShiftAssignments')
	BEGIN
		DROP  Procedure  RemoveExistingUserShiftAssignments
	END

GO

CREATE Procedure dbo.RemoveExistingUserShiftAssignments
	(
	@DailyWorkAssignmentId int
	)
AS
DELETE
FROM 
	UserShiftAssignment
WHERE 
	DailyWorkAssignmentId = @DailyWorkAssignmentId


GO
  