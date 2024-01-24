if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateCategory]
GO




 CREATE Procedure QueryWorkPermitTemplateCategory    
 (        
@SiteId bigint    
    
       
 )      
AS      
      
Select  Categories  from workpermittemplate    
where SiteId = @SiteId and Deleted = 0

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateCategory TO PUBLIC
GO
