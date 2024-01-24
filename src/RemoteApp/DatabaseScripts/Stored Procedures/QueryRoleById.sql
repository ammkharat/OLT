IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleById
	END
GO

CREATE Procedure dbo.QueryRoleById
	(
	@id int
	)
AS
SELECT * FROM Role WHERE Id=@Id
GO

GRANT EXEC ON QueryRoleById TO PUBLIC
GO