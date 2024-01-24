IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetDefinitionsByName')
    BEGIN
        DROP PROCEDURE [dbo].QueryTargetDefinitionsByName
    END
GO

CREATE Procedure dbo.QueryTargetDefinitionsByName
    (
        @SiteId BIGINT,
        @Name VARCHAR(50)
    )
AS

SELECT
    TargetDefinition.*
FROM
    TargetDefinition
	INNER JOIN FunctionalLocation ON TargetDefinition.FunctionalLocationId = FunctionalLocation.Id
WHERE 
    TargetDefinition.Deleted  = 0 AND
    FunctionalLocation.SiteId = @SiteId AND
    TargetDefinition.[Name] = @Name
GO 

GRANT EXEC ON QueryTargetDefinitionsByName TO PUBLIC
GO