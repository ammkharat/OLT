IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentByRestrictionLocationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentByRestrictionLocationId
	END
GO

CREATE Procedure [dbo].QueryWorkAssignmentByRestrictionLocationId
(
	@RestrictionLocationId bigint,
	@SiteId bigint
)
AS

SELECT 
	wa.* 
FROM 
	RestrictionLocationWorkAssignment assoc
	INNER JOIN WorkAssignment wa on wa.Id = assoc.WorkAssignmentId
WHERE 
	assoc.RestrictionLocationId=@RestrictionLocationId and wa.siteid = @SiteId
GO

GRANT EXEC ON QueryWorkAssignmentByRestrictionLocationId TO PUBLIC
GO