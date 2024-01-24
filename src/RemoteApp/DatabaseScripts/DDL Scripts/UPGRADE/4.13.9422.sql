ALTER TABLE [dbo].[RestrictionDefinition] ADD [IsOnlyVisibleOnReports] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[RestrictionDefinition] ALTER COLUMN [IsOnlyVisibleOnReports] bit NOT NULL
GO

ALTER TABLE [dbo].[RestrictionDefinitionHistory] ADD [IsOnlyVisibleOnReports] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[RestrictionDefinitionHistory] ALTER COLUMN [IsOnlyVisibleOnReports] bit NOT NULL
GO

ALTER TABLE [dbo].[DeviationAlert] ADD [IsOnlyVisibleOnReports] bit NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[DeviationAlert] ALTER COLUMN [IsOnlyVisibleOnReports] bit NOT NULL
GO



GO

