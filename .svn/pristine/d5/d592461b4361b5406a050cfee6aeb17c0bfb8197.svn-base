--Declare site variables
declare @sitename varchar(100) = 'TLP'
declare @LoginApprev varchar(100) = 'TLP'
declare @siteid bigint = 11
--declare @NumberOfPlants bigint 
--create temp table to hold the plant id values
--declare @tmpplantid table (id int, plantid bigint)
--insert into @tmpplantid
--SELECT ROW_NUMBER() OVER(ORDER BY plant.id) AS Row,plant.Id
--FROM Plant where SiteId = @siteid
SET IDENTITY_INSERT dbo.Plant ON;
if not exists(select 1 from Plant where Plant.Id = 1365)
begin
INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (1365, 'TLP', 11)
end
SET IDENTITY_INSERT dbo.Plant OFF;

--get how many plant belongs to the same site
--select @NumberOfPlants =  count(1) from plant where siteid = @siteid  
delete from FunctionalLocationAncestor from FunctionalLocationAncestor inner join FunctionalLocation on FunctionalLocationAncestor.AncestorId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'TLP%'
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join FunctionalLocation on WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'TLP%'
delete from FunctionalLocationOperationalMode from FunctionalLocationOperationalMode inner join FunctionalLocation on FunctionalLocationOperationalMode.UnitId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'TLP%'
delete from UserLoginHistoryFunctionalLocation from UserLoginHistoryFunctionalLocation inner join FunctionalLocation on UserLoginHistoryFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id and FunctionalLocation.FullHierarchy like 'TLP%'
delete from FunctionalLocation where FullHierarchy like 'TLP%'
--- temporarily disable all floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] DISABLE;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] DISABLE;

--declare index to iterate thru the number of plants from the temp table
--declare @index int = 1
--while @index <= @NumberOfPlants 
--Begin
	INSERT INTO [dbo].[FunctionalLocation] (SiteId, [Description], FullHierarchy, OutOfService, Deleted, [Level], PlantId, Culture, Source) VALUES (@siteid, N'Thebacha Limited Partnership', 'TLP', 0, 0, 1, 1365, N'en', 2)
--	set @index = @index + 1
--End

--- re-enable disabled floc indexes to speed up bulk insert
ALTER INDEX [IDX_FunctionalLocation_Level] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_SiteId] ON [dbo].[FunctionalLocation] REBUILD;
ALTER INDEX [IDX_FunctionalLocation_Unique_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation] REBUILD;
go
declare @siteid bigint = 11
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
declare @siteid bigint = 11

	INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId], [AncestorLevel] ) (
		SELECT 
			c.id, a.id, a.[Level]
			FROM FunctionalLocation a
			INNER JOIN FunctionalLocation c 
				ON c.siteid = a.siteid and 
				c.[Level] > a.[Level] and
				CHARINDEX(a.FullHierarchy + '-', c.fullhierarchy) = 1
			where
				c.SiteId = @siteid and c.FullHierarchy like 'TLP%'
)

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
go
declare @siteid bigint = 11
declare @sitename varchar(100) = 'TLP'

delete from RoleElementTemplate from RoleElementTemplate inner join Role on RoleElementTemplate.RoleId = role.Id and role.SiteId = 11 and role.Name like 'TLP%'
delete WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup inner join WorkAssignment on WorkAssignmentVisibilityGroup.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.Category = 'TLP'
delete UserLoginHistory from UserLoginHistory inner join WorkAssignment on UserLoginHistory.AssignmentId = WorkAssignment.Id and WorkAssignment.Category='TLP'
delete WorkAssignment where Category='TLP'
delete from Role where Name like 'TLP%'

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Operator', 0, 'TLPOperator', @siteid, 0, 0, 0, 1, 'tlpoper',0);
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Area Manager
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Area Manager


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Shift Supervisor', 0, 'TLPShiftSupervisor', @siteid, 0, 0, 0, 1, 'tlpshiftsup',0);
-- Operating / Chief Engineer Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (2,IDENT_CURRENT('ROLE')); 				-- Action Items - Approve Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (3,IDENT_CURRENT('ROLE')); 				-- Action Items - Reject Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (4,IDENT_CURRENT('ROLE')); 				-- Action Items - Create Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (6,IDENT_CURRENT('ROLE')); 				-- Action Items - Edit Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (8,IDENT_CURRENT('ROLE')); 				-- Action Items - Delete Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (11,IDENT_CURRENT('ROLE')); 			-- Action Items - Toggle Approval Required for Action Item Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (63,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (64,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (65,IDENT_CURRENT('ROLE')); 			-- Logs - Cancel Log Flagged as Operating Engineer Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - Process SAP Notifications, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operating / Chief Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operating / Chief Engineer




insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Coordinator', 0, 'TLPCoordinator', @siteid, 0, 0, 0, 1, 'tlpcoord',0);
-- Operator Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - Process SAP Notifications, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (115,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Create Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (116,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Edit Shift Handover Questionnaire, Operator
insert into RoleElementTemplate (RoleElementId, RoleId) values (117,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - Delete Shift Handover Questionnaire, Operator



insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Engineer', 0, 'TLPEngineer', @siteid, 0, 0, 0, 1, 'tlpengineer',0);
-- Production Engineer Role Elements
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (10,IDENT_CURRENT('ROLE')); 			-- Action Items - Comment Action Item Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (40,IDENT_CURRENT('ROLE')); 			-- Action Items - Respond to Action Item, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (269,IDENT_CURRENT('ROLE')); 		-- Directives - Create Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (270,IDENT_CURRENT('ROLE')); 		-- Directives - Edit Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (271,IDENT_CURRENT('ROLE')); 		-- Directives - Delete Directives, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (266,IDENT_CURRENT('ROLE')); 		-- Events - Respond to Excursion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (276,IDENT_CURRENT('ROLE')); 		-- Forms - Create Form - Document Suggestion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (277,IDENT_CURRENT('ROLE')); 		-- Forms - Edit Form - Document Suggestion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (278,IDENT_CURRENT('ROLE')); 		-- Forms - Approve Form - Document Suggestion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (279,IDENT_CURRENT('ROLE')); 		-- Forms - Delete Form - Document Suggestion, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (54,IDENT_CURRENT('ROLE')); 			-- Logs - View Log Definitions, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (32,IDENT_CURRENT('ROLE')); 			-- Logs - Create Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (34,IDENT_CURRENT('ROLE')); 			-- Logs - Edit Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (35,IDENT_CURRENT('ROLE')); 			-- Logs - Delete Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (51,IDENT_CURRENT('ROLE')); 			-- Logs - Reply To Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (176,IDENT_CURRENT('ROLE')); 		-- Logs - Cancel Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (187,IDENT_CURRENT('ROLE')); 		-- Logs - Create Log Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (188,IDENT_CURRENT('ROLE')); 		-- Logs - Edit Log Definition, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (235,IDENT_CURRENT('ROLE')); 		-- Logs - Copy Log, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (236,IDENT_CURRENT('ROLE')); 		-- Logs - Add Shift Information, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (48,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - Process SAP Notifications, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Production Engineer
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Production Engineer


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Read User', 0, 'TLPReadUser', @siteid, 0, 1, 0, 0, 'tlpreaduser', 1);
--insert role elements for read user
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User

insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Team Lead', 0, 'TLPTeamLead', @siteid, 0, 1, 0, 0, 'tlpteamlead', 1);
--insert role elements for read user
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Manager', 0, 'TLPManager', @siteid, 0, 1, 0, 0, 'tlpmanager', 1);
--insert role elements for read user
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User


insert into Role (Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias, IsDefaultReadOnlyRoleForSite)
values ('TLP Maintenance', 0, 'TLPMaintenance', @siteid, 0, 1, 0, 0, 'tlpmaintenance', 1);
--insert role elements for read user
insert into RoleElementTemplate (RoleElementId, RoleId) values (1,IDENT_CURRENT('ROLE')); 				-- Action Items - View Action Item Definition, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (39,IDENT_CURRENT('ROLE')); 			-- Action Items - View Action Item, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (210,IDENT_CURRENT('ROLE')); 		-- Action Items - View Navigation - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (218,IDENT_CURRENT('ROLE')); 		-- Action Items - View Priorities - Action Items, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (272,IDENT_CURRENT('ROLE')); 		-- Action Items & Targets - Set Operational Modes, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (231,IDENT_CURRENT('ROLE')); 		-- Directives - View Navigation - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (232,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives - Future, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (267,IDENT_CURRENT('ROLE')); 		-- Directives - View Priorities - Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (268,IDENT_CURRENT('ROLE')); 		-- Directives - View Directives, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (264,IDENT_CURRENT('ROLE')); 		-- Events - View Navigation - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (265,IDENT_CURRENT('ROLE')); 		-- Events - View Priorities - Events, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (207,IDENT_CURRENT('ROLE')); 		-- Forms - View Form, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (217,IDENT_CURRENT('ROLE')); 		-- Forms - View Navigation - Forms, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (275,IDENT_CURRENT('ROLE')); 		-- Forms - View Priorities - Document Suggestion, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (33,IDENT_CURRENT('ROLE')); 			-- Logs - View Log, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (212,IDENT_CURRENT('ROLE')); 		-- Logs - View Navigation - Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (47,IDENT_CURRENT('ROLE')); 			-- Logs - Notifications - View SAP Notifications, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (88,IDENT_CURRENT('ROLE')); 			-- Logs - Summary Logs - View Summary Logs, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (114,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Shift Handover, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (214,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Navigation - Shift Handovers, Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (223,IDENT_CURRENT('ROLE')); 		-- Shift Handovers - View Priorities - Shift Handovers, Read User


--Work Assignment based on the roles 
delete from WorkAssignmentVisibilityGroup from WorkAssignmentVisibilityGroup inner join WorkAssignment on WorkAssignmentVisibilityGroup.WorkAssignmentId = WorkAssignment.Id	and WorkAssignment.Category = 'TLP'
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join WorkAssignment on WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.Category = 'TLP'
delete from WorkAssignment where Category = 'TLP'
insert into WorkAssignment 
(Name, [Description], SiteId, Deleted, RoleId, Category, UseWorkAssignmentForActionItemHandoverDisplay, CopyTargetAlertResponseToLog, ShowLubesCsdOnShiftHandoverReport, ShowEventExcursionsOnShiftHandoverReport) 
values 
(@sitename + ' Operator','TLP Operator',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'TLP Operator'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Shift Supervisor','TLP Shift Supervisor',@siteid, 0, (select ID from Role where SiteId = @siteid and Name= 'TLP Shift Supervisor'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Coordinator','TLP Coordinator',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'TLP Coordinator'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Engineer','TLP Engineer',@siteid, 0, (select id from Role where SiteId = @siteid and Name= 'TLP Engineer'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Read User','TLP Read User',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'TLP Read User'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Team Lead','TLP Team Lead',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'TLP Team Lead'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Manager','TLP Manager',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'TLP Manager'), 'TLP', 1, 1, 0, 0),
(@sitename + ' Maintenance','TLP Maintenance',@siteid, 0, (select id from Role where SiteId = @siteid and Name = 'TLP Maintenance'), 'TLP', 1, 1, 0, 0)

go
--insert workassignment function location for TLP
declare @siteid bigint = 11

--delete existing first
delete from WorkAssignmentFunctionalLocation from WorkAssignmentFunctionalLocation inner join WorkAssignment on WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id and WorkAssignment.Name like 'TLP%'

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Operator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Shift Supervisor' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Coordinator' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Engineer' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Read User' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Team Lead' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Manager' and a.SiteId = @siteid;

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = @siteid and f.fullhierarchy = 'TLP' and a.name = 'TLP Maintenance' and a.SiteId = @siteid;

go
declare @siteid bigint = 11
INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid), -- Operations visibility group for the site
			wa.Id,
			1 -- Read
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where VisibilityGroup.SiteId = @siteid) AND WorkAssignmentId = wa.Id AND VisibilityType=1)
)

INSERT INTO WorkAssignmentVisibilityGroup
(VisibilityGroupId, WorkAssignmentId, VisibilityType)
(
		Select
			(select VisibilityGroup.Id from VisibilityGroup where SiteId = @siteid), -- Operations visibility group for the site
			wa.Id,
			2 -- Write
		FROM
			WorkAssignment wa
		WHERE
			wa.SiteId=@siteid
			AND NOT EXISTS(SELECT VisibilityGroupId FROM WorkAssignmentVisibilityGroup WHERE VisibilityGroupId=(select VisibilityGroup.Id from VisibilityGroup where VisibilityGroup.SiteId = @siteid) AND WorkAssignmentId = wa.Id AND VisibilityType=2)
)





GO

