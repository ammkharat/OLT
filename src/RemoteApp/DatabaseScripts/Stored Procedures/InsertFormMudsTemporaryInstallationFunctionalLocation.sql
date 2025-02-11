if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormMudsTemporaryInstallationFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormMudsTemporaryInstallationFunctionalLocation]
GO


CREATE Procedure [dbo].[InsertFormMudsTemporaryInstallationFunctionalLocation]  
 (  
 @FormMudsTemporaryInstallationId bigint,  
 @FunctionalLocationId bigint   
 )  
AS  
  
INSERT INTO   
 [FormMudsTemporaryInstallationFunctionalLocation]  
 (  
 [FormMudsTemporaryInstallationId],  
 [FunctionalLocationId]  
 )  
VALUES  
 (   
 @FormMudsTemporaryInstallationId,  
 @FunctionalLocationId   
 )  
   
  

GRANT EXEC ON InsertFormMudsTemporaryInstallationFunctionalLocation TO PUBLIC
GO
