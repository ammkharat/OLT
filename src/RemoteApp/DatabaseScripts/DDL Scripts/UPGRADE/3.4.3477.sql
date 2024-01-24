DECLARE @rolegroup as bigint;
DECLARE @role as bigint;

SET IDENTITY_INSERT [RoleGroup] ON
INSERT INTO dbo.RoleGroup(Id,Name) VALUES (6,'Production Engineer')
set @rolegroup = @@IDENTITY
SET IDENTITY_INSERT [RoleGroup] OFF

INSERT INTO [Role] ([Name], [RoleGroupId], [ActiveDirectoryKey]) VALUES('Production Engineer', 6, 'ProductionEngineer')
set @role = @@IDENTITY


-- Update View (Area Manager) Directive to say 'View directive'
UPDATE dbo.[RoleElement]
    SET [Name] = 'View Directives'
  WHERE Id = 96
  
-- delete references to View chief engineer directive  
DELETE FROM
	dbo.RoleElementTemplate
WHere RoleElementId = 139
    
DELETE FROM
	dbo.RoleElement
WHERE Id = 139

-- creating new roleelements
INSERT INTO RoleElement VALUES(143, 'Edit Production Engineer Logs')
INSERT INTO RoleElement VALUES(144, 'Delete Production Engineer Logs')
INSERT INTO RoleElement VALUES(145, 'Cancel Production Engineer Logs')

INSERT INTO RoleElement VALUES(146, 'Create Production Engineer Directive')
INSERT INTO RoleElement VALUES(147, 'Edit Production Engineer Directive')
INSERT INTO RoleElement VALUES(148, 'Delete Production Engineer Directive')

-- Firebag Production Engineer Role Elements
INSERT INTO RoleElementTemplate VALUES(1, @role, 5)
INSERT INTO RoleElementTemplate VALUES(10, @role, 5)
INSERT INTO RoleElementTemplate VALUES(32, @role, 5)
INSERT INTO RoleElementTemplate VALUES(33, @role, 5)
INSERT INTO RoleElementTemplate VALUES(34, @role, 5)
INSERT INTO RoleElementTemplate VALUES(35, @role, 5)
INSERT INTO RoleElementTemplate VALUES(39, @role, 5)
INSERT INTO RoleElementTemplate VALUES(40, @role, 5)
INSERT INTO RoleElementTemplate VALUES(47, @role, 5)
INSERT INTO RoleElementTemplate VALUES(48, @role, 5)
INSERT INTO RoleElementTemplate VALUES(51, @role, 5)
INSERT INTO RoleElementTemplate VALUES(54, @role, 5)

INSERT INTO RoleElementTemplate VALUES(88, @role, 5)
INSERT INTO RoleElementTemplate VALUES(96, @role, 5)

INSERT INTO RoleElementTemplate VALUES(114, @role, 5)

INSERT INTO RoleElementTemplate VALUES(143, @role, 5)
INSERT INTO RoleElementTemplate VALUES(144, @role, 5)
INSERT INTO RoleElementTemplate VALUES(145, @role, 5)

INSERT INTO RoleElementTemplate VALUES(146, @role, 5)
INSERT INTO RoleElementTemplate VALUES(147, @role, 5)
INSERT INTO RoleElementTemplate VALUES(148, @role, 5)
GO
