
IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestTemplate]') AND name = 'LastModifiedByUserId'
)
begin
ALTER TABLE PermitRequestTemplate ADD LastModifiedByUserId bigint
end

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestTemplate]') AND name = 'LastModifiedDateTime'
)
begin
ALTER TABLE PermitRequestTemplate ADD LastModifiedDateTime datetime 
end


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
  


GO

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
  


GO

