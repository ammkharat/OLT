IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestEdmontonSAPImportData')
	BEGIN
		DROP  Procedure  DeletePermitRequestEdmontonSAPImportData
	END

GO

CREATE Procedure [dbo].[DeletePermitRequestEdmontonSAPImportData]
(
    @BatchId bigint
)
AS

DELETE FROM [PermitRequestEdmontonSAPImportData]
where BatchId=@BatchId

GO

GRANT EXEC ON DeletePermitRequestEdmontonSAPImportData TO PUBLIC
GO