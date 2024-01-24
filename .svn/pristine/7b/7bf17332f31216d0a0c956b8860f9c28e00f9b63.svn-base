IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationInfosForUnitsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationInfosForUnitsBySiteId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationInfosForUnitsBySiteId
	(
	@SiteId bigint
	)
AS
SELECT 
    ParentFloc.*, 
    COALESCE(PArentChildrenCount.NumChildren, 0) as NumChildren
FROM FunctionalLocation ParentFloc
	LEFT OUTER JOIN VFunctionalLocationChildrenCount ParentChildrenCount
	ON ParentChildrenCount.ParentId = ParentFloc.Id
	WHERE SiteId = @SiteId
		AND [Level] = 3
		AND Deleted = 0
		AND OutOfService = 0
ORDER BY
    FullHierarchy
GO 

GRANT EXEC ON [QueryFunctionalLocationInfosForUnitsBySiteId] TO PUBLIC
GO