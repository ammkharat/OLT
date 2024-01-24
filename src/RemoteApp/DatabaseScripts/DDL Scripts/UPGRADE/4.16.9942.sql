-- Add new security role elements to Role Matrix - Forms section.
-- "Create Form - Lubes CSD" - Give to: "Operator", "Lead Technician", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   241   -- Id - bigint
  ,'Create Form - Lubes CSD'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  241, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator')


-- "Edit Form - Lubes CSD" - Give to: "Operator", "Lead Technician", "Supervisor", "Operations Coordinator", "Engineer", "Area Team Lead".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   242   -- Id - bigint
  ,'Edit Form - Lubes CSD'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  242, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator', 'Engineering', 'AreaTeamLead' )

-- "Approve Form - Lubes CSD - Process Engineer" - Give to "Engineer".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   243   -- Id - bigint
  ,'Approve Form - Lubes CSD - Process Engineer'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  243, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Engineering')


-- "Approve Form - Lubes CSD - Lead Tech" - Give to: "Lead Technician", "Supervisor", "Area Team Lead".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   244   -- Id - bigint
  ,'Approve Form - Lubes CSD - Lead Tech'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  244, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('LeadTechnician', 'Supervisor', 'AreaTeamLead' )


-- "Approve Form - Lubes CSD - Area Team Lead" - Give to: "Supervisor", "Area Team Lead".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   245   -- Id - bigint
  ,'Approve Form - Lubes CSD - Area Team Lead'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  245, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Supervisor', 'AreaTeamLead' )
  
  
-- "Approve Form - Lubes CSD - Director of Production" - Give to "Area Team Lead".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   246   -- Id - bigint
  ,'Approve Form - Lubes CSD - Director of Production'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  246, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('AreaTeamLead' )  


-- "Close Form - Lubes CSD" - Give to: "Lead Technician", "Supervisor".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   247   -- Id - bigint
  ,'Close Form - Lubes CSD'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  247, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('LeadTechnician', 'Supervisor') 
  
  
-- "View Priorities - Lubes CSD" - Give to all Lubes site roles.
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   248   -- Id - bigint
  ,'View Priorities - Lubes CSD'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  248, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10
  
 
-- "No approval require for Lubes CSD End Date Change" - Give to "Supervisor" and "Operations Coordinator".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   249   -- Id - bigint
  ,'No approval require for Lubes CSD End Date Change'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  249, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Supervisor', 'OperationsCoordinator') 
   
   

-- Add new security role elements to the Shift Handover section.
-- "Show Active CSDs on Shift Handover Report" - Give to "Supervisor" and "Lead Technician".
INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   250   -- Id - bigint
  ,'Show Active CSDs on Shift Handover Report'  -- Name - varchar(60)
  ,'Shift Handovers'  -- FunctionalArea - varchar(100)
)
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  250, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Supervisor', 'LeadTechnician') 
   
   
   
-- Assign existing security role elements found in the Role Matrix - Forms section.
-- "View Form" - Give to all Lubes site roles.   
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  207, r.Id FROM [Role] r -- 207 "View Form"
WHERE 
  r.SiteId = 10    
   
   
-- "View Navigation - Forms" - Give to all Lubes site roles.   
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  217, r.Id FROM [Role] r -- 217 "View Navigation - Forms"
WHERE 
  r.SiteId = 10     
  
  
-- "View Priorities - Forms" - Give to all Lubes site roles.
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  221, r.Id FROM [Role] r -- 221 "View Priorities - Forms"
WHERE 
  r.SiteId = 10     
  
-- "Delete Form" - Give to "Operator", "Lead Technician", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  198, r.Id FROM [Role] r -- 198 "Delete Form"
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'LeadTechnician', 'Supervisor', 'OperationsCoordinator')  
  

-- "Configure Form Templates" - Give to the "Administrator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  200, r.Id FROM [Role] r -- 200 "Configure Form Templates"
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Administrator')  



GO

