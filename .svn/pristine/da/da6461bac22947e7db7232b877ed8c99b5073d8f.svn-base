IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByWorkOrderNumberAndSAPWorkCentre')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByWorkOrderNumberAndSAPWorkCentre
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByWorkOrderNumberAndSAPWorkCentre
(
	@SourceId int,
	@WorkOrderNumber varchar(25),
	@SAPWorkCentre varchar(40)
)
AS

select * from PermitRequestEdmonton pre
where 
pre.Deleted = 0
and pre.DataSourceId=@SourceId
and pre.WorkOrderNumber=@WorkOrderNumber
and pre.SAPWorkCentre=@SAPWorkCentre

GO

GRANT EXEC ON QueryPermitRequestEdmontonByWorkOrderNumberAndSAPWorkCentre TO PUBLIC
GO