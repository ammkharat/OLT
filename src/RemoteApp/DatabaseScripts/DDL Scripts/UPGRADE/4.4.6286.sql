
insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8   -- Edmonton
where re.Name in ('Print Permit')
and r.Name in ('Supervisor', 'Operator')



GO

