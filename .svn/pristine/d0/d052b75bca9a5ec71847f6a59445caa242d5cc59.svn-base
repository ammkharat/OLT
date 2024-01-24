 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveAllDocumentRootFunctionalLocationAssociations')
	BEGIN
		DROP  Procedure  RemoveAllDocumentRootFunctionalLocationAssociations
	END

GO
					 
CREATE Procedure dbo.RemoveAllDocumentRootFunctionalLocationAssociations
	(
	@DocumentRootPathId bigint
	)
AS

DELETE FROM DocumentRootPathFunctionalLocation
	WHERE 
		[DocumentRootPathId] = @DocumentRootPathId
GO