 
  
IF OBJECT_ID('QueryWorkPermitFortHillsForReuse', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsForReuse
GO 


CREATE Procedure [dbo].QueryWorkPermitFortHillsForReuse    
 (     
  @Id bigint    
 )    
AS    
    
SELECT     
  Top 1 previous.*, details.*    
from     
  WorkPermitFortHills previous    
INNER JOIN       
 WorkPermitFortHills [current] ON [current].PermitRequestId = previous.PermitRequestId and [current].Id != previous.Id    
INNER JOIN WorkPermitFortHillsDetails details ON details.WorkPermitFortHillsId = previous.Id    
WHERE    
  [current].PermitRequestId IS NOT NULL    
  and previous.Deleted = 0    
  and [current].Id = @Id    
  and (previous.IssuedDateTime IS NOT NULL OR previous.IssuedByUserId IS NOT NULL) -- these should both be not null, but there were some bugs in the past where it may not be the case.    
Order By    
  previous.PermitNumber DESC    
    
GRANT EXEC ON QueryWorkPermitFortHillsForReuse TO PUBLIC  