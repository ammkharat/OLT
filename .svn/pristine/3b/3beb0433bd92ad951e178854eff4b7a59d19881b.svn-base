
delete from RoleElementTemplate 
where RoleElementId in (select Id from RoleElement where Name in ('Configure Site', 'Configure Role Permissions') and FunctionalArea = 'Technical Admin');
go

delete from RoleElement where Name in ('Configure Site', 'Configure Role Permissions') and FunctionalArea = 'Technical Admin';
go

update RoleElement set Name = 'Perform Tech Admin Tasks' where Name = 'Configure Role Matrix' and FunctionalArea = 'Technical Admin';
go






GO

