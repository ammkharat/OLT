IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleElementById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleElementById
	END
GO

CREATE Procedure dbo.QueryRoleElementById
	(
	@Id int
	)
AS

SELECT 
	* 
FROM 
	RoleElement 
WHERE 
	Id=@Id
GO

GRANT EXEC ON [QueryRoleElementById] TO PUBLIC
GO