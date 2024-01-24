if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateEmailEFormsBySite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateEmailEFormsBySite]
GO
Create  Procedure [dbo].[QueryFormGenericTemplateEmailEFormsBySite]                
 (                
  @SiteId BIGINT      
 )                
AS                
SELECT *                
FROM GenericTemplateEmailEFormHeader                
WHERE SiteId = @SiteId    
  
GRANT EXEC ON QueryFormGenericTemplateEmailEFormsBySite TO PUBLIC  