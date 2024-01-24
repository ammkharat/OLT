IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormGenericTemplateApproverEmail')
	BEGIN
		DROP PROCEDURE [dbo].RemoveFormGenericTemplateApproverEmail
	END
GO
Create Procedure [dbo].[RemoveFormGenericTemplateApproverEmail]            
 (            
  @Id BIGINT            
 )            
AS            
Update  FormGenericTemplateEmailApprover    
Set IsDeleted = 1    
Where       
Id = @Id   
  
GRANT EXEC ON RemoveFormGenericTemplateApproverEmail TO PUBLIC 