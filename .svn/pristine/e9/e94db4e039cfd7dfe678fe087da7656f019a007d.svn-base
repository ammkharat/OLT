

update RoleElement
set Name = 'Configure Work Assignments for Work Permit Auto-Assignment'
where Id = 153;
go

INSERT INTO RoleElement (Id, Name, FunctionalArea) VALUES (201, 'Configure Work Assignments for Work Permits', 'Admin - Work Permits');
go

insert into RoleElementTemplate (RoleElementId, RoleId) 
select 201, r.Id
from Role r
where r.SiteId = 8 and r.Name = 'Administrator'
go


GO

