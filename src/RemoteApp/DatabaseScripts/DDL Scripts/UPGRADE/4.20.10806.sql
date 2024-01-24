DECLARE @OutputTbl TABLE (Alias varchar(20), Id INT, SiteId INT);

DECLARE @SelcPlannerRoleId int;
DECLARE @SelcCoordinatorRoleId int;
DECLARE @SelcManagerRoleId int;
DECLARE @SelcSupportRoleId int;
DECLARE @SelcAdministratorRoleId int; 

DECLARE @OilsandsPlannerRoleId int;
DECLARE @OilsandsCoordinatorRoleId int;
DECLARE @OilsandsManagerRoleId int;
DECLARE @OilsandsSupportRoleId int;

DECLARE @VoyageurPlannerRoleId int;
DECLARE @VoyageurCoordinatorRoleId int;
DECLARE @VoyageurManagerRoleId int;
DECLARE @VoyageurSupportRoleId int;

-- P&L selc roles
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Planner', 'plplanner', 'PLPlanner', 13, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Coordinator', 'plcoord', 'PLCoordinator', 13, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Manager', 'plmgr', 'PLManager', 13, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Support', 'plsup', 'PLSupport', 13, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Administrator', 'pladmin', 'PLAdministrator', 13, 0, 0, 0, 0, 1, 0)

-- P&L Oilsands Roles
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Planner', 'plplanner', 'PLPlanner', 3, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Coordinator', 'plcoord', 'PLCoordinator', 3, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Manager', 'plmgr', 'PLManager', 3, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Support', 'plsup', 'PLSupport', 3, 0, 0, 0, 0, 1, 0)

-- P&L Voyageur Roles
INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Planner', 'plplanner', 'PLPlanner', 11, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Coordinator', 'plcoord', 'PLCoordinator', 11, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Manager', 'plmgr', 'PLManager', 11, 0, 0, 0, 0, 1, 0)

INSERT INTO Role ([Name], Alias, ActiveDirectoryKey, SiteId, deleted, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, IsDefaultReadOnlyRoleForSite) 
OUTPUT INSERTED.Alias, INSERTED.Id, INSERTED.SiteId INTO @OutputTbl
VALUES ('P&L Support', 'plsup', 'PLSupport', 11, 0, 0, 0, 0, 1, 0)






SELECT @SelcPlannerRoleId = Id FROM @OutputTbl WHERE Alias = 'plplanner' and SiteId = 13
SELECT @SelcCoordinatorRoleId = Id FROM @OutputTbl WHERE Alias = 'plcoord' and SiteId = 13
SELECT @SelcManagerRoleId = Id FROM @OutputTbl WHERE Alias = 'plmgr' and SiteId = 13
SELECT @SelcSupportRoleId = Id FROM @OutputTbl WHERE Alias = 'plsup' and SiteId = 13
SELECT @SelcAdministratorRoleId = Id FROM @OutputTbl WHERE Alias = 'pladmin' and SiteId = 13

SELECT @OilsandsPlannerRoleId = Id FROM @OutputTbl WHERE Alias = 'plplanner' and SiteId = 3
SELECT @OilsandsCoordinatorRoleId = Id FROM @OutputTbl WHERE Alias = 'plcoord' and SiteId = 3
SELECT @OilsandsManagerRoleId = Id FROM @OutputTbl WHERE Alias = 'plmgr' and SiteId = 3
SELECT @OilsandsSupportRoleId = Id FROM @OutputTbl WHERE Alias = 'plsup' and SiteId = 3

SELECT @VoyageurPlannerRoleId = Id FROM @OutputTbl WHERE Alias = 'plplanner' and SiteId = 11
SELECT @VoyageurCoordinatorRoleId = Id FROM @OutputTbl WHERE Alias = 'plcoord' and SiteId = 11
SELECT @VoyageurManagerRoleId = Id FROM @OutputTbl WHERE Alias = 'plmgr' and SiteId = 11
SELECT @VoyageurSupportRoleId = Id FROM @OutputTbl WHERE Alias = 'plsup' and SiteId = 11

-- ACTION ITEMS
-- Add "Action Items - View Action Item Definition" RoleElementTemplate items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  1, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Add View Action Item
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  39, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Add View Navigation - Action Items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  210, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Add View Prioritis - Action Items 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  218, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)


-- Add Approve Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  2, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Add Reject Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  3, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)


-- Add Create Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  4, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Add Edit Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  6, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Add Delete Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  8, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Add Comment Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  10, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)


-- Add Toggle Approval for Action Item Definition
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  11, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- DIRECTIVES
-- View Navigation - directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  231, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)

-- View Directives - Future
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  232, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)

-- View Priorities - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  267, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)

-- View - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  268, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)


-- Create - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  269, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId)

-- Edit - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  270, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId)

-- Delete - Directives 
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  271, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, 
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId)


-- EVENTS
-- View Navigation - Events
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  264, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)

-- View Priorities - Events
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  265, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)


-- LOGS
-- Add View Log
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  33, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Add View Navigation - Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  212, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)


-- Add View Priorities - Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  220, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)


-- LOGS - DIRECTIVES
-- Add Log Based Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  96, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- View Standing Orders
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  178, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)


-- Create Log Based Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  97, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)


-- Edit Log Based Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  98, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Delete Log Based Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  99, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- Cancel Standing Orders
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  177, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId,  
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId)

-- LOGS Notifications
-- View SAP Notifications
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  47, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId)

-- LOGS SUMMARY
-- View Summary Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  88, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Create Summary Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  89, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)


-- Edit Summary Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  92, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)

-- Delete  Summary Logs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  95, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)


-- Shift Handover
-- View Shift Handover
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  114, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- View Shift Handover - Navigation
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  214, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- View Shift Handover - Priorities
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  223, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcPlannerRoleId, @SelcCoordinatorRoleId, @SelcManagerRoleId, @SelcSupportRoleId, @SelcAdministratorRoleId,
                                      @OilsandsPlannerRoleId, @OilsandsCoordinatorRoleId, @OilsandsManagerRoleId, @OilsandsSupportRoleId, 
                                      @VoyageurPlannerRoleId, @VoyageurCoordinatorRoleId, @VoyageurManagerRoleId, @VoyageurSupportRoleId)

-- Create Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  115, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)

-- Edit Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  116, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)

-- Delete Shift Handover Questionnaire
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  117, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcCoordinatorRoleId)


-- ADMIN
-- Configure Business Categories
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  111, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Associate Business Categories to Func Locs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  112, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Associate Business Categories to Func Locs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  84, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Log Guidelines
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  113, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Summary Log Custom Fields
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  122, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Edit Log Templates
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  129, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Plant Historian Tag List
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  80, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Edit Shift Handover Configurations
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  120, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Edit Shift Handover E-mail configs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  206, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Display Limits
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  76, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Work Assignments
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  82, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Default FLOCS for Assignments
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  85, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Default Tabs
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  136, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Work Assignment Not Selected Warning
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  141, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure UNC Paths for Links
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  142, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Priorities Page
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  179, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Area Labels
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  204, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

-- Configure Site Communications
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  225, r.Id FROM [Role] r
WHERE 
  r.SiteId in (13,3,11) and r.[Id] IN (@SelcAdministratorRoleId)

INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 270, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 270, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 270, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 270, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 270, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 270, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 270, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 270, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 270, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 271, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 271, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcPlannerRoleId, 271, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 271, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 271, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcCoordinatorRoleId, 271, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 271, @SelcPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 271, @SelcCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@SelcManagerRoleId, 271, @SelcManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 270, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 270, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 270, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 270, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 270, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 270, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 270, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 270, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 270, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 271, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 271, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 271, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 271, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 271, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 271, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 271, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 271, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 271, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 98, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 98, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 98, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 177, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 177, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 177, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 98, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 98, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 98, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 177, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 177, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 177, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 98, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 98, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 98, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 177, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 177, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 177, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 99, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 99, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsPlannerRoleId, 99, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 99, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 99, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsCoordinatorRoleId, 99, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 99, @OilsandsPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 99, @OilsandsCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@OilsandsManagerRoleId, 99, @OilsandsManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 98, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 98, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 98, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 177, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 177, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 177, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 98, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 98, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 98, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 177, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 177, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 177, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 98, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 98, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 98, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 177, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 177, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 177, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 99, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 99, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurPlannerRoleId, 99, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 99, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 99, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurCoordinatorRoleId, 99, @VoyageurManagerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 99, @VoyageurPlannerRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 99, @VoyageurCoordinatorRoleId)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(@VoyageurManagerRoleId, 99, @VoyageurManagerRoleId)
GO





GO

