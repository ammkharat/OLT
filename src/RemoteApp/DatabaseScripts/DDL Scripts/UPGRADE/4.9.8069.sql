

alter table FormOilsandsTraining add CreatedByRoleId bigint;
go

declare @UpgradingOperatorRoleId bigint;
select @UpgradingOperatorRoleId = r.Id from Role r where r.Name = 'Operator' and SiteId = 3;
update FormOilsandsTraining set CreatedByRoleId = @UpgradingOperatorRoleId;  --- this table isn't in production yet so setting this value to the operator role is ok.
go

alter table FormOilsandsTraining alter column CreatedByRoleId bigint not null;
go



declare @EditFormRoleElementId bigint;
select @EditFormRoleElementId = re.Id from RoleElement re where re.Name = 'Edit Form';

--- Supervisors can edit forms created by Operators and Supervisors
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
(
   select editRole.Id, @EditFormRoleElementId, createdByRole.Id
   from Role as editRole, Role as createdByRole
   where 
         editRole.SiteId = 3 and
		 editRole.Name in ('Supervisor') and
		 createdByRole.SiteId = 3 and
         createdByRole.Name in ('Supervisor', 'Operator')
)




GO

