  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteRestrictionLocationWorkAssignmentsByRestrictionLocationId')
	BEGIN
		DROP  Procedure  DeleteRestrictionLocationWorkAssignmentsByRestrictionLocationId
	END

GO

CREATE Procedure dbo.DeleteRestrictionLocationWorkAssignmentsByRestrictionLocationId
	(	
	@RestrictionLocationId bigint
	)
AS
DELETE FROM RestrictionLocationWorkAssignment WHERE RestrictionLocationId = @RestrictionLocationId

RETURN

GO   