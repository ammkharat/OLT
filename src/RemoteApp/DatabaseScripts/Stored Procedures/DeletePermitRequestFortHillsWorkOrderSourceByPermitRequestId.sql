 
  
IF OBJECT_ID('DeletePermitRequestFortHillsWorkOrderSourceByPermitRequestId', 'P') IS NOT NULL
DROP PROC DeletePermitRequestFortHillsWorkOrderSourceByPermitRequestId
GO 


CREATE Procedure [dbo].DeletePermitRequestFortHillsWorkOrderSourceByPermitRequestId    
(    
    @PermitRequestId bigint    
)    
AS    
    
DELETE FROM [PermitRequestFortHillsWorkOrderSource] where [PermitRequestFortHillsId] = @PermitRequestId    
    
  
GRANT EXEC ON DeletePermitRequestFortHillsWorkOrderSourceByPermitRequestId TO PUBLIC 