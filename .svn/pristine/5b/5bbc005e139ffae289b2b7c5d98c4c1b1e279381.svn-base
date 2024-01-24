IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFunctionalLocation')
	BEGIN
		DROP  Procedure  UpdateFunctionalLocation
	END

GO

CREATE Procedure [dbo].[UpdateFunctionalLocation]
	(
	    @Id bigint,
	    @Description varchar(50),
		@Culture varchar(5)
	)

AS
UPDATE 
    [FunctionalLocation] 
    SET  
        Description = @Description,
		Culture = @Culture		
WHERE 
    Id = @Id 
GO

GRANT EXEC ON UpdateFunctionalLocation TO PUBLIC
GO

