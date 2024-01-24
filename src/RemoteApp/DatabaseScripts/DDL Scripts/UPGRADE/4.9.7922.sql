
insert into SiteFunctionalArea (SiteId, FunctionalArea) values (3, 12);

insert into RoleElement (Id, Name, FunctionalArea) values (207, 'View Form', 'Forms');
insert into RoleElement (Id, Name, FunctionalArea) values (208, 'Approve Oilsands Training Form', 'Forms');


INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Administrator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Contractor / Tradesperson' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Coordinator / Area Team Lead' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Operating / Chief Engineer' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Operator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Read User' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Restriction Reporting Admin' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Running Unit Support' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Scheduler' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Supervisor' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Support Coordinator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'TA Support' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'TA Tech' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Unit Leader' and re.[Name] = 'View Form';



INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Administrator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Area Manager' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Maintenance Supervisor' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Operating / Chief Engineer' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Operator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Operator' and re.[Name] = 'Create Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Operator' and re.[Name] = 'Delete Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Operator' and re.[Name] = 'Edit Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Process Engineer' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Process Engineer Target Admin' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Read User' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Restriction Reporting Admin' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Supervisor' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Supervisor' and re.[Name] = 'Create Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Supervisor' and re.[Name] = 'Delete Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Supervisor' and re.[Name] = 'Edit Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Supervisor' and re.[Name] = 'Approve Oilsands Training Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TA Coordinator' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TA Director' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TA Engineer' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TA Execution Manager' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'TA Manager' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Unit Leader' and re.[Name] = 'View Form';
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 3 and r.[Name] = 'Utilities Supervisor' and re.[Name] = 'View Form';



GO

