
-- montreal target stuff

update SiteConfiguration set DefaultTargetDefinitionRequiresResponseWhenAlertedValue = 1 where SiteId = 9;
update SiteConfigurationDefaults set CopyTargetAlertResponseToLog = 1 where SiteId = 9;
update WorkAssignment set CopyTargetAlertResponseToLog = 1 where SiteId = 9;
go

SET IDENTITY_INSERT [Role] ON

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (184, 'Ingénieur de Procedé/Fiabilité', 0, 'ProcessEngineer', 9, 0, 0, 0, 1, 'ingdeproc');

SET IDENTITY_INSERT [Role] OFF;






INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Administrateur des Opérations' and re.[Name] = 'View Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Administrateur des Opérations' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Administrateur des Opérations' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Administrateur des Opérations' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Administrateur des Opérations' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur de l''Entretien' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur des Opérations' and re.[Name] = 'View Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur des Opérations' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur des Opérations' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur des Opérations' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Coordonnateur des Opérations' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'View Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur' and re.[Name] = 'Respond to Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'View Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Approve Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Reject Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Create Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Edit Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Delete Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Toggle Approval Required for Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Respond to Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Ingénieur de Procedé/Fiabilité' and re.[Name] = 'Configure Pre-Approved Target Ranges';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Leader de  Secteur' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Lecture Seule' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Opérateur' and re.[Name] = 'View Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Opérateur' and re.[Name] = 'View Navigation - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Opérateur' and re.[Name] = 'View Priorities - Targets';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Opérateur' and re.[Name] = 'Respond to Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Superviseur' and re.[Name] = 'Comment on Target Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Superviseur' and re.[Name] = 'Respond to Target Alerts';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 9 and r.[Name] = 'Superviseur de l''Entretien' and re.[Name] = 'Comment on Target Definition';
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Superviseur') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Approve Target Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Superviseur') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Create Target Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Superviseur') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Edit Target Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Superviseur') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Delete Target Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Administrateur des Permis') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('View Target Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 9 and r.[Name] = 'Entrepreneur de l''Entretien') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('View Target Definition'));



GO

