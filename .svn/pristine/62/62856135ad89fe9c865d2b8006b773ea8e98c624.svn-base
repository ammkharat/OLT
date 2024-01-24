CREATE UNIQUE CLUSTERED INDEX [IDX_FunctionalLocationAncestor]
ON [dbo].[FunctionalLocationAncestor]
([AncestorId], [Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO

DROP INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] WITH ( ONLINE = OFF )
DROP INDEX [IDX_FunctionalLocation_FullHierarchy] ON [dbo].[FunctionalLocation] WITH ( ONLINE = OFF )

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_ParentId] ON [dbo].[FunctionalLocation] 
(
	[ParentId] ASC,
	[Deleted] ASC,
	[OutOfService] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = OFF) ON [PRIMARY]
GO
