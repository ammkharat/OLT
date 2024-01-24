CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefinitionComment_CommentId]
ON [dbo].[ActionItemDefinitionComment]
([CommentId] , [ActionItemDefinitionId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ActionItemDefinitionFunctionalLocation]') AND name = N'IDX_ActionItemDefinitionFunctionalLocation')
	BEGIN
		DROP INDEX [IDX_ActionItemDefinitionFunctionalLocation] ON [dbo].[ActionItemDefinitionFunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefinitionFunctionalLocation]
ON [dbo].[ActionItemDefinitionFunctionalLocation]
([FunctionalLocationId] , [ActionItemDefinitionId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_ActionItemDefTargetDef_TargetDefId]
ON [dbo].[ActionItemDefinitionTargetDefinition]
([TargetDefinitionId] , [ActionItemDefinitionId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 90,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FormGN59FunctionalLocation]') AND  name = N'IDX_FormGN59FunctionalLocation')
	BEGIN
		DROP INDEX [IDX_FormGN59FunctionalLocation] ON [dbo].[FormGN59FunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormGN59FunctionalLocation]
ON [dbo].[FormGN59FunctionalLocation]
([FunctionalLocationId] , [FormGN59Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FormGN7FunctionalLocation]') AND  name = N'IDX_FormGN7FunctionalLocation')
	BEGIN
		DROP INDEX [IDX_FormGN7FunctionalLocation] ON [dbo].[FormGN7FunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormGN7FunctionalLocation]
ON [dbo].[FormGN7FunctionalLocation]
([FunctionalLocationId] , [FormGN7Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FormOP14FunctionalLocation]') AND  name = N'IDX_FormOP14FunctionalLocation')
	BEGIN
		DROP INDEX [IDX_FormOP14FunctionalLocation] ON [dbo].[FormOP14FunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_FormOP14FunctionalLocation]
ON [dbo].[FormOP14FunctionalLocation]
([FunctionalLocationId] , [FormOP14Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogFunctionalLocation]') AND  name = N'IDX_LogFunctionalLocation')
	BEGIN
		DROP INDEX [IDX_LogFunctionalLocation] ON [dbo].[LogFunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogFunctionalLocation]
ON [dbo].[LogFunctionalLocation]
([FunctionalLocationId] , [LogId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogRead]') AND  name = N'IDX_LogRead_UserId')
	BEGIN
		DROP INDEX [IDX_LogRead_UserId] ON [dbo].[LogRead]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_LogRead_UserId]
ON [dbo].[LogRead]
([UserId] , [LogId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestionnaireFunctionalLocation]') AND  name = N'IDX_ShiftHandoverQuestionnaireFunctionalLocation')
	BEGIN
		DROP INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation] ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireFunctionalLocation]
ON [dbo].[ShiftHandoverQuestionnaireFunctionalLocation]
([FunctionalLocationId] , [ShiftHandoverQuestionnaireId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestionnaireRead]') AND  name = N'IDX_ShiftHandoverQuestionnaireRead_UserId')
	BEGIN
		DROP INDEX [IDX_ShiftHandoverQuestionnaireRead_UserId] ON [dbo].[ShiftHandoverQuestionnaireRead]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_ShiftHandoverQuestionnaireRead_UserId]
ON [dbo].[ShiftHandoverQuestionnaireRead]
([UserId] , [ShiftHandoverQuestionnaireId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SummaryLogFunctionalLocation]') AND  name = N'IDX_SummaryLogFunctionalLocation')
	BEGIN
		DROP INDEX [IDX_SummaryLogFunctionalLocation] ON [dbo].[SummaryLogFunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_SummaryLogFunctionalLocation]
ON [dbo].[SummaryLogFunctionalLocation]
([FunctionalLocationId] , [SummaryLogId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealFunctionalLocation]') AND  name = N'IDX_WorkPermitMontrealFunctionalLocation_Floc')
	BEGIN
		DROP INDEX [IDX_WorkPermitMontrealFunctionalLocation_Floc] ON [dbo].[WorkPermitMontrealFunctionalLocation]
	END
GO

CREATE UNIQUE NONCLUSTERED INDEX [IDX_WorkPermitMontrealFunctionalLocation_Floc]
ON [dbo].[WorkPermitMontrealFunctionalLocation]
([FunctionalLocationId] , [WorkPermitMontrealId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO


GO

