

-- trade supervisors should be able to delete the request of any trade supervisor (#2662)
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    (SELECT r.Id, re.Id, createRole.Id FROM [Role] r, [RoleElement] re, [Role] createRole   where r.[SiteId] = 10 and createRole.[SiteId] = 10 and r.[Name] = 'Trade Supervisor' and re.[Name] = 'Delete Permit Request' and createRole.[Name]= 'Trade Supervisor')

-- everybody who can delete permit requests (except trade supervisors) should be able to delete permit requests made by any other role that can delete permit requests (#2680, #2472)
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId)    
(SELECT r.Id, re.Id, createRole.Id 
FROM [Role] r, [RoleElement] re, [Role] createRole   
where r.[SiteId] = 10 and createRole.[SiteId] = 10 and 
      r.[Name] in ('Maintenance Coordinator', 'Operations Coordinator', 'Scheduler', 'Supervisor') and
      createRole.[Name] in ('Maintenance Coordinator', 'Operations Coordinator', 'Scheduler', 'Supervisor', 'Trade Supervisor') and	  
	  re.[Name] = 'Delete Permit Request')





GO

