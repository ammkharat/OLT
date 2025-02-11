if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDocumentLinkByFormMudsTemporaryInstallationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDocumentLinkByFormMudsTemporaryInstallationId]
GO
  
CREATE Procedure [dbo].[QueryDocumentLinkByFormMudsTemporaryInstallationId](@FormMudsTemporaryInstallationId bigint)  
AS  
SELECT * FROM DocumentLink WHERE FormMudsTemporaryInstallationId = @FormMudsTemporaryInstallationId and Deleted = 0   
and FormMudsTemporaryInstallationId IS NOT NULL -- this is here to force the use of a Filtered index on the table  


GRANT EXEC ON QueryDocumentLinkByFormMudsTemporaryInstallationId TO PUBLIC
GO



