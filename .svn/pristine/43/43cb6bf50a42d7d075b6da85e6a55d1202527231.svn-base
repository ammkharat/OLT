IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryEmailListApproverBySite')
	BEGIN
		DROP Procedure [dbo].QueryEmailListApproverBySite
	END
	GO
Create Procedure [dbo].[QueryEmailListApproverBySite]              
 (              
  @SiteId BIGINT  ,          
  @FormTypeID BIGINT,
  @Name nvarchar(100)           
 )              
AS              
SELECT EmailList              
FROM FormGenericTemplateEmailApprover              
WHERE   
SiteId = @SiteId          
And FormTypeID = @FormTypeID  
And Name=@Name  
And IsDeleted = 0 

GRANT EXEC ON QueryEmailListApproverBySite TO PUBLIC 
GO
