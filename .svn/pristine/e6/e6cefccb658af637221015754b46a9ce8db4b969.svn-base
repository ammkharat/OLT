
insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8   -- Edmonton
where re.Name in ('Clone work permit with no restriction')
and r.Name in ('Supervisor', 'Operator')

GO


GO

