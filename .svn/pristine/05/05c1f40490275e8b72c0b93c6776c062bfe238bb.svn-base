IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGenericTemplateEmailByApprover')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGenericTemplateEmailByApprover
	END
GO
CREATE Procedure [dbo].[UpdateFormGenericTemplateEmailByApprover]            
 (            
          
  @FormTypeID BIGINT,      
  @SiteID BIGINT  ,  
  @PlantID BIGINT,      
  @Name varchar(100),  
  @EmailList varchar(500)    
           
 )   
 As  
Update   FormGenericTemplateEmailApprover    
    set EmailList=@EmailList  
Where FormTypeID=@FormTypeID AND SiteID=@SiteID AND PlantID= @PlantID AND Name=@Name AND IsDeleted=0     
  
    
 GRANT EXEC ON dbo.UpdateFormGenericTemplateEmailByApprover TO PUBLIC 