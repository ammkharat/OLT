if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFunctionalLocationsByFormMudsTemporaryInstallationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFunctionalLocationsByFormMudsTemporaryInstallationId]
GO

  
CREATE Procedure [dbo].[QueryFunctionalLocationsByFormMudsTemporaryInstallationId]  
(  
    @FormMudsTemporaryInstallationId bigint  
)  
AS  
  
SELECT fl.*   
FROM   
 FormMudsTemporaryInstallationFunctionalLocation ffl  
 INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id  
WHERE FormMudsTemporaryInstallationId = @FormMudsTemporaryInstallationId  


GRANT EXEC ON QueryFunctionalLocationsByFormMudsTemporaryInstallationId TO PUBLIC
GO
