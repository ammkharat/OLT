IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogHistoriesById
	END
GO

CREATE Procedure [dbo].QueryLogHistoriesById
	(
	@Id bigint
	)
AS

SELECT * FROM LogHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryLogHistoriesById] TO PUBLIC
GO