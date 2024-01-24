IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefinitionHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryActionItemDefinitionHistoriesById
	END
GO

CREATE Procedure dbo.QueryActionItemDefinitionHistoriesById
	(
	@Id bigint
	)
AS

SELECT * FROM ActionItemDefinitionHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryActionItemDefinitionHistoriesById TO PUBLIC
GO