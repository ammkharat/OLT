INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   259   -- Id - bigint
  ,'Create Form - SWP Audit'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  259, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Name] IN ('Upgrading Supervisor', 'Extraction Supervisor', 'Supervisor', 'Upgrading Area Manager', 'Extraction Area Manager', 'Area Manager', 'OEMS Admin', 'SWP Audit Entry Clerk')
  

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   260   -- Id - bigint
  ,'Edit Form - SWP Audit'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  260, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Name] IN ('Upgrading Supervisor', 'Extraction Supervisor', 'Supervisor', 'Upgrading Area Manager', 'Extraction Area Manager', 'Area Manager', 'OEMS Admin', 'SWP Audit Entry Clerk')

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   261   -- Id - bigint
  ,'Cancel Form During Shift - SWP Audit'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  261, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Name] IN ('Upgrading Supervisor', 'Extraction Supervisor', 'Supervisor', 'Upgrading Area Manager', 'Extraction Area Manager', 'Area Manager', 'OEMS Admin', 'SWP Audit Entry Clerk')

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   262   -- Id - bigint
  ,'Cancel Form Anytime - SWP Audit'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  262, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Name] IN ('OEMS Admin')

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   263   -- Id - bigint
  ,'Admin Form - SWP Audit'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  263, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Name] IN ('OEMS Admin')
----------------

-- add view form to rest of oilsands roles that don't have it
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  207, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.id IN (148,195,196,197,198)

-- add view navigation forms to rest of oilsands roles that don't have it
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  217, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.id IN (195,196,197,198)

-- add view priorities forms to rest of oilsands roles that don't have it
INSERT INTO RoleElementTemplate(
   RoleElementId
  ,RoleId
) SELECT 
  221, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.id IN (148,195,196,197,198)


GO

