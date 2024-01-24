drop index IDX_PermitRequestLubesSourceWorkOrder_Covering_SAP_Data on PermitRequestLubesWorkOrderSource;
GO

alter table PermitRequestLubesWorkOrderSource drop column WorkOrderNumber;
GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestLubesSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestLubesWorkOrderSource]
(
	[OperationNumber], [SubOperationNumber] 
)
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

