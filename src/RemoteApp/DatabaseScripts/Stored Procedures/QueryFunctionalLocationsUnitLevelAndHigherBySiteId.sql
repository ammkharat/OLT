IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsUnitLevelAndHigherBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationsUnitLevelAndHigherBySiteId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationsUnitLevelAndHigherBySiteId
	(
	@SiteId int
	)
AS
SELECT 
	* 
FROM 
	FunctionalLocation 
WHERE 
	SiteId=@SiteId 
	and [Level] <= 3
	and deleted = 0
	and OutOfService = 0
order by 
	FULLHIERARCHY
GO

GRANT EXEC ON [QueryFunctionalLocationsUnitLevelAndHigherBySiteId] TO PUBLIC
GO