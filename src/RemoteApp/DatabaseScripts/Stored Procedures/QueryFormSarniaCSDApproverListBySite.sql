IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormSarniaCSDApproverListBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormSarniaCSDApproverListBySite
	END
GO
  CREATE Procedure [dbo].[QueryFormSarniaCSDApproverListBySite]                  
 (                  
  @SiteId BIGINT  ,          
  @PlantID BIGINT ,        
  @FormTypeID BIGINT               
 )                  
AS                  
SELECT         
A.ID, A.FormTypeID as 'FormSarniaCsdID',        
A.Name as 'Approver',        
Null as 'ApprovedByUserId',        
Null as 'ApprovalDateTime',        
0 as 'DisplayOrder',        
1 as 'ShouldBeEnabledBehaviourId',  
A.EmailList ,       
CAST(1 AS BIT) as 'Enabled'        
FROM FormGenericTemplateEmailApprover  A                
WHERE     
SiteId = @SiteId        
And  PlantID = @PlantID       
And FormTypeID = @FormTypeID        
And A.IsDeleted = 0    
Order By A.Name      
      
      
GRANT EXEC ON QueryFormSarniaCSDApproverListBySite TO PUBLIC   