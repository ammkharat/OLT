IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByDocumentRootPathId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsByDocumentRootPathId
	END
GO
					 
CREATE Procedure dbo.QueryFunctionalLocationsByDocumentRootPathId
	(
	@DocumentRootPathId bigint
	)
AS
SELECT 
	fl.*
FROM 
	FunctionalLocation fl
	INNER JOIN DocumentRootPathFunctionalLocation rootpathfloc 
		ON fl.Id = rootpathfloc.FunctionalLocationId
WHERE 
	rootpathfloc.DocumentRootPathId = @DocumentRootPathId
GO

GRANT EXEC ON [QueryFunctionalLocationsByDocumentRootPathId] TO PUBLIC
GO 