﻿CREATE NONCLUSTERED INDEX [IDX_SummaryLogCustomFieldEntry_CustomFieldId]
ON [dbo].[SummaryLogCustomFieldEntry]
([SummaryLogId], [CustomFieldId])
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


CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_CustomFieldId]
ON [dbo].[LogCustomFieldEntry]
([LogId], [CustomFieldId])
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

DROP INDEX [IDX_SummaryLogCustomFieldEntry_SummaryLogId] ON [dbo].[SummaryLogCustomFieldEntry]

CREATE UNIQUE NONCLUSTERED INDEX [IDX_SummaryLogCustomFieldEntry_SummaryLogId]
ON [dbo].[SummaryLogCustomFieldEntry]
([SummaryLogId] , [Id])
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

DROP INDEX [IDX_LogCustomFieldEntry_Log] ON [dbo].[LogCustomFieldEntry]

CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_Log]
ON [dbo].[LogCustomFieldEntry]
([LogId] , [Id])
INCLUDE ([CustomFieldName], [NumericFieldEntry])
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