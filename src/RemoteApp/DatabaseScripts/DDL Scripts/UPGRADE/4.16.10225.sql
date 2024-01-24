SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

if not exists(select * from sys.columns 
            where Name = N'Comments' and Object_ID = Object_ID(N'DeviationAlertResponse'))
begin
	ALTER TABLE [dbo].[DeviationAlertResponse] ADD [Comments] varchar(2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO

if not exists(select * from sys.columns 
            where Name = N'Comments' and Object_ID = Object_ID(N'DeviationAlertResponseHistory'))
begin
	ALTER TABLE [dbo].[DeviationAlertResponseHistory] ADD [Comments] varchar(2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
end
GO



GO

