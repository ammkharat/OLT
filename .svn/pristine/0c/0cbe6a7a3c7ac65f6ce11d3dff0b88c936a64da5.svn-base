-- Create new RoleElement "View Priorities - Montreal CSD"
--INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (252, 'View Priorities - Montreal CSD', 'Forms')
--GO

-- Update Oilsands Matrix to assign Admin roles to security element roles: "Configure Work Permit Contractor", "Configure Craft Or Trade"
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[ActiveDirectoryKey] = 'Administrator' and re.[Name] = 'Configure Work Permit Contractor';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[ActiveDirectoryKey] = 'Administrator' and re.[Name] = 'Configure Craft Or Trade';
GO





GO

