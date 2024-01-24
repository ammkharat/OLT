IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogDefinitionCustomFieldEntryByLogDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogDefinitionCustomFieldEntryByLogDefinitionId
	END
GO

CREATE Procedure dbo.QueryLogDefinitionCustomFieldEntryByLogDefinitionId
	(
	@LogDefinitionId bigint
	)
AS
SELECT * FROM LogDefinitionCustomFieldEntry WHERE LogDefinitionId = @LogDefinitionId
GO

GRANT EXEC ON QueryLogDefinitionCustomFieldEntryByLogDefinitionId TO PUBLIC
GO