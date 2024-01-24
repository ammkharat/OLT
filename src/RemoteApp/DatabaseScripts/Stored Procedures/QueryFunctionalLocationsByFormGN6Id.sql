IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormGN6Id')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormGN6Id
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormGN6Id
(
    @FormGN6Id bigint
)
AS

SELECT fl.* 
FROM 
	FormGN6FunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormGN6Id = @FormGN6Id
GO

GRANT EXEC ON QueryFunctionalLocationsByFormGN6Id TO PUBLIC
GO