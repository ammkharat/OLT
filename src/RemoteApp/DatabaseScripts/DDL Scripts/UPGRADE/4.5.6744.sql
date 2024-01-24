

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8
left outer join RoleElementTemplate ret on ret.RoleElementId = re.Id and ret.RoleId = r.Id
where 
re.Name in ('View Permit Requests', 'View Permit')
and ret.RoleElementId is null







GO

