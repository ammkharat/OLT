----------------------------------------------------------------------------------------
--  Add Metatarsal Guard to Work Permit
----------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'SpecialProtectiveFootwearMetatarsalGuard')
BEGIN
	ALTER TABLE [dbo].[WorkPermit]
	  ADD [SpecialProtectiveFootwearMetatarsalGuard] [bit] NOT NULL DEFAULT (0)
END
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermitHistory' AND Column_name = 'SpecialProtectiveFootwearMetatarsalGuard')
BEGIN
	ALTER TABLE [dbo].[WorkPermitHistory]
	  ADD [SpecialProtectiveFootwearMetatarsalGuard] [bit] NOT NULL DEFAULT (0)
END
GO


GO
