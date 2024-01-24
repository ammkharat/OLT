CREATE NONCLUSTERED INDEX [IDX_Log_DTO_WorkAssignment] ON [dbo].[Log] 
(
	[LogType] ASC,
	[CreatedDateTime] ASC,
	[Deleted] ASC,
	[WorkAssignmentId] ASC,
	[Id] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_LogCustomFieldEntry_Log]
ON [dbo].[LogCustomFieldEntry]
([LogId] , [Id])
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = ON, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO




GO

CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireRead_UserId]
ON [dbo].[ShiftHandoverQuestionnaireRead]
([UserId] , [ShiftHandoverQuestionnaireId])
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

CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverAnswer_QuestionId]
ON [dbo].[ShiftHandoverAnswer]
([ShiftHandoverQuestionnaireId] , [ShiftHandoverQuestionId] , [Id])
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

