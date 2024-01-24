IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[UserPrintPreference]') 
         AND name = 'ShowSoundAlertforActionItemDirectiveTargets'
)
BEGIN
ALTER TABLE UserPrintPreference ADD ShowSoundAlertforActionItemDirectiveTargets BIT NOT NULL DEFAULT '0'
END