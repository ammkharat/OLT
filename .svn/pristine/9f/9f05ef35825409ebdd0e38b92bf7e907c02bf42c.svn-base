IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemDefinitionFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertActionItemDefinitionFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertActionItemDefinitionFunctionalLocation]
	(
	@ActionItemDefinitionId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[ActionItemDefinitionFunctionalLocation]
	(
	[ActionItemDefinitionId], 
	[FunctionalLocationId]
	)
VALUES
	(
	@ActionItemDefinitionId, 
	@FunctionalLocationId
	)
GO

GRANT EXEC ON InsertActionItemDefinitionFunctionalLocation TO PUBLIC
GO


 