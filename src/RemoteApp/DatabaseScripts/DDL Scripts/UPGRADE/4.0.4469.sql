-- #1349
-- Role Id = 108 is a OilSands: MaintenanceSupervisor should be allowed to Create, Edit and Delete Summary Logs:
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(89, 108);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(92, 108);
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) VALUES(95, 108);


-- Role Id = 108 is a OilSands: MaintenanceSupervisor should be allowed to Edit and Delete Summary Logs made by other  MaintenanceSupervisors
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(108, 92, 108);
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId) VALUES(108, 95, 108);
GO
