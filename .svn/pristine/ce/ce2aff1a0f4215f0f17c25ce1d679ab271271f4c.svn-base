

--- Operators can edit the logs of operators
insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select r.Id, 34, r.Id
from Role r
where r.SiteId = 10 and r.Name = 'Operator'

--- Lead techs can edit the logs of Operators
insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select r.Id, 34, r2.Id
from Role r, Role r2
where r.SiteId = 10 and r.Name = 'Lead Technician' and
      r2.SiteId = 10 and r2.Name = 'Operator'








GO

