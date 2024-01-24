IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormDocumentSuggestionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormDocumentSuggestionId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormDocumentSuggestionId(@FormDocumentSuggestionId bigint)
AS
SELECT * FROM DocumentLink WHERE FormDocumentSuggestionId = @FormDocumentSuggestionId	and Deleted = 0	
and FormDocumentSuggestionId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormDocumentSuggestionId] TO PUBLIC
GO