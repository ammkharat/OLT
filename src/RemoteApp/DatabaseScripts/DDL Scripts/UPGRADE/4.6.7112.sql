-- fix the alias of Coordinator/Manager
update [role] 
  set 
	alias = 'coord',
	[name] = 'Coordinator' 
where 
	[name] = 'Coordinator/Manager' and siteid = 11


-- delete the Chief Engineer role from Voyageur
delete from dbo.RoleElementTemplate where RoleId = 
  (Select dbo.[Role].Id from [role] where siteid = 11 and [name] = 'Chief Engineer/Assistant Chief Engineer')

delete from dbo.WorkAssignmentFunctionalLocation where EXISTS 
  (select * from WorkAssignment where dbo.WorkAssignment.RoleId = 
    (Select dbo.[Role].Id from [role] where siteid = 11 and [name] = 'Chief Engineer/Assistant Chief Engineer')
   and dbo.WorkAssignmentFunctionalLocation.WorkAssignmentId = dbo.WorkAssignment.Id)

delete from dbo.WorkAssignment where RoleId =   
  (Select dbo.[Role].Id from [role] where siteid = 11 and [name] = 'Chief Engineer/Assistant Chief Engineer')
  
delete from [role] where siteid = 11 and [name] = 'Chief Engineer/Assistant Chief Engineer'


-- Insert missing roles
INSERT INTO dbo.[Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
) VALUES (
   'Team Lead'  -- Name - varchar(40)
  ,0  -- deleted - bit
  ,'TeamLead'  -- ActiveDirectoryKey - varchar(255)
  ,0  -- IsAdministratorRole - bit
  ,0  -- IsReadOnlyRole - bit
  ,0  -- IsWorkPermitNonOperationsRole - bit
  ,11   -- SiteId - bigint
  ,1  -- WarnIfWorkAssignmentNotSelected - bit
  ,'lead'  -- Alias - varchar(10)
)

INSERT INTO dbo.[Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
) VALUES (
   'Manager'  -- Name - varchar(40)
  ,0  -- deleted - bit
  ,'Manager'  -- ActiveDirectoryKey - varchar(255)
  ,0  -- IsAdministratorRole - bit
  ,0  -- IsReadOnlyRole - bit
  ,0  -- IsWorkPermitNonOperationsRole - bit
  ,11   -- SiteId - bigint
  ,1  -- WarnIfWorkAssignmentNotSelected - bit
  ,'mgr'  -- Alias - varchar(10)
)

INSERT INTO dbo.[Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
) VALUES (
   'Maintenance'  -- Name - varchar(40)
  ,0  -- deleted - bit
  ,'Maintenance'  -- ActiveDirectoryKey - varchar(255)
  ,0  -- IsAdministratorRole - bit
  ,0  -- IsReadOnlyRole - bit
  ,0  -- IsWorkPermitNonOperationsRole - bit
  ,11   -- SiteId - bigint
  ,1  -- WarnIfWorkAssignmentNotSelected - bit
  ,'maint'  -- Alias - varchar(10)
)



INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Automatic Re-Approval by Field';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Administrator' and re.[Name] = 'Maintain Shift-FLOC Relationship';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Operator' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Respond to Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Create Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Edit Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Team Lead' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Approve Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Reject Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Comment Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Toggle Approval Required for Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Create Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Edit Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Delete Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'Cancel Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Manager' and re.[Name] = 'View Shift Handover';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Shift Supervisor' and re.[Name] = 'Delete Shift Handover Questionnaire';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Engineer' and re.[Name] = 'Create Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Engineer' and re.[Name] = 'Edit Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Engineer' and re.[Name] = 'Delete Action Item Definition';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Engineer' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Engineer' and re.[Name] = 'View Standing Orders';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'View Action Item';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'View Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'Create Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'Edit Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'Delete Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'Reply To Log';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'View Directives';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'View Summary Logs';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 11 and r.[Name] = 'Maintenance' and re.[Name] = 'View Shift Handover';
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Operator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Comment Action Item Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Shift Supervisor') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Configure Auto Approve SAP Action Item Definition'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Shift Supervisor') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Configure Plant Historian Tag List'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Engineer') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Respond to Action Item'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Engineer') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Edit Log Flagged as Operating Engineer Log'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Administrator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Configure Plant Historian Tag List'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Administrator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Configure Craft Or Trade'));
DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 11 and r.[Name] = 'Administrator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Configure Configured Document Links'));




GO

