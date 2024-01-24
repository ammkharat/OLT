IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealByWorkOrderNumberAndOperationAndSource')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestMontrealByWorkOrderNumberAndOperationAndSource
	END
GO

CREATE Procedure [dbo].QueryPermitRequestMontrealByWorkOrderNumberAndOperationAndSource
(
	@SourceId int,
	@OperationNumber varchar(4) = null,
	@SubOperationNumber varchar(4) = null,
	@WorkOrderNumber varchar(12) = null
)
AS

SELECT *
FROM PermitRequestMontreal
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

GRANT EXEC ON QueryPermitRequestMontrealByWorkOrderNumberAndOperationAndSource TO PUBLIC
GO