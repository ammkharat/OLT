  

IF OBJECT_ID('QueryWorkPermitFortHillsById', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsById
GO 

    
CREATE Procedure [dbo].QueryWorkPermitFortHillsById    
(    
 @Id bigint    
)    
AS    
    
select wpe.*, wped.* from WorkPermitFortHills wpe        
inner join WorkPermitFortHillsDetails wped on wpe.Id = wped.WorkPermitFortHillsId where wpe.Id = @Id 

 

GRANT EXEC ON QueryWorkPermitFortHillsById TO PUBLIC   