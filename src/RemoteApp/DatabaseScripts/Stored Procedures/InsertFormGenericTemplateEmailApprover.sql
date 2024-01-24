IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGenericTemplateEmailApprover')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormGenericTemplateEmailApprover
	END
GO
Create Procedure [dbo].[InsertFormGenericTemplateEmailApprover]              
 (              
  @Id BIGINT OUTPUT,            
  @FormTypeId BIGINT  ,          
  @Name NVARCHAR(100),              
  @SiteId BIGINT  ,        
  @PlantId BIGINT ,  
  @EmailList NVARCHAR(500)             
 )              
AS              
 INSERT INTO FormGenericTemplateEmailApprover              
 (              
     FormTypeID,         
     Name,        
     SiteID,             
     PlantID ,  
     EmailList             
 )              
 VALUES              
 (              
  @FormTypeId,              
  @Name,          
  @SiteId,        
  @PlantId ,  
  @EmailList             
 )              
SET @Id = SCOPE_IDENTITY()       
      
      
GRANT EXEC ON InsertFormGenericTemplateEmailApprover TO PUBLIC