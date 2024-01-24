  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestMontrealFunctionalLocationsByPermitRequestMontrealId')
	BEGIN
		DROP  Procedure  DeletePermitRequestMontrealFunctionalLocationsByPermitRequestMontrealId
	END

GO

CREATE Procedure dbo.DeletePermitRequestMontrealFunctionalLocationsByPermitRequestMontrealId
	(	
	@PermitRequestMontrealId bigint
	)
AS
DELETE FROM PermitRequestMontrealFunctionalLocation WHERE PermitRequestMontrealId = @PermitRequestMontrealId

RETURN

GO   
