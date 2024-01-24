DROP INDEX [IDX_FunctionalLocationAncestorId] ON [dbo].[FunctionalLocationAncestor]

CREATE UNIQUE NONCLUSTERED INDEX [IDX_FunctionalLocationAncestorId]
ON [dbo].[FunctionalLocationAncestor]
([Id] , [AncestorId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO


GO

