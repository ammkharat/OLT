IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogActionItemAssociation')
	BEGIN
		DROP  Procedure  InsertLogActionItemAssociation
	END

GO

CREATE Procedure [dbo].[InsertLogActionItemAssociation]
	(
	@LogId bigint,
	@ActionItemId bigint
	)
AS
							
INSERT INTO 
	[LogActionItemAssociation]
	(	
	[LogId],
	[ActionItemId]
	)
VALUES
	(	
	@LogId,
	@ActionItemId
	)

GRANT EXEC ON [InsertLogActionItemAssociation] TO PUBLIC
GO