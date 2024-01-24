  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteRolePermission')
	BEGIN
		DROP  Procedure  DeleteRolePermission
	END

GO

CREATE Procedure dbo.DeleteRolePermission
	(	
	@RoleId bigint,
	@RoleElementId bigint,
	@CreatedByRoleId bigint
	)
AS

DELETE FROM RolePermission 
WHERE RoleId = @RoleId and 
      RoleElementId = @RoleElementId and
	  CreatedByRoleId = @CreatedByRoleId

RETURN

GO    