CREATE NONCLUSTERED INDEX [IDX_Log_Deleted_LogType_LoggedDate] ON [dbo].[Log] 
(
	[Deleted] ASC,
	[LogType] ASC,
	[LoggedDate] ASC
)

go


CREATE NONCLUSTERED INDEX [IDX_LogComment_LogId_Id] ON [dbo].[LogComment] 
(
	[LogId] ASC,
	[Id] ASC
)

go



CREATE NONCLUSTERED INDEX [IDX_LogCommentHistory_LogHistoryId] ON [dbo].[LogCommentHistory] 
(
	[LogHistoryId] ASC
)

go


CREATE NONCLUSTERED INDEX [IDX_SummaryLogComment_SummaryLogId_Id] ON [dbo].[SummaryLogComment] 
(
	[SummaryLogId] ASC,
	[Id] ASC
)

go



CREATE NONCLUSTERED INDEX [IDX_SummaryLogCommentHistory_SummaryLogHistoryId] ON [dbo].[SummaryLogCommentHistory] 
(
	[SummaryLogHistoryId] ASC
)

go

GO
