IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocation]') AND name = N'IDX_FunctionalLocation_ParentId')
	BEGIN
		DROP INDEX [IDX_FunctionalLocation_ParentId] ON [dbo].[FunctionalLocation];
	END
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocation]') AND name = N'IDX_FunctionalLocation_SiteId')
	BEGIN
		DROP INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation];
	END
GO

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_SiteId]
ON [dbo].[FunctionalLocation]
(
 [SiteId] , [Level] , [Deleted] , [OutOfService] , [Id] , [FullHierarchy] 
)
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocation]') AND name = N'IDX_FunctionalLocation_Site')
	BEGIN
		DROP INDEX [IDX_FunctionalLocation_Site] ON [dbo].[FunctionalLocation];
	END
GO

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Site]
ON [dbo].[FunctionalLocation]
([SiteId] , [Id])
INCLUDE ([OutOfService], [Deleted])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

ALTER TABLE dbo.FunctionalLocation
  DROP COLUMN ParentId
  
ALTER TABLE [dbo].[FunctionalLocationAncestor] 
  ADD [AncestorLevel] tinyint NULL
GO
  
UPDATE a
  SET a.[AncestorLevel] = f.[Level]
  FROM FunctionalLocationAncestor a
  INNER JOIN FunctionalLocation f ON a.AncestorId = f.Id
GO

ALTER TABLE [dbo].[FunctionalLocationAncestor] 
  ALTER COLUMN [AncestorLevel] tinyint NOT NULL
GO


GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocation]') AND name = N'IDX_FunctionalLocation_UnitId')
	BEGIN
		DROP INDEX [IDX_FunctionalLocation_UnitId] ON [dbo].[FunctionalLocation];
	END
GO

ALTER TABLE dbo.FunctionalLocation
  DROP COLUMN UnitId



GO

