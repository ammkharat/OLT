ALTER TABLE [dbo].[Shift] ADD [StartTime_New] time(0) NULL
GO
ALTER TABLE [dbo].[Shift] ADD [EndTime_New] time(0) NULL
GO

UPDATE Shift  
  SET 
    StartTime_New = StartTime,
    EndTime_New = EndTime
    
    
ALTER TABLE [dbo].[Shift] DROP COLUMN [StartTime]
GO
ALTER TABLE [dbo].[Shift] DROP COLUMN [EndTime]
GO 

EXEC sys.sp_rename @objname = N'[dbo].[Shift].[StartTime_New]', @newname = [StartTime], @objtype = N'COLUMN';
GO
EXEC sys.sp_rename @objname = N'[dbo].[Shift].[EndTime_New]', @newname = [EndTime], @objtype = N'COLUMN';
GO

ALTER TABLE [dbo].[Shift] ALTER COLUMN [StartTime] time(0) NOT NULL
GO
ALTER TABLE [dbo].[Shift] ALTER COLUMN [EndTime] time(0) NOT NULL
GO


GO

