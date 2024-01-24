insert into RoleElement (Id, Name, FunctionalArea)
select 178, 'View Standing Orders', 'Logs - Directives';

go

insert into RoleElementTemplate
select 178, RoleId
from RoleElementTemplate
where RoleElementId = 96;

go

delete from RoleElementTemplate
where RoleElementId = 178
and RoleId in (select Id from Role where SiteId = 8 and Name = 'Operator');

go


delete from RoleElementTemplate
where RoleElementId = 1
and RoleId in (select Id from Role where SiteId = 8 and Name = 'Operator');

go

GO
