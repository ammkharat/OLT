if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateNameandCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateNameandCategory]
GO



CREATE Procedure QueryPermitRequestTemplateNameandCategory
 (        
  @id bigint,      
  @TemplateName varchar(100),    
  @Categories varchar(100)        
       
 )      
AS      
   
Select wpt.TemplateName, wpt.Categories     
 from  PermitRequestTemplate wpt    
   
where     
wpt.Id = @id and TemplateName = @TemplateName and wpt.Categories = @Categories


OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateNameandCategory TO PUBLIC
GO