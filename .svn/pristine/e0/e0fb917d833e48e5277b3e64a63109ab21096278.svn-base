IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByLogDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByLogDefinitionId
	END
GO
					 
CREATE Procedure dbo.QueryFunctionalLocationsByLogDefinitionId
	(
	@LogDefinitionId bigint
	)
AS

SELECT 
	fl.*
FROM 
	FunctionalLocation fl
	INNER JOIN LogDefinitionFunctionalLocation ldfl 
		ON ldfl.FunctionalLocationId = fl.Id AND ldfl.LogDefinitionId = @LogDefinitionId
GO

GRANT EXEC ON [QueryFunctionalLocationsByLogDefinitionId] TO PUBLIC
GO 