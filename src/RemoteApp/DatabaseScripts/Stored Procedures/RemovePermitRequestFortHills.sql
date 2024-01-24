
 
  
IF OBJECT_ID('RemovePermitRequestFortHills', 'P') IS NOT NULL
DROP PROC RemovePermitRequestFortHills
GO  
  
CREATE Procedure [dbo].RemovePermitRequestFortHills    
 (    
  @id bigint,    
  @LastModifiedByUserId bigint,     
  @LastModifiedDateTime datetime    
 )    
AS    
    
UPDATE  PermitRequestFortHills    
 SET LastModifiedByUserId = @LastModifiedByUserId,     
  LastModifiedDateTime = @LastModifiedDateTime,    
  Deleted = 1    
 WHERE Id=@Id    
   
 GRANT EXEC ON RemovePermitRequestFortHills TO PUBLIC 