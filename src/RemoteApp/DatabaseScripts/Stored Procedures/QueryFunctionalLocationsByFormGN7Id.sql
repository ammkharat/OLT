IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormGN7Id')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormGN7Id
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormGN7Id
(
    @FormGN7Id bigint
)
AS

SELECT fl.* 
FROM 
	FormGN7FunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormGN7Id = @FormGN7Id
GO

GRANT EXEC ON QueryFunctionalLocationsByFormGN7Id TO PUBLIC
GO