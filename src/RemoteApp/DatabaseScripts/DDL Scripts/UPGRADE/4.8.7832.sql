

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (158, 'Maintenance Tech', 0, 'MaintenanceTech', 10, 0, 0, 0, 1, 'mainttech');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (159, 'Maintenance Supervisor', 0, 'MaintenanceSupervisor', 10, 0, 0, 0, 1, 'maintsup');

SET IDENTITY_INSERT [Role] OFF;


INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Create Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Edit Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Delete Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 10 and r.[Name] = 'Maintenance Tech' and re.[Name] = 'Edit Shift Handover Questionnaire';





GO




GO

