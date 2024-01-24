  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFunctionalLocationForWorkAssignmentForWorkPermit')
	BEGIN
		DROP  Procedure  InsertFunctionalLocationForWorkAssignmentForWorkPermit
	END

GO

CREATE Procedure dbo.InsertFunctionalLocationForWorkAssignmentForWorkPermit
	(
	
	@WorkAssignmentId bigint,
	@FlocId bigint
	
	)
AS
INSERT INTO WorkPermitFunctionalLocationConfiguration (WorkAssignmentId, FunctionalLocationId)
VALUES (@WorkAssignmentId, @FlocId)

RETURN
GO 

GRANT EXEC ON InsertFunctionalLocationForWorkAssignmentForWorkPermit TO PUBLIC
GO 