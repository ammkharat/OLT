
insert into RoleElement (Id, Name, FunctionalArea) values (205, 'Configure Site', 'Technical Admin');

go

insert into RoleElementTemplate (RoleElementId, RoleId)
select 205, r.Id
from Role r
where r.Name = 'Technical Administrator'

go


GO

