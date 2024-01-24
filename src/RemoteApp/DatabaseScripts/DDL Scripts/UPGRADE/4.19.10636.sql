-- Clear all SWP-related role elements and template items
delete from RoleElementTemplate where RoleElementId in (select Id from roleelement where [Name]like '%Configure Work Permit Contractor%') 
  and RoleId = (select Id from Role where [Name] like 'Administrator' and SiteId = 3)
go

delete from RoleElementTemplate where RoleElementId in (select Id from roleelement where [Name]like '%Configure Craft Or Trade%')
  and RoleId = (select Id from Role where [Name] like 'Administrator' and SiteId = 3)
go

delete from RoleElementTemplate where RoleElementId in (select Id from roleelement where [Name]like '%SWP Audit%')
go

delete from roleelement where [Name]like '%SWP Audit%'
go

-- Add Administrator role element template items
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  78, r.Id FROM [Role] r
WHERE 
  r.Id = (select Id from Role where [Name] like 'Administrator' and SiteId = 3)
GO

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  81, r.Id FROM [Role] r
WHERE 
  r.Id = (select Id from Role where [Name] like 'Administrator' and SiteId = 3)
GO

-- Add SWP Audit role elements and template items
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
GO  

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
GO

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
GO

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
GO

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
GO



GO

