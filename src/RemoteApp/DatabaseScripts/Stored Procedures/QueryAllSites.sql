IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllSites')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllSites
	END
GO

CREATE Procedure [dbo].QueryAllSites
AS

SELECT 
	*
FROM
	Site
ORDER BY Name
GO

GRANT EXEC ON QueryAllSites TO PUBLIC
GO