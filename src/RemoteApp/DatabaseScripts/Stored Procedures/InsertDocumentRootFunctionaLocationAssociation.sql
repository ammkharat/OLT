IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDocumentRootFunctionaLocationAssociation')
	BEGIN
		DROP  Procedure  InsertDocumentRootFunctionaLocationAssociation
	END

GO
					 
CREATE Procedure dbo.InsertDocumentRootFunctionaLocationAssociation
	(
	@FunctionalLocationId bigint,
	@DocumentRootPathId bigint
	)
AS

INSERT INTO DocumentRootPathFunctionalLocation
	(
  [FunctionalLocationId],
	[DocumentRootPathId]
  )
VALUES
  (
		@FunctionalLocationId,
		@DocumentRootPathId
  )
GO