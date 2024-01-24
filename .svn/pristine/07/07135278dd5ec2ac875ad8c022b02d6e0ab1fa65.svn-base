-- Update the role table so it has a deleted column

alter table role add deleted bit not null default 0;

GO

-- Remove old roles that nobody is assigned to.

update [Role] set Deleted = 1 where id = 20;
update [Role] set Deleted = 1 where id between 22 and 36;

GO

-- Sarnia Supervisor
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,2,3,4,6,8,10,11,12,13,14,15,17,19,21,22,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,44,46,47,48,50,51,52,54,69,70,71,73,77,79,80,83,84,86,88,89,92,95)

-- Denver Supervisor		
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,2,3,4,6,8,10,11,12,13,14,15,17,19,21,22,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,44,46,47,48,50,51,52,54,69,70,71,73,77,79,80,83,84,86,88,89,92,95)

-- OilSands Supervisor
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,2,3,4,6,8,10,11,32,33,34,35,39,40,44,47,48,51,54,69,70,71,73,77,79,80,84,85,88,89,92,95,100,104,105,106,110)
	
GO	
	
-- Firebag Supervisor is already added. Only additional ones here.
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 5, [id] FROM RoleElement e WHERE e.id IN
	(80)

-- SWS Supervisior
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 6, [id] FROM RoleElement e WHERE e.id IN
	(1,2,3,4,6,8,10,11,32,33,34,35,39,40,44,47,48,51,54,69,70,71,73,77,79,80,84,85,88,89,92,95)

-- MacKay River Supervisor	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 1, 7, [id] FROM RoleElement e WHERE e.id IN
	(1,2,3,4,6,8,10,11,32,33,34,35,39,40,44,47,48,51,54,69,70,71,73,77,79,80,84,85,88,89,92,95)	

GO
	
-- Sarnia and Denver Operator Plus 
-- Delete role and make all users operators
UPDATE [User] Set RoleId = 2 where [roleId] = 21

update [Role] set Deleted = 1 where id = 21;
	
GO	
	
-- Sarnia Operator
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 2, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,10,12,21,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,46,47,48,50,51,52,54,66,67,68,86,88)
	
-- Denver Operator
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 2, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,10,12,21,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,46,47,48,50,51,52,54,66,67,68,86,88)
	
-- OilSands Operator
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 2, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,10,32,33,34,35,39,40,47,48,51,54,66,67,68,88,100,104,105)

GO	
	
-- Firebag Operator	is already added.
	
--- SWS Operator
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 2, 6, [id] FROM RoleElement e WHERE e.id IN
	(1,10,32,33,34,35,39,40,47,48,51,54,66,67,68,88)

-- MacKay River Operator
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 2, 7, [id] FROM RoleElement e WHERE e.id IN
	(1,10,32,33,34,35,39,40,47,48,51,54,66,67,68,88)
	
-- Sarnia Engineering Support
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 3, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,4,6,8,10,12,15,17,19,21,23,24,33,39,41,47,73,79,88)

GO
	
-- Denver Engineering Support
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 3, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,4,6,8,10,12,15,17,19,21,23,24,33,39,41,47,73,79,88)

-- Sarnia Administrator	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 37, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,12,24,33,39,41,47,72,74,75,76,77,78,80,81,82,85,88,111,112)	

GO
	
-- Change Sarnia Admins to have Role 37	
UPDATE [User] Set RoleId = 37 where [roleId] = 4

-- Sarnia Operating Engineer
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 5, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,10,12,21,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,46,47,48,50,51,52,54,63,64,65,66,67,68,86,88)
	
-- OilSands Operating Engineer
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 5, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,10,32,33,34,35,39,40,47,48,51,54,63,64,65,66,67,68,88,100,106,110)

GO
	
-- Firebag Operating Engineers already added

-- MacKay River Operating Engineer
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 5, 7, [id] FROM RoleElement e WHERE e.id IN
	(1,10,32,33,34,35,39,40,47,48,51,54,63,64,65,66,67,68,88)
	
-- Sarnia Permit Screener
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 6, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,12,23,24,28,33,39,41,45,47,49)

-- Denver Permit Screener	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 6, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,12,23,24,28,33,39,41,45,47,49)
	
GO

-- Sarnia Read User
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 7, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,12,24,33,39,41,47,88)
	
-- Denver Read User
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 7, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,12,24,33,39,41,47,88)
	
-- OilSands Read User
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 7, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,88,100)

GO
	
-- Firebag Read User already entered

-- SWS Read User
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 7, 6, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,88)

-- MacKay River Read User
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 7, 7, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,88)

-- Sarnia No-ops Permit Issuer
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 8, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,12,23,24,33,39,41,46,47,50,57,58,59,60,61,62)

GO

-- Denver No-ops Permit Issuer
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 8, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,12,23,24,33,39,41,46,47,50,57,58,59,60,61,62)

-- Sarnia Supervisor Plus	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 12, 1, [id] FROM RoleElement e WHERE e.id IN
(1,2,3,4,6,8,10,11,12,13,14,15,17,19,21,22,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,44,46,47,48,50,51,52,54,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,88,89,92,95)

-- Denver Supervisor Plus
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 12, 2, [id] FROM RoleElement e WHERE e.id IN
(1,2,3,4,6,8,10,11,12,13,14,15,17,19,21,22,23,24,25,26,27,29,31,32,33,34,35,39,40,41,42,44,46,47,48,50,51,52,54,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,88,89,92,95)

GO

-- Sarnia Engineering Support Plus
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 18, 1, [id] FROM RoleElement e WHERE e.id IN
	(1,4,6,8,10,11,12,15,17,19,21,22,23,24,28,33,39,41,45,47,49,73,79,80,88)
	
-- Denver Engineering Support Plus	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 18, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,4,6,8,10,11,12,15,17,19,21,22,23,24,28,33,39,41,45,47,49,73,79,80,88)

-- Denver Permit Screener Commentor
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 19, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,10,12,23,24,28,32,33,39,41,45,47,49,51,73,79,80)

GO

-- Denver Administrator	
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 37, 2, [id] FROM RoleElement e WHERE e.id IN
	(1,12,24,33,39,41,47,72,74,75,76,77,78,80,81,82,85,88,111,112)	
	
-- OilSands Admin
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 37, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,74,76,77,80,82,85,88,100,111,112)	

GO

-- Firebag Admin, insert correctly
DELETE FROM RoleElementTemplate WHERE roleid=37 and siteid=5
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
SELECT 37, 5, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,74,76,77,80,82,85,88,96,111,112)	

GO

-- 	SWS Admin
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 37, 6, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,74,76,77,80,82,85,88,111,112)
	
-- MacKay River Admin
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 37, 7, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,47,74,76,77,80,82,85,88,111,112)

-- OilSands Restriction Reporting Admin
INSERT INTO RoleElementTemplate (RoleId, SiteId, RoleElementId)
	SELECT 38, 3, [id] FROM RoleElement e WHERE e.id IN
	(1,33,39,82,85,47,88,100,101,102,103,107,108,109)

GO

DROP TABLE UserRoleElements		
go

-- Delete DWS role elements
delete from roleelement
where id in (43, 55, 56)

DELETE FROM [RoleElement] WHERE Id = 30

go


	
GO
