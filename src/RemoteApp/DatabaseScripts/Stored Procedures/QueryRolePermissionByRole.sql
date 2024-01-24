IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRolePermissionByRole')
	BEGIN
		DROP PROCEDURE [dbo].QueryRolePermissionByRole
	END
GO

CREATE Procedure dbo.QueryRolePermissionByRole
	(
	@RoleId int
	)
AS

SELECT 
	* 
FROM 
	RolePermission 
WHERE 
	RoleId=@RoleId
GO

GRANT EXEC ON [QueryRolePermissionByRole] TO PUBLIC
GO