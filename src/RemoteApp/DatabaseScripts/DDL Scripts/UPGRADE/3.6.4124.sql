DECLARE @role as bigint;

SET IDENTITY_INSERT dbo.[RoleGroup] ON;
insert into RoleGroup (id, Name) values (13, 'Maintenance Supervisor');
SET IDENTITY_INSERT dbo.[RoleGroup] OFF;

insert into [Role] 
(Name, RoleGroupId, Deleted, ActiveDirectoryKey, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, SiteId, WarnIfWorkAssignmentNotSelected)
values ('Maintenance Supervisor', 13, 0, 'MaintenanceSupervisor', 0, 0, 0, 3, 1);
set @role = @@IDENTITY

insert into RoleElement (Id, Name, FunctionalArea) values (173, 'Edit log created by a Maintenance Supervisor', 'Logs');
insert into RoleElement (Id, Name, FunctionalArea) values (174, 'Delete log created by a Maintenance Supervisor', 'Logs');
insert into RoleElement (Id, Name, FunctionalArea) values (175, 'Cancel log created by a Maintenance Supervisor', 'Logs');

insert into RoleElementTemplate (RoleElementId, RoleId) values (1, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (10, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (32, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (33, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (34, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (35, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (39, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (47, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (48, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (51, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (54, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (88, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (96, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (100, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (114, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (115, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (116, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (117, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (130, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (149, @role);

insert into RoleElementTemplate (RoleElementId, RoleId) values (173, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (174, @role);
insert into RoleElementTemplate (RoleElementId, RoleId) values (175, @role);

GO



GO
