----------------------------------------------------------------------------------------
--  Add ActualLoggedDateTime Column to the Log
----------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'Log' AND Column_name = 'ActualLoggedDateTime')
BEGIN
	ALTER TABLE [dbo].[Log]
	  ADD [ActualLoggedDateTime] DATETIME
END
GO
