 
  
IF OBJECT_ID('QueryPermitRequestFortHillsById', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsById
GO  

   
CREATE Procedure [dbo].QueryPermitRequestFortHillsById
(    
 @Id bigint    
)    
AS  
BEGIN    
select * from PermitRequestFortHills where Id = @Id    
END  
  
GRANT EXEC ON QueryPermitRequestFortHillsById TO PUBLIC 