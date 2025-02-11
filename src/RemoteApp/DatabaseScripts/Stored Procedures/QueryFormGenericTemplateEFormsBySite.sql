if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateEFormsBySite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateEFormsBySite]
GO  
    

Create Procedure [dbo].[QueryFormGenericTemplateEFormsBySite]              
 (              
  @SiteId BIGINT  ,      
  @PlantID BIGINT   
 )              
AS              
SELECT *              
FROM GenericTemplateEFormHeader              
WHERE SiteId = @SiteId    And  PlantID = @PlantID 


GRANT EXEC ON QueryFormGenericTemplateEFormsBySite TO PUBLIC
GO