INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  255, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('LeadTechnician', 'OperationsCoordinator')
GO

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  256, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('LeadTechnician')
GO

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  257, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('OperationsCoordinator') 
GO 

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  258, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('OperationsCoordinator') 
GO   






GO

