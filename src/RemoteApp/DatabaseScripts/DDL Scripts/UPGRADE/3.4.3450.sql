CREATE NONCLUSTERED INDEX [IDX_WorkPermit_SAPOperId] ON [dbo].[WorkPermit] 
(
	[SapOperationId] ASC,
	[Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]


CREATE CLUSTERED INDEX [IDX_SapWorkOrderOperation]
ON [dbo].[SapWorkOrderOperation]
([WorkOrderNumber] , [OperationNumber] , [OperationType])
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

GO
