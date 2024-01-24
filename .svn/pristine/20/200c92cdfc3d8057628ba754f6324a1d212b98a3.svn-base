IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentBySiteId
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentBySiteId
	(
	@SiteId bigint
	)
AS

SELECT * 
FROM 
	WorkAssignment 
WHERE 
	SiteId=@SiteId
	AND Deleted = 0
ORDER BY 
	[Name]
GO  

GRANT EXEC ON QueryWorkAssignmentBySiteId TO PUBLIC
GO