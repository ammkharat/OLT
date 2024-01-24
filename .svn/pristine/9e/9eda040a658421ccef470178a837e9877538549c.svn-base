  
IF OBJECT_ID('QueryPermitRequestFortHillsHistoriesById', 'P') IS NOT NULL
DROP PROC QueryPermitRequestFortHillsHistoriesById
GO 

    
CREATE Procedure [dbo].QueryPermitRequestFortHillsHistoriesById    
 (    
 @Id bigint    
 )    
AS    
SELECT *     
FROM PermitRequestFortHillsHistory     
WHERE Id=@Id     
ORDER BY LastModifiedDateTime 


 

GRANT EXEC ON QueryPermitRequestFortHillsHistoriesById TO PUBLIC   