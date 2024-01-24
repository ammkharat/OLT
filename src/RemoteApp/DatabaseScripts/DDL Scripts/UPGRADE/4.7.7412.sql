SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (156, 'Support Coordinator', 0, 'SupportCoordinator', 8, 0, 0, 0, 1, 'supco');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (157, 'Running Unit Support', 0, 'RunningUnitSupport', 8, 0, 0, 0, 1, 'runningu');

SET IDENTITY_INSERT [Role] OFF;

go


INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Create Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Delete Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Edit Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Log Definitions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Cancel Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Create Log Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Edit Log Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Permit';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Permit Requests';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Create Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Edit Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Delete Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Submit Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Import Permit Requests';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'Clone Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Delete Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Log Definitions';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Cancel Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Log Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Log Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Permit';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Permit Requests';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Create Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Edit Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Delete Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Submit Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Import Permit Requests';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Clone Permit Request';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'Manage Operational Modes';

go




GO

