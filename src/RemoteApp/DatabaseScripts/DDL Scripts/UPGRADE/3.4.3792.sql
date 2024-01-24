IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionFunctionalLocation]') AND name = N'IDX_ActionItemDefinitionFunctionalLocation')
	BEGIN
	DROP INDEX [IDX_ActionItemDefinitionFunctionalLocation] ON [dbo].[ActionItemDefinitionFunctionalLocation] WITH ( ONLINE = OFF )
	END
GO

CREATE NONCLUSTERED INDEX [IDX_ActionItemDefinitionFunctionalLocation] ON [dbo].[ActionItemDefinitionFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[ActionItemDefinitionId] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogFunctionalLocation]') AND name = N'IDX_LogFunctionalLocation_FlocId')
	BEGIN
	DROP INDEX [IDX_LogFunctionalLocation_FlocId] ON [dbo].[LogFunctionalLocation] WITH ( ONLINE = OFF )
	END
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogFunctionalLocation]') AND name = N'IDX_LogFunctionalLocation')
	BEGIN
	DROP INDEX [IDX_LogFunctionalLocation] ON [dbo].[LogFunctionalLocation] WITH ( ONLINE = OFF )
	END
GO

CREATE NONCLUSTERED INDEX [IDX_LogFunctionalLocation] ON [dbo].[LogFunctionalLocation] 
(
	[FunctionalLocationId] ASC,
	[LogId] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = ON) ON [PRIMARY]

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocationAncestor]') AND name = N'IDX_FunctionalLocationAncestorId')
	BEGIN
	DROP INDEX [IDX_FunctionalLocationAncestorId] ON [dbo].[FunctionalLocationAncestor] WITH ( ONLINE = OFF )
	END
GO
	
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocationAncestorId]
ON [dbo].[FunctionalLocationAncestor]
([Id])
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

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestionnaireFunctionalLocation]') AND name = N'IDX_ShiftHandoverQuestionnaireFunctionalLocation')
	BEGIN
	DROP INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation] ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation] WITH ( ONLINE = OFF )
	END
GO

CREATE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation]
ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
([FunctionalLocationId])
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

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SummaryLogFunctionalLocation]') AND name = N'IDX_SummaryLogFunctionalLocation')
	BEGIN
	DROP INDEX [IDX_SummaryLogFunctionalLocation] ON [dbo].[SummaryLogFunctionalLocation] WITH ( ONLINE = OFF )
	END
GO

CREATE NONCLUSTERED INDEX [IDX_SummaryLogFunctionalLocation]
ON [dbo].[SummaryLogFunctionalLocation]
([FunctionalLocationId])
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