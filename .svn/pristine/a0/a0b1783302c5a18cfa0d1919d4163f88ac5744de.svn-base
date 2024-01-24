
insert into RoleElement (Id, Name, FunctionalArea) values (209, 'Configure Training Blocks', 'Admin - Forms');
go

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Administrator' and re.[Name] = 'Configure Training Blocks';




GO

