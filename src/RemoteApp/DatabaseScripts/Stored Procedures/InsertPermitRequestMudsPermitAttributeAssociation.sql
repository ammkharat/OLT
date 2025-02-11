
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMudsPermitAttributeAssociation')
	BEGIN
		DROP Procedure [dbo].InsertPermitRequestMudsPermitAttributeAssociation
	END
GO

CREATE Procedure [dbo].[InsertPermitRequestMudsPermitAttributeAssociation]  
 (  
 @PermitRequestId bigint,  
 @PermitAttributeId bigint   
 )  
AS  
  
INSERT INTO PermitRequestMudsPermitAttributeAssociation  
(  
 PermitRequestId,   
 PermitAttributeId  
)  
VALUES  
(  
 @PermitRequestId,   
 @PermitAttributeId  
)
GO

GRANT EXEC ON InsertPermitRequestMudsPermitAttributeAssociation TO PUBLIC
GO

