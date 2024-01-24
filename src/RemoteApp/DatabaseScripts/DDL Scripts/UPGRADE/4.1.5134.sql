-- #1548
-- Ensure all Montreal operator work assignments are linked to handover configs

-- ShiftHandoverConfiguration 'Relève de Quart Quotidien' is the sole Montreal one

insert into ShiftHandoverConfigurationWorkAssignment
select shc.id, wa.id
from ShiftHandoverConfiguration shc, WorkAssignment wa
where shc.Name = 'Relève de Quart Quotidien' and
	  wa.Name in ('RP&S - Opérateur', 'Laboratoire - Octane', 'Laboratoire - Général', 'Laboratoire - Contrôle/Procédés', 'Laboratoire - Chromatographie', 'Laboratoire - Bitume', 'Laboratoire - Analytique');
	  
go


