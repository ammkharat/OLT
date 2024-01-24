IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDocumentSuggestionFunctionalLocation')
	BEGIN
		DROP Procedure InsertDocumentSuggestionFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertDocumentSuggestionFunctionalLocation]
(
	@DocumentSuggestionId bigint,
	@FunctionalLocationId bigint	
)
AS

INSERT INTO [FormDocumentSuggestionFunctionalLocation]
(	
	[FormDocumentSuggestionId],
	[FunctionalLocationId]
)
VALUES
(	
	@DocumentSuggestionId,
	@FunctionalLocationId	
)
	
GRANT EXEC ON [InsertDocumentSuggestionFunctionalLocation] TO PUBLIC
GO