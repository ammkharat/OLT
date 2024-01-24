
-- 
update PermitRequestEdmonton set ConfinedSpaceClass = '1' where ConfinedSpaceClass = 'A' and Deleted = 0;
GO
update PermitRequestEdmonton set ConfinedSpaceClass = '2' where ConfinedSpaceClass = 'B' and Deleted = 0;
GO
update PermitRequestEdmonton set ConfinedSpaceClass = '3' where ConfinedSpaceClass = 'C' and Deleted = 0;
GO

UPDATE WorkPermitEdmontonDetails set ConfinedSpaceClass = '1'
from WorkPermitEdmontonDetails inner join WorkPermitEdmonton on WorkPermitEdmontonDetails.WorkPermitEdmontonId = WorkPermitEdmonton.Id
where
WorkPermitEdmontonDetails.ConfinedSpaceClass = 'A' and
WorkPermitEdmonton.Deleted = 0 and
(WorkPermitEdmonton.WorkPermitStatusId = 1 or WorkPermitEdmonton.WorkPermitStatusId = 2);
GO

UPDATE WorkPermitEdmontonDetails set ConfinedSpaceClass = '2'
from WorkPermitEdmontonDetails inner join WorkPermitEdmonton on WorkPermitEdmontonDetails.WorkPermitEdmontonId = WorkPermitEdmonton.Id
where
WorkPermitEdmontonDetails.ConfinedSpaceClass = 'B' and
WorkPermitEdmonton.Deleted = 0 and
(WorkPermitEdmonton.WorkPermitStatusId = 1 or WorkPermitEdmonton.WorkPermitStatusId = 2)
GO

UPDATE WorkPermitEdmontonDetails set ConfinedSpaceClass = '3'
from WorkPermitEdmontonDetails inner join WorkPermitEdmonton on WorkPermitEdmontonDetails.WorkPermitEdmontonId = WorkPermitEdmonton.Id
where
WorkPermitEdmontonDetails.ConfinedSpaceClass = 'C' and
WorkPermitEdmonton.Deleted = 0 and
(WorkPermitEdmonton.WorkPermitStatusId = 1 or WorkPermitEdmonton.WorkPermitStatusId = 2)


GO

