insert into RoleElement (id, name, functionalarea)
values (187, 'Create Log Definition', 'Logs');

insert into RoleElement (id, name, functionalarea)
values (188, 'Edit Log Definition', 'Logs');

insert into RoleElementTemplate
select 187, RoleId
from RoleElementTemplate
where RoleElementId = 32;

insert into RoleElementTemplate
select 188, RoleId
from RoleElementTemplate
where RoleElementId = 54;

update RoleElement
set Name = 'View Log Definitions'
where Id = 54 and Name = 'View/Edit Log Definitions';

go




GO
