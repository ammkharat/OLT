ALTER TABLE [dbo].[SiteConfiguration] ADD [ItemFlocSelectionLevel] int NULL
GO

UPDATE SiteConfiguration Set ItemFlocSelectionLevel = 5
where SiteId != 9

UPDATE SiteConfiguration Set ItemFlocSelectionLevel = 7
where SiteId = 9

ALTER TABLE [dbo].[SiteConfiguration] ALTER COLUMN [ItemFlocSelectionLevel] int NOT NULL
GO


GO

