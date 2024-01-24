

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re, Role r
where r.SiteId = 8 and r.Name = 'Administrator'
and re.Name = 'Configure Configured Document Links'
go



GO

