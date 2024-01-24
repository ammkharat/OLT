IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllVisibilityGroups')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllVisibilityGroups
	END
GO

CREATE Procedure dbo.QueryAllVisibilityGroups
	(
	@SiteId bigint
	)
AS

SELECT 
	* 
from 
	VisibilityGroup
where 
	SiteId = @SiteId
	and Deleted = 0
GO  

GRANT EXEC ON QueryAllVisibilityGroups TO PUBLIC
GO