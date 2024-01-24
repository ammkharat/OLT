-- Create new RoleElement "View Priorities - Directives"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (267, 'View Priorities - Directives', 'Directives')
GO

-- Create new RoleElement "View Directives"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (268, 'View Directives', 'Directives')
GO

-- Create new RoleElement "Create Directives"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (269, 'Create Directives', 'Directives')
GO

-- Create new RoleElement "Edit Directives"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (270, 'Edit Directives', 'Directives')
GO

-- Create new RoleElement "Delete Directives"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (271, 'Delete Directives', 'Directives')
GO

-- For all sites not using LogBasedDirectives in site config, add RoleElementTemplates for the new RoleElements, and remove the old ones

--Migrate Montreal, Wood Buffalo, Edmonton Pipelines (SELC) View Priorities - Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  267, r.Id FROM [Role] r
WHERE 
  r.SiteId in (9,12,13) and r.[Id] IN 
  (
    select r.[Id]
    from RoleElementTemplate rt
    inner join RoleElement re on rt.RoleElementId = re.Id and re.Id in (220)
    inner join Role r on r.Id = rt.RoleId
  )
GO

--Migrate Montreal, Wood Buffalo, Edmonton Pipelines (SELC) View Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  268, r.Id FROM [Role] r
WHERE 
  r.SiteId in (9,12,13) and r.[Id] IN 
  (
    select r.[Id]
    from RoleElementTemplate rt
    inner join RoleElement re on rt.RoleElementId = re.Id and re.Id in (96)
    inner join Role r on r.Id = rt.RoleId
  )
GO

--Migrate Montreal, Wood Buffalo, Edmonton Pipelines (SELC) Create Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  269, r.Id FROM [Role] r
WHERE 
  r.SiteId in (9,12,13) and r.[Id] IN 
  (
    select r.[Id]
    from RoleElementTemplate rt
    inner join RoleElement re on rt.RoleElementId = re.Id and re.Id in (97)
    inner join Role r on r.Id = rt.RoleId
  )
GO

--Migrate Montreal, Wood Buffalo, Edmonton Pipelines (SELC) Edit Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  270, r.Id FROM [Role] r
WHERE 
  r.SiteId in (9,12,13) and r.[Id] IN 
  (
    select r.[Id]
    from RoleElementTemplate rt
    inner join RoleElement re on rt.RoleElementId = re.Id and re.Id in (98)
    inner join Role r on r.Id = rt.RoleId
  )
GO

--Migrate Montreal, Wood Buffalo, Edmonton Pipelines (SELC) Delete Directives
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  271, r.Id FROM [Role] r
WHERE 
  r.SiteId in (9,12,13) and r.[Id] IN 
  (
    select r.[Id]
    from RoleElementTemplate rt
    inner join RoleElement re on rt.RoleElementId = re.Id and re.Id in (99)
    inner join Role r on r.Id = rt.RoleId
  )
GO

-- Remove the OLD RoleElementTemplates for the migrated sites
DELETE FROM RoleElementTemplate 
WHERE RoleElementId IN (220, 96, 97, 98, 99, 177, 178) -- view [OLD] priorities, view directives, create, edit, delete, cancel standing orders, view standing orders
AND RoleId IN (SELECT r.[Id] FROM Role r WHERE r.SiteId IN (9,12,13))
GO

--Remove the OLD RolePermissions for fully migrated sites (not for sites that are still using OLD directives as well)
DELETE FROM RolePermission
WHERE RoleId IN (SELECT r.Id FROM Role r WHERE SiteId IN (9,12,13))
AND RoleElementId IN (220,177,178,96,97,98,99)
GO

--Add Edit Directives RolePermissions for Montreal - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 9 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 9 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 270, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO

--Add Delete Directives RolePermissions for Montreal - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 9 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 9 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 271, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO

--Add Edit Directives RolePermissions for Wood Buffalo - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 12 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 12 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 270, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO

--Add Delete Directives RolePermissions for Wood Buffalo - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 12 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 12 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 271, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO

--Add Edit Directives RolePermissions for SELC - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 13 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 13 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 270, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO

--Add Delete Directives RolePermissions for SELC - all users with Edit Directives
;WITH CreateRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 13 and RoleElementId = 269)
),
EditRole ([Id], [Name])
AS
(
  SELECT r.[Id], r.[Name] 
  FROM Role r 
    INNER JOIN RoleElementTemplate ret 
    ON ret.RoleId = r.Id AND 
    r.[Id] IN (SELECT r.[Id] FROM Role r WHERE r.SiteId = 13 and RoleElementId = 270)
)
INSERT INTO RolePermission (RoleId, RoleElementId, CreatedByRoleId)
SELECT er.[Id] EditRoleId, 271, cr.[Id] CreateRoleId 
FROM CreateRole cr CROSS JOIN EditRole er
GO








