IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionHistoryById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionHistoryById
	END
GO

CREATE Procedure [dbo].QueryLogDefinitionHistoryById
	(
	@Id bigint
	)
AS
SELECT * FROM LogDefinitionHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryLogDefinitionHistoryById TO PUBLIC
GO