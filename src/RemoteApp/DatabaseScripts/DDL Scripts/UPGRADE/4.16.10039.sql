-- Update Montreal Matrix to assign all admin roles to security element roles: "Configure Form Templates"
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[ActiveDirectoryKey] = 'OperationsAdministrator' and re.[Name] = 'Configure Form Templates';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[ActiveDirectoryKey] = 'PermitAdministrator' and re.[Name] = 'Configure Form Templates';



GO

