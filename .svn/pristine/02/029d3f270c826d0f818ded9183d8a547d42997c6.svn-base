 ------------------------------------------------  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveFormGenericTemplateApprover]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveFormGenericTemplateApprover]
GO
      
Create Procedure [dbo].[RemoveFormGenericTemplateApprover]          
 (          
  @Id BIGINT          
 )          
AS          
----DELETE FROM FormGenericTemplateApprover WHERE Id = @Id       
  
Update  FormGenericTemplateApprover  
Set IsDeleted = 1  
Where     
Id = @Id     
     
    
GRANT EXEC ON RemoveFormGenericTemplateApprover TO PUBLIC    
