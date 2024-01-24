IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonWorkOrderSourceByPermitRequestId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonWorkOrderSourceByPermitRequestId
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonWorkOrderSourceByPermitRequestId
(
	@PermitRequestId bigint
)
AS

SELECT * FROM PermitRequestEdmontonWorkOrderSource WHERE PermitRequestEdmontonId=@PermitRequestId
GO

GRANT EXEC ON QueryPermitRequestEdmontonWorkOrderSourceByPermitRequestId TO PUBLIC
GO