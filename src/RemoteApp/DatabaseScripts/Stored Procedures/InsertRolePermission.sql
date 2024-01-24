 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRolePermission')
	BEGIN
		DROP  Procedure  InsertRolePermission
	END

GO

CREATE Procedure [dbo].[InsertRolePermission]
	(
	@RoleId bigint,
	@RoleElementId bigint,
	@CreatedByRoleId bigint
	)
AS

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
VALUES (@RoleId, @RoleElementId, @CreatedByRoleId)

GO

GRANT EXEC ON [InsertRolePermission] TO PUBLIC
GO


