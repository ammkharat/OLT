IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionsByName')
    BEGIN
        DROP PROCEDURE [dbo].QueryRestrictionDefinitionsByName
    END
GO

CREATE Procedure dbo.QueryRestrictionDefinitionsByName
    (
        @SiteId BIGINT,
        @Name VARCHAR(50)
    )
AS

SELECT
    RestrictionDefinition.*
FROM
    RestrictionDefinition
 	INNER JOIN FunctionalLocation ON RestrictionDefinition.FunctionalLocationId = FunctionalLocation.Id
WHERE 
    RestrictionDefinition.Deleted  = 0 AND
    FunctionalLocation.SiteId = @SiteId AND
    RestrictionDefinition.[Name] = @Name
GO 

GRANT EXEC ON QueryRestrictionDefinitionsByName TO PUBLIC
GO