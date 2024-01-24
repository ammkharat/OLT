  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermitAutoAssignment')
	BEGIN
		DROP  Procedure  DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermitAutoAssignment
	END

GO

CREATE Procedure dbo.DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermitAutoAssignment
	(	
	@WorkAssignmentId bigint		
	)
AS
DELETE FROM WorkPermitAutoAssignmentConfigurationFunctionalLocation WHERE WorkAssignmentId = @WorkAssignmentId

RETURN

GO   