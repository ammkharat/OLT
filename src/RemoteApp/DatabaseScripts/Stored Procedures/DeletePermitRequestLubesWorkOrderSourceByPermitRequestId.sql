IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestLubesWorkOrderSourceByPermitRequestId')
	BEGIN
		DROP  Procedure  DeletePermitRequestLubesWorkOrderSourceByPermitRequestId
	END

GO

CREATE Procedure [dbo].[DeletePermitRequestLubesWorkOrderSourceByPermitRequestId]
(
    @PermitRequestId bigint
)
AS

DELETE FROM [PermitRequestLubesWorkOrderSource] where [PermitRequestLubesId] = @PermitRequestId

GO
 