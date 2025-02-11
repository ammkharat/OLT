
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestMudsFunctionalLocationsByPermitRequestMudsId')
	BEGIN
		DROP Procedure [dbo].DeletePermitRequestMudsFunctionalLocationsByPermitRequestMudsId
	END
GO


CREATE Procedure [dbo].[DeletePermitRequestMudsFunctionalLocationsByPermitRequestMudsId]  
 (   
 @PermitRequestMudsId bigint  
 )  
AS  
DELETE FROM PermitRequestMudsFunctionalLocation WHERE PermitRequestMudsId = @PermitRequestMudsId  
  
RETURN
GO


GRANT EXEC ON DeletePermitRequestMudsFunctionalLocationsByPermitRequestMudsId TO PUBLIC
GO

