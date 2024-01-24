if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateEmailApproverBySite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)  
begin
 drop procedure [dbo].[QueryFormGenericTemplateEmailApproverBySite] 
 end
 go
Create Procedure [dbo].[QueryFormGenericTemplateEmailApproverBySite]                
 (                
  @SiteId BIGINT  ,            
  @FormTypeID BIGINT             
 )                
AS                
SELECT *                
FROM FormGenericTemplateEmailApprover                
WHERE     
SiteId = @SiteId            
And FormTypeID = @FormTypeID      
And IsDeleted = 0      
      
      
GRANT EXEC ON QueryFormGenericTemplateEmailApproverBySite TO PUBLIC    
  
------------------------------------------------------  
 