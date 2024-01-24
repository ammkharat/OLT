IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDocumentRootPathConfiguration')
	BEGIN
		DROP  Procedure  InsertDocumentRootPathConfiguration
	END

GO
					 
CREATE Procedure dbo.InsertDocumentRootPathConfiguration
	(
	@Id bigint Output,
	@PathName VARCHAR(50),
	@UncPath VARCHAR(200)
	)
AS

INSERT INTO DocumentRootPathConfiguration
	(
  [PathName],
	[UncPath]
  )
VALUES
  (
		@PathName,
		@UncPath
  )

SET @Id= SCOPE_IDENTITY() 
GO