 
 
 
IF OBJECT_ID('RemoveWorkPermitFortHills', 'P') IS NOT NULL
DROP PROC RemoveWorkPermitFortHills
GO  
   
CREATE Procedure [dbo].RemoveWorkPermitFortHills  
 (  
  @id bigint,  
  @LastModifiedByUserId bigint,   
  @LastModifiedDateTime datetime  
 )  
AS  
  
UPDATE WorkPermitFortHills  
SET LastModifiedByUserId = @LastModifiedByUserId,  
 LastModifiedDateTime = @LastModifiedDateTime,  
 Deleted = 1  
WHERE Id = @Id  

GRANT EXEC ON RemoveWorkPermitFortHills TO PUBLIC   
