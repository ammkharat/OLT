IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveDocumentLink')
	BEGIN
		DROP  Procedure  RemoveDocumentLink
	END

GO

CREATE Procedure [dbo].RemoveDocumentLink
	(
		@id bigint
	)
AS

UPDATE 	[DocumentLink] 
	SET 
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveDocumentLink TO PUBLIC

GO 