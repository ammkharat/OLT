  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFunctionalLocationForWorkAssignmentForRestrictions')
	BEGIN
		DROP  Procedure  InsertFunctionalLocationForWorkAssignmentForRestrictions
	END

GO

CREATE Procedure dbo.InsertFunctionalLocationForWorkAssignmentForRestrictions
	(
	
	@WorkAssignmentId bigint,
	@FlocId bigint
	
	)
AS
INSERT INTO RestrictionWorkAssignmentConfigurationFunctionalLocation (WorkAssignmentId, FunctionalLocationId)
VALUES (@WorkAssignmentId, @FlocId)

RETURN
GO 

GRANT EXEC ON InsertFunctionalLocationForWorkAssignmentForRestrictions TO PUBLIC
GO 