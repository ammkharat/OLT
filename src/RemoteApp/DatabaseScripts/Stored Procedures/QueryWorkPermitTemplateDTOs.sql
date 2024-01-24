if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateDTOs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateDTOs]
GO

CREATE Procedure [dbo].[QueryWorkPermitTemplateDTOs]    
    (       
  @SiteId bigint,    
  @CreatedByUser varchar(100)    
    )    
AS    
    
SELECT    
   wpt.Id,      
    wpt.PermitNumber ,      
 wpt.TemplateName ,      
 wpt.Categories,      
 wpt.WorkPermitType,      
 wpt.Description ,
 wpt.Global    ,
 wpt.TemplateId 
  
FROM    
  WorkPermitTemplate wpt       
       
  Where  wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.CreatedByUser  = @CreatedByUser  and wpt.Deleted = 0  and Global != 1
   
   UNION ALL
    
	SELECT    
   wpt.Id,      
    wpt.PermitNumber ,      
 wpt.TemplateName ,      
 wpt.Categories,      
 wpt.WorkPermitType,      
 wpt.Description ,
 wpt.Global    , 
 wpt.TemplateId 
  
FROM    
  WorkPermitTemplate wpt       
       
  Where  wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.Global = 1  and wpt.Deleted = 0  

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateDTOs TO PUBLIC
GO
