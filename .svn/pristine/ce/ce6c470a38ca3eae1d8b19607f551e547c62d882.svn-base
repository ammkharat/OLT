    
 
  
IF OBJECT_ID('QueryPermitRequestFortHillsByWorkOrderNumberAndOperationAndSource', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsByWorkOrderNumberAndOperationAndSource
GO 


CREATE Procedure [dbo].QueryPermitRequestFortHillsByWorkOrderNumberAndOperationAndSource    
(    
 @SourceId int,    
 @OperationNumber varchar(4) = null,    
 @SubOperationNumber varchar(4) = null,    
 @WorkOrderNumber varchar(12) = null    
)    
AS    
    
select * from PermitRequestFortHills pre    
inner join PermitRequestFortHillsWorkOrderSource preswo on preswo.PermitRequestFortHillsId = pre.Id    
where     
pre.Deleted = 0    
and pre.DataSourceId=@SourceId    
and ((@OperationNumber is not null and @OperationNumber = preswo.OperationNumber) or     
 (@OperationNumber is null and preswo.OperationNumber is null))    
and ((@SubOperationNumber is not null and @SubOperationNumber = preswo.SubOperationNumber) or     
 (@SubOperationNumber is null and preswo.SubOperationNumber is null))    
and ((@WorkOrderNumber is not null and @WorkOrderNumber = pre.WorkOrderNumber) or     
(@WorkOrderNumber is null and pre.WorkOrderNumber is null))    
  
 GRANT EXEC ON QueryPermitRequestFortHillsByWorkOrderNumberAndOperationAndSource TO PUBLIC 