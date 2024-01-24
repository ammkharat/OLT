

update Role
set Name = 'Coordinator / Area Team Lead'
where SiteId = 8 and Name = 'Ops Coordinator / Area Team Lead'
go



SET IDENTITY_INSERT [Role] ON;  
  
insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)  
values (132, 'Contractor / Tradesperson', 0, 'Contractor', 8, 0, 0, 0, 1, 'cont');  

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)  
values (133, 'Scheduler', 0, 'Scheduler', 8, 0, 0, 0, 1, 'sched');

SET IDENTITY_INSERT [Role] OFF;

go


--- elements for contractor:  
  
INSERT INTO RoleElementTemplate (RoleElementId, RoleId)  
select re.Id, r.Id  
from RoleElement re  
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Contractor / Tradesperson')
where re.Name in ('View Directives', 'View Log', 'View Summary Logs', 'View Shift Handover', 'View Action Item', 
    'View Permit Requests', 'Create Permit Request', 'Delete Permit Request', 'Submit Permit Request', 'Edit Permit Request',
	'View Permit')  
go


--- elements for scheduler:

INSERT INTO RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Scheduler')
where re.Name in ('View Directives', 'View Log', 'View Summary Logs', 'View Shift Handover', 'View Action Item', 
    'View Permit Requests', 'Create Permit Request', 'Delete Permit Request', 'Submit Permit Request', 'Edit Permit Request', 'Import Permit Requests',
	'View Permit')  
go


--- add missing elements for coordinator:

INSERT INTO RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Coordinator / Area Team Lead')
where re.Name in ('View Permit')
go

--- add missing elements for operator:

INSERT INTO RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Operator')
where re.Name in ('Comment WorkPermit', 'Reject Permit')
go

--- add missing elements for supervisor:

INSERT INTO RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
left outer join Role r on r.Id in (select Id from Role where SiteId = 8 and Name = 'Supervisor')
where re.Name in ('Comment WorkPermit', 'Reject Permit')
go










GO



alter table dbo.PermitRequestEdmonton alter column Location varchar(100) not null;
alter table dbo.PermitRequestEdmontonHistory alter column Location varchar(100) not null;

alter table dbo.WorkPermitEdmontonDetails alter column ConfinedSpaceCardNumber varchar(15) null;
alter table dbo.WorkPermitEdmontonHistory alter column ConfinedSpaceCardNumber varchar(15) null;
alter table dbo.PermitRequestEdmonton alter column ConfinedSpaceCardNumber varchar(15) null;
alter table dbo.PermitRequestEdmontonHistory alter column ConfinedSpaceCardNumber varchar(15) null;

alter table dbo.WorkPermitEdmontonDetails alter column RescuePlanFormNumber varchar(15) null;
alter table dbo.WorkPermitEdmontonHistory alter column RescuePlanFormNumber varchar(15) null;
alter table dbo.PermitRequestEdmonton alter column RescuePlanFormNumber varchar(15) null;
alter table dbo.PermitRequestEdmontonHistory alter column RescuePlanFormNumber varchar(15) null;

alter table dbo.WorkPermitEdmontonDetails alter column SpecialWorkFormNumber varchar(15) null;
alter table dbo.WorkPermitEdmontonHistory alter column SpecialWorkFormNumber varchar(15) null;
alter table dbo.PermitRequestEdmonton alter column SpecialWorkFormNumber varchar(15) null;
alter table dbo.PermitRequestEdmontonHistory alter column SpecialWorkFormNumber varchar(15) null;

alter table dbo.WorkPermitEdmontonDetails alter column VehicleEntryType varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column VehicleEntryType varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column VehicleEntryType varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column VehicleEntryType varchar(30) null;

alter table dbo.WorkPermitEdmontonDetails alter column OtherAreasAndOrUnitsAffectedArea varchar(50) null;
alter table dbo.WorkPermitEdmontonHistory alter column OtherAreasAndOrUnitsAffectedArea varchar(50) null;
alter table dbo.PermitRequestEdmonton alter column OtherAreasAndOrUnitsAffectedArea varchar(50) null;
alter table dbo.PermitRequestEdmontonHistory alter column OtherAreasAndOrUnitsAffectedArea varchar(50) null;

alter table dbo.WorkPermitEdmontonDetails alter column OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column OtherAreasAndOrUnitsAffectedPersonNotified varchar(30) null;

alter table dbo.WorkPermitEdmontonDetails alter column WorkersMonitorNumber varchar(10) null;
alter table dbo.WorkPermitEdmontonHistory alter column WorkersMonitorNumber varchar(10) null;
alter table dbo.PermitRequestEdmonton alter column WorkersMonitorNumber varchar(10) null;
alter table dbo.PermitRequestEdmontonHistory alter column WorkersMonitorNumber varchar(10) null;

alter table dbo.WorkPermitEdmontonDetails alter column RadioChannelNumber varchar(10) null;
alter table dbo.WorkPermitEdmontonHistory alter column RadioChannelNumber varchar(10) null;
alter table dbo.PermitRequestEdmonton alter column RadioChannelNumber varchar(10) null;
alter table dbo.PermitRequestEdmontonHistory alter column RadioChannelNumber varchar(10) null;

alter table dbo.WorkPermitEdmontonDetails alter column Other1 varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column Other1 varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column Other1 varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column Other1 varchar(30) null;

alter table dbo.WorkPermitEdmontonDetails alter column Other2 varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column Other2 varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column Other2 varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column Other2 varchar(30) null;

alter table dbo.WorkPermitEdmontonDetails alter column Other3 varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column Other3 varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column Other3 varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column Other3 varchar(30) null;

alter table dbo.WorkPermitEdmontonDetails alter column Other4 varchar(30) null;
alter table dbo.WorkPermitEdmontonHistory alter column Other4 varchar(30) null;
alter table dbo.PermitRequestEdmonton alter column Other4 varchar(30) null;
alter table dbo.PermitRequestEdmontonHistory alter column Other4 varchar(30) null;

go




GO

