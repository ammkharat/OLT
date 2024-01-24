  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFunctionalLocationForWorkAssignmentForWorkPermitAutoAssignment')
	BEGIN
		DROP  Procedure  InsertFunctionalLocationForWorkAssignmentForWorkPermitAutoAssignment
	END

GO

CREATE Procedure dbo.InsertFunctionalLocationForWorkAssignmentForWorkPermitAutoAssignment
	(
	
	@WorkAssignmentId bigint,
	@FlocId bigint
	
	)
AS
INSERT INTO WorkPermitAutoAssignmentConfigurationFunctionalLocation (WorkAssignmentId, FunctionalLocationId)
VALUES (@WorkAssignmentId, @FlocId)

RETURN
GO 

GRANT EXEC ON InsertFunctionalLocationForWorkAssignmentForWorkPermitAutoAssignment TO PUBLIC
GO 