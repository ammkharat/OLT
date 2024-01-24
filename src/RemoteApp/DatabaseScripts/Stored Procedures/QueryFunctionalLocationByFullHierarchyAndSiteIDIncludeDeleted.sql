IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationByFullHierarchyAndSiteIDIncludeDeleted')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationByFullHierarchyAndSiteIDIncludeDeleted
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationByFullHierarchyAndSiteIDIncludeDeleted
	(
	@FullHierarchy varchar(90),
	@SiteID [bigint]
	)
AS
SELECT
	*
FROM
	FunctionalLocation
WHERE
	FullHierarchy = @FullHierarchy
	AND SiteID=@SiteID
GO

GRANT EXEC ON [QueryFunctionalLocationByFullHierarchyAndSiteIDIncludeDeleted] TO PUBLIC
GO