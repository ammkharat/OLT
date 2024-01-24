IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UndoRemoveFunctionalLocation')
	BEGIN
		DROP  Procedure UndoRemoveFunctionalLocation
	END

GO

CREATE Procedure [dbo].UndoRemoveFunctionalLocation
	(
		@FunctionalLocationId bigint
	)
AS

UPDATE 	
	    [FunctionalLocation] 
	SET 	
		[Deleted] = 0
	WHERE
	    [Id] = @FunctionalLocationId
GO


GRANT EXEC ON UndoRemoveFunctionalLocation TO PUBLIC

GO 