if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateNameandCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateNameandCategory]
GO




CREATE Procedure QueryWorkPermitTemplateNameandCategory    
 (        
  @id bigint,      
  @TemplateName varchar(100),    
  @Categories varchar(100)         
 )      
AS      
      
Select wpt.TemplateName, wpt.Categories     
 from  WorkPermitTemplate wpt    
    
where     
wpt.Id = @id and TemplateName = @TemplateName and wpt.Categories = @Categories

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateNameandCategory TO PUBLIC
GO
