IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCommentsByDocumentSuggestionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCommentsByDocumentSuggestionId
	END

GO

CREATE Procedure [dbo].QueryCommentsByDocumentSuggestionId
(
	@DocumentSuggestionId bigint
)
AS

SELECT
    comment.*
FROM
    Comment comment
    JOIN FormDocumentSuggestionComment documentSuggestionComment ON comment.Id = documentSuggestionComment.CommentId
WHERE
    documentSuggestionComment.FormDocumentSuggestionId = @DocumentSuggestionId
GO

GRANT EXEC ON QueryCommentsByDocumentSuggestionId TO PUBLIC
GO


  