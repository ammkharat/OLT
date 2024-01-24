ALTER TABLE [dbo].[SiteConfiguration] ADD DaysToDisplayFormsBackwards INT NULL;
ALTER TABLE [dbo].[SiteConfiguration] ADD DaysToDisplayFormsForwards INT NULL;

GO

UPDATE [dbo].[SiteConfiguration] SET DaysToDisplayFormsBackwards = 3;
UPDATE [dbo].[SiteConfiguration] SET DaysToDisplayFormsForwards = 3;

GO

ALTER TABLE SiteConfiguration ALTER COLUMN DaysToDisplayFormsBackwards INT NOT NULL;
ALTER TABLE SiteConfiguration ALTER COLUMN DaysToDisplayFormsForwards INT NOT NULL;

GO




GO

