IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesByWorkOrderNumberAndOperationAndSource')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestLubesByWorkOrderNumberAndOperationAndSource
	END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesByWorkOrderNumberAndOperationAndSource
(
	@SourceId int,
	@OperationNumber varchar(4) = null,
	@SubOperationNumber varchar(4) = null,
	@WorkOrderNumber varchar(12) = null
)
AS

select * from PermitRequestLubes prl
inner join PermitRequestLubesWorkOrderSource prlswo on prlswo.PermitRequestLubesId = prl.Id
where 
prl.Deleted = 0
and prl.DataSourceId=@SourceId
and ((@OperationNumber is not null and @OperationNumber = prlswo.OperationNumber) or 
	(@OperationNumber is null and prlswo.OperationNumber is null))
and ((@SubOperationNumber is not null and @SubOperationNumber = prlswo.SubOperationNumber) or 
	(@SubOperationNumber is null and prlswo.SubOperationNumber is null))
and ((@WorkOrderNumber is not null and @WorkOrderNumber = prl.WorkOrderNumber) or 
(@WorkOrderNumber is null and prl.WorkOrderNumber is null))
GO
GO

GRANT EXEC ON QueryPermitRequestLubesByWorkOrderNumberAndOperationAndSource TO PUBLIC
GO