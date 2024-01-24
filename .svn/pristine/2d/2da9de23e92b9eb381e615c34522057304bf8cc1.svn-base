insert into RoleElement (Id, Name, FunctionalArea) values (226, 'No reapproval required for GN-59 End Date Change', 'Forms');
GO

-- insert into RoleElementTemplate (RoleElementId, RoleId) values (226, 97);
insert into RoleElementTemplate (RoleElementId, RoleId) select 226, r.Id from [Role] r where Name = 'Coordinator / Area Team Lead' and SiteId = 8;
GO

