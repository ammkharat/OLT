

-- change the category of the two new work assignments to 'Turnaround'

update WorkAssignment
set Category = 'Turnaround'
where SiteId = 8 and Name in ('Turnaround Tech', 'Turnaround Team Leader')

go


--- make the Role Permissions for 'Turnaround Tech' the same as 'Operator'   (Turnaround Tech role id: 134)

insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select 134, rp.RoleElementId, 134
from RolePermission rp
where rp.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Operator')
and rp.CreatedByRoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Operator')

insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select 134, rp.RoleElementId, rp.CreatedByRoleId
from RolePermission rp
where rp.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Operator')
and rp.CreatedByRoleId not in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Operator')



--- make the Role Permissions for 'Turnaround Team Leader' the same as 'Supervisor' (Turnaround Team Leader id: 135)

insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select 135, rp.RoleElementId, 135
from RolePermission rp
where rp.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Supervisor')
and rp.CreatedByRoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Supervisor')

insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select 135, rp.RoleElementId, rp.CreatedByRoleId
from RolePermission rp
where rp.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Supervisor')
and rp.CreatedByRoleId not in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Supervisor')














GO

