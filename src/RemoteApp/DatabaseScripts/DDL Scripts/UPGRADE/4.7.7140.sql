CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([Level], [SiteId])
INCLUDE ([FullHierarchy],[Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = OFF
)
ON [PRIMARY];
GO    

ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO


INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
SELECT 
  c.Id, a.Id, a.[Level]
	FROM FunctionalLocation a
	INNER JOIN FunctionalLocation c 
		ON c.siteid = a.siteid and 
		c.[Level] > a.[Level] and
		c.Fullhierarchy like a.fullhierarchy + '-%'
where
  c.Id between 328400 and 332500 and
  NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)
  
DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO


ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;

  


GO

