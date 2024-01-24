IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkOrderImportData')
	BEGIN
		DROP  Procedure  DeleteWorkOrderImportData
	END

GO

CREATE Procedure [dbo].[DeleteWorkOrderImportData]
(
    @BatchId bigint
)
AS

delete from WorkOrderImportData where BatchId = @BatchId

GO

GRANT EXEC ON DeleteWorkOrderImportData TO PUBLIC
GO