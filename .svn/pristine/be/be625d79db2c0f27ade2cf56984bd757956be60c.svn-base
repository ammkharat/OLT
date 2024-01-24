-- #1865 adding security to roles
insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select r.Id, re.Id, r.Id
from Role r, RoleElement re
where r.SiteId = 10 and r.Name in ('Supervisor', 'Area Team Lead', 'Engineering', 'Operations Coordinator') and
      re.Name in ('Edit Directives', 'Delete Directives', 'Cancel Standing Orders');
go


GO

