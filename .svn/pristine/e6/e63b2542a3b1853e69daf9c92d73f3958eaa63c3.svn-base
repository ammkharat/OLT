IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFormGenericTemplateHeaderEmail')
	BEGIN
		DROP PROCEDURE [dbo].UpdateFormGenericTemplateHeaderEmail
	END
GO
  CREATE Procedure [dbo].[UpdateFormGenericTemplateHeaderEmail]            
 (            
          
  @FormTypeId BIGINT,      
  @PlantId BIGINT,      
  @SiteId BIGINT        
  ,@isNeverEnd BIT    
           
 )            
            
AS            
      
 UPDATE dbo.GenericTemplateEmailEFormHeader                             
 SET           
     isNeverEnd=@isNeverEnd             
 WHERE FormTypeId =@FormTypeId  AND PlantId=@PlantId AND SiteId=@SiteId     
     
 GRANT EXEC ON dbo.UpdateFormGenericTemplateHeaderEmail TO PUBLIC 