if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteFormMudsTemporaryInstallationFunctionalLocationsByFormMudsTemporaryInstallationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DeleteFormMudsTemporaryInstallationFunctionalLocationsByFormMudsTemporaryInstallationId]
GO

  
CREATE Procedure [dbo].[DeleteFormMudsTemporaryInstallationFunctionalLocationsByFormMudsTemporaryInstallationId]  
 (   
 @FormMudsTemporaryInstallationId bigint  
 )  
AS  
DELETE FROM FormMudsTemporaryInstallationFunctionalLocation WHERE FormMudsTemporaryInstallationId = @FormMudsTemporaryInstallationId  
  
RETURN  


GRANT EXEC ON DeleteFormMudsTemporaryInstallationFunctionalLocationsByFormMudsTemporaryInstallationId TO PUBLIC
GO  