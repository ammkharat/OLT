ALTER TABLE [dbo].[VisibilityGroup] ADD [IsSiteDefault] bit NULL
GO
UPDATE VisibilityGroup Set [IsSiteDefault] = 1 where [Name] = 'Operations'
UPDATE VisibilityGroup Set [IsSiteDefault] = 0 where [IsSiteDefault] IS NULL
UPDATE VisibilityGroup Set [Name] = 'Opérations' where [Name] = 'Operations' and SiteId = 9
ALTER TABLE [dbo].[VisibilityGroup] ALTER COLUMN [IsSiteDefault] bit NOT NULL
GO



GO

