IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionFunctionalLocationByLogDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionFunctionalLocationByLogDefinitionId
	END
GO

CREATE Procedure dbo.QueryLogDefinitionFunctionalLocationByLogDefinitionId
	(
	@LogDefinitionId bigint
	)
AS
SELECT * 
FROM LogDefinitionFunctionalLocation
WHERE LogDefinitionId = @LogDefinitionId
GO

GRANT EXEC ON QueryLogDefinitionFunctionalLocationByLogDefinitionId TO PUBLIC
GO