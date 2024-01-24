  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFunctionalLocationForWorkAssignment')
	BEGIN
		DROP  Procedure  InsertFunctionalLocationForWorkAssignment
	END

GO

CREATE Procedure dbo.InsertFunctionalLocationForWorkAssignment
	(
	
	@WorkAssignmentId bigint,
	@FlocId bigint
	
	)
AS
INSERT INTO WorkAssignmentFunctionalLocation (WorkAssignmentId, FunctionalLocationId)
VALUES (@WorkAssignmentId, @FlocId)

RETURN
GO 

GRANT EXEC ON InsertFunctionalLocationForWorkAssignment TO PUBLIC
GO 