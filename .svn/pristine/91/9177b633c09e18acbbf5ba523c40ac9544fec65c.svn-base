IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertDefinitionsByName')
    BEGIN
        DROP PROCEDURE [dbo].QueryLabAlertDefinitionsByName
    END
GO

CREATE Procedure dbo.QueryLabAlertDefinitionsByName
    (
        @SiteId BIGINT,
        @Name VARCHAR(50)
    )

AS
SELECT
    LabAlertDefinition.*
FROM
    LabAlertDefinition
	INNER JOIN FunctionalLocation 
		ON LabAlertDefinition.FunctionalLocationId = FunctionalLocation.Id
WHERE 
    LabAlertDefinition.Deleted  = 0 AND
    FunctionalLocation.SiteId = @SiteId AND
    LabAlertDefinition.[Name] = @Name
GO 

GRANT EXEC ON QueryLabAlertDefinitionsByName TO PUBLIC
GO 