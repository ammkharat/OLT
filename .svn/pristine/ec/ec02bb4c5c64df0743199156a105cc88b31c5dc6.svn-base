insert into RoleElement(Id, Name, FunctionalArea) values (235, 'Copy Log', 'Logs');
insert into RoleElement(Id, Name, FunctionalArea) values (236, 'Add Shift Information', 'Logs');
GO

-- Everyone who can Create Log (32) can Copy Log (235) for all sites other than Lubes (10)
insert into RoleElementTemplate (RoleElementId, RoleId)
select 235, ret.RoleId from RoleElementTemplate ret 
inner join Role r on ret.RoleId = r.Id
where ret.RoleElementId = 32 and r.SiteID <> 10;

-- Everyone who can Create Log (32) can Add Shift Information (236)
insert into RoleElementTemplate (RoleElementId, RoleId)
select 236, ret.RoleId from RoleElementTemplate ret 
inner join Role r on ret.RoleId = r.Id
where ret.RoleElementId = 32 and r.SiteID <> 10;



GO




GO

