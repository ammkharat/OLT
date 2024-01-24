IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonSAPImportDataByBatchId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonSAPImportDataByBatchId
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonSAPImportDataByBatchId
(	
	@BatchId bigint
)
AS

select * from PermitRequestEdmontonSAPImportData pre
where pre.BatchId = @BatchId


GO

GRANT EXEC ON QueryPermitRequestEdmontonSAPImportDataByBatchId TO PUBLIC
GO