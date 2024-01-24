update RoleElement
set name = 'View Summary Logs'
where id = 88 and name = 'View Shift Summary Logs';

update RoleElement
set name = 'Create Summary Logs'
where id = 89 and name = 'Create Shift Summary Logs';

update RoleElement
set name = 'Edit Summary Logs'
where id = 92 and name = 'Edit Shift Summary Logs';

update RoleElement
set name = 'Delete Summary Logs'
where id = 95 and name = 'Delete Shift Summary Logs';

go

INSERT INTO RolePermission
select distinct r1.id, t1.roleelementid, r2.id 
from Role r1, 
RoleElementTemplate t1,
Role r2,
RoleelementTemplate t2
where r1.siteid = r2.siteid
and r1.id = t1.roleid
and r2.id = t2.roleid
and t1.roleelementid in (92, 95)
and t2.roleelementid in (92, 95)
and r1.name not like 'TA%'
and r2.name not like 'TA%'
and r1.siteid != 6
;

go






GO
