


declare @RoleId bigint;
select @RoleId = r.Id from Role r where SiteId = 3 and Name = 'Utilities Supervisor';

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, @RoleId
from RoleElement re
where re.Name = 'View SAP Notifications' or re.Name = 'Process SAP Notifications'





GO

