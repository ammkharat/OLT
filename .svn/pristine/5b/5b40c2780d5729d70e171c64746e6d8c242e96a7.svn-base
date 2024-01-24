-- Replace indexes on CommentCategoryFunctionalLocation
CREATE CLUSTERED INDEX [IDX_CommentCategoryFunctionalLocation]
ON [dbo].[CommentCategoryFunctionalLocation]
([CommentCategoryId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO

-- Create clustered index on the Deviation Response History Table
CREATE CLUSTERED INDEX [IDX_DeviationAlertResponseHistory]
ON [dbo].[DeviationAlertResponseHistory]
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

-- replace existing non-clustered index on FunctionalLocationOperationalMode with a clustered one.
ALTER TABLE [dbo].[FunctionalLocationOperationalMode]
  DROP CONSTRAINT UQ_FunctionalLocationOperationalMode
  
ALTER TABLE [dbo].[FunctionalLocationOperationalMode]
ADD  CONSTRAINT [PK_FunctionalLocationOperationalMode]
PRIMARY KEY CLUSTERED ([UnitId] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
GO

CREATE CLUSTERED INDEX [IDX_LogCommentHistory_LogHistoryId]
ON [dbo].[LogCommentHistory]
([LogHistoryId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO

CREATE CLUSTERED INDEX [IDX_LogDefinitionCommentHistory_Id]
ON [dbo].[LogDefinitionCommentHistory]
([LogDefinitionHistoryId])
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


CREATE CLUSTERED INDEX [IDX_RoleElementTemplate_Role_Site]
ON [dbo].[RoleElementTemplate]
([RoleId] , [SiteId])
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

CREATE CLUSTERED INDEX [IDX_SapWorkOrderOperation]
ON [dbo].[SapWorkOrderOperation]
([WorkOrderNumber] , [OperationNumber])
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

CREATE CLUSTERED INDEX [IDX_ShiftFunctionalLocation_Floc]
ON [dbo].[ShiftFunctionalLocation]
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


CREATE CLUSTERED INDEX [IDX_ShiftHandoverAnswerHistory_Id]
ON [dbo].[ShiftHandoverAnswerHistory]
([ShiftHandoverQuestionnaireHistoryId])
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

CREATE CLUSTERED INDEX [IDX_SummaryLogCommentHistory_SummaryLogHistoryId]
ON [dbo].[SummaryLogCommentHistory]
([SummaryLogHistoryId])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = ON
)
ON [PRIMARY];
GO

CREATE CLUSTERED INDEX [IDX_SummaryLogCustomFieldEntryHistory]
ON [dbo].[SummaryLogCustomFieldEntryHistory]
([SummaryLogHistoryId])
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
