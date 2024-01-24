
declare @EditPermitRequestRoleElementId bigint;
select @EditPermitRequestRoleElementId = re.Id from RoleElement re where re.Name = 'Edit Permit Request';

--- Supervisors, Maint. Coordinators, Ops Coordinators can edit requests created by anyone
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
(
   select editRole.Id, @EditPermitRequestRoleElementId, createdByRole.Id
   from Role as editRole, Role as createdByRole
   where 
         editRole.SiteId = 10 and
		 editRole.Name in ('Supervisor', 'Maintenance Coordinator', 'Operations Coordinator') and
		 createdByRole.SiteId = 10 and
         createdByRole.Name in ('Supervisor', 'Maintenance Coordinator', 'Operations Coordinator', 'Trade Supervisor')
)

--- Trade Supervisors can only edit requests created by other Trade Supervisors
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
(
   select editRole.Id, @EditPermitRequestRoleElementId, createdByRole.Id
   from Role as editRole, Role as createdByRole
   where 
         editRole.SiteId = 10 and
		 editRole.Name in ('Trade Supervisor') and
		 createdByRole.SiteId = 10 and
         createdByRole.Name in ('Trade Supervisor')
)




GO

