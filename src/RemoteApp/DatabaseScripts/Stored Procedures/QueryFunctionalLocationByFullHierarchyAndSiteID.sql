IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationByFullHierarchyAndSiteID')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationByFullHierarchyAndSiteID
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationByFullHierarchyAndSiteID
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
	AND SiteID = @SiteID
	and Deleted = 0
GO

GRANT EXEC ON [QueryFunctionalLocationByFullHierarchyAndSiteID] TO PUBLIC
GO