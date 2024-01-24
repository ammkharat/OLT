CREATE NONCLUSTERED INDEX [IDX_PermitRequestPermitAttributeAssociation]
ON [dbo].[PermitRequestPermitAttributeAssociation]
([PermitRequestId])
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

CREATE NONCLUSTERED INDEX [IDX_WorkPermitMontrealPermitAttributeAssociation]
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
ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
GO


GO

