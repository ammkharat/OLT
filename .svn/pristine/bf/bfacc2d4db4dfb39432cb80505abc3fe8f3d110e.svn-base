

ALTER TABLE [dbo].[SiteConfiguration] ADD [DaysToDisplayDirectivesBackwards] int NULL
ALTER TABLE [dbo].[SiteConfiguration] ADD [DaysToDisplayDirectivesForwards] int NULL
GO

UPDATE SiteConfiguration Set DaysToDisplayDirectivesBackwards = 3;
go

ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [DaysToDisplayDirectivesBackwards] int NOT NULL
go


GO

