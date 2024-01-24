CREATE NONCLUSTERED INDEX [IDX_SummaryLog_ReplyToLogId] ON [dbo].[SummaryLog] 
(
	[Deleted] ASC,
	[ReplyToLogId] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_SummaryLog_DTO] ON [dbo].[SummaryLog] 
(
	[CreatedDateTime] ASC,
	[Deleted] ASC,
	[Id] ASC,
	[CreationUserShiftPatternId] ASC 
)
INCLUDE ( [CreatedByUserId],
[WorkAssignmentId]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = ON, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY];
GO

-- Need to rename these to better match what they are for.
CREATE NONCLUSTERED INDEX [IDX_SummaryLog_Deleted_CreatedDateTime] ON [dbo].[SummaryLog] 
(
	[Deleted] ASC,
	[CreatedDateTime] ASC,
	[Id] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY];
GO

-- Need to rename these to better match what they are for.
CREATE NONCLUSTERED INDEX [IDX_SummaryLog_Id_CreatedDateTime] ON [dbo].[SummaryLog] 
(
	[Id] ASC,
	[CreatedDateTime] ASC,
	[Deleted] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IDX_SummaryLogCustomFieldEntry_SummaryLogId] ON [dbo].[SummaryLogCustomFieldEntry]
([SummaryLogId] , [Id]
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY];
GO



GO

