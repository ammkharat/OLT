EXEC sys.sp_rename @objname = N'[dbo].[WorkAssignmentGroupVisibility]', @newname = N'WorkAssignmentVisibilityGroup', @objtype = N'OBJECT';
GO


EXEC sys.sp_rename @objname = N'[dbo].[GroupVisibility]', @newname = N'VisibilityGroup', @objtype = N'OBJECT';
GO



GO

