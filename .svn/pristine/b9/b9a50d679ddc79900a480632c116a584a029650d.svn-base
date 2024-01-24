 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteConfigurationBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteConfigurationBySiteId
	END
GO

CREATE Procedure [dbo].QuerySiteConfigurationBySiteId
	(
		@Id bigint
	)

AS

SELECT 
	*
FROM
	SiteConfiguration
WHERE
	[SiteId] = @Id
GO

GRANT EXEC ON QuerySiteConfigurationBySiteId TO PUBLIC
GO