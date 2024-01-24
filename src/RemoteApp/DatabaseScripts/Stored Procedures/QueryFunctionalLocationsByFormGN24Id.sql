IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormGN24Id')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormGN24Id
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormGN24Id
(
    @FormGN24Id bigint
)
AS

SELECT fl.* 
FROM 
	FormGN24FunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormGN24Id = @FormGN24Id
GO

GRANT EXEC ON QueryFunctionalLocationsByFormGN24Id TO PUBLIC
GO