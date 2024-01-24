  
  
IF OBJECT_ID('InsertPermitRequestFortHillsWorkOrderSource', 'P') IS NOT NULL
DROP PROC InsertPermitRequestFortHillsWorkOrderSource
GO 
   
CREATE Procedure [dbo].InsertPermitRequestFortHillsWorkOrderSource    
    (    
    @PermitRequestId bigint,    
    @OperationNumber varchar(25) = NULL,    
    @SubOperationNumber varchar(25) = NULL    
    )    
AS    
    
INSERT INTO PermitRequestFortHillsWorkOrderSource    
(    
 PermitRequestFortHillsId,    
 OperationNumber,    
 SubOperationNumber    
)    
VALUES    
(    
    @PermitRequestId,    
    @OperationNumber,    
    @SubOperationNumber    
)    
    
GRANT EXEC ON InsertPermitRequestFortHillsWorkOrderSource TO PUBLIC 