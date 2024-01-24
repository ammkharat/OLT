  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkAssignmentFunctionalLocationMappingsForRestrictions')
	BEGIN
		DROP  Procedure  DeleteWorkAssignmentFunctionalLocationMappingsForRestrictions
	END

GO

CREATE Procedure dbo.DeleteWorkAssignmentFunctionalLocationMappingsForRestrictions
	(	
	@WorkAssignmentId bigint		
	)
AS
DELETE FROM RestrictionWorkAssignmentConfigurationFunctionalLocation WHERE WorkAssignmentId = @WorkAssignmentId

RETURN

GO   