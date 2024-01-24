SET IDENTITY_INSERT [Role] ON

if not exists (select * from Role where role.Id = 219)
begin
insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias,IsDefaultReadOnlyRoleForSite)
values (219, 'OEMS Admin', 0, 'OEMSAdmin', 3, 0, 0, 0, 1, 'oemsadmin',0);
end

if not exists (select * from Role where role.Id = 220)
begin
insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias,IsDefaultReadOnlyRoleForSite)
values (220, 'SWP Audit Entry Clerk', 0, 'SWPAuditEntryClerk', 3, 0, 0, 0, 1, 'swpclerk',0);
end 

SET IDENTITY_INSERT [Role] OFF;

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Action Item Definition';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Action Item';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Action Items';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Priorities - Action Items';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Priorities - Action Items';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Coker Card';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Coker Card';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Form';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Forms';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Forms';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Priorities - Forms';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Priorities - Forms';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Lab Alert Definitions and Lab Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Lab Alert Definitions and Lab Alerts';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Lab Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Lab Alerts';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Log';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Logs';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Priorities - Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Priorities - Directives';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Directives';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Standing Orders';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View SAP Notifications';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View SAP Notifications';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Summary Logs';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Restriction Reporting';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Restriction Reporting';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Restrictions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Restrictions';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Shift Handover';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Shift Handovers';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Priorities - Shift Handovers';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Priorities - Shift Handovers';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Target Definition';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Target Alerts';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Navigation - Targets';

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'OEMS Admin' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'SWP Audit Entry Clerk' and re.[Name] = 'View Priorities - Targets';

Go


GO

