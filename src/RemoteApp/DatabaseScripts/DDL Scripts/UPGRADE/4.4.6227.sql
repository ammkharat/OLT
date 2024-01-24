

--- make it so the roles in Montreal that can create directives can also delete them

insert into dbo.RoleElementTemplate (RoleElementId, RoleId)
select re2.Id, ret.RoleId
from RoleElementTemplate ret
inner join Role r on r.Id = RoleId
inner join RoleElement re on re.Id = RoleElementId
inner join RoleElement re2 on re2.Name = 'Delete Directives'
where r.SiteId = 9 and re.Name = 'Create Directives'





GO

