if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveWorkPermitTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveWorkPermitTemplate]
GO

    
CREATE Procedure [dbo].RemoveWorkPermitTemplate    
 (    
  @id bigint,    
  @LastModifiedUserId bigint,     
  @LastModifiedDateTime datetime    
 )    
AS    
    
UPDATE WorkPermitTemplate     
 SET LastModifiedByUserId = @LastModifiedUserId,     
  LastModifiedDateTime = @LastModifiedDateTime,    
  [Deleted] = 1    
 WHERE TemplateId=@Id    
 
 
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON RemoveWorkPermitTemplate TO PUBLIC
GO
  