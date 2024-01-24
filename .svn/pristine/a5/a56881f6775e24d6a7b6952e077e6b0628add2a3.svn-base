 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySiteConfigurationDefaultsBySiteId')
	BEGIN
		DROP PROCEDURE [dbo].QuerySiteConfigurationDefaultsBySiteId
	END
GO

CREATE Procedure [dbo].QuerySiteConfigurationDefaultsBySiteId (@Id bigint)
AS

SELECT * FROM SiteConfigurationDefaults WHERE [SiteId] = @Id
GO

GRANT EXEC ON QuerySiteConfigurationDefaultsBySiteId TO PUBLIC
GO