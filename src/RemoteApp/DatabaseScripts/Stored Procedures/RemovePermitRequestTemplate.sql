if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemovePermitRequestTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemovePermitRequestTemplate]
GO

    
CREATE Procedure [dbo].RemovePermitRequestTemplate    
 (    
  @id bigint,    
  @LastModifiedUserId bigint,     
  @LastModifiedDateTime datetime    
 )    
AS    
    
UPDATE PermitRequestTemplate     
 SET LastModifiedByUserId = @LastModifiedUserId,     
  LastModifiedDateTime = @LastModifiedDateTime,    
  [Deleted] = 1    
 WHERE TemplateId=@Id   
 
 
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON RemovePermitRequestTemplate TO PUBLIC
GO
  