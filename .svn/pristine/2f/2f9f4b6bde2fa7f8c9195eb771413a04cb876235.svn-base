

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (146, 'Technical Administrator', 0, 'TechnicalAdmin', 1, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (147, 'Technical Administrator', 0, 'TechnicalAdmin', 2, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (148, 'Technical Administrator', 0, 'TechnicalAdmin', 3, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (149, 'Technical Administrator', 0, 'TechnicalAdmin', 5, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (150, 'Technical Administrator', 0, 'TechnicalAdmin', 6, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (151, 'Technical Administrator', 0, 'TechnicalAdmin', 7, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (152, 'Technical Administrator', 0, 'TechnicalAdmin', 8, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (153, 'Technical Administrator', 0, 'TechnicalAdmin', 9, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (154, 'Technical Administrator', 0, 'TechnicalAdmin', 10, 0, 0, 0, 0, 'techadmin');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (155, 'Technical Administrator', 0, 'TechnicalAdmin', 11, 0, 0, 0, 0, 'techadmin');

SET IDENTITY_INSERT [Role] OFF;

go

insert into RoleElement (Id, Name, FunctionalArea) values (202, 'Configure Role Matrix', 'Technical Admin');

go

insert into RoleElementTemplate (RoleElementId, RoleId)
select 202, r.Id
from Role r
where r.Name = 'Technical Administrator'

GO

