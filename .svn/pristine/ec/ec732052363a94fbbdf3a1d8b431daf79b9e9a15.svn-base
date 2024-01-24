CREATE TABLE [dbo].[PermitRequestLubesWorkOrderSource](    
    [PermitRequestLubesId] [bigint] NOT NULL,
    [WorkOrderNumber] [varchar](25) NULL,  
    [OperationNumber] [varchar](4) NULL,  
    [SubOperationNumber] [varchar](4) NULL 
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[PermitRequestLubesWorkOrderSource]  
WITH CHECK ADD CONSTRAINT [FK_PermitRequestLubesWorkOrderSource_PermitRequestLubes] 
FOREIGN KEY([PermitRequestLubesId]) REFERENCES [dbo].[PermitRequestLubes] ([Id])  
GO  
  
insert into PermitRequestLubesWorkOrderSource (PermitRequestLubesId, WorkOrderNumber, OperationNumber, SubOperationNumber) 
select Id, WorkOrderNumber, OperationNumber, SubOperationNumber from PermitRequestLubes;
GO

-- alter table dbo.PermitRequestLubes drop column WorkOrderNumber;
alter table dbo.PermitRequestLubes drop column OperationNumber;
alter table dbo.PermitRequestLubes drop column SubOperationNumber;
GO

CREATE NONCLUSTERED INDEX [IDX_PermitRequestLubesSourceWorkOrder_Covering_SAP_Data] ON [dbo].[PermitRequestLubesWorkOrderSource]
(
	[WorkOrderNumber], [OperationNumber], [SubOperationNumber] 
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

alter table dbo.PermitRequestLubes add SAPWorkCentre varchar(40);
GO




GO

