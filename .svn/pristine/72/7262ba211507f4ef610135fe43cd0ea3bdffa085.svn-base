DROP INDEX [_dta_index_TargetAlert_DTO] 
ON [dbo].[TargetAlert];
GO

DROP INDEX [IDX_TargetAlert_Priority_DTO] 
ON [dbo].[TargetAlert];
GO

CREATE NONCLUSTERED INDEX [IDX_TargetAlert_DTO]
ON [dbo].[TargetAlert]
([CreatedDateTime], TargetAlertStatusId)
INCLUDE ([TagId], [TargetDefinitionID], [FunctionalLocationID])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO


GO

