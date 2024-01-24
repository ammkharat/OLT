

SET IDENTITY_INSERT [Role] ON;  
  
insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)  
values (134, 'TA Tech', 0, 'TATech', 8, 0, 0, 0, 1, 'tatech');  

insert into Role (Id, Name, Deleted, ActiveDirectoryKey, SiteId, IsAdministratorRole, IsReadOnlyRole, IsWorkPermitNonOperationsRole, WarnIfWorkAssignmentNotSelected, Alias)  
values (135, 'TA Team Leader', 0, 'TATeamLeader', 8, 0, 0, 0, 1, 'tateamlead');

SET IDENTITY_INSERT [Role] OFF;

go


--- give TA Techs the same permissions as Edmonton Operators

insert into RoleElementTemplate (RoleElementId, RoleId)
select ret.RoleElementId, 134
from RoleElementTemplate ret
where ret.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Operator')

go

--- give TA Team Leaders the same permissions as Edmonton Shift Supervisors

insert into RoleElementTemplate (RoleElementId, RoleId)
select ret.RoleElementId, 135
from RoleElementTemplate ret
where ret.RoleId in (select r.Id from Role r where r.SiteId = 8 and r.Name = 'Supervisor')

go

--- create the two work assignments

insert into [WorkAssignment] ([Name],[Description],SiteId,Deleted,RoleId,Category) 
values ('Turnaround Tech', 'Turnaround Tech', 8, 0, 134, 'General')

insert into [WorkAssignment] ([Name],[Description],SiteId,Deleted,RoleId,Category) 
values ('Turnaround Team Leader', 'Turnaround Team Leader', 8, 0, 135, 'General')

go

--- set the flocs to be 'ED1' for both because the story doesn't specify

insert into WorkAssignmentFunctionalLocation (WorkAssignmentId, FunctionalLocationId)
select wa.Id, fl.Id
from WorkAssignment wa, FunctionalLocation fl
where wa.Id in (select Id from WorkAssignment where SiteId = 8 and Name in ('Turnaround Tech', 'Turnaround Team Leader'))
and fl.Id in (select Id from FunctionalLocation where FullHierarchy = 'ED1')

go






GO

