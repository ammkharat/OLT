-- Configuration for #1222

ALTER TABLE [dbo].[SiteConfiguration] ADD UseCreatedByColumnForLogs bit NULL;

GO

-- Turn this off for all sites
UPDATE [dbo].[SiteConfiguration] SET UseCreatedByColumnForLogs = 0;

-- Turn this on for Edmonton
UPDATE [dbo].[SiteConfiguration] SET UseCreatedByColumnForLogs = 1 WHERE SiteId = 8;

GO

-- Configuration for #1431

ALTER TABLE [dbo].[SiteConfiguration] ADD ShowIsModifiedColumnForLogs bit NULL;

GO

-- Turn this off for all sites
UPDATE [dbo].[SiteConfiguration] SET ShowIsModifiedColumnForLogs = 0;

-- Turn this on for Montreal
UPDATE [dbo].[SiteConfiguration] SET ShowIsModifiedColumnForLogs = 1 WHERE SiteId = 9;







GO

