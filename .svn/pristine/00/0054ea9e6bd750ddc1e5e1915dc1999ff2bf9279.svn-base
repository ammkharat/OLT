IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'SiteConfiguration' AND Column_name = 'ShowActionItemsOnShiftHandover')
BEGIN
ALTER TABLE [SiteConfiguration]
ADD ShowActionItemsOnShiftHandover bit NOT NULL DEFAULT (1);
END
GO
GO
