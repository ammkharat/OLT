CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_SapOperation] ON [dbo].[ActionItemDefinition] 
(
	[SapOperationId] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_Floc] ON [dbo].[ActionItemFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[ActionItemId] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_ParentId] ON [dbo].[FunctionalLocation] 
(
	[ParentId] ASC,
	[Deleted] ASC,
	[OutOfService] ASC,
	[Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] 
(
	[SiteId] ASC,
	[Level] ASC,
	[Deleted] ASC,
	[OutOfService] ASC,
	[Id] ASC,
	[ParentId] ASC,
	[FullHierarchy] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_First_Two_Levels] ON [dbo].[FunctionalLocation] 
(
	[Level] ASC,
	[SiteId] ASC,
	[Division] ASC,
	[Section] ASC,
	[Id] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]

DROP INDEX [IDX_FunctionalLocation_Id_SiteId_Level_Include_FullHierarchy] ON [dbo].[FunctionalLocation] WITH ( ONLINE = OFF )

CREATE NONCLUSTERED INDEX [IDX_Log_Deleted_And_DefId] ON [dbo].[Log] 
(
	[Deleted] ASC,
	[LogDefinitionId] ASC,
	[Id] ASC
)
INCLUDE ( [LoggedDate]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_Log_ReplyToLog] ON [dbo].[Log] 
(
	[ReplyToLogId] ASC,
	[Deleted] ASC
)
INCLUDE(
	[Id]
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_LogDefinition_Id_And_Schedule] ON [dbo].[LogDefinition] 
(
	[Id] ASC,
	[ScheduleId] ASC
)
INCLUDE ( [Deleted]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IDX_LogHistory] ON [dbo].[LogHistory] 
(
	[Id] ASC,
	[LogHistoryId] ASC,
	[LastModifiedDateTime] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverAnswer] ON [dbo].[ShiftHandoverAnswer] 
(
	[ShiftHandoverQuestionnaireId] ASC,
	[Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_TargetAlert_FLOC] ON [dbo].[TargetAlert] 
(
	[FunctionalLocationId] ASC,
	[TargetAlertStatusId] ASC,
	[ID] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_TargetAlert_DefId] ON [dbo].[TargetAlert] 
(
	[TargetDefinitionID] ASC,
	[TargetAlertStatusID] ASC,
	[ID] ASC
)
 WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

 CREATE NONCLUSTERED INDEX [IDX_UserLoginHistory_UserId_LoginDateTime] ON [dbo].[UserLoginHistory] 
(
	[UserId] ASC,
	[LoginDateTime] ASC
)
INCLUDE ( [Id]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_WorkAssignment_Including] ON [dbo].[WorkAssignment] 
(
	[Id] ASC
)
INCLUDE ( [Name]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]


GO
