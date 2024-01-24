CREATE CLUSTERED INDEX [IDX_WorkPermitMontrealHistory]
ON [dbo].[WorkPermitMontrealHistory]
([Id])
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


CREATE CLUSTERED INDEX [IDX_WorkPermitEdmontonHistory]
ON [dbo].[WorkPermitEdmontonHistory]
([Id])
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


CREATE CLUSTERED INDEX [IDX_WorkPermitMontrealPermitAttributeAssociation]
ON [dbo].[WorkPermitMontrealPermitAttributeAssociation]
([WorkPermitMontrealId])
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

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestMontrealHistory]') AND name = N'PermitRequestMontrealHistory.IDX_PermitRequestMontrealHistory')
DROP INDEX [PermitRequestMontrealHistory.IDX_PermitRequestMontrealHistory] ON [dbo].[PermitRequestMontrealHistory] WITH ( ONLINE = OFF )


CREATE CLUSTERED INDEX [IDX_PermitRequestMontrealHistory_Id]
ON [dbo].[PermitRequestMontrealHistory]
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

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmontonHistory]') AND name = N'IDX_PermitRequestEdmontonHistory')
DROP INDEX [IDX_PermitRequestEdmontonHistory] ON [dbo].[PermitRequestEdmontonHistory] WITH ( ONLINE = OFF )

CREATE CLUSTERED INDEX [IDX_PermitRequestEdmontonHistory_Id]
ON [dbo].[PermitRequestEdmontonHistory]
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


GO

