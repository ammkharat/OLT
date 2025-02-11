CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaire_DTO]
ON [dbo].[ShiftHandoverQuestionnaire]
([CreatedDateTime], [WorkAssignmentId])
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

CREATE NONCLUSTERED INDEX [IDX_SummaryLog_DTO]
ON [dbo].[SummaryLog]
([LoggedDate] , [Deleted])
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

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Log]') AND name = N'IDX_Log_Deleted_LogType_LoggedDate')
	BEGIN
		DROP INDEX [IDX_Log_Deleted_LogType_LoggedDate] ON [dbo].[Log];
	END
GO

CREATE NONCLUSTERED INDEX [IDX_Log_DTO] ON [dbo].[Log] 
(
	[LoggedDate] ASC,
	[Deleted] ASC,
	[LogType] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

GO
