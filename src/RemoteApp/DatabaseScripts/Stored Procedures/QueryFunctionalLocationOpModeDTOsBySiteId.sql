IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationOpModeDTOsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFunctionalLocationOpModeDTOsBySiteId
	END
GO

CREATE Procedure dbo.QueryFunctionalLocationOpModeDTOsBySiteId
	(
	@SiteId bigint
	)
AS

SELECT 	
	floc.FullHierarchy, floc.Description, opMode.* 
FROM 
	 FunctionalLocation floc
	 INNER JOIN FunctionalLocationOperationalMode opMode ON floc.Id = opMode.UnitId
WHERE 
	floc.SiteId=@SiteId 
	and floc.deleted = 0
	and floc.OutOfService = 0
order by 
	floc.FullHierarchy
GO

GRANT EXEC ON [QueryFunctionalLocationOpModeDTOsBySiteId] TO PUBLIC
GO 
 