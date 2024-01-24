IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByWorkOrderNumberAndOperationAndSource')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByWorkOrderNumberAndOperationAndSource
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByWorkOrderNumberAndOperationAndSource
(
	@SourceId int,
	@OperationNumber varchar(4) = null,
	@SubOperationNumber varchar(4) = null,
	@WorkOrderNumber varchar(12) = null
)
AS

select * from PermitRequestEdmonton pre
inner join PermitRequestEdmontonWorkOrderSource preswo on preswo.PermitRequestEdmontonId = pre.Id
where 
pre.Deleted = 0
and pre.DataSourceId=@SourceId
and ((@OperationNumber is not null and @OperationNumber = preswo.OperationNumber) or 
	(@OperationNumber is null and preswo.OperationNumber is null))
and ((@SubOperationNumber is not null and @SubOperationNumber = preswo.SubOperationNumber) or 
	(@SubOperationNumber is null and preswo.SubOperationNumber is null))
and ((@WorkOrderNumber is not null and @WorkOrderNumber = pre.WorkOrderNumber) or 
(@WorkOrderNumber is null and pre.WorkOrderNumber is null))
GO

GRANT EXEC ON QueryPermitRequestEdmontonByWorkOrderNumberAndOperationAndSource TO PUBLIC
GO