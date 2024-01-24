
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 10 and r.[Name] = 'Supervisor') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Comment WorkPermit'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 10 and r.[Name] = 'Operations Coordinator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Comment WorkPermit'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 10 and r.[Name] = 'Maintenance Coordinator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Comment WorkPermit'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 10 and r.[Name] = 'Trade Supervisor') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Comment WorkPermit'));

DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 10 and r.[Name] = 'Operator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('View Permit Requests'));



GO

