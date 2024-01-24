IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserById')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserById
	END
GO

CREATE Procedure dbo.QueryUserById
	(
	@id bigint
	)
AS

SELECT *
FROM
	[User]
WHERE 
	[User].Id=@Id
GO
 
GRANT EXEC ON QueryUserById TO PUBLIC
GO