IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionDefinitionHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionDefinitionHistoriesById
	END
GO

CREATE Procedure [dbo].QueryRestrictionDefinitionHistoriesById
	(
	@Id bigint
	)
AS
SELECT * FROM RestrictionDefinitionHistory WHERE Id=@Id ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON [QueryRestrictionDefinitionHistoriesById] TO PUBLIC
GO