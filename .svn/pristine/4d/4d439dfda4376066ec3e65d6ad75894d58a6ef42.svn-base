IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteByActiveDirectoryKey')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteByActiveDirectoryKey
	END
GO

CREATE Procedure [dbo].QuerySiteByActiveDirectoryKey
	(
		@ActiveDirectoryKey varchar(255)
	)
AS

SELECT	
	*
FROM Site
WHERE
	ActiveDirectoryKey = @ActiveDirectoryKey;
GO

GRANT EXEC ON QuerySiteByActiveDirectoryKey TO PUBLIC
GO