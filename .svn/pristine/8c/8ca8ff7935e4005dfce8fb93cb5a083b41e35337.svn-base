/*--------------------FortHills----1---INTEGRATED OPERATIONS LEAD-----------------------------*/
IF not EXISTS (  select * from Role where SiteId = 15 and Name like 'INT Operations Lead')
begin
insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('INT Operations Lead',0,'IntegratedOperationsLead', 0, 0, 0, 15,1,'integratedoperlead', 0 )
end
/*--------------------FortHills----2---'SITE PRODUCTION MANAGER' -------------------------------*/
IF not EXISTS (  select * from Role where SiteId = 15 and Name like 'INT Production Manager' )
begin
insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('INT Production Manager',0,'IntegratedProductionManager', 0, 0, 0, 15,1, 'integratedpromanager', 0 )
end
/*------------------FortHills---3---'INTEGRATED PROCESS LEAD'-------------------------------*/
IF not EXISTS (  select * from Role where SiteId = 15 and Name like 'INT Process Lead')
begin
insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('INT Process Lead',0,'IntegratedProcessLead', 0, 0, 0, 15,1, 'integratedproclead', 0 )
end
/*------------------FortHills---4----'Utilities CRS'-----------------------------------*/
IF not EXISTS (  select * from Role where SiteId = 15 and Name like 'UO CRS')
begin
insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('UO CRS',0,'UtilitiesCRS', 0, 0, 0, 15,1, 'utilitiescrs', 0 )
end


GO

