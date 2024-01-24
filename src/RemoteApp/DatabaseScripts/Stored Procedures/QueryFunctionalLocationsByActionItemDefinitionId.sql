IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByActionItemDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByActionItemDefinitionId
	END
GO
					 
CREATE Procedure dbo.QueryFunctionalLocationsByActionItemDefinitionId
	(
	@ActionItemDefinitionId bigint
	)
AS
SELECT 
	fl.* 
FROM 
	ActionItemDefinitionFunctionalLocation aifl
	INNER JOIN FunctionalLocation fl 
		ON aifl.FunctionalLocationId = fl.Id
WHERE aifl.ActionItemDefinitionId=@ActionItemDefinitionId 
GO

GRANT EXEC ON [QueryFunctionalLocationsByActionItemDefinitionId] TO PUBLIC
GO 