IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByLogDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByLogDefinitionId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByLogDefinitionId
	(
		@LogDefinitionId BIGINT
	)
AS

SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	LogDefinitionId = @LogDefinitionId 
	and Deleted = 0 and LogDefinitionId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByLogDefinitionId] TO PUBLIC
GO