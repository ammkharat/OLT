IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentSuggestionHistoryById')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentSuggestionHistoryById
	END
GO

CREATE Procedure [dbo].QueryDocumentSuggestionHistoryById
(
	@Id bigint
)
AS

SELECT * 
FROM 
	FormDocumentSuggestionHistory 
WHERE 
	Id=@Id 
ORDER BY 
	LastModifiedDateTime
GO

GO
GRANT EXEC ON QueryDocumentSuggestionHistoryById TO PUBLIC