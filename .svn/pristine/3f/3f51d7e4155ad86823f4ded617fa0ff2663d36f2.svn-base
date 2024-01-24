insert into RoleElement (Id, Name, FunctionalArea) values (203, 'Configure Role Permissions', 'Technical Admin');

go

insert into RoleElementTemplate (RoleElementId, RoleId)
select 203, r.Id
from Role r
where r.Name = 'Technical Administrator'

GO

