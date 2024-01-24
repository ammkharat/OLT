

insert into RoleElement (Id, Name, FunctionalArea) values (206, 'Edit Shift Handover E-mail Configurations', 'Admin - Shift Handovers');

go

insert into RoleElementTemplate (RoleElementId, RoleId)
select 206, r.Id
from Role r
inner join RoleElementTemplate ret on ret.RoleId = r.Id
where ret.RoleElementId = 120   --  120 == 'Edit Shift Handover Configurations'

go


GO

