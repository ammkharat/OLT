﻿------------------------------RITM0156153--- Add new role 'SE Maintenance Coordinator' in forthill site ------------------------------

IF not EXISTS (  select * from Role where SiteId = 15 and Name like 'SE Maintenance Coordinator')
begin
insert into Role (Name,deleted,ActiveDirectoryKey,IsAdministratorRole,IsReadOnlyRole,IsWorkPermitNonOperationsRole,
SiteId,WarnIfWorkAssignmentNotSelected,Alias,IsDefaultReadOnlyRoleForSite)
values('SE Maintenance Coordinator',0,'SEMaintenanceCoordinator', 0, 0, 0, 15,1,'semntcoord', 0 )
end

------------------------------RITM0156153--- Add new role 'SE Maintenance Coordinator' in forthill site ------------------------------


GO

--Alter actionitem and actionitemdefinition tables to add visibilitygroupids column
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Actionitem]') 
         AND name = 'visibilitygroupids'
)
begin
alter table [dbo].[Actionitem] Add [visibilitygroupids] varchar(100) sparse
end
Go
 
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ActionitemDefinition]') 
         AND name = 'visibilitygroupids'
)
begin
alter table [dbo].[ActionitemDefinition] Add [visibilitygroupids] varchar(100) sparse
end
Go