
--- Script 4.3.5575 (Partial) Begin

insert into SiteFunctionalArea (SiteId, FunctionalArea) values (8, 6);

-- View Permit Requests

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (181, 55);
-- Read User
insert into RoleElementTemplate (RoleElementId, RoleId) values (181, 78);
-- Administrator
insert into RoleElementTemplate (RoleElementId, RoleId) values (181, 92);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (181, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (181, 99);

-- Create Permit Request

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (182, 55);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (182, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (182, 99);

-- Edit Permit Request

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (183, 55);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (183, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (183, 99);

-- Delete Permit Request

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (184, 55);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (184, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (184, 99);

-- Submit Permit Request

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (185, 55);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (185, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (185, 99);

-- Import Permit Request

-- Supervisor
insert into RoleElementTemplate (RoleElementId, RoleId) values (186, 55);
-- Ops Coordinator
insert into RoleElementTemplate (RoleElementId, RoleId) values (186, 97);
-- Unit Leader
insert into RoleElementTemplate (RoleElementId, RoleId) values (186, 99);


GO

--- Script 4.3.5575 End

--- Script 4.3.5715 (Partial) Begin

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8   -- Edmonton
where re.Name in ('Create Permit', 'View Permit')
and r.Name in ('Supervisor', 'Operator')

GO

--- Script 4.3.5715 End

--- Script 4.3.5776 Begin

insert into RoleElementTemplate (RoleElementId, RoleId)
select re.Id, r.Id
from RoleElement re
inner join Role r on r.SiteId = 8   -- Edmonton
where re.Name in ('Update Permit at any time')
and r.Name in ('Supervisor', 'Operator')

GO

--- Script 4.3.5776 End




GO

