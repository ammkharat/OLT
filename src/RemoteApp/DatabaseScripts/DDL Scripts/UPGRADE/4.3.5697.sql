﻿CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_Log]
ON [dbo].[LogCustomFieldEntry]
([LogId])
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


CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntryHistory_LogId]
ON [dbo].[LogCustomFieldEntryHistory]
([Id])
INCLUDE ([LogHistoryId])
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



CREATE NONCLUSTERED INDEX [IDX_WorkPermitOssa_DTO]
ON [dbo].[WorkPermitOssa]
([StartDateTime] , [EndDateTime] , [FunctionalLocationId] , [Deleted])
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


GO

