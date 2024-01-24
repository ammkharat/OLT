INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   238   -- Id - bigint
  ,'View Form - Overtime Request'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)


INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  238, r.Id FROM [Role] r
WHERE 
  r.SiteId = 8 and r.[Name] IN ('Contractor / Tradesperson', 'Supervisor', 'Scheduler', 'Support Coordinator', 'Administrator')
  
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   239   -- Id - bigint
  ,'Approve Form - Overtime Request'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  239, r.Id FROM [Role] r
WHERE 
  r.SiteId = 8 and r.[Name] IN ('Supervisor', 'Scheduler', 'Support Coordinator', 'Administrator')



GO

