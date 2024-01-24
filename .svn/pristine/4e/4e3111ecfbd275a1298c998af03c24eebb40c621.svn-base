

update PermitRequestEdmonton
set PermitRequestEdmonton.WorkOrderNumber = wos.WorkOrderNumber
from PermitRequestEdmonton
inner join PermitRequestEdmontonWorkOrderSource wos on wos.PermitRequestEdmontonId = PermitRequestEdmonton.Id
go

drop index IDX_PermitRequestEdmontonSourceWorkOrder_Covering_SAP_Data on PermitRequestEdmontonWorkOrderSource
go

CREATE NONCLUSTERED INDEX [IDX_PermitRequestEdmontonSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestEdmontonWorkOrderSource]
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


alter table PermitRequestEdmontonWorkOrderSource drop column WorkOrderNumber
go



GO

