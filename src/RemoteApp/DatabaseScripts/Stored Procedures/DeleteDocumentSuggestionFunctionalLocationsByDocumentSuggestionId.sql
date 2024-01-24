IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteDocumentSuggestionFunctionalLocationsByDocumentSuggestionId')
BEGIN
	DROP Procedure DeleteDocumentSuggestionFunctionalLocationsByDocumentSuggestionId
END
GO

CREATE Procedure dbo.DeleteDocumentSuggestionFunctionalLocationsByDocumentSuggestionId
(
	@DocumentSuggestionId bigint
)
AS
DELETE FROM FormDocumentSuggestionFunctionalLocation WHERE FormDocumentSuggestionId = @DocumentSuggestionId

RETURN

GO   