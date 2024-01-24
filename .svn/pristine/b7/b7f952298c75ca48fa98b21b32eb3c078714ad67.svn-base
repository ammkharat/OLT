INSERT INTO dbo.[Site] (Id,[Name],TimeZone ,ActiveDirectoryKey) VALUES (
   9   -- Id
  ,'Montréal'  -- Name
  ,'Eastern Standard Time'  -- TimeZone
  ,'Montreal'  -- ActiveDirectoryKey
)

INSERT INTO [SiteConfiguration]
           ([SiteId]
           ,[DaysToDisplayActionItems],[DaysToDisplayShiftLogs],[DaysToDisplayShiftHandovers],[DaysToDisplayDeviationAlerts],[DaysToDisplayLabAlerts], [DaysToDisplayCokerCards]
           ,[DaysBeforeArchivingClosedWorkPermits],[DaysBeforeDeletingPendingWorkPermits],[DaysBeforeClosingIssuedWorkPermits]
           ,[WorkPermitNotApplicableAutoSelected],[WorkPermitOptionAutoSelected]
           ,[AutoApproveWorkOrderActionItemDefinition],[AutoApproveSAPAMActionItemDefinition],[AutoApproveSAPMCActionItemDefinition]
           ,[DaysToEditDeviationAlerts]
           ,[CreateOperatingEngineerLogs],[OperatingEngineerLogDisplayName]
           ,[DorCutoffTime],[SummaryLogFunctionalLocationDisplayLevel],[AllowStandardLogAtSecondLevelFunctionalLocation]
           ,[ShowActionItemsByWorkAssignmentOnPriorityPage],[LabAlertRetryAttemptLimit]
           ,[RequireActionItemResponseLog],[ActionItemRequiresApprovalDefaultValue], [ActionItemRequiresResponseDefaultValue],
		   [HideDORCommentEntry],
		   ShowActionItemsOnShiftHandover, 
		   UseNewPriorityPage, ShowDirectivesOnPriorityPage, ShowShiftHandoversOnPriorityPage, ShowShiftHandoversByWorkAssignmentOnPriorityPage, 
           DaysToDisplayDirectivesOnPriorityPage, DaysToDisplayShiftHandoversOnPriorityPage, DisplayActionItemWorkAssignmentOnPriorityPage,
           DaysToDisplayWorkPermitsForwards, DaysToDisplayWorkPermitsBackwards,
           DaysToDisplayPermitRequestsBackwards, DaysToDisplayPermitRequestsForwards, DisplayActionItemCommentOnly,
           DefaultNumberOfCopiesForWorkPermits,
           ShowFollowupOnLogForm, AllowCreateALogForEachSelectedFlocOnLogForm, ShowAdditionalDetailsOnLogFormByDefault
           )
     VALUES(
           9
           ,7,14,7,30,30,14
           ,7,7,1
           ,1,1
           ,1,1,1
           ,7
           ,0,'Ingénieur de procédés l''entrée'
           ,'1753-01-01 10:00:00.000',1,0
           ,0,3
           ,1,0,1,		   
		   1,
		   0, 
		   1, 1, 1, 1, 
           3, 3, 0,
           1, 1,
           0, 1, 0,
           2,
           0, 0, 0);

go

SET IDENTITY_INSERT dbo.Plant ON;
INSERT INTO dbo.[Plant] (Id,[Name],SiteId) VALUES (
   302   -- Id
  ,'Montreal Refinery'  -- Name
  ,9   -- SiteId
)
SET IDENTITY_INSERT dbo.Plant OFF;

INSERT INTO dbo.[Shift] 
VALUES (
'Jour'  -- Name
  ,'03/22/2011 6:00:00 AM'  -- StartTime
  ,'03/22/2011 6:00:00 PM'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,9   -- SiteId
)

INSERT INTO dbo.[Shift] 
VALUES (
  'Nuit'  -- Name
  ,'03/22/2011 6:00:00 PM'  -- StartTime
  ,'03/23/2011 6:00:00 AM'  -- EndTime
  ,getdate()  -- CreatedDateTime
  ,9   -- SiteId
)

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

go

insert into TargetDefinitionAutoReApprovalConfiguration
values (9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

-- ------------------------------------------------------------------------------

SET IDENTITY_INSERT [Role] ON;

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (109, 'Opérateur', 0, 'Operator', 9, 0, 0, 0, 1, 'oper');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (110, 'Superviseur', 0, 'Supervisor', 9, 0, 0, 0, 1, 'super');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (111, 'Administrateur des Opérations', 0, 'OperationsAdministrator', 9, 1, 0, 0, 0, 'admino');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (112, 'Lecture Seule', 0, 'ReadUser', 9, 0, 1, 0, 0, 'lect');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (113, 'Leader de  Secteur', 0, 'TeamLeader', 9, 0, 0, 0, 0, 'lead');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (114, 'Coordonnateur des Opérations', 0, 'OperationsCoordinator', 9, 0, 0, 0, 0, 'coord');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (115, 'Formateur', 0, 'Trainer', 9, 0, 0, 0, 0, 'form');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (116, 'Ingénieur', 0, 'Engineer', 9, 0, 0, 0, 0, 'ing');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (117, 'Administrateur des Permis', 0, 'PermitAdministrator', 9, 0, 0, 0, 0, 'adminp');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (118, 'Superviseur de l''Entretien', 0, 'MaintenanceSupervisor', 9, 0, 0, 0, 0, 'supere');

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)
values (119, 'Coordonnateur de l''Entretien', 0, 'MaintenanceCoordinator', 9, 0, 0, 0, 0, 'coorde');

SET IDENTITY_INSERT [Role] OFF;

go

-- ------------------------------------------------------------------------------

-- all users
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		39, 33, 96, 88, 114, 24, 181, 192 -- read
	)
);
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		1, 178 -- action item definition and standing order for everyone but operators
	)
	and r.Name != 'Opérateur'
);


-- Montreal OBU Leader, Engineer
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		97, 98, 177, -- create edit directives
		23, 27, 29, 31, 46, 52, -- work permits
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Leader de  Secteur', 'Ingénieur')
)

go

-- Montreal Operations Coordinator
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		2, 3, 4, 6, 8, 11, -- action item definitions
		97, 98, 177, -- create edit directives
		23, 27, 29, 31, 46, 52, -- work permits
		182, 183, 184, 185, 186, -- permit requests
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Coordonnateur des Opérations')
)

go

-- Montreal Trainer
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		2, 3, 4, 6, 8, 11, -- action item definitions
		40, -- action item
		32, 34, 51, -- logs		
		97, 98, 177, -- create edit directives
		89, 92, -- summary logs
		115, 116, -- shift handover
		23, 27, 29, 31, 46, 52, -- work permits
		86, -- comment on work permit
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Formateur')
)


go

-- Montreal Supervisor
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(		
		40, -- action item
		97, 98, 177, -- create edit directives
		89, 92, -- summary logs
		115, 116, -- shift handover
		23, 27, 29, 31, 46, 52, -- work permits
		86, -- comment on work permit
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Superviseur')
)

go

-- Montreal Operator 
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		40, -- action item
		32, 34, 51, -- logs		
		115, 116, -- shift handover
		23, 27, 29, 31, 46, 52, -- work permits
		86, -- comment on work permit
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Opérateur')
)

go

-- Montreal Operations Admin
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		77, 111, 112, 73, 84, -- admin action items
		113, 119, 122, 129, -- admin logs		
		120, -- admin shift handover
		74, 76, 82, 85, 136, 141, 142, 179 -- site config
	)
	and r.Name in ('Administrateur des Opérations')
)

go

-- Montreal Permit Administrator
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		23, 27, 29, 31, 46, 52, -- work permits
		182, 183, 184, 185, 186, -- permit requests
		78, 81, 180, -- permit admin
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Administrateur des Permis')
)

go

-- Montreal Maintenance Supervisor
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		23, 27, 29, 31, 46, 52, -- work permits
		182, 183, 184, 185, 186, -- permit requests
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Superviseur de l''Entretien')
)

go

-- Montreal Maintenance Coordinator = Operations Coordinator + Maintenance Supervisor
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		2, 3, 4, 6, 8, 11, -- action item definitions
		97, 98, 177, -- create edit directives
		23, 27, 29, 31, 46, 52, -- work permits
		182, 183, 184, 185, 186, -- permit requests
		189, 190, 191, 193 -- confined space documents
	)
	and r.Name in ('Coordonnateur de l''Entretien')
)

go

