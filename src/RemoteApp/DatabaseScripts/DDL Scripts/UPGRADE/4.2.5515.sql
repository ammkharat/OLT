

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
left outer join Role r on r.SiteId = 3 and r.Name = 'Operating / Chief Engineer'
where re.Name in ('View Target Alerts', 'View Target Definition');





GO

