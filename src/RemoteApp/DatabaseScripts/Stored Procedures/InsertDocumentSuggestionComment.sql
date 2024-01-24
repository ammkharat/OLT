if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDocumentSuggestionComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertDocumentSuggestionComment]
GO


CREATE Procedure [dbo].[InsertDocumentSuggestionComment]
(
	@Id bigint Output,
	@DocumentSuggestionId bigint,
	@CreatedUserId bigint,
	@CreatedDate datetime,
	@Text varchar(MAX)
)
AS

INSERT INTO Comment
(
	[CreatedUserId],
	[CreatedDate],
	[Text]
)
VALUES
(
	@CreatedUserId,
	@CreatedDate,
	@Text
)
SET @Id= SCOPE_IDENTITY() 

INSERT INTO FormDocumentSuggestionComment
(
	FormDocumentSuggestionId,
	CommentId
)
VALUES
(
	@DocumentSuggestionId,
	@Id
)
GO 

GRANT EXEC ON InsertDocumentSuggestionComment TO PUBLIC
GO 