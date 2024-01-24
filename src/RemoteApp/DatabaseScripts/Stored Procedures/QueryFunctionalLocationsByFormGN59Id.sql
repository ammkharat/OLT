IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormGN59Id')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormGN59Id
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormGN59Id
(
    @FormGN59Id bigint
)
AS

SELECT fl.* 
FROM 
	FormGN59FunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormGN59Id = @FormGN59Id
GO

GRANT EXEC ON QueryFunctionalLocationsByFormGN59Id TO PUBLIC
GO