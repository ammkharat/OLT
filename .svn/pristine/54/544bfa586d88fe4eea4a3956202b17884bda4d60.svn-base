

INSERT INTO RoleElement (Id, Name, FunctionalArea) VALUES (200, 'Configure Form Templates', 'Admin - Forms');
go

insert into RoleElementTemplate (RoleElementId, RoleId) 
select 200, r.Id
from Role r
where r.SiteId = 8 and r.Name = 'Administrator'
go





GO

