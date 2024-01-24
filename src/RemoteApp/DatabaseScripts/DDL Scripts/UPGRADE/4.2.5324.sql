ALTER TABLE [dbo].[SiteConfiguration] ADD DaysToDisplayTargetAlertsOnPriorityPage INT NULL;

GO

-- Default all Sites to zero to start
UPDATE [dbo].[SiteConfiguration] SET DaysToDisplayTargetAlertsOnPriorityPage = 0;

GO

-- Only Denver, Oilsands, Sarnia should be using Target Alerts on Priority Page
UPDATE [dbo].[SiteConfiguration] SET DaysToDisplayTargetAlertsOnPriorityPage = 7
WHERE SiteId IN (1,2,3);

GO

ALTER TABLE SiteConfiguration ALTER COLUMN DaysToDisplayTargetAlertsOnPriorityPage INT NOT NULL;

GO


GO

