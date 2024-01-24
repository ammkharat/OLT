IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionItemDefinitionFunctionalLocation')
	BEGIN
		DROP  Procedure  RemoveActionItemDefinitionFunctionalLocation
	END

GO

CREATE Procedure [dbo].RemoveActionItemDefinitionFunctionalLocation
	(
		@ActionItemDefinitionId bigint
	)
AS

DELETE FROM ActionItemDefinitionFunctionalLocation WHERE ActionItemDefinitionId = @ActionItemDefinitionId
GO


GRANT EXEC ON RemoveActionItemDefinitionFunctionalLocation TO PUBLIC

GO

