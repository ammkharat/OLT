ALTER TABLE Role ALTER COLUMN [Alias] VARCHAR (20) NOT NULL

DECLARE @OutputTbl TABLE (Alias varchar(20), Id INT);

DECLARE @MiningOpsDispatchersRoleId int;
DECLARE @MiningFieldServicesRoleId int;
DECLARE @MiningOpsSupervisorRoleId int;
DECLARE @MiningManagerRoleId int;
DECLARE @MiningTechnicalGroupRoleId int; 

-- Create new Role "Mining Ops Dispatchers" (Alias: mnopsdisp, ActiveDirectoryKey: OLT-OilSands-1100-MiningOpsDispatchers)
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id INTO @OutputTbl
VALUES ('Mining Ops Dispatchers', 'mnopsdisp', 'MiningOpsDispatchers', 3, 0, 0, 0, 0, 1, 0)

-- Create new Role "Mining Field Services" (Alias: mnfieldservices, ActiveDirectoryKey: OLT-OilSands-1100-MiningFieldServices)
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id INTO @OutputTbl
VALUES ('Mining Field Services', 'mnfieldservices', 'MiningFieldServices', 3, 0, 0, 0, 0, 1, 0)

-- Create new Role "Mining Ops Supervisor" (Alias: mnopssuper, ActiveDirectoryKey: OLT-OilSands-1100-MiningOpsSupervisor)
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id INTO @OutputTbl
VALUES ('Mining Ops Supervisor', 'mnopssuper', 'MiningOpsSupervisor', 3, 0, 0, 0, 0, 1, 0)

-- Create new Role "Mining Manager" (Alias: mnmgr, ActiveDirectoryKey: OLT-OilSands-1100-MiningManager)
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id INTO @OutputTbl
VALUES ('Mining Manager', 'mnmgr', 'MiningManager', 3, 0, 0, 0, 0, 1, 0)

-- Create new Role "Mining Technical Group" (Alias: mntechgrp, ActiveDirectoryKey: OLT-OilSands-1100-MiningTechnicalGroup)
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id INTO @OutputTbl
VALUES ('Mining Technical Group', 'mntechgrp', 'MiningTechnicalGroup', 3, 0, 0, 0, 0, 1, 0)

SELECT @MiningOpsDispatchersRoleId = Id FROM @OutputTbl WHERE Alias = 'mnopsdisp'
SELECT @MiningFieldServicesRoleId = Id FROM @OutputTbl WHERE Alias = 'mnfieldservices'
SELECT @MiningOpsSupervisorRoleId = Id FROM @OutputTbl WHERE Alias = 'mnopssuper'
SELECT @MiningManagerRoleId = Id FROM @OutputTbl WHERE Alias = 'mnmgr'
SELECT @MiningTechnicalGroupRoleId = Id FROM @OutputTbl WHERE Alias = 'mntechgrp'

-- Add "Action Items - View Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  1, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - View Action Item" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  39, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - View Navigation - Action Items" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  210, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - View Priorities - Action Items" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  218, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Approve Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  2, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Reject Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  3, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Create Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  4, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Edit Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  6, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Delete Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  8, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Comment Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  10, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Toggle Approval Required for Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  11, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Action Items - Respond to Action Item" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  40, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)


-- Add "Directives - View Navigation - Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  231, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - View Directives - Future" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  232, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - View Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  268, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - View Priorities - Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  267, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - Create Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  269, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - Edit Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  270, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Directives - Delete Directives" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  271, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)


-- Add "Logs - View Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  33, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Logs - View Navigation - Logs" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  212, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Logs - Create Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  32, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Logs - Edit Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  34, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Logs - Delete Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  35, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Logs - Reply To Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  51, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Logs - Copy Log" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  235, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Logs - Add Shift Information" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  236, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)


-- Add "Logs - Summary Logs - View Summary Logs" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  88, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Logs - Summary Logs - Create Summary Logs" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  89, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId)

-- Add "Logs - Summary Logs - Edit Summary Logs" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  92, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId)

-- Add "Logs - Summary Logs - Delete Summary Logs" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  95, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningFieldServicesRoleId)


-- Add "Restriction Reporting - View Restriction Reporting" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  100, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Restriction Reporting - View Navigation - Restrictions" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  216, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)


-- Add "Shift Handovers - View Shift Handover" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  114, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Shift Handovers - View Navigation - Shift Handovers" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  214, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Shift Handovers - View Priorities - Shift Handovers" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  223, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId, @MiningManagerRoleId, @MiningTechnicalGroupRoleId)

-- Add "Shift Handovers - Create Shift Handover Questionnaire" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  115, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Shift Handovers - Edit Shift Handover Questionnaire" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  116, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)

-- Add "Shift Handovers - Delete Shift Handover Questionnaire" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  117, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3) and r.[Id] IN (@MiningOpsDispatchersRoleId, @MiningFieldServicesRoleId, @MiningOpsSupervisorRoleId)


-- Add "Mining Ops Supervisor" Role Permissions
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 270, @MiningFieldServicesRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 271, @MiningFieldServicesRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 270, @MiningOpsSupervisorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 271, @MiningOpsSupervisorRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 270, @MiningManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 271, @MiningManagerRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 270, @MiningTechnicalGroupRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningOpsSupervisorRoleId, 271, @MiningTechnicalGroupRoleId)


-- Add "Mining Manager" Role Permissions
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 270, @MiningFieldServicesRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 271, @MiningFieldServicesRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 270, @MiningOpsSupervisorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 271, @MiningOpsSupervisorRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 270, @MiningManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 271, @MiningManagerRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 270, @MiningTechnicalGroupRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningManagerRoleId, 271, @MiningTechnicalGroupRoleId)


-- Add "Mining Field Services" Role Permissions
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 270, @MiningFieldServicesRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 271, @MiningFieldServicesRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 270, @MiningOpsSupervisorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 271, @MiningOpsSupervisorRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 270, @MiningManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 271, @MiningManagerRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 270, @MiningTechnicalGroupRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningFieldServicesRoleId, 271, @MiningTechnicalGroupRoleId)


-- Add "Mining Technical Group" Role Permissions
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 270, @MiningFieldServicesRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 271, @MiningFieldServicesRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 270, @MiningOpsSupervisorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 271, @MiningOpsSupervisorRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 270, @MiningManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 271, @MiningManagerRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 270, @MiningTechnicalGroupRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES (@MiningTechnicalGroupRoleId, 271, @MiningTechnicalGroupRoleId)


GO


