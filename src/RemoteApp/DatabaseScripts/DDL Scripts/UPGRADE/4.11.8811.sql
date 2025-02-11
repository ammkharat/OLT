﻿DROP INDEX [IDX_Log_Deleted_And_DefId] 
ON [dbo].[Log];
GO

DROP INDEX [IDX_Log_ReplyToLog] 
ON [dbo].[Log];
GO

DROP INDEX [IDX_Log_DTO] ON [dbo].[Log]
DROP INDEX [IDX_Log_DTO_WorkAssignment] ON [dbo].[Log]

ALTER TABLE [dbo].[Log] ALTER COLUMN LogDefinitionId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[Log] ALTER COLUMN RootLogId BIGINT SPARSE NULL;
ALTER TABLE [dbo].[Log] ALTER COLUMN ReplyToLogId BIGINT SPARSE NULL;

CREATE NONCLUSTERED INDEX [IDX_Log_DefinitionId]
ON [dbo].[Log]
([LogDefinitionId])
INCLUDE ([LogDateTime])
WHERE Deleted = 0
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_Log_ReplyToLog]
ON [dbo].[Log]
([ReplyToLogId])
WHERE Deleted = 0
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

CREATE NONCLUSTERED INDEX [IDX_Log_LogByWorkAssignmentPage]
ON [dbo].[Log]
([CreatedDateTime], WorkAssignmentId)
INCLUDE (UserId, LastModifiedUserId, CreationUserShiftPatternId, LogDefinitionId )
WHERE (DELETED = 0 AND LogType = 1)
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
DROP_EXISTING = OFF
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_Log_DirectiveByWorkAssignmentPage]
ON [dbo].[Log]
([CreatedDateTime], WorkAssignmentId)
INCLUDE (UserId, LastModifiedUserId, CreationUserShiftPatternId, LogDefinitionId )
WHERE (DELETED = 0 AND LogType = 3)
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
DROP_EXISTING = OFF
)
ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_Log_LogAndDirectivePage]
ON [dbo].[Log]
([CreatedDateTime], WorkAssignmentId, LogType)
INCLUDE (CreationUserShiftPatternId, UserId, LastModifiedUserId, LogDefinitionId)
WHERE (DELETED = 0)
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
DROP_EXISTING = OFF
)
ON [PRIMARY];
GO