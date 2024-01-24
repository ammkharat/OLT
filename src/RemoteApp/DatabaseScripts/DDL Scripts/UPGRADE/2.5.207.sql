IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'SiteConfiguration' AND Column_name = 'OperatingEngineerLogDisplayName')
BEGIN
ALTER TABLE [SiteConfiguration]
	ADD OperatingEngineerLogDisplayName VARCHAR(100)
END
GO

-- Name Operating Engineer Logs properly for Denver and Sarnia	
UPDATE SiteConfiguration SET OperatingEngineerLogDisplayName = 'Operating Engineer Log'
WHERE SiteId IN (1, 2)
GO

-- Name Operating Engineer Logs properly for oil sands.
UPDATE SiteConfiguration SET OperatingEngineerLogDisplayName = 'Chief Engineer Log'
WHERE SiteId IN (3, 4, 5, 6)
GO

-- turn off operating engineer logs at SWS.
UPDATE SiteConfiguration SET [CreateOperatingEngineerLogs] = 0 WHERE SiteId = 6
GO
