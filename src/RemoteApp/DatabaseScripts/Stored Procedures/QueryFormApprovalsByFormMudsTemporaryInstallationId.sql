if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormApprovalsByFormMudsTemporaryInstallationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormApprovalsByFormMudsTemporaryInstallationId]
GO
  
CREATE Procedure [dbo].[QueryFormApprovalsByFormMudsTemporaryInstallationId]  
(  
    @FormMudsTemporaryInstallationId bigint  
)  
AS  
  
SELECT approval.*   
FROM   
 FormMudsTemporaryInstallationApproval approval  
WHERE FormMudsTemporaryInstallationId = @FormMudsTemporaryInstallationId  
ORDER BY approval.DisplayOrder ASC  


GRANT EXEC ON QueryFormApprovalsByFormMudsTemporaryInstallationId TO PUBLIC
GO