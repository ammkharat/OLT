
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePermitRequestMudsPermitAttributeAssociation')
	BEGIN
		DROP Procedure [dbo].DeletePermitRequestMudsPermitAttributeAssociation
	END
GO


CREATE Procedure [dbo].[DeletePermitRequestMudsPermitAttributeAssociation]  
 (  
  @PermitRequestId bigint  
 )  
AS  
  
DELETE FROM PermitRequestMudsPermitAttributeAssociation   
WHERE PermitRequestId = @PermitRequestId
GO



GRANT EXEC ON DeletePermitRequestMudsPermitAttributeAssociation TO PUBLIC
GO

