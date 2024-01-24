insert into RoleElement (Id, Name, FunctionalArea) values (204, 'Configure Area Labels', 'Admin - Site Configuration');

go

declare @RoleId bigint;
select @RoleId = r.Id from Role r where r.SiteId = 8 and r.Name = 'Administrator';

insert into RoleElementTemplate (RoleElementId, RoleId) values (204, @RoleId);

go


GO

