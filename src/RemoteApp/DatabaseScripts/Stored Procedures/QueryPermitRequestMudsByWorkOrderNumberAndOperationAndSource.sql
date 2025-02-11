
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsByWorkOrderNumberAndOperationAndSource')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsByWorkOrderNumberAndOperationAndSource
	END
GO

CREATE Procedure [dbo].[QueryPermitRequestMudsByWorkOrderNumberAndOperationAndSource]  
(  
 @SourceId int,  
 @OperationNumber varchar(4) = null,  
 @SubOperationNumber varchar(4) = null,  
 @WorkOrderNumber varchar(12) = null  
)  
AS  
  
SELECT *  
FROM PermitRequestMuds  
WHERE   
 Deleted = 0  
 and SourceId=@SourceId  
 and ((@OperationNumber is not null and @OperationNumber = OperationNumber) or   
 (@OperationNumber is null and OperationNumber is null))  
 and ((@SubOperationNumber is not null and @SubOperationNumber = SubOperationNumber) or   
 (@SubOperationNumber is null and SubOperationNumber is null))  
 and ((@WorkOrderNumber is not null and @WorkOrderNumber = WorkOrderNumber) or   
 (@WorkOrderNumber is null and WorkOrderNumber is null))
GO


GRANT EXEC ON QueryPermitRequestMudsByWorkOrderNumberAndOperationAndSource TO PUBLIC
GO

