
insert into RoleElement (Id, Name, FunctionalArea) values (232, 'View Directives - Future', 'Directives');
go

declare @ViewDirectivesRoleElementId bigint;
select @ViewDirectivesRoleElementId = re.Id from RoleElement re where re.Name = 'View Directives';

--- make it so everyone with the 'view directives' role element also has the 'view future directives' role element
insert into RoleElementTemplate (RoleElementId, RoleId)
select 232, ret.RoleId
from RoleElementTemplate ret
where ret.RoleElementId = @ViewDirectivesRoleElementId







GO

