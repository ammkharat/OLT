ALTER TABLE RoleElement ALTER COLUMN [Name] VARCHAR(100) NOT NULL
GO

-- Add new security role elements to Role Matrix - Forms section.
-- "Create Form - Lubes Alarm Temporary Disable" - Give to: "Operator", "Lead Technician", "Supervisor", Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   253   -- Id - bigint
  ,'Create Form - Lubes Alarm Temporary Disable'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  253, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator')
GO

-- "Edit Form - Lubes Alarm Temporary Disable" - Give to: "Operator", "Lead Technicians", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   254   -- Id - bigint
  ,'Edit Form - Lubes Alarm Temporary Disable'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  254, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[ActiveDirectoryKey] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator')
GO


-- "Delete Form - Lubes Alarm Temporary Disable" - Give to "Operators", "Lead Technician", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   255   -- Id - bigint
  ,'Delete Form - Lubes Alarm Temporary Disable'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  255, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator')
GO

  
-- "Approve Form - Lubes Temporary Alarm Disable" - Give to: "Lead Technician", "Supervisor".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   256   -- Id - bigint
  ,'Approve Form - Lubes Temporary Alarm Disable'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  256, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('LeadTechnician', 'Supervisor')
GO


-- "Close Form - Lubes Temporary Alarm Disable" - Give to: "Supervisor", "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   257   -- Id - bigint
  ,'Close Form - Lubes Temporary Alarm Disable'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  257, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Supervisor', 'OperationsCoordinator') 
GO 
  
  
-- "No approval require for Lubes Temporary Alarm Disable End Date Change" - Give to "Supervisor" and "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   258   -- Id - bigint
  ,'No approval require for Lubes Temporary Alarm Disable End Date Change'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  258, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Supervisor', 'OperationsCoordinator') 
GO   
  
  
  
-- Assign existing security role elements found in the Role Matrix - Forms section.
-- "Configure Form Dropdowns" - Give to "Administrator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  251, r.Id FROM [Role] r -- 251 "Configure Form Dropdowns"
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Administrator')  
GO




GO

