SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

if exists(select * from sys.columns 
            where Name = N'CriticalSystemDefeated' and Object_ID = Object_ID(N'FormLubesAlarmDisableHistory'))
begin
	EXECUTE sys.sp_rename @objname = N'[dbo].[FormLubesAlarmDisableHistory].[CriticalSystemDefeated]', @newname = N'Alarm', @objtype = 'COLUMN'
end
GO

if exists(select * from sys.columns 
            where Name = N'IsTheCSDForAPressureSafetyValve' and Object_ID = Object_ID(N'FormLubesAlarmDisableHistory'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisableHistory]
	DROP COLUMN [IsTheCSDForAPressureSafetyValve]
end
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

if not exists(select * from sys.columns 
            where Name = N'Criticality' and Object_ID = Object_ID(N'FormLubesAlarmDisableHistory'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisableHistory] ADD [Criticality] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO

if not exists(select * from sys.columns 
            where Name = N'SapNotification' and Object_ID = Object_ID(N'FormLubesAlarmDisableHistory'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisableHistory] ADD [SapNotification] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO


GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

if exists(select * from sys.columns 
            where Name = N'CriticalSystemDefeated' and Object_ID = Object_ID(N'FormLubesAlarmDisable'))
begin
	EXECUTE sys.sp_rename @objname = N'[dbo].[FormLubesAlarmDisable].[CriticalSystemDefeated]', @newname = N'Alarm', @objtype = 'COLUMN'
end
GO

if exists(select * from sys.columns 
            where Name = N'IsTheCSDForAPressureSafetyValve' and Object_ID = Object_ID(N'FormLubesAlarmDisable'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisable]
	DROP COLUMN [IsTheCSDForAPressureSafetyValve]
end
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

if not exists(select * from sys.columns 
            where Name = N'Criticality' and Object_ID = Object_ID(N'FormLubesAlarmDisable'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisable] ADD [Criticality] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO

if not exists(select * from sys.columns 
            where Name = N'SapNotification' and Object_ID = Object_ID(N'FormLubesAlarmDisable'))
begin
	ALTER TABLE [dbo].[FormLubesAlarmDisable] ADD [SapNotification] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO

GO

