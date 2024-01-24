-- #1548  
-- Ensure all Montreal supervisor work assignments are linked to handover configs  
  
-- ShiftHandoverConfiguration with name 'Rel�ve de Quart Quotidien' is the sole Montreal one
-- The only Montreal supervisor work assignment not linked to the shift config was 'Superviseur de Laboratoire'
  
insert into ShiftHandoverConfigurationWorkAssignment
select shc.id, wa.id
from ShiftHandoverConfiguration shc, WorkAssignment wa
where shc.Name = 'Relève de Quart Quotidien' and
	  wa.Name = 'Superviseur de Laboratoire';

go


GO

