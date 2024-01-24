  
    
IF OBJECT_ID('QueryPermitRequestFortHillsSAPImportDataByBatchId', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsSAPImportDataByBatchId
GO 


CREATE Procedure [dbo].QueryPermitRequestFortHillsSAPImportDataByBatchId    
(     
 @BatchId bigint    
)    
AS    
    
select * from PermitRequestFortHillsSAPImportData pre    
where pre.BatchId = @BatchId    
    
    
GRANT EXEC ON QueryPermitRequestFortHillsSAPImportDataByBatchId TO PUBLIC  