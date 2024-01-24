IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionBySapOperationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionBySapOperationId
	END
GO

CREATE Procedure dbo.QueryActionItemDefinitionBySapOperationId
	(
	@SapOperationId bigint
	)
AS
SELECT * FROM ActionItemDefinition WHERE SapOperationId = @SapOperationId
GO

GRANT EXEC ON QueryActionItemDefinitionBySapOperationId TO PUBLIC
GO