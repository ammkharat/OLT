IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRoleByActiveDirectoryKey')
	BEGIN
		DROP PROCEDURE [dbo].QueryRoleByActiveDirectoryKey
	END
GO

CREATE Procedure [dbo].QueryRoleByActiveDirectoryKey
	(
		@SiteId bigint,
		@ActiveDirectoryKey varchar(255)
	)
AS

SELECT	
	*
FROM Role
WHERE
	SiteId = @SiteId
	and ActiveDirectoryKey = @ActiveDirectoryKey
	and Deleted = 0;
GO

GRANT EXEC ON QueryRoleByActiveDirectoryKey TO PUBLIC
GO