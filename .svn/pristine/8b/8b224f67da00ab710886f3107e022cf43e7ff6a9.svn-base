SET IDENTITY_INSERT dbo.[Role] ON;

insert into Role
(Id, Name, RoleGroupId, Deleted, ActiveDirectoryKey)
values
(47, 'Process Engineer Target Admin', 1, 0, 'ProcessEngineerTargetAdmin');

insert into Role
(Id, Name, RoleGroupId, Deleted, ActiveDirectoryKey)
values
(48, 'Process Engineer', 1, 0, 'ProcessEngineer');

SET IDENTITY_INSERT dbo.[Role] OFF;

go

insert RoleElementTemplate
(RoleElementId, RoleId, SiteId)
select Id, 47, 3
from RoleElement 
where Id in (
12, 13, 14, 15, 17, 19, 21, 22, 41, 42, 83, -- targets
1, 33, 39, 47, 88, 96, 100, 114, 130, 149); -- view

insert RoleElementTemplate
(RoleElementId, RoleId, SiteId)
select Id, 48, 3
from RoleElement 
where Id in (
12, 21, 41, 42, -- targets
1, 33, 39, 47, 88, 96, 100, 114, 130, 149); -- view

go


GO
