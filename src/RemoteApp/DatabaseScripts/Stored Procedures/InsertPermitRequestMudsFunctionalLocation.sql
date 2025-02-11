
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPermitRequestMudsFunctionalLocation')
	BEGIN
		DROP Procedure [dbo].InsertPermitRequestMuds
	END
GO

CREATE Procedure [dbo].[InsertPermitRequestMudsFunctionalLocation]  
 (  
 @PermitRequestMudsId bigint,  
 @FunctionalLocationId bigint   
 )  
AS  
         
INSERT INTO  
 [PermitRequestMudsFunctionalLocation]  
 (  
 [PermitRequestMudsId],  
 [FunctionalLocationId]  
 )  
VALUES  
 (   
 @PermitRequestMudsId,  
 @FunctionalLocationId   
 )  
   
  
GRANT EXEC ON [InsertPermitRequestMudsFunctionalLocation] TO PUBLIC
GO
