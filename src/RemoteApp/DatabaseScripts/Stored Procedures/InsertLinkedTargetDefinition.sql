IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLinkedTargetDefinition')
	BEGIN
		DROP  Procedure  InsertLinkedTargetDefinition
	END

GO

CREATE Procedure [dbo].[InsertLinkedTargetDefinition]
	(
	@ActionItemDefinitionId bigint,
	@TargetDefinitionId bigint	
	)
AS

INSERT INTO [ActionItemDefinitionTargetDefinition]
	    (
	    [ActionItemDefinitionId], 
	    [TargetDefinitionId]
	    )
    VALUES
	    (
	    @ActionItemDefinitionId, 
	    @TargetDefinitionId
	    )
GO

GRANT EXEC ON InsertLinkedTargetDefinition TO PUBLIC
GO