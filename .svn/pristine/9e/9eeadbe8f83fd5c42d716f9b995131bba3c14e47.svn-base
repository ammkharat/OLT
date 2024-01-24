ALTER TABLE [dbo].[SiteConfiguration] ADD [DefaultSelectedFlocsToWorkAssignmentFlocs] bit NULL
GO

UPDATE SiteConfiguration Set DefaultSelectedFlocsToWorkAssignmentFlocs = 0;

UPDATE SiteConfiguration Set DefaultSelectedFlocsToWorkAssignmentFlocs = 1 where SiteId = 8;

ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [DefaultSelectedFlocsToWorkAssignmentFlocs] bit NOT NULL

GO




GO

