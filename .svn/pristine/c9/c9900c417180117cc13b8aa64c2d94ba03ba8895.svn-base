IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGenericTemplateApproverBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGenericTemplateApproverBySite
	END
GO
     
Create Procedure [dbo].[QueryFormGenericTemplateApproverBySite]            
 (            
  @SiteId BIGINT  ,    
  @PlantID BIGINT ,  
  @FormTypeID BIGINT         
 )            
AS            
SELECT *            
FROM FormGenericTemplateApprover            
WHERE 
SiteId = @SiteId    
And  PlantID = @PlantID   
And FormTypeID = @FormTypeID  
And IsDeleted = 0  
  
  
GRANT EXEC ON QueryFormGenericTemplateApproverBySite TO PUBLIC  

