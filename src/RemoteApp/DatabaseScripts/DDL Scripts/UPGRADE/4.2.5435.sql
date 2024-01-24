-- Configuration for #1680

ALTER TABLE [dbo].[SiteConfiguration] ADD CopyTargetAlertResponseToLog BIT NULL;

GO

-- Turn this ON for all sites by default
UPDATE [dbo].[SiteConfiguration] SET CopyTargetAlertResponseToLog = 1;

GO

-- ...except for Oilsands who does not want to copy Target Alert Responses to Logs by default
UPDATE [dbo].[SiteConfiguration] SET CopyTargetAlertResponseToLog = 0 
WHERE SiteId = 3;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN CopyTargetAlertResponseToLog BIT NOT NULL;

GO


GO

