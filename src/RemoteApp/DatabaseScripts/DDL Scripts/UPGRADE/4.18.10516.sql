-- "View Navigation - Events" - give to: all Oilsands
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  264, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3
GO

-- "View Priorities - Events" - give to: all Oilsands
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  265, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3
GO

-- "Respond to Excursion" - give to: Oilsands - Extraction Operator (extoper), Extraction Supervisor (extsuper), Extraction Unit Leader (extulead), Operating / Chief Engineer (openg), Supervisor (super), Unit Leader (ulead), Upgrading Operator (upgoper), Upgrading Supervisor (upgsuper), Upgrading Unit Leader (upgulead)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  266, r.Id FROM [Role] r
WHERE 
  r.SiteId = 3 and r.[Alias] IN ('extoper', 'extsuper', 'extulead', 'openg', 'super', 'ulead', 'upgoper', 'upgsuper', 'upgulead')
GO



GO

