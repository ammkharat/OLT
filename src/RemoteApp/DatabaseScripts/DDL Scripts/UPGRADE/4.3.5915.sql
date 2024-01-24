ALTER TABLE [dbo].[SiteConfiguration] ADD [PreShiftPaddingInMinutes] int NULL
ALTER TABLE [dbo].[SiteConfiguration] ADD [PostShiftPaddingInMinutes] int NULL
GO

UPDATE [dbo].[SiteConfiguration] 
  SET 
    PreShiftPaddingInMinutes = 30,
    PostShiftPaddingInMinutes = 30
  WHERE SiteId != 10
  
ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [PreShiftPaddingInMinutes] int NOT NULL
ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [PostShiftPaddingInMinutes] int NOT NULL
GO

EXECUTE sys.sp_rename 
  @objname = N'[dbo].[UserWorkPermitDefaultTimesPreference].[ShiftStartAddOffset]', 
  @newname = N'PreShiftPadding', @objtype = 'COLUMN'
GO

EXECUTE sys.sp_rename 
  @objname = N'[dbo].[UserWorkPermitDefaultTimesPreference].[ShiftEndSubtractOffset]', 
  @newname = N'PostShiftPadding', @objtype = 'COLUMN'
GO