-- Create new RoleElement "View Priorities - Document Suggestion"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (275, 'View Priorities - Document Suggestion', 'Forms')
GO

-- Create new RoleElement "Create Form - Document Suggestion"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (276, 'Create Form - Document Suggestion', 'Forms')
GO

-- Create new RoleElement "Edit Form - Document Suggestion"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (277, 'Edit Form - Document Suggestion', 'Forms')
GO

-- Create new RoleElement "Approve Form - Document Suggestion"
INSERT INTO RoleElement(Id,[Name], FunctionalArea) VALUES (278, 'Approve Form - Document Suggestion', 'Forms')
GO

-- Assign role elements to all WoodBuffalo region sites. Sites include: Firebag (SiteId: 5), MacKay (SiteId: 7), Oilsands (SiteId: 3), Pipelines (SELC) (SiteId: 13), Site Wide Services (SiteId: 6), Voyageur (a.k.a. East Tank Farm) (SiteId: 11), Wood Buffalo Labs (SiteId: 12)

-- Assign View Priorities - Document Suggestion to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  275, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Create Form - Document Suggestion to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  276, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Edit Form - Document Suggestion to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  277, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign Approve Form - Document Suggestion to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  278, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13)
GO

-- Assign View Form to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  207, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13) AND
  r.Id not in (select re.RoleId from RoleElementTemplate re where re.RoleElementId = 207)
GO

-- Assign View Navigation - Forms to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  217, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13) AND
  r.Id not in (select re.RoleId from RoleElementTemplate re where re.RoleElementId = 217)
GO

-- Assign Delete Form to all site roles
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  198, r.Id FROM [Role] r
WHERE 
  r.SiteId in (3,5,6,7,11,12,13) AND
  r.Id not in (select re.RoleId from RoleElementTemplate re where re.RoleElementId = 198)
GO











GO

