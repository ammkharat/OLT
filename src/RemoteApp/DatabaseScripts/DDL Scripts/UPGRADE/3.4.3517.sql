CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinition_WorkAssignmentId] ON [dbo].[ActionItemDefinition] 
(
	[WorkAssignmentId] ASC,
	[Deleted] ASC,
	[Active] ASC,
	[Id] ASC,
	[ScheduleId] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_UnitId] ON [dbo].[FunctionalLocation] 
(
	[UnitId] ASC,
	[Id] ASC
)
INCLUDE ( [FullHierarchy]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Deleted] ON [dbo].[FunctionalLocation] 
(
	[Deleted] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Site] ON [dbo].[FunctionalLocation] 
(
	[SiteId] ASC,
	[Id] ASC
)
INCLUDE ( [OutOfService],
[Deleted],
[ParentId]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IDX_LogComment] ON [dbo].[LogComment] 
(
	[LogId] ASC,
	[Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireHistory_Id] ON [dbo].[ShiftHandoverQuestionnaireHistory] 
(
	[Id] ASC,
	[ShiftHandoverQuestionnaireHistoryId] ASC,
	[LastModifiedDateTime] ASC
)
INCLUDE ( [FunctionalLocations],
[LastModifiedByUserId]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IDX_TargetDefinitionReadWriteTagConf] ON [dbo].[TargetDefinitionReadWriteTagConfiguration] 
(
	[Deleted] ASC,
	[TargetDefinitionId] ASC,
	[GapUnitValueTagId] ASC,
	[TargetTagId] ASC
)
INCLUDE ( [TargetDirectionId],
[GapUnitValueDirectionId]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IDX_WorkPermitGasTestElementInfo_WorkPermit] ON [dbo].[WorkPermitGasTestElementInfo] 
(
	[WorkPermitId] ASC,
	[Id] ASC,
	[GasTestElementInfoId] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = ON, ONLINE = ON) ON [PRIMARY]





GO
