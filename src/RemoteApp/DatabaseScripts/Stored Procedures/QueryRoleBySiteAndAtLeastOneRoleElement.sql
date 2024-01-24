IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleBySiteAndAtLeastOneRoleElement')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleBySiteAndAtLeastOneRoleElement
	END
GO

CREATE Procedure [dbo].QueryRoleBySiteAndAtLeastOneRoleElement
	(
		@CsvRoleElementIds VARCHAR(MAX),
		@SiteId bigint
	)
AS
SELECT r.*
FROM Role r
WHERE 
  r.Siteid = @SiteId AND
  EXISTS 
  (
	SELECT * 
	FROM IdSplitter(@CsvRoleElementIds) RoleElementIds
	INNER JOIN RoleElementTemplate ON RoleElementIds.Id = RoleElementTemplate.RoleElementId
    WHERE RoleElementTemplate.RoleId = r.ID
  )
GO

GRANT EXEC ON QueryRoleBySiteAndAtLeastOneRoleElement TO PUBLIC
GO