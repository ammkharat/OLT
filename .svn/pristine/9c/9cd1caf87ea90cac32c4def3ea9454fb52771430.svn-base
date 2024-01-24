-- #1347
-- Role Id = 64 >> Denver: EngineeringSupport should be allowed to Create Log, Edit Log, Delete Log, Reply to Log, Edit Log Definition and Cancel Log.
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(32, 64);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(34, 64);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(35, 64);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(51, 64);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(54, 64);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(176, 64);

-- Role Id = 64 >> Denver: EngineeringSupport should be allowed to Edit, Delete and Cancel logs created by other EngineeringSupport 
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(64, 34, 64);
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(64, 35, 64);
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(64, 176, 64);
GO
