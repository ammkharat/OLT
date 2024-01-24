SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite, Alias)
values (199, 'Upgrading Student', 0, 'UpgradingStudent', 3, 0, 0, 0, 1, 0, 'upgstud');

SET IDENTITY_INSERT [Role] OFF;

GO

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Log Definitions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Restriction Reporting';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Lab Alert Definitions and Lab Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Coker Card';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'Create Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'Delete Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'Edit Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Lab Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Restrictions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Navigation - Forms';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Priorities - Forms';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Upgrading Student' and re.[Name] = 'View Directives - Future';
GO


GO

