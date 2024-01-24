-- Add new security role elements to Role Matrix - Forms section.
-- "Create Form - Lubes CSD" - Give to: "Operator", "Lead Technician", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  241, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ( 'Lead Technician','Operations Coordinator')


-- "Edit Form - Lubes CSD" - Give to: "Operator", "Lead Technician", "Supervisor", "Operations Coordinator", "Engineer", "Area Team Lead".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  242, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Lead Technician', 'Operations Coordinator', 'Area Team Lead' )


-- "Approve Form - Lubes CSD - Lead Tech" - Give to: "Lead Technician", "Supervisor", "Area Team Lead".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  244, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Lead Technician', 'Area Team Lead' )


-- "Approve Form - Lubes CSD - Area Team Lead" - Give to: "Supervisor", "Area Team Lead".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  245, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Area Team Lead' )
  
  
-- "Approve Form - Lubes CSD - Director of Production" - Give to "Area Team Lead".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  246, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Area Team Lead' )  


-- "Close Form - Lubes CSD" - Give to: "Lead Technician", "Supervisor".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  247, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Lead Technician') 
  
    
 
-- "No approval require for Lubes CSD End Date Change" - Give to "Supervisor" and "Operations Coordinator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  249, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operations Coordinator') 
   
   

-- Add new security role elements to the Shift Handover section.
-- "Show Active CSDs on Shift Handover Report" - Give to "Supervisor" and "Lead Technician".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  250, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Lead Technician') 
   
   
   
-- Assign existing security role elements found in the Role Matrix - Forms section.  
-- "Delete Form" - Give to "Operator", "Lead Technician", "Supervisor", "Operations Coordinator".
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  198, r.Id FROM [Role] r -- 198 "Delete Form"
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Lead Technician', 'Operations Coordinator')  
  

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  196, r.Id FROM [Role] r -- 196 "Create Form"
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'Lead Technician', 'Supervisor', 'Operations Coordinator')  

GO



GO

