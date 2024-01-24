IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormOP14Id')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormOP14Id
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormOP14Id
(
    @FormOP14Id bigint
)
AS

SELECT fl.* 
FROM 
	FormOP14FunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormOP14Id = @FormOP14Id
GO

GRANT EXEC ON QueryFunctionalLocationsByFormOP14Id TO PUBLIC
GO