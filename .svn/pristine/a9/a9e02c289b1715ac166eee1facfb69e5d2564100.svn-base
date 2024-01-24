 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGenericTemplateHeader')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGenericTemplateHeader
	END
GO   
CREATE Procedure [dbo].[UpdateFormGenericTemplateHeader]        
 (        
      
  @FormTypeId BIGINT,  
  @PlantId BIGINT,  
  @SiteId BIGINT    
  ,@isNeverEnd BIT
       
 )        
        
AS        
  
 UPDATE dbo.GenericTemplateEFormHeader                         
 SET       
     isNeverEnd=@isNeverEnd         
 WHERE FormTypeId =@FormTypeId  AND PlantId=@PlantId AND SiteId=@SiteId 
 
 GRANT EXEC ON dbo.UpdateFormGenericTemplateHeader TO PUBLIC  