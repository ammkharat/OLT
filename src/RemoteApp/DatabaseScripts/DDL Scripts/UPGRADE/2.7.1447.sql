IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[colt_admin].[DeviationAlertResponseHistory]') AND type in (N'U'))
ALTER SCHEMA dbo TRANSFER colt_admin.DeviationAlertResponseHistory;

GO
