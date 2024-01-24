IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActiveUserByUsername')
	BEGIN
		DROP PROCEDURE [dbo].QueryActiveUserByUsername
	END
GO

CREATE Procedure [dbo].QueryActiveUserByUsername
	(
		@Username varchar(30)
	)
AS

SELECT *
FROM
	[User]
WHERE
	[User].Username = @Username
	AND
	[User].[Deleted] = 0
GO

GRANT EXEC ON QueryActiveUserByUsername TO PUBLIC
GO