insert into RoleElement values (177, 'Cancel Standing Orders', 'Logs - Directives')

go

update RoleElement 
set Name = 'Delete Directives'
where Id = 99
and Name = 'Delete Directives and Cancel Standing Orders';

go

insert into RoleElementTemplate 
(RoleElementId, RoleId)
select 177, RoleId
from RoleElementTemplate
where RoleElementId = 99;

go

insert into RolePermission
(RoleId, RoleElementId, CreatedByRoleId)
select RoleId, 177, CreatedByRoleId
from RolePermission
where RoleelementId = 99;

go

GO
