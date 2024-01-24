IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestEdmontonWorkOrderSourceByPermitRequestId')
	BEGIN
		DROP  Procedure  DeletePermitRequestEdmontonWorkOrderSourceByPermitRequestId
	END

GO

CREATE Procedure [dbo].[DeletePermitRequestEdmontonWorkOrderSourceByPermitRequestId]
(
    @PermitRequestId bigint
)
AS

DELETE FROM [PermitRequestEdmontonWorkOrderSource] where [PermitRequestEdmontonId] = @PermitRequestId

GO
 