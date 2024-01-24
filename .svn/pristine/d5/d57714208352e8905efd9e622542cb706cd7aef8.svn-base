if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateDto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateDto]
GO

     
CREATE  Procedure [dbo].[QueryPermitRequestTemplateDto]        
    (        
       
@SiteId bigint,      
@CreatedByUser varchar(100)         
    )        
AS        
        
SELECT     
distinct       
 wpt.Id ,                 
 wpt.TemplateName ,          
 wpt.Categories,          
 wpt.WorkPermitType,          
 wpt.Description    ,
 wpt.Global   ,
 wpt.TemplateId 
      
FROM        
      
PermitRequestTemplate wpt       
   
WHERE       
wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.CreatedByUser  = @CreatedByUser and wpt.Deleted = 0   and Global != 1  

UNION ALL

SELECT     
distinct       
 wpt.Id ,                 
 wpt.TemplateName ,          
 wpt.Categories,          
 wpt.WorkPermitType,          
 wpt.Description  ,
 wpt.Global  ,
 wpt.TemplateId    
      
FROM        
      
PermitRequestTemplate wpt       
   
WHERE       
wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.Global = 1 and wpt.Deleted = 0  

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateDto TO PUBLIC
GO
