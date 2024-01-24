    
  
  
IF OBJECT_ID('QueryDocumentLinkByPermitRequestFortHillsId', 'P') IS NOT NULL
DROP PROC QueryDocumentLinkByPermitRequestFortHillsId
GO 

   
CREATE Procedure [dbo].QueryDocumentLinkByPermitRequestFortHillsId    
 (    
  @PermitRequestFortHillsId bigint    
 )    
    
AS    
SELECT      
 *    
FROM    
 [DocumentLink]     
WHERE    
 PermitRequestFortHillsId = @PermitRequestFortHillsId     
 and Deleted = 0    
 and PermitRequestFortHillsId IS NOT NULL -- this is here to force the use of a Filtered index on the table    
   
  GRANT EXEC ON QueryDocumentLinkByPermitRequestFortHillsId TO PUBLIC 