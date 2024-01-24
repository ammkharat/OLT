IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'SoundAlertforActionItemDirectiveEventsTargets'
)
BEGIN
ALTER TABLE SiteConfiguration ADD SoundAlertforActionItemDirectiveEventsTargets BIT NOT NULL DEFAULT '0'
END


GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[UserPrintPreference]') 
         AND name = 'ShowSoundAlertforActionItemDirectiveTargets'
)
BEGIN
ALTER TABLE UserPrintPreference ADD ShowSoundAlertforActionItemDirectiveTargets BIT NOT NULL DEFAULT '0'
END


GO

