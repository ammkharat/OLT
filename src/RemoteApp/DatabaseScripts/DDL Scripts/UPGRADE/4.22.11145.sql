--**************************************************************************************************** New flocs for PL1 start *********************************************************
--Declare site variables
declare @sitename varchar(100) = 'P&L'
declare @LoginApprev varchar(100) = 'PL1'
declare @siteid bigint = 3


--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;

--declare index to iterate thru the number of plants from the temp table
--declare @index int = 1
--while @index <= @NumberOfPlants 
--Begin
--delete existing flocs 
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join FunctionalLocation on WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'PL1%'
delete from FunctionalLocationOperationalMode from FunctionalLocationOperationalMode inner join FunctionalLocation on FunctionalLocationOperationalMode.UnitId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'PL1%'
--delete Ancestors
delete from FunctionalLocationAncestor from FunctionalLocationAncestor inner join functionallocation on FunctionalLocationAncestor.id = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'PL1%'
delete from UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation inner join FunctionalLocation on UserLoginHistoryFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.SiteId in (3,11,13) and FunctionalLocation.FullHierarchy like 'PL1'
delete from DirectiveFunctionalLocation from DirectiveFunctionalLocation inner join functionallocation on DirectiveFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from ShiftHandoverQuestionnaireFunctionalLocation from ShiftHandoverQuestionnaireFunctionalLocation inner join functionallocation on ShiftHandoverQuestionnaireFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from LogFunctionalLocation from LogFunctionalLocation inner join functionallocation on LogFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join functionallocation on WorkAssignmentFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from FunctionalLocationAncestor from FunctionalLocationAncestor inner join functionallocation on FunctionalLocationAncestor.ancestorid = functionallocation.id and FullHierarchy like 'PL1%'
delete from ActionItemDefinitionFunctionalLocation from ActionItemDefinitionFunctionalLocation inner join functionallocation on ActionItemDefinitionFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from ActionItemFunctionalLocation from ActionItemFunctionalLocation inner join functionallocation on ActionItemFunctionalLocation.functionallocationid = functionallocation.id and FullHierarchy like 'PL1%'
delete from FunctionalLocationOperationalMode from FunctionalLocationOperationalMode inner join functionallocation on FunctionalLocationOperationalMode.unitid = functionallocation.id and FullHierarchy like 'PL1%'
delete FunctionalLocation where FullHierarchy like 'PL1%'

	INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Planning and Logistics', 'PL1', 0, 0, 1, 1200, N'en', 2)
	INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'General', N'PL1-General', 0, 0, 2,1200 , N'en', 2)
	INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Sub General', N'PL1-Sub-General', 0, 0, 3, 1200, N'en', 2)
--	set @index = @index + 1
--End

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
go
declare @siteid bigint = 3

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
			SiteId = @siteid
			AND Level = 3
			AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
	)


----------------------------------------------------
----  Update Ancestor Table                           ---
----------------------------------------------------
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
go
declare @siteid bigint = 3

--Add the Ancestor
	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
		SELECT 
			c.id, a.id, a.[Level]
			FROM FunctionalLocation a
			INNER JOIN FunctionalLocation c 
				ON c.siteid = a.siteid and 
				c.[Level] > a.[Level] and
				CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
			where
				c.SiteId = @siteid and c.FullHierarchy like 'PL1%'
)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
go


--**************************************************************************************************** New flocs for PL1 end *********************************************************

--PL1 work Assignments for site 3
declare @siteid bigint = 3
declare @sitename varchar(100) = 'P&L'

--delete work assignment
delete from WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup inner join WorkAssignment on WorkAssignmentVisibilityGroup.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.SiteId in (3,11,13) and WorkAssignment.Category = 'P&L'
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join WorkAssignment on WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.SiteId in (3,11,13) and WorkAssignment.Category = 'P&L'

alter table UserLoginHistoryFunctionalLocation nocheck constraint FK_UserLoginHistoryFunctionalLocation_UserLoginHistory

delete from UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation inner join FunctionalLocation on UserLoginHistoryFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy = 'PL1'
delete from userloginhistory from userloginhistory inner join workassignment on userloginhistory.assignmentid = workassignment.id and workassignment.category = 'P&L'
delete userloginhistory from userloginhistory inner join workassignment on userloginhistory.assignmentid = workassignment.id and workassignment.category = 'P&L'
delete from logtemplateworkassignment from logtemplateworkassignment inner join workassignment on logtemplateworkassignment.workassignmentid = workassignment.id and workassignment.category = 'P&L'
alter table LogActionItemAssociation nocheck constraint FK_LogAssociation_ActionItem
delete from actionitem from actionitem inner join workassignment on actionitem.workassignmentid = workassignment.id and workassignment.category = 'P&L'
alter table ActionItemDefinitionHistory nocheck constraint FK_ActionItemDefinitionHistory_ActionItem
delete from actionitemdefinition from actionitemdefinition inner join workassignment on actionitemdefinition.workassignmentid = workassignment.id and workassignment.category = 'P&L'
delete from CustomFieldGroupWorkassignment from CustomFieldGroupWorkassignment inner join workassignment on CustomFieldGroupWorkassignment.workassignmentid = workassignment.id and workassignment.category = 'P&L'
delete from workassignmentfunctionallocation from workassignmentfunctionallocation inner join workassignment on workassignmentfunctionallocation.workassignmentid = workassignment.id and workassignment.category = 'P&L'
delete from ShiftHandoverConfigurationWorkAssignment from ShiftHandoverConfigurationWorkAssignment inner join workassignment on ShiftHandoverConfigurationWorkAssignment.workassignmentid = workassignment.id and workassignment.category = 'P&L'
alter table LogCustomFieldEntryHistory nocheck constraint FK_LogCustomFieldEntryHistory_LogHistory
delete from loghistory from loghistory inner join log on loghistory.id = log.id inner join workassignment on log.workassignmentid = workassignment.id and workassignment.category = 'P&L'
delete from LogFunctionalLocationList from LogFunctionalLocationList inner join log on LogFunctionalLocationList.logid = log.id inner join workassignment on log.workassignmentid = workassignment.id and workassignment.category = 'P&L'
alter table LogCustomFieldEntry nocheck constraint FK_LogCustomFieldEntry_Log
alter table LogCustomFieldGroup nocheck constraint FK_LogCustomFieldGroup_Log
alter table ShiftHandoverQuestionnaireLog nocheck constraint FK_ShiftHandoverQuestionnaireLog_Log
alter table LogActionItemAssociation nocheck constraint FK_LogAssociation_Log
delete from log from log inner join workassignment on log.workassignmentid = workassignment.id and workassignment.category = 'P&L'
alter table ShiftHandoverAnswer nocheck constraint FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire
alter table ShiftHandoverQuestionnaireFunctionalLocationList nocheck constraint FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire
alter table ShiftHandoverQuestionnaireLog nocheck constraint FK_ShiftHandoverQuestionnaireLog_ShiftHandover
alter table ShiftHandoverQuestionnaire nocheck constraint FK_ShiftHandoverQuestionnaire_WorkUnitAssignment
alter table ShiftHandoverQuestionnaireRead nocheck constraint FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire

delete from ShiftHandoverQuestionnaire from ShiftHandoverQuestionnaire inner join workassignment on ShiftHandoverQuestionnaire.workassignmentid = workassignment.id and workassignment.category = 'P&L'

delete WorkAssignment where SiteId in (3,11,13) and WorkAssignment.Category = 'P&L'
alter table UserLoginHistoryFunctionalLocation check constraint FK_UserLoginHistoryFunctionalLocation_UserLoginHistory
alter table LogActionItemAssociation check constraint FK_LogAssociation_ActionItem
alter table ActionItemDefinitionHistory check constraint FK_ActionItemDefinitionHistory_ActionItem
alter table LogCustomFieldEntryHistory check constraint FK_LogCustomFieldEntryHistory_LogHistory
alter table LogCustomFieldEntry check constraint FK_LogCustomFieldEntry_Log
alter table LogCustomFieldGroup check constraint FK_LogCustomFieldGroup_Log
alter table ShiftHandoverQuestionnaireLog check constraint FK_ShiftHandoverQuestionnaireLog_Log
alter table LogActionItemAssociation check constraint FK_LogAssociation_Log
alter table ShiftHandoverAnswer check constraint FK_ShiftHandoverAnswer_ShiftHandoverQuestionnaire
alter table ShiftHandoverQuestionnaireFunctionalLocationList check constraint FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire
alter table ShiftHandoverQuestionnaireLog check constraint FK_ShiftHandoverQuestionnaireLog_ShiftHandover
alter table ShiftHandoverQuestionnaire check constraint FK_ShiftHandoverQuestionnaire_WorkUnitAssignment
alter table ShiftHandoverQuestionnaireRead check constraint FK_ShiftHandoverQuestionnaireRead_ShiftHandoverQuestionnaire

--Insert work assignment
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--('Administrator','Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'General', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator','Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator','Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator','Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator','Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator','Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
--insert into WorkAssignment 
--([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
--values (@sitename + ' Production Coordination Manager','Production Coordination Manager',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Manager'), 'P&L', 1, 1, 0, 0);
(@sitename + ' Production Planner','Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT','Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist','Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support','Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
--('Read-Only','Read-Only',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Read User'), 'General', 1, 1, 0, 0);
go

--PL1 work Assignments for site 11 UP3
declare @siteid bigint = 11
declare @sitename varchar(100) = 'P&L'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator','Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator','Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator','Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator','Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator','Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator','Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
--insert into WorkAssignment 
--([Name], [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
--values (@sitename + ' Production Coordination Manager','Production Coordination Manager',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Manager'), 'P&L', 1, 1, 0, 0);
(@sitename + ' Production Planner','Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT','Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist','Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support','Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
--('Read-Only','Read-Only',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Read User'), 'P&L', 1, 1, 0, 0);
go

--PL1 work Assignments for site 13 SELC
declare @siteid bigint = 13
declare @sitename varchar(100) = 'P&L'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
('Administrator','Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'General', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator','Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator','Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator','Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator','Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator','Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Coordination Manager','Production Coordination Manager',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Manager'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner','Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT','Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist','Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support','Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go

--select site.ActiveDirectoryKey,site.Name,FunctionalLocation.* 
--from FunctionalLocation 
--inner join Site on FunctionalLocation.SiteId = site.Id and FunctionalLocation.Level = 1 
--inner join Plant on FunctionalLocation.PlantId = plant.Id
--order by siteid,FullHierarchy
--******************************************************************* Mining *********************************************************************************
--PL1 work Assignments for MN1
declare @siteid bigint = 3
declare @sitename varchar(100) = 'P&L Min'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator',@sitename + ' Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator',@sitename + ' Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator',@sitename + ' Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator',@sitename + ' Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator',@sitename + ' Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator',@sitename + ' Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner',@sitename + ' Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT',@sitename + ' Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist',@sitename + ' Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support',@sitename + ' Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go

--*******************************************************************************Extraction*****************************************************************************
--PL1 work Assignments for EX1
declare @siteid bigint = 3
declare @sitename varchar(100) = 'P&L Ext'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator',@sitename + ' Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator',@sitename + ' Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator',@sitename + ' Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator',@sitename + ' Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator',@sitename + ' Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator',@sitename + ' Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner',@sitename + ' Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT',@sitename + ' Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist',@sitename + ' Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support',@sitename + ' Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go

--*****************************************************************************upgrading******************************************************************************
--PL1 work Assignments for Upgrading
declare @siteid bigint = 3
declare @sitename varchar(100) = 'P&L Up'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator',@sitename + ' Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator',@sitename + ' Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator',@sitename + ' Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator',@sitename + ' Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator',@sitename + ' Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator',@sitename + ' Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner',@sitename + ' Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT',@sitename + ' Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist',@sitename + ' Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support',@sitename + ' Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go

--***************************************************************************SELC***********************************************************************************
--PL1 work Assignments for SELC
declare @siteid bigint = 13
declare @sitename varchar(100) = 'P&L SELC'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator',@sitename + ' Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator',@sitename + ' Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator',@sitename + ' Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator',@sitename + ' Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator',@sitename + ' Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator',@sitename + ' Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Coordination Manager','Production Coordination Manager',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Manager'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner',@sitename + ' Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT',@sitename + ' Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist',@sitename + ' Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support',@sitename + ' Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go
--**********************************************************************upgrader 3 (voyageur)*******************************************************************
--PL1 work Assignments for Upgrading
declare @siteid bigint = 11
declare @sitename varchar(100) = 'P&L Up3'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
--(@sitename + ' Administrator',@sitename + ' Administrator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'Administrator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Bitumen Coordinator',@sitename + ' Bitumen Coordinator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Day Production Coordinator',@sitename + ' Day Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Lead Production Coordinator',@sitename + ' Lead Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Shift Production Coordinator',@sitename + ' Shift Production Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Logistics Coordinator',@sitename + ' Logistics Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Coordinator'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planner',@sitename + ' Production Planner',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Production Planning/Quality EIT',@sitename + ' Production Planning/Quality EIT',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Planner'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Quality Control Specialist',@sitename + ' Quality Control Specialist',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0),
(@sitename + ' Support',@sitename + ' Support',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'P&L Support'), 'P&L', 1, 1, 0, 0);
go

--PL1 work Assignments for Read only sites 5 FB1,8 ED1,7 MR1
--PL1 work Assignments for FB1  ***************************************************** FB1 *****************************************************
declare @siteid bigint = 5
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
('Read-Only','Read-Only',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Read User'), 'P&L', 1, 1, 0, 0);
go
--PL1 work Assignments for ED1  **************************************************** ED1 *****************************************************
declare @siteid bigint = 8
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
('Read-Only','Read-Only',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Read User'), 'P&L', 1, 1, 0, 0);

go
--PL1 work Assignments for MR1 **************************************************** MR1 *****************************************************
declare @siteid bigint = 7
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
('Read-Only','Read-Only',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'Read User'), 'P&L', 1, 1, 0, 0);

go

--insert workassignment function location for Site 3
declare @siteid bigint = 3
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Logistics Coordinator' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = 11 and f.fullhierarchy = 'P&L' and a.name = 'P&L Production Coordination Manager' and a.SiteId = 11;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'P&L Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

go
--insert workassignment function location for MN1 ****************************************** MN1 ******************************************************
declare @siteid bigint = 3
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'MN1' and a.name = 'P&L Min Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

go

--insert workassignment function location for EX1 ****************************************** EX1 ******************************************************
declare @siteid bigint = 3
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'EX1' and a.name = 'P&L Ext Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

go
--insert workassignment function location for Upgrading ****************************************** upgrading ******************************************************
declare @siteid bigint = 3
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP1' and a.name = 'P&L Up Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

-- up2
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP2' and a.name = 'P&L Up Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;


go
--insert workassignment function location for SELC ****************************************** SELC ******************************************************
declare @siteid bigint = 13
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Production Coordination Manager' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'SE1' and a.name = 'P&L SELC Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

go
--insert workassignment function location for Upgrader 3 ****************************************** Upgrader 3 ******************************************************
declare @siteid bigint = 11
--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'Administrator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Bitumen Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Day Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Lead Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Shift Production Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Logistics Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Production Planner' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Production Planning/Quality EIT' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Quality Control Specialist' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'UP3' and a.name = 'P&L Up3 Support' and a.SiteId = @siteid;

--insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
--select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'PL1' and a.name = 'Read-Only' and a.SiteId = @siteid;

go


--************************************************************** work assignment visibility group ********************************************************

declare @siteid bigint = 3
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name = 'Operations'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name = 'Operations') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name = 'Operations'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name = 'Operations') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)

go

declare @siteid bigint = 11
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)
go

declare @siteid bigint = 13
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)

go
declare @siteid bigint = 8
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)

go
declare @siteid bigint = 5
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)

go
declare @siteid bigint = 7
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%'), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid and wa.Category = 'P&L'
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid and Name like '%Operations%') AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)


go

--Security Role Matrix for siteid 3
if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId=231)
begin
insert into RoleElementTemplate values (1,231)
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (39,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (210,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (218,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (2,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (3,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (4,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (6,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (8,231) 
end 


if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (10,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (11,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (1,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (39,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (210,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (218,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (2,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (3,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (4,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (6,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (8,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (10,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (11,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (1,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (39,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (210,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (218,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (2,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (3,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (4,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (6,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (8,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (10,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (11,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (1,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (39,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (210,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (218,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (1,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (231,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (232,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (267,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (268,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (269,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (270,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (271,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (231,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (232,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (267,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (268,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (269,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (270,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (271,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (231,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (232,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (267,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (268,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (269,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (270,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (271,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (231,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (232,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (267,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (268,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (33,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (33,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (33,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (33,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (212,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (212,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (212,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (212,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (220,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (220,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (220,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (220,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (88,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (88,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (88,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (88,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (114,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (114,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (114,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (114,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (214,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (214,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (214,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (214,234) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 231)
begin
insert into RoleElementTemplate values (223,231) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 232)
begin
insert into RoleElementTemplate values (223,232) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 233)
begin
insert into RoleElementTemplate values (223,233) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 234)
begin
insert into RoleElementTemplate values (223,234) 
end 


--Site 11

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (1,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (39,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (210,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (218,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (2,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (3,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (4,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (6,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (8,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (10,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (11,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (1,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (39,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (210,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (218,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (2,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (3,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (4,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (6,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (8,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (10,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (11,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (1,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (39,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (210,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (218,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (2,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (3,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (4,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (6,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (8,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (10,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (11,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (1,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (39,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (210,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (218,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (231,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (232,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (267,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (268,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (269,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (270,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (271,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (231,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (232,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (267,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (268,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (269,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (270,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (271,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (231,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (232,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (267,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (268,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (269,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (270,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (271,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (231,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (232,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (267,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (268,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (33,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (33,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (33,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (33,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (212,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (212,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (212,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (212,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (220,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (220,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (220,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (220,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (88,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (88,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (88,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (88,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (114,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (114,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (114,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (114,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (214,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (214,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (214,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (214,238) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 235)
begin
insert into RoleElementTemplate values (223,235) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 236)
begin
insert into RoleElementTemplate values (223,236) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 237)
begin
insert into RoleElementTemplate values (223,237) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 238)
begin
insert into RoleElementTemplate values (223,238) 
end 

go
----SELC siteid 13

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (1,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (39,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (210,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (218,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (2,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (3,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (4,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (6,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (8,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (10,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (11,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (1,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (39,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (210,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (218,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (2,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (3,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (4,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (6,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (8,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (10,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (11,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (1,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (39,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (210,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (218,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 2 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (2,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 3 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (3,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 4 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (4,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 6 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (6,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 8 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (8,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 10 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (10,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 11 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (11,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 1 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (1,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 39 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (39,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 210 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (210,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 218 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (218,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (231,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (232,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (267,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (268,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (269,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (270,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (271,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (231,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (232,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (267,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (268,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (269,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (270,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (271,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (231,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (232,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (267,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (268,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 269 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (269,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 270 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (270,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 271 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (271,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 231 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (231,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 232 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (232,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 267 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (267,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 268 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (268,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (33,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (33,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (33,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 33 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (33,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (212,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (212,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (212,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 212 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (212,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (220,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (220,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (220,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 220 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (220,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (88,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (88,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (88,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 88 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (88,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (114,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (114,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (114,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 114 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (114,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (214,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (214,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (214,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 214 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (214,229) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 226)
begin
insert into RoleElementTemplate values (223,226) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 227)
begin
insert into RoleElementTemplate values (223,227) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 228)
begin
insert into RoleElementTemplate values (223,228) 
end 

if not exists(select * from RoleElementTemplate where RoleElementTemplate.RoleElementId = 223 and RoleElementTemplate.RoleId = 229)
begin
insert into RoleElementTemplate values (223,229) 
end 




GO

