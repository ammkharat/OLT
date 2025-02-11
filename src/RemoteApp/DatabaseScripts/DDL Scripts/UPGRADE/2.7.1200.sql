CREATE TABLE [dbo].[RoleElementTemplate] (
	[RoleElementId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[SiteId] [bigint] NOT NULL
)

ALTER TABLE [dbo].[RoleElementTemplate]
 ADD CONSTRAINT RET_UNIQUE
 UNIQUE(RoleElementId, RoleId, SiteId)

-- Firebag Supervisor
INSERT INTO RoleElementTemplate VALUES(1, 1, 5)
INSERT INTO RoleElementTemplate VALUES(2, 1, 5)
INSERT INTO RoleElementTemplate VALUES(3, 1, 5)
INSERT INTO RoleElementTemplate VALUES(4, 1, 5)
INSERT INTO RoleElementTemplate VALUES(6, 1, 5)
INSERT INTO RoleElementTemplate VALUES(8, 1, 5)
INSERT INTO RoleElementTemplate VALUES(10, 1, 5)
INSERT INTO RoleElementTemplate VALUES(11, 1, 5)
INSERT INTO RoleElementTemplate VALUES(32, 1, 5)
INSERT INTO RoleElementTemplate VALUES(33, 1, 5)
INSERT INTO RoleElementTemplate VALUES(34, 1, 5)
INSERT INTO RoleElementTemplate VALUES(35, 1, 5)
INSERT INTO RoleElementTemplate VALUES(39, 1, 5)
INSERT INTO RoleElementTemplate VALUES(40, 1, 5)
INSERT INTO RoleElementTemplate VALUES(43, 1, 5)
INSERT INTO RoleElementTemplate VALUES(44, 1, 5)
INSERT INTO RoleElementTemplate VALUES(47, 1, 5)
INSERT INTO RoleElementTemplate VALUES(48, 1, 5)
INSERT INTO RoleElementTemplate VALUES(51, 1, 5)
INSERT INTO RoleElementTemplate VALUES(54, 1, 5)
INSERT INTO RoleElementTemplate VALUES(69, 1, 5)
INSERT INTO RoleElementTemplate VALUES(70, 1, 5)
INSERT INTO RoleElementTemplate VALUES(71, 1, 5)
INSERT INTO RoleElementTemplate VALUES(73, 1, 5)
INSERT INTO RoleElementTemplate VALUES(77, 1, 5)
INSERT INTO RoleElementTemplate VALUES(79, 1, 5)
INSERT INTO RoleElementTemplate VALUES(84, 1, 5)
INSERT INTO RoleElementTemplate VALUES(85, 1, 5)
INSERT INTO RoleElementTemplate VALUES(88, 1, 5)
INSERT INTO RoleElementTemplate VALUES(89, 1, 5)
INSERT INTO RoleElementTemplate VALUES(92, 1, 5)
INSERT INTO RoleElementTemplate VALUES(95, 1, 5)
INSERT INTO RoleElementTemplate VALUES(96, 1, 5)
INSERT INTO RoleElementTemplate VALUES(97, 1, 5)
INSERT INTO RoleElementTemplate VALUES(98, 1, 5)
INSERT INTO RoleElementTemplate VALUES(99, 1, 5)

-- Firebag Operator
INSERT INTO RoleElementTemplate VALUES(1, 2, 5)
INSERT INTO RoleElementTemplate VALUES(10, 2, 5)
INSERT INTO RoleElementTemplate VALUES(32, 2, 5)
INSERT INTO RoleElementTemplate VALUES(33, 2, 5)
INSERT INTO RoleElementTemplate VALUES(34, 2, 5)
INSERT INTO RoleElementTemplate VALUES(35, 2, 5)
INSERT INTO RoleElementTemplate VALUES(39, 2, 5)
INSERT INTO RoleElementTemplate VALUES(40, 2, 5)
INSERT INTO RoleElementTemplate VALUES(43, 2, 5)
INSERT INTO RoleElementTemplate VALUES(47, 2, 5)
INSERT INTO RoleElementTemplate VALUES(48, 2, 5)
INSERT INTO RoleElementTemplate VALUES(51, 2, 5)
INSERT INTO RoleElementTemplate VALUES(54, 2, 5)
INSERT INTO RoleElementTemplate VALUES(55, 2, 5)
INSERT INTO RoleElementTemplate VALUES(56, 2, 5)
INSERT INTO RoleElementTemplate VALUES(66, 2, 5)
INSERT INTO RoleElementTemplate VALUES(67, 2, 5)
INSERT INTO RoleElementTemplate VALUES(68, 2, 5)
INSERT INTO RoleElementTemplate VALUES(88, 2, 5)
INSERT INTO RoleElementTemplate VALUES(96, 2, 5)

-- Firebag Engineering
INSERT INTO RoleElementTemplate VALUES(1, 5, 5)
INSERT INTO RoleElementTemplate VALUES(10, 5, 5)
INSERT INTO RoleElementTemplate VALUES(32, 5, 5)
INSERT INTO RoleElementTemplate VALUES(33, 5, 5)
INSERT INTO RoleElementTemplate VALUES(34, 5, 5)
INSERT INTO RoleElementTemplate VALUES(35, 5, 5)
INSERT INTO RoleElementTemplate VALUES(39, 5, 5)
INSERT INTO RoleElementTemplate VALUES(40, 5, 5)
INSERT INTO RoleElementTemplate VALUES(43, 5, 5)
INSERT INTO RoleElementTemplate VALUES(47, 5, 5)
INSERT INTO RoleElementTemplate VALUES(48, 5, 5)
INSERT INTO RoleElementTemplate VALUES(51, 5, 5)
INSERT INTO RoleElementTemplate VALUES(54, 5, 5)
INSERT INTO RoleElementTemplate VALUES(55, 5, 5)
INSERT INTO RoleElementTemplate VALUES(56, 5, 5)
INSERT INTO RoleElementTemplate VALUES(63, 5, 5)
INSERT INTO RoleElementTemplate VALUES(64, 5, 5)
INSERT INTO RoleElementTemplate VALUES(65, 5, 5)
INSERT INTO RoleElementTemplate VALUES(66, 5, 5)
INSERT INTO RoleElementTemplate VALUES(67, 5, 5)
INSERT INTO RoleElementTemplate VALUES(68, 5, 5)
INSERT INTO RoleElementTemplate VALUES(88, 5, 5)
INSERT INTO RoleElementTemplate VALUES(96, 5, 5)

-- Firebag Read User
INSERT INTO RoleElementTemplate VALUES(1, 7, 5)
INSERT INTO RoleElementTemplate VALUES(33, 7, 5)
INSERT INTO RoleElementTemplate VALUES(39, 7, 5)
INSERT INTO RoleElementTemplate VALUES(47, 7, 5)
INSERT INTO RoleElementTemplate VALUES(88, 7, 5)
INSERT INTO RoleElementTemplate VALUES(96, 7, 5)

-- Firebag Admin 
INSERT INTO RoleElementTemplate VALUES(1, 37, 5)
INSERT INTO RoleElementTemplate VALUES(33, 37, 5)
INSERT INTO RoleElementTemplate VALUES(39, 37, 5)
INSERT INTO RoleElementTemplate VALUES(47, 37, 5)
INSERT INTO RoleElementTemplate VALUES(72, 37, 5)
INSERT INTO RoleElementTemplate VALUES(74, 37, 5)
INSERT INTO RoleElementTemplate VALUES(76, 37, 5)
INSERT INTO RoleElementTemplate VALUES(77, 37, 5)
INSERT INTO RoleElementTemplate VALUES(81, 37, 5)
INSERT INTO RoleElementTemplate VALUES(82, 37, 5)
INSERT INTO RoleElementTemplate VALUES(85, 37, 5)
INSERT INTO RoleElementTemplate VALUES(88, 37, 5)
INSERT INTO RoleElementTemplate VALUES(96, 37, 5)

GO
