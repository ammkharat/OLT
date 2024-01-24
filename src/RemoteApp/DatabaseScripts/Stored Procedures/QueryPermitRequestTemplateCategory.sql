if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateCategory]
GO


 CREATE Procedure QueryPermitRequestTemplateCategory    
 (        
@SiteId bigint    
    
       
 )      
AS      
      
Select  Categories  from PermitRequestTemplate    
where SiteId = @SiteId and Deleted = 0


OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateCategory TO PUBLIC
GO