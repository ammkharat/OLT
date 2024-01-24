IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByLogId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByLogId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByLogId
	(
		@LogId BIGINT
	)
AS

SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	LogId = @LogId 
	and deleted = 0
	and LogId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByLogId] TO PUBLIC
GO