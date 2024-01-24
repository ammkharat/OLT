IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentRootsBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentRootsBySite
	END
GO
					 
CREATE Procedure dbo.QueryDocumentRootsBySite
	(
	@SiteId bigint
	)
AS
SELECT 
	DISTINCT rp.*
FROM 
	DocumentRootPathConfiguration rp
	INNER JOIN DocumentRootPathFunctionalLocation rpfloc ON rp.Id = rpfloc.DocumentRootPathId
	INNER JOIN FunctionalLocation floc ON floc.Id = rpfloc.FunctionalLocationId
WHERE
	floc.SiteId = @SiteId
	and rp.Deleted = 0
GO

GRANT EXEC ON [QueryDocumentRootsBySite] TO PUBLIC
GO