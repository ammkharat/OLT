IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGenericTemplateApproverListBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGenericTemplateApproverListBySite
	END
GO
     
  
Create Procedure [dbo].[QueryFormGenericTemplateApproverListBySite]              
 (              
  @SiteId BIGINT  ,      
  @PlantID BIGINT ,    
  @FormTypeID BIGINT           
 )              
AS              
SELECT     
A.ID, A.FormTypeID as 'FormGenericTemplateID',    
A.Name as 'Approver',    
Null as 'ApprovedByUserId',    
Null as 'ApprovalDateTime',    
0 as 'DisplayOrder',    
1 as 'ShouldBeEnabledBehaviourId',    
CAST(1 AS BIT) as 'Enabled'    
FROM FormGenericTemplateApprover  A            
WHERE 
SiteId = @SiteId    
And  PlantID = @PlantID   
And FormTypeID = @FormTypeID    
And A.IsDeleted = 0
Order By A.Name  
  
  
GRANT EXEC ON QueryFormGenericTemplateApproverListBySite TO PUBLIC  


