IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationInfosForDivisionsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationInfosForDivisionsBySiteId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationInfosForDivisionsBySiteId
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
		AND [Level] = 1
		AND Deleted = 0
		AND OutOfService = 0
ORDER BY
    FullHierarchy
GO 

GRANT EXEC ON [QueryFunctionalLocationInfosForDivisionsBySiteId] TO PUBLIC
GO