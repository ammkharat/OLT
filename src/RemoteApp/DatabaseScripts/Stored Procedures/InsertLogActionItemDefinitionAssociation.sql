IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogActionItemDefinitionAssociation')
	BEGIN
		DROP  Procedure  InsertLogActionItemDefinitionAssociation
	END
GO

CREATE Procedure [dbo].[InsertLogActionItemDefinitionAssociation]
	(
	@LogId bigint,
	@ActionItemDefinitionId bigint
	)
AS
							
INSERT INTO 
	[LogActionItemDefinitionAssociation]
	(	
	[LogId],
	[ActionItemDefinitionId]
	)
VALUES
	(	
	@LogId,
	@ActionItemDefinitionId
	)
	
GRANT EXEC ON [InsertLogActionItemDefinitionAssociation] TO PUBLIC
GO