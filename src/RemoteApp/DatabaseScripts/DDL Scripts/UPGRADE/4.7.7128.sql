﻿CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_Log]
ON [dbo].[LogCustomFieldEntry]
([LogId] , [Id])
INCLUDE ([CustomFieldName], [NumericFieldEntry])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING=ON
)
ON [PRIMARY];
GO



GO
