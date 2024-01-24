if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormSarniaEipIssueApproverListBySite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormSarniaEipIssueApproverListBySite]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[QueryFormSarniaEipIssueApproverListBySite]              
 (              
  @SiteId BIGINT  ,      
  @PlantID BIGINT ,    
  @FormTypeID BIGINT           
 )              
AS              
SELECT     
A.ID, A.FormTypeID as 'FormSarniaEipIssueID',    
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
  
  
GRANT EXEC ON QueryFormSarniaEipIssueApproverListBySite TO PUBLIC  



