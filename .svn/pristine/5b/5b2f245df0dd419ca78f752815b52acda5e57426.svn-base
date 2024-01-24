  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkAssignmentFunctionalLocationMappings')
	BEGIN
		DROP  Procedure  DeleteWorkAssignmentFunctionalLocationMappings
	END

GO

CREATE Procedure dbo.DeleteWorkAssignmentFunctionalLocationMappings
	(	
	@WorkAssignmentId bigint		
	)
AS
DELETE FROM WorkAssignmentFunctionalLocation WHERE WorkAssignmentId = @WorkAssignmentId

RETURN

GO   