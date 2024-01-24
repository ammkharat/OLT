IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestLubesWorkOrderSourceByPermitRequestId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestLubesWorkOrderSourceByPermitRequestId
	END
GO

CREATE Procedure [dbo].QueryPermitRequestLubesWorkOrderSourceByPermitRequestId
(
	@PermitRequestId bigint
)
AS

SELECT * FROM PermitRequestLubesWorkOrderSource WHERE PermitRequestLubesId=@PermitRequestId
GO

GRANT EXEC ON QueryPermitRequestLubesWorkOrderSourceByPermitRequestId TO PUBLIC
GO