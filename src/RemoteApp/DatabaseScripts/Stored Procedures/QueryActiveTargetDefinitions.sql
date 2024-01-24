IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActiveTargetDefinitions')
    BEGIN
        DROP PROCEDURE [dbo].QueryActiveTargetDefinitions
    END
GO

CREATE Procedure dbo.QueryActiveTargetDefinitions
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
    TargetDefinition.IsActive = 1 AND
    FunctionalLocation.SiteId = @SiteId AND
    TargetDefinition.[Name] LIKE @Name + '%'
GO

GRANT EXEC ON QueryActiveTargetDefinitions TO PUBLIC
GO