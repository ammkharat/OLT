if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateEmailApproverBySiteandFormTypeid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
Begin
	drop procedure [dbo].[QueryFormGenericTemplateEmailApproverBySiteandFormTypeid]
End
Go
       
Create Procedure [dbo].[QueryFormGenericTemplateEmailApproverBySiteandFormTypeid]              
 (              
  @SiteId BIGINT  ,          
  @FormTypeID BIGINT,
  @Approver varchar(50)           
 )              
AS              
SELECT *              
FROM FormGenericTemplateEmailApprover              
WHERE   
SiteId = @SiteId          
And FormTypeID = @FormTypeID    
And Name = @Approver  
    
    
GRANT EXEC ON QueryFormGenericTemplateEmailApproverBySiteandFormTypeid TO PUBLIC 