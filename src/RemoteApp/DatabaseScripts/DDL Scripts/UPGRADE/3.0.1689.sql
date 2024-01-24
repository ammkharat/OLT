DECLARE @rolegroup as bigint;
DECLARE @role as bigint;

SET IDENTITY_INSERT [RoleGroup] ON
INSERT INTO [RoleGroup] ([Id], [Name]) VALUES(5, 'Area Manager')
set @rolegroup = @@IDENTITY
SET IDENTITY_INSERT [RoleGroup] OFF

INSERT INTO [Role] ([Name], [RoleGroupId]) VALUES('Area Manager', 5)
set @role = @@IDENTITY

-- OilSands Area Manager Role Elements
INSERT INTO RoleElementTemplate VALUES(1, @role, 3)
INSERT INTO RoleElementTemplate VALUES(4, @role, 3)
INSERT INTO RoleElementTemplate VALUES(6, @role, 3)
INSERT INTO RoleElementTemplate VALUES(8, @role, 3)
INSERT INTO RoleElementTemplate VALUES(10, @role, 3)
INSERT INTO RoleElementTemplate VALUES(33, @role, 3)
INSERT INTO RoleElementTemplate VALUES(39, @role, 3)
INSERT INTO RoleElementTemplate VALUES(47, @role, 3)
INSERT INTO RoleElementTemplate VALUES(88, @role, 3)
INSERT INTO RoleElementTemplate VALUES(96, @role, 3)
INSERT INTO RoleElementTemplate VALUES(97, @role, 3)
INSERT INTO RoleElementTemplate VALUES(98, @role, 3)
INSERT INTO RoleElementTemplate VALUES(99, @role, 3)
INSERT INTO RoleElementTemplate VALUES(100, @role, 3)
INSERT INTO RoleElementTemplate VALUES(114, @role, 3)

-- Firebag Area Manager Role Elements
INSERT INTO RoleElementTemplate VALUES(1, @role, 5)
INSERT INTO RoleElementTemplate VALUES(4, @role, 5)
INSERT INTO RoleElementTemplate VALUES(6, @role, 5)
INSERT INTO RoleElementTemplate VALUES(8, @role, 5)
INSERT INTO RoleElementTemplate VALUES(10, @role, 5)
INSERT INTO RoleElementTemplate VALUES(33, @role, 5)
INSERT INTO RoleElementTemplate VALUES(39, @role, 5)
INSERT INTO RoleElementTemplate VALUES(47, @role, 5)
INSERT INTO RoleElementTemplate VALUES(88, @role, 5)
INSERT INTO RoleElementTemplate VALUES(96, @role, 5)
INSERT INTO RoleElementTemplate VALUES(97, @role, 5)
INSERT INTO RoleElementTemplate VALUES(98, @role, 5)
INSERT INTO RoleElementTemplate VALUES(99, @role, 5)
GO

GO
