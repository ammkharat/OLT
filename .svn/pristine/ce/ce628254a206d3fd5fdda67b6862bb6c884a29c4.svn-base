IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateDocumentRootPathConfiguration')
	BEGIN
		DROP  Procedure  UpdateDocumentRootPathConfiguration
	END

GO

CREATE Procedure dbo.UpdateDocumentRootPathConfiguration
	(
		@PathName VARCHAR(50),
		@UncPath VARCHAR(200),
		@Id bigint
	)

AS
UPDATE DocumentRootPathConfiguration
	SET 
	  [PathName] = @PathName,
	  [UncPath] = @UncPath
	WHERE
		Id = @Id
GO



