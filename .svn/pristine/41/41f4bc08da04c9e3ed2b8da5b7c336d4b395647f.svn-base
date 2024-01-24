IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkOrderImportDataByBatchId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkOrderImportDataByBatchId
	END
GO

CREATE Procedure [dbo].QueryWorkOrderImportDataByBatchId
(	
	@BatchId bigint
)
AS

select * from WorkOrderImportData where BatchId = @BatchId


GO

GRANT EXEC ON QueryWorkOrderImportDataByBatchId TO PUBLIC
GO

