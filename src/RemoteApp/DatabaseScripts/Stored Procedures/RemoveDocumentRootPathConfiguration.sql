IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveDocumentRootPathConfiguration')
	BEGIN
		DROP  Procedure  RemoveDocumentRootPathConfiguration
	END

GO
					 
CREATE Procedure dbo.RemoveDocumentRootPathConfiguration
	(
	@Id bigint
	)
AS

UPDATE DocumentRootPathConfiguration
	SET Deleted = 1
	WHERE Id = @Id
GO