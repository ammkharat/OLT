DECLARE @OutputTbl TABLE (Alias varchar(20), Id INT, SiteId INT);

DECLARE @ManagerRoleId int;
DECLARE @TechnicalEngineerRoleId int;
DECLARE @MaintenanceTechRoleId int;
DECLARE @OperatingEngineerRoleId int;
DECLARE @SupervisorRoleId int;


-- P&L selc roles
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('Manager', 'mgr', 'Manager', 7, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('Technical Engineer', 'techeng', 'TechnicalEngineer', 7, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('Maintenance Tech', 'maintech', 'MaintenanceTech', 7, 0, 0, 0, 0, 1, 0)

SELECT @ManagerRoleId = Id FROM @OutputTbl WHERE Alias = 'mgr' and SiteId = 7
SELECT @TechnicalEngineerRoleId = Id FROM @OutputTbl WHERE Alias = 'techeng' and SiteId = 7
SELECT @MaintenanceTechRoleId = Id FROM @OutputTbl WHERE Alias = 'maintech' and SiteId = 7
SELECT @OperatingEngineerRoleId = Id FROM Role WHERE name like 'Operating Engineer' and SiteId = 7
SELECT @SupervisorRoleId = Id FROM Role WHERE name like  'Supervisor' and SiteId = 7

-- ACTION ITEMS
-- Add "Action Items - View Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  1, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Add View Action Item
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  39, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Add View Navigation - Action Items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  210, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)


-- Add View Prioritis - Action Items 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  218, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)


-- Add Approve Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  2, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Add Reject Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  3, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Add Create Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  4, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Add Edit Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  6, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Add Delete Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  8, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Add Comment Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  10, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)


-- Add Toggle Approval for Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  11, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)


-- Add Toggle Approval for Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  40, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- DIRECTIVES
-- View Navigation - directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  231, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)


-- View Directives - Future
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  232, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- View Priorities - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  267, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)
-- View - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  268, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)


-- Create - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  269, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Edit - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  270, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)

-- Delete - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  271, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId)


-- EVENTS
-- View Navigation - Events
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  264, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- View Priorities - Events
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  265, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Respond Events
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  266, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId)


-- LOGS
-- Add View Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  33, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Add View Navigation - Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  212, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Create Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  32, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Edit Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  34, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Delete Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  35, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Reply to Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  51, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Copy Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  235, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Add shift information
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  236, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)




-- LOGS Notifications
-- View SAP Notifications
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  47, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Process SAP Notifications
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  48, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- LOGS SUMMARY
-- View Summary Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  88, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN(@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)


-- Shift Handover
-- View Shift Handover
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  114, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- View Shift Handover - Navigation
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  214, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- View Shift Handover - Priorities
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  223, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@ManagerRoleId, @TechnicalEngineerRoleId, @MaintenanceTechRoleId)

-- Create Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  115, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Edit Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  116, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

-- Delete Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  117, r.Id FROM [Role] r
WHERE 
  r.SiteId in (7) and r.[Id] IN (@MaintenanceTechRoleId)

go


GO

