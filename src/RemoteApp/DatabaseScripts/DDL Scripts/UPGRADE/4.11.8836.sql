﻿CREATE NONCLUSTERED INDEX [IDX_LogDefinition_Id_And_Schedule]
ON [dbo].[LogDefinition]
([Id] , [ScheduleId])
WHERE (DELETED = 0 and Active = 1)
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

