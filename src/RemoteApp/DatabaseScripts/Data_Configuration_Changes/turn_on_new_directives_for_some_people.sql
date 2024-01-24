

-- update SiteConfiguration set UseLogBasedDirectives = 0 where SiteId = 8;
go
/*
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) 
select re.Id, r.Id 
from RoleElement re, Role r 
where r.SiteId = 8 and r.[Name] in ('Supervisor', 'Operator', 'Administrator') 
and re.[Name] = 'View Navigation - Directives';
*/
go