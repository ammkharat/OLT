
sp_RENAME 'SiteConfiguration.DefaultSelectedFlocsToLoginFlocs' , 'DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs', 'COLUMN'
go

ALTER TABLE [dbo].[SiteConfiguration] ADD [DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders] bit NULL
GO

UPDATE SiteConfiguration Set DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders = DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs;

UPDATE SiteConfiguration Set DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs = 1 where SiteId = 10;    -- Mississauga
UPDATE SiteConfiguration Set DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders = 0 where SiteId = 10;    -- Mississauga
go

ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders] bit NOT NULL
go




GO

