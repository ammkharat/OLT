IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields
(	
	@WorkOrderNumber varchar(25),
	@OperationNumber varchar(4),
	@SubOperationNumber varchar(4)	
)
AS

select * from PermitRequestEdmontonSAPImportData pre
where 
pre.WorkOrderNumber=@WorkOrderNumber
and pre.OperationNumber=@OperationNumber
and pre.SubOperationNumber=@SubOperationNumber


GO

GRANT EXEC ON QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields TO PUBLIC
GO