
ALTER TABLE [dbo].[SiteConfiguration] ADD LoginFlocSelectionLevel INT NULL;

GO

-- Default all Sites to 3 to start
UPDATE [dbo].[SiteConfiguration] SET LoginFlocSelectionLevel = 3;

GO

-- 5th level for Montreal
UPDATE [dbo].[SiteConfiguration] SET LoginFlocSelectionLevel = 5 WHERE SiteId = 9;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN LoginFlocSelectionLevel INT NOT NULL;

GO


GO




GO

