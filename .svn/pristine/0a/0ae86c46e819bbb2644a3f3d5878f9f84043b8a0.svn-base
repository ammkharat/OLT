IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleElementsByRole')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleElementsByRole
	END
GO

CREATE Procedure [dbo].QueryRoleElementsByRole
	(
		@RoleId bigint
	)
AS
SELECT
	RoleElement.*
FROM
	RoleElement
INNER JOIN RoleElementTemplate ON [RoleElementId] = [RoleElement].[Id]
WHERE 
	RoleId = @RoleId
GO

GRANT EXEC ON [QueryRoleElementsByRole] TO PUBLIC
GO