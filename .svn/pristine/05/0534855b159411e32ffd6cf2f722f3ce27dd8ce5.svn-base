-- edmonton unit leader
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 69
and CreatedByRoleId = 99;

-- oilsands unit leader
insert into RolePermission 
select CreatedByRoleId, RoleElementId, RoleId
from RolePermission
where RoleId = 66
and CreatedByRoleId = 98;


delete
from RolePermission
where CreatedByRoleId in (select id from Role where SiteId = 3 and name like 'TA %')
or RoleId in (select id from Role where SiteId = 3 and name like 'TA %')
GO
