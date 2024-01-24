
  
IF OBJECT_ID('QueryPermitRequestFortHillsLastImportDateTime', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsLastImportDateTime
GO 


   
CREATE Procedure [dbo].QueryPermitRequestFortHillsLastImportDateTime    
AS    
    
SELECT MAX(LastImportedDateTime) as LastImportedDateTime FROM PermitRequestFortHills    
  
   
 GRANT EXEC ON QueryPermitRequestFortHillsLastImportDateTime TO PUBLIC 
 
 