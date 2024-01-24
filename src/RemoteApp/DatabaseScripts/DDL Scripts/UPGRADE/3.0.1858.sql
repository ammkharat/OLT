--- Adds Shift Handover to Firebag users.

DECLARE @role as bigint;
DECLARE @site as bigint;
set @site = 5  -- Firebag

set @role = 1  -- Supervisor
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
INSERT INTO RoleElementTemplate VALUES(115, @role, @site)
INSERT INTO RoleElementTemplate VALUES(116, @role, @site)
INSERT INTO RoleElementTemplate VALUES(117, @role, @site)


set @role = 2 -- Operator
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
INSERT INTO RoleElementTemplate VALUES(115, @role, @site)
INSERT INTO RoleElementTemplate VALUES(116, @role, @site)
INSERT INTO RoleElementTemplate VALUES(117, @role, @site)


set @role = 5 -- Operating Engineer
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)


set @role = 7 -- Read User
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)


set @role = 37 -- Administrator
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)


set @role = 39 -- Area Manager
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)









GO
--- Adds Shift Handover, Daily Directives to MacKay users.

DECLARE @role as bigint;
DECLARE @site as bigint;
set @site = 7  -- MacKay

set @role = 1  -- Supervisor
-- shift handover
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
INSERT INTO RoleElementTemplate VALUES(115, @role, @site)
INSERT INTO RoleElementTemplate VALUES(116, @role, @site)
INSERT INTO RoleElementTemplate VALUES(117, @role, @site)
-- daily directives
INSERT INTO RoleElementTemplate VALUES(96, @role, @site)
INSERT INTO RoleElementTemplate VALUES(97, @role, @site)
INSERT INTO RoleElementTemplate VALUES(98, @role, @site)
INSERT INTO RoleElementTemplate VALUES(99, @role, @site)


set @role = 2 -- Operator
-- shift handover
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
INSERT INTO RoleElementTemplate VALUES(115, @role, @site)
INSERT INTO RoleElementTemplate VALUES(116, @role, @site)
INSERT INTO RoleElementTemplate VALUES(117, @role, @site)
-- daily directives
INSERT INTO RoleElementTemplate VALUES(96, @role, @site)


set @role = 5 -- Operating Engineer
-- shift handover
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
-- daily directives
INSERT INTO RoleElementTemplate VALUES(96, @role, @site)


set @role = 7 -- Read User
-- shift handover
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
-- daily directives
INSERT INTO RoleElementTemplate VALUES(96, @role, @site)


set @role = 37 -- Administrator
-- shift handover
INSERT INTO RoleElementTemplate VALUES(114, @role, @site)
-- daily directives
INSERT INTO RoleElementTemplate VALUES(96, @role, @site)









GO
