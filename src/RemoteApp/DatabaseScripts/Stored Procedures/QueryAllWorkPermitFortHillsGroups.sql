 
  
IF OBJECT_ID('QueryAllWorkPermitFortHillsGroups', 'P') IS NOT NULL
DROP PROC QueryAllWorkPermitFortHillsGroups
GO 


CREATE Procedure [dbo].QueryAllWorkPermitFortHillsGroups    
AS    
    
SELECT wpeg.*, priority.SAPImportPriority    
FROM WorkPermitFortHillsGroup wpeg    
left outer join SAPImportPriorityWorkPermitFortHillsGroup priority on priority.WorkPermitFortHillsGroupId = wpeg.Id    
where wpeg.Deleted = 0    
ORDER BY wpeg.DisplayOrder 

GRANT EXEC ON QueryAllWorkPermitFortHillsGroups TO PUBLIC   
