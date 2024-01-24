
ALTER TABLE [dbo].[SiteConfiguration] ADD [DaysToDisplaySAPNotificationsBackwards] int NULL
GO

UPDATE SiteConfiguration Set DaysToDisplaySAPNotificationsBackwards = 1;
UPDATE SiteConfiguration Set DaysToDisplaySAPNotificationsBackwards = 7 where SiteId = 3;    -- Oilsands
go

ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [DaysToDisplaySAPNotificationsBackwards] int NOT NULL
go







GO

