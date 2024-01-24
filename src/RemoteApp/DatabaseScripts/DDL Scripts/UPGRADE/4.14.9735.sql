INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   237  
  ,'Configure Functional Locations'  
  ,'Admin - Site Configuration');

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
   re.Id, r.Id
FROM
  Role r, RoleElement re
WHERE
  r.SiteId = 12 and r.[Name] = 'Administrator'
  and re.[Name] = 'Configure Functional Locations' and re.FunctionalArea = 'Admin - Site Configuration'
GO



GO

