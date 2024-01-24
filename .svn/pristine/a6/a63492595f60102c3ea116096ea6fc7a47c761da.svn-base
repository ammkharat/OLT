IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByActionItemId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByActionItemId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationsByActionItemId
	(
	@ActionItemId bigint
	)
AS

SELECT 
	fl.* 
FROM 
	ActionItemFunctionalLocation aifl
	INNER JOIN FunctionalLocation fl 
		ON aifl.FunctionalLocationId = fl.Id
WHERE aifl.ActionItemId = @ActionItemId 
GO

GRANT EXEC ON [QueryFunctionalLocationsByActionItemId] TO PUBLIC
GO 