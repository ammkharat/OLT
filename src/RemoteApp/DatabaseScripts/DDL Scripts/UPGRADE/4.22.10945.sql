if not exists (select * from Site where site.Id = 15)
begin
INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (15, 'Fort Hills Operations', 'Mountain Standard Time', 'FortHills');
end
GO

--SET IDENTITY_INSERT dbo.Plant ON;
--INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (888, 'Fort Hills Operations', 15)
--SET IDENTITY_INSERT dbo.Plant OFF;
UPDATE dbo.[Plant] SET SiteId = 15 WHERE Id=764
GO


--- site configuration

INSERT INTO dbo.[Shift] ([Name], [StartTime], [EndTime], [CreatedDateTime], SiteId)
VALUES (
  'D'  -- Name
  ,'2016-03-01 06:00:00'  -- StartTime
  ,'2016-03-01 18:00:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,15  -- SiteId
)

INSERT INTO dbo.[Shift] ([Name], [StartTime], [EndTime], [CreatedDateTime], SiteId)
VALUES (
  'N'  -- Name
  ,'2016-03-01 18:00:00'  -- StartTime
  ,'2016-03-01 06:00:00'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,15  -- SiteId
)

GO

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

GO

insert into TargetDefinitionAutoReApprovalConfiguration
values (15, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

GO
-- ------------------------------------------------------------------------------

--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;
GO

BEGIN TRANSACTION
INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (15, N'FORT HILLS OPERATIONS', N'FH1', 0, 0, 1, 764, N'en', 2)
-- Remaining flocs will be synchronized from SAP
COMMIT TRANSACTION

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
GO
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
GO

---------------------------------------------------------------------------------------------
DECLARE @SiteId bigint
SET @SiteId = 15
-- ------------------------------------------------------------------------------------

---------------------------------------------------
---  Insert Operational Modes for each Unit   ---
---------------------------------------------------

BEGIN TRANSACTION
INSERT INTO FunctionalLocationOperationalMode
( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
(
    Select
        FunctionalLocation.Id,
        0,
        0,
        GETDATE()
    FROM
        FunctionalLocation
    WHERE
		SiteId = @SiteId 
		AND Level = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
COMMIT TRANSACTION


--------------------------------------------------
--  Update Ancestor Table                           ---
--------------------------------------------------
-- create a temp index for fast querying
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([SiteId] , [Level])
INCLUDE ([FullHierarchy],[Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = OFF
)
ON [PRIMARY];
   

-- Insert the Ancestor records for these Fort Hills Operations Flocs
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
	SELECT 
		c.id, a.id, a.[Level]
		FROM FunctionalLocation a
		INNER JOIN FunctionalLocation c 
			ON c.siteid = a.siteid and 
			c.[Level] > a.[Level] and
			CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
		where
			c.SiteId = @SiteId
)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO

insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Operator Handover Questions',0
insert ShiftHandoverConfiguration ( Name,Deleted )  select 'Supervisor Handover Questions',0

insert into SiteConfiguration ( 
SiteId,
DaysToDisplayActionItems,
DaysToDisplayShiftLogs,
DaysBeforeArchivingClosedWorkPermits,
DaysBeforeDeletingPendingWorkPermits,
DaysBeforeClosingIssuedWorkPermits,
AutoApproveWorkOrderActionItemDefinition,
AutoApproveSAPAMActionItemDefinition,
AutoApproveSAPMCActionItemDefinition,
CreateOperatingEngineerLogs,
WorkPermitNotApplicableAutoSelected,
WorkPermitOptionAutoSelected,
OperatingEngineerLogDisplayName,
DaysToEditDeviationAlerts,
DaysToDisplayShiftHandovers,
SummaryLogFunctionalLocationDisplayLevel,
ShowActionItemsByWorkAssignmentOnPriorityPage,
DaysToDisplayDeviationAlerts,
AllowStandardLogAtSecondLevelFunctionalLocation,
DorCutoffTime,
DaysToDisplayWorkPermitsBackwards,
DaysToDisplayLabAlerts,
LabAlertRetryAttemptLimit,
RequireActionItemResponseLog,
ActionItemRequiresApprovalDefaultValue,
HideDORCommentEntry,
DaysToDisplayCokerCards,
ActionItemRequiresResponseDefaultValue,
ShowActionItemsOnShiftHandover,
UseNewPriorityPage,
ShowShiftHandoversByWorkAssignmentOnPriorityPage,
DaysToDisplayDirectivesOnPriorityPage,
DaysToDisplayShiftHandoversOnPriorityPage,
DisplayActionItemWorkAssignmentOnPriorityPage,
DaysToDisplayPermitRequestsBackwards,
DaysToDisplayPermitRequestsForwards,
DaysToDisplayWorkPermitsForwards,
DisplayActionItemCommentOnly,
DefaultNumberOfCopiesForWorkPermits,
ShowFollowupOnLogForm,
AllowCreateALogForEachSelectedFlocOnLogForm,
ShowAdditionalDetailsOnLogFormByDefault,
Culture,
ShowWorkPermitPrintingTabInPreferences,
ShowDefaulPermitTimesTabInPreferences,
DaysToDisplayTargetAlertsOnPriorityPage,
LoginFlocSelectionLevel,
UseCreatedByColumnForLogs,
ShowIsModifiedColumnForLogs,
ItemFlocSelectionLevel,
DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
PreShiftPaddingInMinutes,
PostShiftPaddingInMinutes,
DaysToDisplayFormsBackwards,
DaysToDisplayFormsForwards,
DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
DaysToDisplayFormsBackwardsOnPriorityPage,
FormsFlocSetTypeId,
DaysToDisplaySAPNotificationsBackwards,
ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab,
AllowCombinedShiftHandoverAndLog,
ShowCreateShiftHandoverMessageFromNewLogClick,
DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
DefaultTargetDefinitionRequiresResponseWhenAlertedValue,
CollectAnalyticsData,
DaysToDisplayDirectivesBackwards,
DaysToDisplayDirectivesForwards,
UseLogBasedDirectives,
ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab,
RememberActionItemWorkAssignment,
MaximumDirectiveFLOClevel,
MaximumAllowableExcursionEventDurationMins,
MaximumAllowableExcursionEventTimeframeMins,
DaysToDisplayEventsBackwards,
DaysToDisplayDocumentSuggestionFormsBackwards,
DaysToDisplayDocumentSuggestionFormsForwards,
DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage)  
select 
15,
7,7,7,7,1,1,1,1,1,1,1,'Chief Engineer Log', -- OperatingEngineerLogDisplayName
7,7,2,0,30,1,'Jan  1 1900 10:00AM', -- DorCutoffTime
15,30,3, 1,0,1,14, -- DaysToDisplayCokerCards
1,1,1,0,3,3, -- DaysToDisplayShiftHandoversOnPriorityPage
1,0,0,0,1,1,1,1,0, -- ShowAdditionalDetailsOnLogFormByDefault
'en',0,0,0,3,0,0,5,1, -- DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs
60, 60, -- PreShiftPaddingInMinuts, PostShiftPaddingInMinutes
3,null,1,3,0,1, -- DaysToDisplaySAPNotificationsBackwards
1,0,0,null,0,1, -- CollectAnalyticsData
3,null,0,0,0,1, -- MaximumDirectiveFLOCLevel
0,120,0, -- DaysToDisplayEventsBackwards
30,null,30 -- DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage

GO

insert into SiteConfigurationDefaults (SiteId, CopyTargetAlertResponseToLog)
select 15, 1

GO


insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Unit Guideline / Process','Proc',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Environmental / Safety','Env',0,1,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Production','Prod',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Equipment / Mechanical','Equip',1,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Routine Activity','Rtn',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Regulatory','Reg',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15
insert into BusinessCategory (Name,ShortName,IsSAPWorkOrderDefault,IsSAPNotificationDefault,LastModifiedUserId,LastModifiedDateTime,CreatedDateTime,Deleted,SiteId )  select 'Key Performance Indicators','KPIs',0,0,-1,'Feb 2 2016  2:20PM','Feb 2 2016  2:20PM',0,15


insert into BusinessCategoryFLOCAssociation (BusinessCategoryId,FunctionalLocationId,LastModifiedUserId,LastModifiedDateTime )  
select bc.Id,f.Id,bc.LastModifiedUserId,bc.LastModifiedDateTime from BusinessCategory bc, FunctionalLocation f where f.siteid = 15 and f.FullHierarchy = 'FH1' and bc.SiteId = 15 and bc.Deleted = 0
go

-- Roles: 

ALTER TABLE [Role] 
ALTER COLUMN [Name] VARCHAR(100) NOT NULL
GO 


-- roles - from master data sheet
-- Max 40 chars for name, 255 for active directory key, 20 for alias

SET IDENTITY_INSERT [Role] ON;

-------------------------------
-- General:

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (250, 'Administrator', 0, 'Administrator', 15, 1, 0, 0, 1, 'admin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (251, 'Read User', 0, 'ReadUser', 15, 0, 1, 0, 0, 'read', 1);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (252, 'Technical Administrator', 0, 'TechnicalAdmin', 15, 0, 0, 0, 0, 'techadmin',0);
-------------------------------

-------------------------------
-- Laboratory:
-- Lab Administrator (LabAdministrator, labadmin)
-- Lab Manager (LabManager, labmgr)
-- Lab Supervisor (LabSupervisor, super)
-- Lab Coordinator (LabCoordinator, coord)
-- Lab Quality Specialist (LabQASpecialist, labqaspecial)
-- Lab Technician (LabTechnician, labtech)
-- Lab Laborer (LabLaborer, lablabor)

-- Laboratory Entitlements in iRequest:
-- OLT-FortHills-764-LabAdministrator | OLT Fort Hills Lab Administrator
-- OLT-FortHills-764-LabManager | OLT Fort Hills Lab Manager
-- OLT-FortHills-764-LabSupervisor | OLT Fort Hills Lab Supervisor
-- OLT-FortHills-764-LabCoordinator | OLT Fort Hills Lab Coordinator
-- OLT-FortHills-764-LabQASpecialist | OLT Fort Hills Lab QA Specialist
-- OLT-FortHills-764-LabTechnician | OLT Fort Hills Lab Technician
-- OLT-FortHills-764-LabLaborer | OLT Fort Hills Lab Laborer

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (253, 'Lab Administrator', 0, 'LabAdministrator', 15, 0, 0, 0, 1, 'labadmin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (254, 'Lab Manager', 0, 'LabManager', 15, 0, 0, 0, 1, 'labmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (255, 'Lab Supervisor', 0, 'LabSupervisor', 15, 0, 0, 0, 1, 'super',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (256, 'Lab Coordinator', 0, 'LabCoordinator', 15, 0, 0, 0, 1, 'coord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (257, 'Lab Quality Specialist', 0, 'LabQASpecialist', 15, 0, 0, 0, 1, 'labqaspecial',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (258, 'Lab Technician', 0, 'LabTechnician', 15, 0, 0, 0, 1, 'labtech',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (259, 'Lab Laborer', 0, 'LabLaborer', 15, 0, 0, 0, 1, 'lablabor',0);
-------------------------------

-------------------------------
-- Primary Extraction:
-- PE Administrator (PEAdministrator, peadmin)
-- PE Process Engineer (PEProcessEngineer, peproceng)
-- PE Area Manager (PEAreaManager, peareamgr)
-- PE CRS Operator (PECRSOperator, peoper)
-- PE Manager (PEManager, pemgr)
-- PE Field Operator (PEFieldOperator, peoper)
-- PE Reliability Engineer (PEReliabilityEngineer, pereleng)
-- PE Shift Supervisor (PEShiftSupervisor, peshiftsuper)
-- PE Operations Coordinator (PEOperationsCoordinator, peopscoord)

-- Primary Extraction Entitlements in iRequest:
-- OLT-FortHills-764-PEAdministrator | OLT Fort Hills Primary Extraction Administrator
-- OLT-FortHills-764-PEProcessEngineer | OLT Fort Hills Primary Extraction Process Engineer
-- OLT-FortHills-764-PEAreaManager | OLT Fort Hills Primary Extraction Area Manager
-- OLT-FortHills-764-PECRSOperator | OLT Fort Hills Primary Extraction CRS Operator
-- OLT-FortHills-764-PEManager | OLT Fort Hills Primary Extraction Manager
-- OLT-FortHills-764-PEFieldOperator | OLT Fort Hills Primary Extraction Field Operator
-- OLT-FortHills-764-PEReliabilityEngineer | OLT Fort Hills Primary Extraction Reliability Engineer
-- OLT-FortHills-764-PEShiftSupervisor | OLT Fort Hills Primary Extraction Shift Supervisor
-- OLT-FortHills-764-PEOperationsCoordinator | OLT Fort Hills Primary Extraction Operations Coordinator

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (260, 'PE Administrator', 0, 'PEAdministrator', 15, 0, 0, 0, 1, 'peadmin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (261, 'PE Process Engineer', 0, 'PEProcessEngineer', 15, 0, 0, 0, 1, 'peproceng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (262, 'PE Area Manager', 0, 'PEAreaManager', 15, 0, 0, 0, 1, 'peareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (263, 'PE CRS Operator', 0, 'PECRSOperator', 15, 0, 0, 0, 1, 'peoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (264, 'PE Manager', 0, 'PEManager', 15, 0, 0, 0, 1, 'pemgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (265, 'PE Field Operator', 0, 'PEFieldOperator', 15, 0, 0, 0, 1, 'peoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (266, 'PE Reliability Engineer', 0, 'PEReliabilityEngineer', 15, 0, 0, 0, 1, 'pereleng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (267, 'PE Shift Supervisor', 0, 'PEShiftSupervisor', 15, 0, 0, 0, 1, 'peshiftsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (268, 'PE Operations Coordinator', 0, 'PEOperationsCoordinator', 15, 0, 0, 0, 1, 'peopscoord',0);
-------------------------------

-------------------------------
-- Utilities:
-- UO Administrator (UOAdministrator, uoadmin)
-- UO Operations Manager (UOOperationsManager, uoopmgr)
-- UO Operations Area Manager (UOOperationsAreaManager, uoopareamgr)
-- UO Chief Engineer (UOChiefEngineer, uochiefeng)
-- UO Operations Coordinator (UOOperationsCoordinator, uoopcoord)
-- UO Operations Supervisor (UOOperationsSupervisor, uoopsuper)
-- UO Operator (UOOperator, uooper)
-- UO Maintenance Area Manager (UOMntAreaManager, uomntareamgr)
-- UO Maintenance Coordinator (UOMntCoordinator, uomntcoord)
-- UO Maintenance Supervisor (UOMntSupervisor, uomntsuper)
-- UO Process Engineer (UOProcessEngineer, uoproceng)
-- UO Process Engineer Target Admin (UOProcessEngineerTargetAdmin, uoprocengadm)
-- UO Reliability Engineer (UOReliabilityEngineer, uoreleng)

-- Utilities Entitlements in iRequest:
-- OLT-FortHills-764-UOAdministrator | OLT Fort Hills Utilities Administrator
-- OLT-FortHills-764-UOOperationsManager | OLT Fort Hills Utilities Operations Manager
-- OLT-FortHills-764-UOOperationsAreaManager | OLT Fort Hills Utilities Operations Area Manager
-- OLT-FortHills-764-UOChiefEngineer | OLT Fort Hills Utilities Chief Engineer
-- OLT-FortHills-764-UOOperationsCoordinator | OLT Fort Hills Utilities Operations Coordinator
-- OLT-FortHills-764-UOOperationsSupervisor | OLT Fort Hills Utilities Operations Supervisor
-- OLT-FortHills-764-UOOperator | OLT Fort Hills Utilities Operator
-- OLT-FortHills-764-UOMntAreaManager | OLT Fort Hills Utilities Maintenance Area Manager
-- OLT-FortHills-764-UOMntCoordinator | OLT Fort Hills Utilities Maintenance Coordinator
-- OLT-FortHills-764-UOMntSupervisor | OLT Fort Hills Utilities Maintenance Supervisor
-- OLT-FortHills-764-UOProcessEngineer | OLT Fort Hills Utilities Process Engineer
-- OLT-FortHills-764-UOProcessEngineerTargetAdmin | OLT Fort Hills Utilities Process Engineer Target Admin
-- OLT-FortHills-764-UOReliabilityEngineer | OLT Fort Hills Utilities Reliability Engineer

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (269, 'UO Administrator', 0, 'UOAdministrator', 15, 0, 0, 0, 1, 'uoadmin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (270, 'UO Operations Manager', 0, 'UOOperationsManager', 15, 0, 0, 0, 1, 'uoopmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (271, 'UO Operations Area Manager', 0, 'UOOperationsAreaManager', 15, 0, 0, 0, 1, 'uoopareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (272, 'UO Chief Engineer', 0, 'UOChiefEngineer', 15, 0, 0, 0, 1, 'uochiefeng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (273, 'UO Operations Coordinator', 0, 'UOOperationsCoordinator', 15, 0, 0, 0, 1, 'uoopcoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (274, 'UO Operations Supervisor', 0, 'UOOperationsSupervisor', 15, 0, 0, 0, 1, 'uoopsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (275, 'UO Operator', 0, 'UOOperator', 15, 0, 0, 0, 1, 'uooper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (276, 'UO Maintenance Area Manager', 0, 'UOMntAreaManager', 15, 0, 0, 0, 1, 'uomntareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (277, 'UO Maintenance Coordinator', 0, 'UOMntCoordinator', 15, 0, 0, 0, 1, 'uomntcoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (278, 'UO Maintenance Supervisor', 0, 'UOMntSupervisor', 15, 0, 0, 0, 1, 'uomntsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (279, 'UO Process Engineer', 0, 'UOProcessEngineer', 15, 0, 0, 0, 1, 'uoproceng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (280, 'UO Process Engineer Target Admin', 0, 'UOProcessEngineerTargetAdmin', 15, 0, 0, 0, 1, 'uoprocengadm',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (281, 'UO Reliability Engineer', 0, 'UOReliabilityEngineer', 15, 0, 0, 0, 1, 'uoreleng',0);
-------------------------------

-------------------------------
-- T&D:
-- TD Operator (TDOperator, tdoper)
-- TD Operations Coordinator (TDOperationsCoordinator, tdopscoord)

-- T&D Entitlements in iRequest:
-- OLT-FortHills-764-TDOperator | OLT Fort Hills T&D Operator
-- OLT-FortHills-764-TDOperationsCoordinator | OLT Fort Hills T&D Operations Coordinator

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (282, 'TD Operator', 0, 'TDOperator', 15, 0, 0, 0, 1, 'tdoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (283, 'TD Operations Coordinator', 0, 'TDOperationsCoordinator', 15, 0, 0, 0, 1, 'tdopscoord',0);
-------------------------------

-------------------------------
-- Secondary Extraction:
-- SE Administrator (SEAdministrator, seadmin)
-- SE Manager (SEManager, semanager)
-- SE Supervisor (SESupervisor, sesuper)
-- SE Technical SME (SETechnicalSME, sesme)
-- SE Coordinator (SECoordinator, secoord)
-- SE Control Room Specialist (SEControlRoomSpecialist, secrspecial)
-- SE Operator (SEOperator, seoper)
-- SE Engineer (SEEngineer, seeng)
-- SE Maintenance Area Manager (SEMaintenanceAreaManager, semntareamgr)
-- SE Maintenance Supervisor (SEMaintenanceSupervisor, semntsuper)
-- SE Operator Trainee (SEOperatorTrainee, seopertrn)

-- Secondary Extraction Entitlements in iRequest:
-- OLT-FortHills-764-SEAdministrator | OLT Fort Hills Secondary Extraction Administrator
-- OLT-FortHills-764-SEManager | OLT Fort Hills Secondary Extraction Manager
-- OLT-FortHills-764-SESupervisor | OLT Fort Hills Secondary Extraction Supervisor
-- OLT-FortHills-764-SETechnicalSME | OLT Fort Hills Secondary Extraction Technical SME
-- OLT-FortHills-764-SECoordinator | OLT Fort Hills Secondary Extraction Coordinator
-- OLT-FortHills-764-SEControlRoomSpecialist | OLT Fort Hills Secondary Extraction Control Room Specialist
-- OLT-FortHills-764-SEOperator | OLT Fort Hills Secondary Extraction Operator
-- OLT-FortHills-764-SEEngineer | OLT Fort Hills Secondary Extraction Engineer
-- OLT-FortHills-764-SEMaintenanceAreaManager | OLT Fort Hills Secondary Extraction Maintenance Area Manager
-- OLT-FortHills-764-SEMaintenanceSupervisor | OLT Fort Hills Secondary Extraction Maintenance Supervisor
-- OLT-FortHills-764-SEOperatorTrainee | OLT Fort Hills Secondary Extraction Operator Trainee

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (284, 'SE Administrator', 0, 'SEAdministrator', 15, 0, 0, 0, 1, 'seadmin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (285, 'SE Manager', 0, 'SEManager', 15, 0, 0, 0, 1, 'semanager',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (286, 'SE Supervisor', 0, 'SESupervisor', 15, 0, 0, 0, 1, 'sesuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (287, 'SE Technical SME', 0, 'SETechnicalSME', 15, 0, 0, 0, 1, 'sesme',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (288, 'SE Coordinator', 0, 'SECoordinator', 15, 0, 0, 0, 1, 'secoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (289, 'SE Control Room Specialist', 0, 'SEControlRoomSpecialist', 15, 0, 0, 0, 1, 'secrspecial',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (290, 'SE Operator', 0, 'SEOperator', 15, 0, 0, 0, 1, 'seoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (291, 'SE Engineer', 0, 'SEEngineer', 15, 0, 0, 0, 1, 'seeng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (292, 'SE Maintenance Area Manager', 0, 'SEMaintenanceAreaManager', 15, 0, 0, 0, 1, 'semntareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (293, 'SE Maintenance Supervisor', 0, 'SEMaintenanceSupervisor', 15, 0, 0, 0, 1, 'semntsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (294, 'SE Operator Trainee', 0, 'SEOperatorTrainee', 15, 0, 0, 0, 1, 'seopertrn',0);
-------------------------------

-------------------------------
-- Tailings:
-- TA Administrator (TAAdministrator, taadmin)
-- TA Trainer (TATrainer, tatrnr)
-- TA Operations Manager (TAOperationsManager, taopermgr)
-- TA Area Manager (TAAreaManager, taareamgr)
-- TA Coordinator (TACoordinator, tacoord)
-- TA Shift Supervisor (TAShiftSupervisor, tasuper)
-- TA Operator (TAOperator, taoper)
-- TA Planner (TAPlanner, taplan)
-- TA Maintenance Manager (TAMaintenanceManager, tamntmgr)
-- TA Maintenance Area Manager (TAMaintenanceAreaManager, tamntareamgr)
-- TA Maintenance Coordinator (TAMaintenanceCoordinator, tamntcoord)
-- TA Maintenance Supervisor (TAMaintenanceSupervisor, tamntsuper)
-- TA Maintenance Tech (TAMaintenanceTech, tamnttech)
-- TA Process Engineer (TAProcessEngineer, taproceng)
-- TA Reliability Engineer (TAReliabilityEngineer, tareleng)
-- TA Maintenance Contractor Manager (TAMaintenanceContractorManager, tamntcmgr)
-- TA Maintenance Contractor Coordinator (TAMaintenanceContractorCoordinator, tamntccoord)
-- TA Maintenance Contractor Supervisor (TAMaintenanceContractorSupervisor, tamntcsuper)

-- Tailings Entitlements in iRequest:
-- OLT-FortHills-764-TAAdministrator | OLT Fort Hills Tailings Administrator
-- OLT-FortHills-764-TATrainer | OLT Fort Hills Tailings Trainer
-- OLT-FortHills-764-TAOperationsManager | OLT Fort Hills Tailings Operations Manager
-- OLT-FortHills-764-TAAreaManager | OLT Fort Hills Tailings Area Manager
-- OLT-FortHills-764-TACoordinator | OLT Fort Hills Tailings Coordinator
-- OLT-FortHills-764-TAShiftSupervisor | OLT Fort Hills Tailings Shift Supervisor
-- OLT-FortHills-764-TAOperator | OLT Fort Hills Tailings Operator
-- OLT-FortHills-764-TAPlanner | OLT Fort Hills Tailings Planner
-- OLT-FortHills-764-TAMaintenanceManager | OLT Fort Hills Tailings Maintenance Manager
-- OLT-FortHills-764-TAMaintenanceAreaManager | OLT Fort Hills Tailings Maintenance Area Manager
-- OLT-FortHills-764-TAMaintenanceCoordinator | OLT Fort Hills Tailings Maintenance Coordinator
-- OLT-FortHills-764-TAMaintenanceSupervisor | OLT Fort Hills Tailings Maintenance Supervisor
-- OLT-FortHills-764-TAMaintenanceTech | OLT Fort Hills Tailings Maintenance Tech
-- OLT-FortHills-764-TAProcessEngineer | OLT Fort Hills Tailings Process Engineer
-- OLT-FortHills-764-TAReliabilityEngineer | OLT Fort Hills Tailings Reliability Engineer
-- OLT-FortHills-764-TAMaintenanceContractorManager | OLT Fort Hills Tailings Maintenance Contractor Manager
-- OLT-FortHills-764-TAMaintenanceContractorCoordinator | OLT Fort Hills Tailings Maintenance Contractor Coordinator
-- OLT-FortHills-764-TAMaintenanceContractorSupervisor | OLT Fort Hills Tailings Maintenance Contractor Supervisor

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (295, 'TA Administrator', 0, 'TAAdministrator', 15, 0, 0, 0, 1, 'taadmin',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (296, 'TA Trainer', 0, 'TATrainer', 15, 0, 0, 0, 1, 'tatrnr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (297, 'TA Operations Manager', 0, 'TAOperationsManager', 15, 0, 0, 0, 1, 'taopermgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (298, 'TA Area Manager', 0, 'TAAreaManager', 15, 0, 0, 0, 1, 'taareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (299, 'TA Coordinator', 0, 'TACoordinator', 15, 0, 0, 0, 1, 'tacoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (300, 'TA Shift Supervisor', 0, 'TAShiftSupervisor', 15, 0, 0, 0, 1, 'tasuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (301, 'TA Operator', 0, 'TAOperator', 15, 0, 0, 0, 1, 'taoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (302, 'TA Planner', 0, 'TAPlanner', 15, 0, 0, 0, 1, 'taplan',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (303, 'TA Maintenance Manager', 0, 'TAMaintenanceManager', 15, 0, 0, 0, 1, 'tamntmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (304, 'TA Maintenance Area Manager', 0, 'TAMaintenanceAreaManager', 15, 0, 0, 0, 1, 'tamntareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (305, 'TA Maintenance Coordinator', 0, 'TAMaintenanceCoordinator', 15, 0, 0, 0, 1, 'tamntcoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (306, 'TA Maintenance Supervisor', 0, 'TAMaintenanceSupervisor', 15, 0, 0, 0, 1, 'tamntsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (307, 'TA Maintenance Tech', 0, 'TAMaintenanceTech', 15, 0, 0, 0, 1, 'tamnttech',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (308, 'TA Process Engineer', 0, 'TAProcessEngineer', 15, 0, 0, 0, 1, 'taproceng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (309, 'TA Reliability Engineer', 0, 'TAReliabilityEngineer', 15, 0, 0, 0, 1, 'tareleng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (310, 'TA Maintenance Contractor Manager', 0, 'TAMaintenanceContractorManager', 15, 0, 0, 0, 1, 'tamntcmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (311, 'TA Maintenance Contractor Coordinator', 0, 'TAMaintenanceContractorCoordinator', 15, 0, 0, 0, 1, 'tamntccoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (312, 'TA Maintenance Contractor Supervisor', 0, 'TAMaintenanceContractorSupervisor', 15, 0, 0, 0, 1, 'tamntcsuper',0);
-------------------------------

-------------------------------
-- Mining: 
-- Mining Trainer (MiningTrainer, mntrnr)
-- Mining Operations Manager (MiningOperationsManager, mnopermgr)
-- Mining Area Manager (MiningAreaManager, mnareamgr)
-- Mining Coordinator (MiningCoordinator, mncoord)
-- Mining Shift Supervisor (MiningShiftSupervisor, mnsuper)
-- Mining Operator (MiningOperator, mnoper)
-- Mining Maintenance Manager (MiningMaintenanceManager, mnmntmgr)
-- Mining Maintenance Area Manager (MiningMaintenanceAreaManager, mnmntareamgr)
-- Mining Maintenance Coordinator (MiningMaintenanceCoordinator, mnmntcoord)
-- Mining Maintenance Supervisor (MiningMaintenanceSupervisor, mnmntsuper)
-- Mining Maintenance Tech (MiningMaintenanceTech, mnmnttech)
-- Mining Engineer (MiningEngineer, mneng)
-- Mining Maintenance Contractor Manager (MiningMaintenanceContractorManager, mnmntcmgr)
-- Mining Maintenance Contractor Coordinator (MiningMaintenanceContractorCoordinator, mnmntccoord)
-- Mining Maintenance Contractor Supervisor (MiningMaintenanceContractorSupervisor, mnmntcsuper)

-- Tailings Entitlements in iRequest:
-- OLT-FortHills-764-MiningTrainer | OLT Fort Hills Mining Trainer
-- OLT-FortHills-764-MiningOperationsManager | OLT Fort Hills Mining Operations Manager
-- OLT-FortHills-764-MiningAreaManager | OLT Fort Hills Mining Area Manager
-- OLT-FortHills-764-MiningCoordinator | OLT Fort Hills Mining Coordinator
-- OLT-FortHills-764-MiningShiftSupervisor | OLT Fort Hills Mining Shift Supervisor
-- OLT-FortHills-764-MiningOperator | OLT Fort Hills Mining Operator
-- OLT-FortHills-764-MiningMaintenanceManager | OLT Fort Hills Mining Maintenance Manager
-- OLT-FortHills-764-MiningMaintenanceAreaManager | OLT Fort Hills Mining Maintenance Area Manager
-- OLT-FortHills-764-MiningMaintenanceCoordinator | OLT Fort Hills Mining Maintenance Coordinator
-- OLT-FortHills-764-MiningMaintenanceSupervisor | OLT Fort Hills Mining Maintenance Supervisor
-- OLT-FortHills-764-MiningMaintenanceTech | OLT Fort Hills Mining Maintenance Tech
-- OLT-FortHills-764-MiningEngineer | OLT Fort Hills Mining Engineer
-- OLT-FortHills-764-MiningMaintenanceContractorManager | OLT Fort Hills Mining Maintenance Contractor Manager
-- OLT-FortHills-764-MiningMaintenanceContractorCoordinator | OLT Fort Hills Mining Maintenance Contractor Coordinator
-- OLT-FortHills-764-MiningMaintenanceContractorSupervisor | OLT Fort Hills Mining Maintenance Contractor Supervisor

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (313, 'Mining Trainer', 0, 'MiningTrainer', 15, 0, 0, 0, 1, 'mntrnr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (314, 'Mining Operations Manager', 0, 'MiningOperationsManager', 15, 0, 0, 0, 1, 'mnopermgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (315, 'Mining Area Manager', 0, 'MiningAreaManager', 15, 0, 0, 0, 1, 'mnareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (316, 'Mining Coordinator', 0, 'MiningCoordinator', 15, 0, 0, 0, 1, 'mncoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (317, 'Mining Shift Supervisor', 0, 'MiningShiftSupervisor', 15, 0, 0, 0, 1, 'mnsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (318, 'Mining Operator', 0, 'MiningOperator', 15, 0, 0, 0, 1, 'mnoper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (319, 'Mining Maintenance Manager', 0, 'MiningMaintenanceManager', 15, 0, 0, 0, 1, 'mnmntmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (320, 'Mining Maintenance Area Manager', 0, 'MiningMaintenanceAreaManager', 15, 0, 0, 0, 1, 'mnmntareamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (321, 'Mining Maintenance Coordinator', 0, 'MiningMaintenanceCoordinator', 15, 0, 0, 0, 1, 'mnmntcoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (322, 'Mining Maintenance Supervisor', 0, 'MiningMaintenanceSupervisor', 15, 0, 0, 0, 1, 'mnmntsuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (323, 'Mining Maintenance Tech', 0, 'MiningMaintenanceTech', 15, 0, 0, 0, 1, 'mnmnttech',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (324, 'Mining Engineer', 0, 'MiningEngineer', 15, 0, 0, 0, 1, 'mneng',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (325, 'Mining Maintenance Contractor Manager', 0, 'MiningMaintenanceContractorManager', 15, 0, 0, 0, 1, 'mnmntcmgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (326, 'Mining Maintenance Contractor Coordinator', 0, 'MiningMaintenanceContractorCoordinator', 15, 0, 0, 0, 1, 'mnmntccoord',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (327, 'Mining Maintenance Contractor Supervisor', 0, 'MiningMaintenanceContractorSupervisor', 15, 0, 0, 0, 1, 'mnmntcsuper',0);
-------------------------------

-------------------------------
-- NPA:
-- NPA Manager (NPAManager, npamgr)
-- NPA Supervisor (NPASupervisor, npasuper)
-- NPA Coordinator (NPACoordinator, npacoord)

-- NPA Entitlements in iRequest:
-- OLT-FortHills-764-NPAManager | OLT Fort Hills NPA Manager
-- OLT-FortHills-764-NPASupervisor | OLT Fort Hills NPA Supervisor
-- OLT-FortHills-764-NPACoordinator | OLT Fort Hills NPA Coordinator

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (328, 'NPA Manager', 0, 'NPAManager', 15, 0, 0, 0, 1, 'npamgr',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (329, 'NPA Supervisor', 0, 'NPASupervisor', 15, 0, 0, 0, 1, 'npasuper',0);

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values (330, 'NPA Coordinator', 0, 'NPACoordinator', 15, 0, 0, 0, 1, 'npacoord',0);
-------------------------------


SET IDENTITY_INSERT [Role] OFF;

GO

update Role set WarnIfWorkAssignmentNotSelected = 1 where SiteId = 15 
go  
  
update Role set WarnIfWorkAssignmentNotSelected = 0 where SiteId = 15 and Name in ('Read User', 'Technical Administrator')  
go  

-------------------------------- Role Elements Start --------------------------------------

DECLARE @RoleId bigint;
DECLARE @ListOfRoleElementIds TABLE(RoleElementIds bigint);

-- Administrator Role Elements (Id=250)

set @RoleId = 250;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(272), 		-- Action Items & Targets - Set Operational Modes
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(47), 			-- Logs - Notifications - View SAP Notifications
		(88), 			-- Logs - Summary Logs - View Summary Logs
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223), 		-- Shift Handovers - View Priorities - Shift Handovers
		(77), 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition
		(111), 		-- Admin - Action Items - Configure Business Categories
		(112), 		-- Admin - Action Items - Associate Business Categories To Functional Locations
		(113), 		-- Admin - Logs - Configure Log Guidelines
		(122), 		-- Admin - Logs - Configure Summary Log Custom Fields
		(129), 		-- Admin - Logs - Edit Log Templates
		(80), 			-- Admin - Reports - Configure Plant Historian Tag List
		(120), 		-- Admin - Shift Handovers - Edit Shift Handover Configurations
		(206), 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations
		(76), 			-- Admin - Site Configuration - Configure Display Limits
		(82), 			-- Admin - Site Configuration - Configure Work Assignments
		(85), 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments
		(136), 		-- Admin - Site Configuration - Configure Default Tabs
		(141), 		-- Admin - Site Configuration - Configure Work Assignment Not Selected Warning
		(142), 		-- Admin - Site Configuration - Configure Unc Paths for Links
		(179), 		-- Admin - Site Configuration - Configure Priorities Page
		(225), 		-- Admin - Site Configuration - Configure Site Communications
		(237); 		-- Admin - Site Configuration - Configure Functional Locations

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Read User Role Elements (Id = 251)

set @RoleId = 251;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(272), 		-- Action Items & Targets - Set Operational Modes
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(33), 			-- Logs - View Log
		(212), 		-- Logs - View Navigation - Logs
		(47), 			-- Logs - Notifications - View SAP Notifications
		(88), 			-- Logs - Summary Logs - View Summary Logs
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223); 		-- Shift Handovers - View Priorities - Shift Handovers

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Technical Administrator Role Elements (Id = 252)

set @RoleId = 252;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(210), 		-- Action Items - View Navigation - Action Items
		(272), 		-- Action Items & Targets - Set Operational Modes
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(212), 		-- Logs - View Navigation - Logs
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(225), 		-- Admin - Site Configuration - Configure Site Communications
		(202);			-- Technical Admin - Perform Tech Admin Tasks

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Administrator Role Elements (Id = 253)

set @RoleId = 253;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items

		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(269), 		-- Directives - Create Directives
		(270), 		-- Directives - Edit Directives
		(271), 		-- Directives - Delete Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(266), 		-- Events - Respond to Excursion
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		(196),		-- Forms - Create Form
		(198),		-- Forms - Delete Form
		(199),		-- Forms - Edit Form
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
		(131),		-- Lab Alerts - Create Lab Alert Definition
		(132),		-- Lab Alerts - Edit Lab Alert Definition
		(133),		-- Lab Alerts - Delete Lab Alert Definition
		(134),		-- Lab Alerts - Respond To Lab Alert
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log
		
		(47), 			-- Logs - Notifications - View SAP Notifications
		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223), 		-- Shift Handovers - View Priorities - Shift Handovers
		
		(77), 			-- Admin - Action Items - Configure Auto Approve SAP Action Item Definition
		(111), 		-- Admin - Action Items - Configure Business Categories
		(112), 		-- Admin - Action Items - Associate Business Categories To Functional Locations

		(113), 		-- Admin - Logs - Configure Log Guidelines
		(122), 		-- Admin - Logs - Configure Summary Log Custom Fields
		(129), 		-- Admin - Logs - Edit Log Templates
		(80), 			-- Admin - Reports - Configure Plant Historian Tag List
		(120), 		-- Admin - Shift Handovers - Edit Shift Handover Configurations
		(206), 		-- Admin - Shift Handovers - Edit Shift Handover E-mail Configurations

		(76), 			-- Admin - Site Configuration - Configure Display Limits
		(82), 			-- Admin - Site Configuration - Configure Work Assignments
		(85), 			-- Admin - Site Configuration - Configure Default FLOCs for Assignments
		(136), 		-- Admin - Site Configuration - Configure Default Tabs
		(141), 		-- Admin - Site Configuration - Configure Work Assignment Not Selected Warning
		(142), 		-- Admin - Site Configuration - Configure Unc Paths for Links
		(179), 		-- Admin - Site Configuration - Configure Priorities Page
		(225), 		-- Admin - Site Configuration - Configure Site Communications
		(237); 		-- Admin - Site Configuration - Configure Functional Locations

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Manager Role Elements (Id = 254)

set @RoleId = 254;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(2), 				-- Action Items - Approve Action Item Definition
		(3), 				-- Action Items - Reject Action Item Definition
		(4), 				-- Action Items - Create Action Item Definition
		(6), 				-- Action Items - Edit Action Item Definition
		(8), 				-- Action Items - Delete Action Item Definition
		(10), 			-- Action Items - Comment Action Item Definition
		(40), 			-- Action Items - Respond to Action Item
		
		(272),		-- Action Items & Targets - Set Operational Modes

		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(269), 		-- Directives - Create Directives
		(270), 		-- Directives - Edit Directives
		(271), 		-- Directives - Delete Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(266), 		-- Events - Respond to Excursion
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
		(131),		-- Lab Alerts - Create Lab Alert Definition
		(132),		-- Lab Alerts - Edit Lab Alert Definition
		(133),		-- Lab Alerts - Delete Lab Alert Definition
		(134),		-- Lab Alerts - Respond To Lab Alert
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		
		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223); 		-- Shift Handovers - View Priorities - Shift Handovers

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Supervisor Role Elements (Id = 255)

set @RoleId = 255;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(2), 				-- Action Items - Approve Action Item Definition
		(3), 				-- Action Items - Reject Action Item Definition
		(4), 				-- Action Items - Create Action Item Definition
		(6), 				-- Action Items - Edit Action Item Definition
		(8), 				-- Action Items - Delete Action Item Definition
		(10), 			-- Action Items - Comment Action Item Definition
		(11),			-- Action Items - Toggle Approval Required for Action Item Definition
		(40), 			-- Action Items - Respond to Action Item
		
		(272),		-- Action Items & Targets - Set Operational Modes
		
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(269), 		-- Directives - Create Directives
		(270), 		-- Directives - Edit Directives
		(271), 		-- Directives - Delete Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(266), 		-- Events - Respond to Excursion
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
		(131),		-- Lab Alerts - Create Lab Alert Definition
		(132),		-- Lab Alerts - Edit Lab Alert Definition
		(133),		-- Lab Alerts - Delete Lab Alert Definition
		(134),		-- Lab Alerts - Respond To Lab Alert
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log
		(235),		-- Logs - Copy Log
		(236),		-- Logs - Add Shift Information

		(88), 			-- Logs - Summary Logs - View Summary Logs
		(89),			-- Logs - Summary Logs - Create Summary Logs
		(92),			-- Logs - Summary Logs - Edit Summary Logs
		(95),			-- Logs - Summary Logs - Delete Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223), 		-- Shift Handovers - View Priorities - Shift Handovers
		(115), 		-- Shift Handovers - Create Shift Handover Questionnaire
		(116), 		-- Shift Handovers - Edit Shift Handover Questionnaire
		(117); 		-- Shift Handovers - Delete Shift Handover Questionnaire

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Coordinator Role Elements (Id = 256)

set @RoleId = 256;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(2), 				-- Action Items - Approve Action Item Definition
		(3), 				-- Action Items - Reject Action Item Definition
		(4), 				-- Action Items - Create Action Item Definition
		(6), 				-- Action Items - Edit Action Item Definition
		(8), 				-- Action Items - Delete Action Item Definition
		(10), 			-- Action Items - Comment Action Item Definition
		(40), 			-- Action Items - Respond to Action Item
		
		(272),		-- Action Items & Targets - Set Operational Modes
		
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(269), 		-- Directives - Create Directives
		(270), 		-- Directives - Edit Directives
		(271), 		-- Directives - Delete Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(266), 		-- Events - Respond to Excursion
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
		(131),		-- Lab Alerts - Create Lab Alert Definition
		(132),		-- Lab Alerts - Edit Lab Alert Definition
		(133),		-- Lab Alerts - Delete Lab Alert Definition
		(134),		-- Lab Alerts - Respond To Lab Alert
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log
		(235),		-- Logs - Copy Log
		(236),		-- Logs - Add Shift Information

		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223), 		-- Shift Handovers - View Priorities - Shift Handovers
		(115), 		-- Shift Handovers - Create Shift Handover Questionnaire
		(116), 		-- Shift Handovers - Edit Shift Handover Questionnaire
		(117); 		-- Shift Handovers - Delete Shift Handover Questionnaire

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Quality Specialist Role Elements (Id = 257)

set @RoleId = 257;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(1), 				-- Action Items - View Action Item Definition
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(2), 				-- Action Items - Approve Action Item Definition
		(3), 				-- Action Items - Reject Action Item Definition
		(4), 				-- Action Items - Create Action Item Definition
		(6), 				-- Action Items - Edit Action Item Definition
		(8), 				-- Action Items - Delete Action Item Definition
		(10), 			-- Action Items - Comment Action Item Definition
		
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		(269), 		-- Directives - Create Directives
		(270), 		-- Directives - Edit Directives
		(271), 		-- Directives - Delete Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		(266), 		-- Events - Respond to Excursion
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
		(131),		-- Lab Alerts - Create Lab Alert Definition
		(132),		-- Lab Alerts - Edit Lab Alert Definition
		(133),		-- Lab Alerts - Delete Lab Alert Definition
		(134),		-- Lab Alerts - Respond To Lab Alert
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log
		(235),		-- Logs - Copy Log
		(236),		-- Logs - Add Shift Information

		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223); 		-- Shift Handovers - View Priorities - Shift Handovers

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Technician Role Elements (Id = 258)

set @RoleId = 258;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(40), 			-- Action Items - Respond to Action Item
		
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log

		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223); 		-- Shift Handovers - View Priorities - Shift Handovers

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- Lab Laborer Role Elements (Id = 259)

set @RoleId = 259;
delete from @ListOfRoleElementIds;
insert into @ListOfRoleElementIds values 
		(39), 			-- Action Items - View Action Item
		(210), 		-- Action Items - View Navigation - Action Items
		(218), 		-- Action Items - View Priorities - Action Items
		(273), 		-- Action Items - View Future Action Items
		(40), 			-- Action Items - Respond to Action Item
		
		(231), 		-- Directives - View Navigation - Directives
		(232), 		-- Directives - View Directives - Future
		(267), 		-- Directives - View Priorities - Directives
		(268), 		-- Directives - View Directives
		
		(264), 		-- Events - View Navigation - Events
		(265), 		-- Events - View Priorities - Events
		
		(207),		-- Forms - View Form
		(217),		-- Forms - View Navigation - Forms
		(221),		-- Forms - View Priorities - Forms
		(275),		-- Forms - View Priorities - Document Suggestion
		
		(130),		-- Lab Alerts - View Lab Alert Definitions and Lab Alerts
		(215),		-- Lab Alerts - View Navigation - Lab Alerts
				
		(33), 			-- Logs - View Log, Administrator
		(212), 		-- Logs - View Navigation - Logs
		(32), 			-- Logs - Create Log
		(34), 			-- Logs - Edit Log
		(35), 			-- Logs - Delete Log
		(51), 			-- Logs - Reply To Log

		(88), 			-- Logs - Summary Logs - View Summary Logs
		
		(114), 		-- Shift Handovers - View Shift Handover
		(214), 		-- Shift Handovers - View Navigation - Shift Handovers
		(223); 		-- Shift Handovers - View Priorities - Shift Handovers

insert into RoleElementTemplate (RoleElementId, RoleId) 
select RoleElementIds, @RoleId 
from @ListOfRoleElementIds;

-- PE Administrator Role Elements (Id = 260)
-- PE Process Engineer Role Elements (Id = 261)
-- PE Area Manager Role Elements (Id = 262)
-- PE CRS Operator Role Elements (Id = 263)
-- PE Manager Role Elements (Id = 264)
-- PE Field Operator Role Elements (Id = 265)
-- PE Reliability Engineer Role Elements (Id = 266)
-- PE Shift Supervisor Role Elements (Id = 267)
-- PE Operations Coordinator Role Elements (Id = 268)

-- EU Administrator Role Elements (Id = 269)
-- EU Operations Manager Role Elements (Id = 270)
-- EU Operations Area Manager Role Elements (Id = 271)
-- EU Chief Engineer Role Elements (Id = 272)
-- EU Operations Coordinator Role Elements (Id = 273)
-- EU Operations Supervisor Role Elements (Id = 274)
-- EU Operator Role Elements (Id = 275)
-- EU Maintenance Area Manager Role Elements (Id = 276)
-- EU Maintenance Coordinator Role Elements (Id = 277)
-- EU Maintenance Supervisor Role Elements (Id = 278)
-- EU Process Engineer Role Elements (Id = 279)
-- EU Process Engineer Target Admin Role Elements (Id = 280)
-- EU Reliability Engineer Role Elements (Id = 281)

-- TD Operator Role Elements (Id = 282)
-- TD Operations Coordinator Role Elements (Id = 283)

-- SE Administrator Role Elements (Id = 284)
-- SE Manager Role Elements (Id = 285)
-- SE Supervisor Role Elements (Id = 286)
-- SE Technical SME Role Elements (Id = 287)
-- SE Coordinator Role Elements (Id = 288)
-- SE Control Room Specialist Role Elements (Id = 289)
-- SE Operator Role Elements (Id = 290)
-- SE Engineer Role Elements (Id = 291)
-- SE Maintenance Area Manager Role Elements (Id = 292)
-- SE Maintenance Supervisor Role Elements (Id = 293)
-- SE Operator Trainee Role Elements (Id = 294)

-- TA Administrator Role Elements (Id = 295)
-- TA Trainer Role Elements (Id = 296)
-- TA Operations Manager Role Elements (Id = 297)
-- TA Area Manager Role Elements (Id = 298)
-- TA Coordinator Role Elements (Id = 299)
-- TA Shift Supervisor Role Elements (Id = 300)
-- TA Operator Role Elements (Id = 301)
-- TA Planner Role Elements (Id = 302)
-- TA Maintenance Manager Role Elements (Id = 303)
-- TA Maintenance Area Manager Role Elements (Id = 304)
-- TA Maintenance Coordinator Role Elements (Id = 305)
-- TA Maintenance Supervisor Role Elements (Id = 306)
-- TA Maintenance Tech Role Elements (Id = 307)
-- TA Process Engineer Role Elements (Id = 308)
-- TA Reliability Engineer Role Elements (Id = 309)
-- TA Maintenance Contractor Manager Role Elements (Id = 310)
-- TA Maintenance Contractor Coordinator Role Elements (Id = 311)
-- TA Maintenance Contractor Supervisor Role Elements (Id = 312)

-- Mining Trainer Role Elements (Id = 313)
-- Mining Operations Manager Role Elements (Id = 314)
-- Mining Area Manager Role Elements (Id = 315)
-- Mining Coordinator Role Elements (Id = 316)
-- Mining Shift Supervisor Role Elements (Id = 317)
-- Mining Operator Role Elements (Id = 318)
-- Mining Maintenance Manager Role Elements (Id = 319)
-- Mining Maintenance Area Manager Role Elements (Id = 320)
-- Mining Maintenance Coordinator Role Elements (Id = 321)
-- Mining Maintenance Supervisor Role Elements (Id = 322)
-- Mining Maintenance Tech Role Elements (Id = 323)
-- Mining Engineer Role Elements (Id = 324)
-- Mining Maintenance Contractor Manager Role Elements (Id = 325)
-- Mining Maintenance Contractor Coordinator Role Elements (Id = 326)
-- Mining Maintenance Contractor Supervisor Role Elements (Id = 327)

-- NPA Manager Role Elements (Id = 328)
-- NPA Supervisor Role Elements (Id = 329)
-- NPA Coordinator Role Elements (Id = 330)

GO

-------------------------------- Work Assignments Start --------------------------------------

-- WorkAssignment: Max 40 chars for name, 75 for description, 75 for category

-- General:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Fort Hills Administrator','Fort Hills Administrator',15, 0, 250, 'General', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Fort Hills Read Only','Fort Hills Read Only',15, 0, 251, 'General', 1, 1, 0, 1);

-- Labs:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH GC','FH GC Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH RMN','FH RMN Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Extraction','FH Extraction Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Oil','FH Oil Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Analytical','FH Analytical Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Water','FH Water Lab Tech',15, 0, 258, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Sample','FH Sample Lab Laborer',15, 0, 259, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Lab Administrator','FH Lab Administrator',15, 0, 253, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Lab Manager','FH Lab Manager',15, 0, 254, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Lab Supervisor','FH Lab Supervisor',15, 0, 255, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Lab Coordinator','FH Lab Coordinator',15, 0, 256, 'Labs', 1, 1, 0, 1);

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('FH Lab Quality Specialist','FH Lab Quality Specialist',15, 0, 257, 'Labs', 1, 1, 0, 1);

-- Primary Extraction:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Administrator','Administrator',15, 0, 260, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Administrator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Maintenance Supervisor','Maintenance Supervisor',15, 0, 267, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Maintenance Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Maintenance Area Manager','Area Manager - Maintenance',15, 0, 262, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Maintenance Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Maintenance Manager','Manager - Maintenance',15, 0, 264, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Maintenance Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Maintenance Coordinator','Maintenance - Coordinator',15, 0, 268, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Maintenance Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Process Engineer','Process Engineer',15, 0, 266, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Process Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Operations Manager','Operations - Manager',15, 0, 264, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Area Manager - Ops','Operations - Area Manager',15, 0, 262, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Area Manager - Ops' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Operations Coordinator','Operations Coordinator',15, 0, 268, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Operations Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Shift Supervisor - Ops','Operations - Shift Supervisor',15, 0, 267, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Shift Supervisor - Ops' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Control Room Specialist','Control Room Specialist',15, 0, 267, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Control Room Specialist' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext E&T Outside Operator','E&T Outside Operator',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext E&T Outside Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext E&T Inside Operator','E&T Inside Operator',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext E&T Inside Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext OPP Wet Side Operator #1','OPP Wet Side Operator #1',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext OPP Wet Side Operator #1' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext OPP Wet Side Operator #2','OPP Wet Side Operator #2',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext OPP Wet Side Operator #2' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext OPP Dry Side Operator #1','OPP Dry Side Operator #1',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext OPP Dry Side Operator #1' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext OPP Dry Side Operator #2','OPP Dry Side Operator #2',15, 0, 265, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext OPP Dry Side Operator #2' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Primary Ext Maint Reliability Engineer','Maintenance Reliability Engineer',15, 0, 266, 'Primary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Primary Ext Maint Reliability Engineer' and a.SiteId = 15;

-- Utilities:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Administrator','Utilities Administrator',15, 0, 269, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Administrator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operations Manager','Utilities Operations Manager',15, 0, 270, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operations Area Manager','Utilities Operations Area Manager',15, 0, 270, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operations Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Chief Steam Engineer','Utilities Chief Steam Engineer',15, 0, 272, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Chief Steam Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operations Coordinator','Utilities Operations Coordinator',15, 0, 273, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operations Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operations Day Supervisor','Utilities Operations Day Supervisor',15, 0, 274, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operations Day Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operations Shift Supervisor','Utilities Operations Shift Supervisor',15, 0, 274, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operations Shift Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities CRS - Boilers/Water Treatment','Utilities CRS - Boilers/Water Treatment',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities CRS - Boilers/Water Treatment' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities CRS - Process Water/Cogen','Utilities CRS - Process Water/Cogen',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities CRS - Process Water/Cogen' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - Cogen','Utilities Operator - Cogen',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - Cogen' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - Boiler/Steam','Utilities Operator - Boiler/Steam',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - Boiler/Steam' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - Water Treatment','Utilities Operator - Water Treatment',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - Water Treatment' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - Condensate Recovery','Utilities Operator - Condensate Recovery',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - Condensate Recovery' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - Process Water','Utilities Operator - Process Water',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - Process Water' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Operator - River Water','Utilities Operator - River Water',15, 0, 275, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Operator - River Water' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Maint E&I Supervisor','Utilities Maintenance E&I Supervisor',15, 0, 278, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Maint E&I Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Maint Mechanical Supervisor','Utilities Maintenance Mechanical Supervisor',15, 0, 278, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Maint Mechanical Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Maint Manager','Utilities Maintenance Manager',15, 0, 276, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Maint Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Maint Area Manager','Utilities Maintenance Area Manager',15, 0, 276, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Maint Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Maint Coordinator','Utilities Maintenance Coordinator',15, 0, 277, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Maint Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Process Engineer Target Admin','Utilities Process Engineer Target Admin',15, 0, 280, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Process Engineer Target Admin' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Process Engineer','Utilities Process Engineer',15, 0, 279, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Process Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Utilities Reliability Engineer','Utilities Reliability Engineer',15, 0, 281, 'Utilities', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Utilities Reliability Engineer' and a.SiteId = 15;

-- T&D:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('T&D - Control Room Tech','T&D - Control Room Tech',15, 0, 282, 'T&D', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'T&D - Control Room Tech' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('T&D - Permit Coordinator','T&D - Permit Coordinator',15, 0, 283, 'T&D', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'T&D - Permit Coordinator' and a.SiteId = 15;

-- Secondary Extraction:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Administrator','Administrator',15, 0, 295, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Administrator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Operations Manager','Operations Manager',15, 0, 285, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Area Manager','Area Manager',15, 0, 285, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Technical SME','Technical SME',15, 0, 285, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Technical SME' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Operations Coordinator','Operations Coordinator',15, 0, 288, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Operations Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Shift Supervisor','Shift Supervisor',15, 0, 286, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Shift Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Control Room Specialist','Control Room Specialist',15, 0, 289, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Control Room Specialist' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext FSU/TSRU Operator Train 1','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext FSU/TSRU Operator Train 1' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext FSU/TSRU Operator Train 2','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext FSU/TSRU Operator Train 2' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext FSU/TSRU Operator Train 3','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext FSU/TSRU Operator Train 3' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext SRU Operator Train 1','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext SRU Operator Train 1' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext SRU Operator Train 2','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext SRU Operator Train 2' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Flare Operator','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Flare Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext 2nd Stage TSRU Operator','Fixed Plant Operator',15, 0, 290, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext 2nd Stage TSRU Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Operator Trainee','Fixed Plant Operator',15, 0, 294, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Operator Trainee' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Process Engineer','Engineering',15, 0, 291, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Process Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Reliability Engineer','Engineering',15, 0, 291, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Reliability Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Maintenance Area Manager','Maintenance Manager',15, 0, 292, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Maintenance Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Secondary Ext Maintenance Supervisor','Maintenance Supervisor',15, 0, 293, 'Secondary Extraction', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Secondary Ext Maintenance Supervisor' and a.SiteId = 15;

-- Tailings:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Administrator','Administrator',15, 0, 295, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Administrator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings FT Operations Manager','Operations Manager',15, 0, 297, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings FT Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings CT Operations Manager','Operations Manager',15, 0, 297, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings CT Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings FT Area Manager','Area Manager',15, 0, 298, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings FT Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings CT Area Manager','Area Manager',15, 0, 298, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings CT Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings FT Coordinator','Operations Coordinator',15, 0, 299, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings FT Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings CT Coordinator','Operations Coordinator',15, 0, 299, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings CT Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings FT Shift Supervisor','Shift Supervisor',15, 0, 300, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings FT Shift Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings CT Shift Supervisor','Shift Supervisor',15, 0, 300, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings CT Shift Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings FT Operator','Field Operator',15, 0, 301, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings FT Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings CT Operator','Field Operator',15, 0, 301, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings CT Field Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Planner','Planner',15, 0, 302, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Planner' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Manager','Maint Manager',15, 0, 303, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Area Manager','Maint Area Manager',15, 0, 304, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Coordinator','Maint Coord',15, 0, 305, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Supervisor','Maint Supervisor',15, 0, 306, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Tech','Maint Tech',15, 0, 307, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Tech' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Process Engineer','Process Engineer',15, 0, 308, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Process Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Reliability Engineer','Reliability Engineer',15, 0, 309, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Reliability Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maintenance Contractor VP','Tailings Maintenance Contractor VP',15, 0, 310, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maintenance Contractor VP' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maint Contractor Piping Supt','Tailings Maintenance Contractor Piping Superintendent',15, 0, 310, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maint Contractor Piping Supt' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maint Contractor Civil Supt','Tailings Maintenance Contractor Civil Superintendent',15, 0, 310, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maint Contractor Civil Supt' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maint Contractor Coordinator','Tailings Maintenance Contractor Coordinator',15, 0, 311, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maint Contractor Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Maint Contractor Supervisor','Tailings Maintenance Contractor Supervisor',15, 0, 312, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Maint Contractor Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Tailings Trainer','Tailings Trainer',15, 0, 296, 'Tailings', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Tailings Trainer' and a.SiteId = 15;

-- Mining:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Trainer','Mining Trainer',15, 0, 313, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Trainer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Operations Manager','Operations Manager',15, 0, 314, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Area Manager','Area Manager',15, 0, 315, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Coordinator','Coordinator',15, 0, 316, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Shift Supervisor','Shift Supervisor',15, 0, 317, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Shift Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Operator','Operator',15, 0, 318, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Operator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maintenance Manager','Maintenance Manager',15, 0, 319, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maintenance Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maintenance Area Manager','Maintenance Area Manager',15, 0, 320, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maintenance Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maintenance Coordinator','Maintenance Coordinator',15, 0, 321, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maintenance Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maintenance Supervisor','Maintenance Supervisor',15, 0, 322, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maintenance Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maintenance Tech','Maintenance Tech',15, 0, 323, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maintenance Tech' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Engineer','Mine Engineering Roles',15, 0, 324, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Engineer' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maint Contractor Manager','Maintenance Contractor Management',15, 0, 325, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maint Contractor Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maint Contractor Coordinator','Maintenance Contractor Coordinator',15, 0, 326, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maint Contractor Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('Mining Maint Contractor Supervisor','Maintenance Contractor Supervisor',15, 0, 327, 'Mining', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Mining Maint Contractor Supervisor' and a.SiteId = 15;

-- NPA - Site Services:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Fire Systems Coordinator','Fire Systems Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Fire Systems Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Pressure and Vacuum Coordinator','Pressure and Vacuum Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Pressure and Vacuum Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Site Services Coordinator','Site Services Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Site Services Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Fuel Coordinator','Fuel Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Fuel Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Rental Coordinator','Rental Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Rental Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Radio Coordinator','Radio Coordinator',15, 0, 330, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Radio Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Site Services Supervisor','Site Services Supervisor',15, 0, 329, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Site Services Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Site Services Manager','Site Services Manager',15, 0, 328, 'NPA - Site Services', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Site Services Manager' and a.SiteId = 15;

-- NPA - Operations:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Roads and Grounds Coordinator','Roads and Grounds Coordinator',15, 0, 330, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Roads and Grounds Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Operations Manager','Operations Manager',15, 0, 328, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Operations Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Utilities Coordinator','Utilities Coordinator',15, 0, 330, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Utilities Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Building Services Coordinator','Building Services Coordinator',15, 0, 330, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Building Services Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Permit Coordinator','Permit Coordinator',15, 0, 330, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Permit Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Ground Disturbance Coordinator','Ground Disturbance Coordinator',15, 0, 330, 'NPA - Operations', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Ground Disturbance Coordinator' and a.SiteId = 15;

-- NPA - Maintenance:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Maintenance Manager','Maintenance Manager',15, 0, 328, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Maintenance Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Area Manager','Area Manager',15, 0, 328, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Area Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Maint Coordinator - ISBM','Maintenance Coordinator - ISBM',15, 0, 330, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Maint Coordinator - ISBM' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Maint Coordinator - OSBL','Maintenance Coordinator - OSBL',15, 0, 330, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Maint Coordinator - OSBL' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Maint Coordinator - HVAC','Maintenance Coordinator - HVAC',15, 0, 330, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Maint Coordinator - HVAC' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Maint Coordinator - Doors/Cranes','Maintenance Coordinator - Doors/Cranes',15, 0, 330, 'NPA - Maintenance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Maint Coordinator - Doors/Cranes' and a.SiteId = 15;

-- NPA - Planning & Compliance:
insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Planning & Compliance Manager','Planning & Compliance Manager',15, 0, 328, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Planning & Compliance Manager' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Infrastructure Long Range Planner','Infrastructure Long Range Planner',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Infrastructure Long Range Planner' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Infrastructure Short Range Planner','Infrastructure Short Range Planner',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Infrastructure Short Range Planner' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Infrastructure Supervisor','Infrastructure Supervisor',15, 0, 329, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Infrastructure Supervisor' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Facilities Coordinator (CAFM)','Facilities Coordinator (CAFM)',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Facilities Coordinator (CAFM)' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Logistics Coordinator','Logistics Coordinator',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Logistics Coordinator' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Facilities Coordinator (MAC)','Facilities Coordinator (MAC)',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Facilities Coordinator (MAC)' and a.SiteId = 15;

insert into WorkAssignment (Name, Description, SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) values ('NPA Infrastructure Project Coordinator','Infrastructure Project Coordinator',15, 0, 330, 'NPA - Planning & Compliance', 1, 1, 0, 1);

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'NPA Infrastructure Project Coordinator' and a.SiteId = 15;

GO

-------------------------------- Work Assignment Functional Locations Start --------------------------------------

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Fort Hills Administrator' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'Fort Hills Read Only' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH GC' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH RMN' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Extraction' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Oil' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Analytical' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Water' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Sample' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Lab Administrator' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Lab Manager' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Lab Supervisor' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Lab Coordinator' and a.SiteId = 15;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 15 and f.fullhierarchy = 'FH1' and a.name = 'FH Lab Quality Specialist' and a.SiteId = 15;

GO

-------------------------------- Visibility Group Start --------------------------------------

SET IDENTITY_INSERT [VisibilityGroup] ON;

insert into VisibilityGroup ([Id], [Name], SiteId, IsSiteDefault, [Deleted])
select 22, 'Operations', 15, 1, 0;

SET IDENTITY_INSERT [VisibilityGroup] OFF;

GO

-------------------------------- Work Assignment Visibiliy Group Start --------------------------------------

--------------------------------------------------------------------------------
---  Insert Work Assignment Visibility Group for each Work Assignment   ---
--------------------------------------------------------------------------------

BEGIN TRANSACTION
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			22, -- Operations visibility group for Fort Hills Operations
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=15
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=22 AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			22, -- Operations visibility group for Fort Hills Operations
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=15
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=22 AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)
COMMIT TRANSACTION

GO

