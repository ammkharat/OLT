ALTER TABLE [dbo].[SiteConfiguration] ADD ShowWorkPermitPrintingTabInPreferences BIT NULL;
ALTER TABLE [dbo].[SiteConfiguration] ADD ShowDefaulPermitTimesTabInPreferences BIT NULL;

GO

-- Default all tabs to not visible to start
UPDATE [dbo].[SiteConfiguration] SET ShowWorkPermitPrintingTabInPreferences = 0;
UPDATE [dbo].[SiteConfiguration] SET ShowDefaulPermitTimesTabInPreferences = 0;

GO

-- Only Sarnia, Denver and Montreal all need to see the Work Permit Printing tab
UPDATE [dbo].[SiteConfiguration] SET ShowWorkPermitPrintingTabInPreferences = 1
WHERE SiteId IN (1,2,9);

-- Only Sarnia and Denver need to see Default Print Times tab
UPDATE [dbo].[SiteConfiguration] SET ShowDefaulPermitTimesTabInPreferences = 1
WHERE SiteId IN (1,2);

GO

ALTER TABLE SiteConfiguration ALTER COLUMN ShowWorkPermitPrintingTabInPreferences BIT NOT NULL;
ALTER TABLE SiteConfiguration ALTER COLUMN ShowDefaulPermitTimesTabInPreferences BIT NOT NULL;

GO


GO

