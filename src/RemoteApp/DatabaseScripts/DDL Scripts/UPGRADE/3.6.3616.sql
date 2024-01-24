ALTER TABLE [dbo].[WorkPermit] ADD [GasTestTestTime_temp] datetime NULL
ALTER TABLE [dbo].[WorkPermit] ADD [GasTestSystemEntryTestTime_temp] datetime NULL
ALTER TABLE [dbo].[WorkPermit] ADD [GasTestConfinedSpaceTestTime_temp] datetime NULL
GO

UPDATE WorkPermit SET
  GasTestTestTime_temp = CONVERT(datetime, GasTestTestTime, 108),
  GasTestSystemEntryTestTime_temp = CONVERT(datetime, GasTestSystemEntryTestTime, 108),
  GasTestConfinedSpaceTestTime_temp = CONVERT(datetime, GasTestConfinedSpaceTestTime, 108)
  
ALTER TABLE [dbo].[WorkPermit] DROP COLUMN [GasTestTestTime]
ALTER TABLE [dbo].[WorkPermit] DROP COLUMN [GasTestSystemEntryTestTime]
ALTER TABLE [dbo].[WorkPermit] DROP COLUMN [GasTestConfinedSpaceTestTime]
GO

exec sp_RENAME 'WorkPermit.GasTestTestTime_temp', 'GasTestTestTime', 'COLUMN'
exec sp_RENAME 'WorkPermit.GasTestSystemEntryTestTime_temp', 'GasTestSystemEntryTestTime', 'COLUMN'
exec sp_RENAME 'WorkPermit.GasTestConfinedSpaceTestTime_temp', 'GasTestConfinedSpaceTestTime', 'COLUMN'
GO

ALTER TABLE [dbo].[WorkPermitHistory] ADD [GasTestTestTime_temp] datetime NULL
ALTER TABLE [dbo].[WorkPermitHistory] ADD [GasTestSystemEntryTestTime_temp] datetime NULL
ALTER TABLE [dbo].[WorkPermitHistory] ADD [GasTestConfinedSpaceTestTime_temp] datetime NULL
GO

UPDATE WorkPermitHistory SET
  GasTestTestTime_temp = CONVERT(datetime, GasTestTestTime, 108),
  GasTestSystemEntryTestTime_temp = CONVERT(datetime, GasTestSystemEntryTestTime, 108),
  GasTestConfinedSpaceTestTime_temp = CONVERT(datetime, GasTestConfinedSpaceTestTime, 108)
  
ALTER TABLE [dbo].[WorkPermitHistory] DROP COLUMN [GasTestTestTime]
ALTER TABLE [dbo].[WorkPermitHistory] DROP COLUMN [GasTestSystemEntryTestTime]
ALTER TABLE [dbo].[WorkPermitHistory] DROP COLUMN [GasTestConfinedSpaceTestTime]
GO

exec sp_RENAME 'WorkPermitHistory.GasTestTestTime_temp', 'GasTestTestTime', 'COLUMN'
exec sp_RENAME 'WorkPermitHistory.GasTestSystemEntryTestTime_temp', 'GasTestSystemEntryTestTime', 'COLUMN'
exec sp_RENAME 'WorkPermitHistory.GasTestConfinedSpaceTestTime_temp', 'GasTestConfinedSpaceTestTime', 'COLUMN'
GO
GO
