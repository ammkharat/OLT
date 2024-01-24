IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleElements')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleElements
	END
GO

CREATE Procedure [dbo].QueryRoleElements
AS
SELECT
	RoleElement.*
FROM
	RoleElement
GO

GRANT EXEC ON [QueryRoleElements] TO PUBLIC
GO