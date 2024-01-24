 
  
IF OBJECT_ID('QueryPermitRequestFortHillsWorkOrderSourceByPermitRequestId', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsWorkOrderSourceByPermitRequestId
GO 

    
CREATE Procedure [dbo].QueryPermitRequestFortHillsWorkOrderSourceByPermitRequestId    
(    
 @PermitRequestId bigint    
)    
AS    
    
SELECT * FROM PermitRequestFortHillsWorkOrderSource WHERE PermitRequestFortHillsId=@PermitRequestId    
  
GRANT EXEC ON QueryPermitRequestFortHillsWorkOrderSourceByPermitRequestId TO PUBLIC 