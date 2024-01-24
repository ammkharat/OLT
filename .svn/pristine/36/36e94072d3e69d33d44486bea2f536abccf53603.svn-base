IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleDisplayConfigurationBySiteAndRole')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleDisplayConfigurationBySiteAndRole
	END
GO

CREATE Procedure [dbo].QueryRoleDisplayConfigurationBySiteAndRole
	(
		@SiteId bigint,
		@RoleId bigint = NULL
	)
AS

SELECT 
	c.*
FROM
	RoleDisplayConfiguration c
	INNER JOIN Role r ON c.RoleId = r.Id
WHERE
	r.SiteId = @SiteId
	and r.Deleted = 0
	and (@RoleID is null or c.RoleId = @RoleId)
GO

GRANT EXEC ON QueryRoleDisplayConfigurationBySiteAndRole TO PUBLIC
GO