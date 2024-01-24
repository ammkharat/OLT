IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteById')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteById
	END
GO

CREATE Procedure [dbo].QuerySiteById
	(
		@Id int
	)
AS

SELECT 
	*
FROM
	Site
WHERE
	[Id] = @Id
GO

GRANT EXEC ON QuerySiteById TO PUBLIC
GO