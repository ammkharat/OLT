-- Configuration for #1710

ALTER TABLE [dbo].[SiteConfiguration] ADD ShowLogRecommendedForSummaryColumn bit NULL;

GO

-- Turn this off for all sites
UPDATE [dbo].[SiteConfiguration] SET ShowLogRecommendedForSummaryColumn = 0;

-- Turn this on for Montreal only.
UPDATE [dbo].[SiteConfiguration] SET ShowLogRecommendedForSummaryColumn = 1 WHERE SiteId = 9;

GO
