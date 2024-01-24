  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermit')
	BEGIN
		DROP  Procedure  DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermit
	END

GO

CREATE Procedure dbo.DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermit
	(	
	@WorkAssignmentId bigint		
	)
AS
DELETE FROM WorkPermitFunctionalLocationConfiguration WHERE WorkAssignmentId = @WorkAssignmentId

RETURN

GO   