      
  
IF OBJECT_ID('QueryDoesPermitRequestFortHillsAssociationExist', 'P') IS NOT NULL
DROP PROC QueryDoesPermitRequestFortHillsAssociationExist
GO 

CREATE Procedure [dbo].QueryDoesPermitRequestFortHillsAssociationExist        
 (        
  @WorkPermitStartDateTime datetime,   
  @WorkPermitEndDateTime datetime,           
  @PermitRequestIds VARCHAR(MAX)        
 )        
AS        
        
SELECT         
 COUNT(wp.Id) as COUNT        
FROM         
 [dbo].[WorkPermitFortHills] wp        
 INNER JOIN IDSplitter(@PermitRequestIds) ids ON ids.Id = wp.PermitRequestId        
WHERE         
 wp.RequestedStartDateTime BETWEEN @WorkPermitStartDateTime  and @WorkPermitEndDateTime        
       
       
       
 GRANT EXEC ON QueryDoesPermitRequestFortHillsAssociationExist TO PUBLIC   