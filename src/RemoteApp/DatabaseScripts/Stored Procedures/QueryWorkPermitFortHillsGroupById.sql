  
IF OBJECT_ID('QueryWorkPermitFortHillsGroupById', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsGroupById
GO 
  
CREATE Procedure [dbo].QueryWorkPermitFortHillsGroupById    
 (    
  @Id int    
 )    
AS    
    
SELECT wpeg.*, priority.SAPImportPriority    
FROM WorkPermitFortHillsGroup wpeg    
left outer join SAPImportPriorityWorkPermitFortHillsGroup priority on priority.WorkPermitFortHillsGroupId = wpeg.Id    
WHERE wpeg.Id = @Id 


GRANT EXEC ON QueryWorkPermitFortHillsGroupById TO PUBLIC   