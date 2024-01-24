IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByFormDocumentSuggestionId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByFormDocumentSuggestionId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByFormDocumentSuggestionId
(
	@DocumentSuggestionId bigint
)
AS

SELECT fl.* 
FROM 
	FormDocumentSuggestionFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormDocumentSuggestionId = @DocumentSuggestionId
GO

GRANT EXEC ON QueryFunctionalLocationsByFormDocumentSuggestionId TO PUBLIC
GO