IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentDTOBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentDTOBySiteId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentDTOBySiteId
	(
	@SiteId bigint
	)
AS

SELECT 
	wa.*, 
	r.[Name] as RoleName, 
	s.[Name] as SiteName
FROM 
	WorkAssignment wa
	inner join Role r on wa.RoleId = r.Id
	inner join Site s on wa.SiteId = s.Id
WHERE 
	wa.SiteId=@SiteId
	AND wa.Deleted = 0
ORDER BY 
	[Name]
GO  

GRANT EXEC ON QueryWorkAssignmentDTOBySiteId TO PUBLIC
GO