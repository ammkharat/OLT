IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveDocumentSuggestion')
	BEGIN
		DROP Procedure RemoveDocumentSuggestion
	END

GO

CREATE Procedure [dbo].RemoveDocumentSuggestion
	(
		@id bigint,
		@LastModifiedByUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE FormDocumentSuggestion
	SET LastModifiedByUserId = @LastModifiedByUserId,
		LastModifiedDateTime = @LastModifiedDateTime,
		Deleted = 1
	WHERE Id=@Id
GO

GRANT EXEC ON RemoveDocumentSuggestion TO PUBLIC
GO