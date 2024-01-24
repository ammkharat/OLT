IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDeletedUserByUsername')
	BEGIN
		DROP PROCEDURE [dbo].QueryDeletedUserByUsername
	END
GO

CREATE Procedure [dbo].QueryDeletedUserByUsername
	(
		@Username varchar(24)
	)
AS

SELECT *
FROM
	[User]
WHERE
	[User].Username = @Username
	AND
	[User].[Deleted] = 1
GO

GRANT EXEC ON [QueryDeletedUserByUsername] TO PUBLIC
GO