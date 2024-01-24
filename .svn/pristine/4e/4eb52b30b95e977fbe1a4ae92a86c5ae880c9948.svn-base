  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveConfiguredDocumentLink')
	BEGIN
		DROP Procedure RemoveConfiguredDocumentLink
	END

GO

CREATE Procedure dbo.RemoveConfiguredDocumentLink
	(	
	@Id bigint
	)
AS

update ConfiguredDocumentLink
set Deleted = 1
WHERE Id = @Id

GO

GRANT EXEC ON RemoveConfiguredDocumentLink TO PUBLIC

GO
