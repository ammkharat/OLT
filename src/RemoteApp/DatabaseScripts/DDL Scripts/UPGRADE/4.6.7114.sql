INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (SELECT r.Id, re.Id, r.Id FROM [Role] r, [RoleElement] re
  where r.[SiteId] = 11 and r.[Name] = 'Shift Supervisor' and re.[Name] = 'Edit Summary Logs')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (SELECT r.Id, re.Id, r.Id FROM [Role] r, [RoleElement] re
  where r.[SiteId] = 11 and r.[Name] = 'Shift Supervisor' and re.[Name] = 'Delete Summary Logs')
  
-- allow Supervisor to do the following to items created by anyone else: 
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Shift Supervisor')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Shift Supervisor')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Cancel Standing Orders' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Shift Supervisor')

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Shift Supervisor')
    
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Shift Supervisor')    
    
    
-- allow Manager to do the following to items created by any other role
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Manager')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Manager')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Cancel Standing Orders' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Manager')

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Manager')
    
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Manager')        
    
-- allow Coordinator to do the following to items created by any other role
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Coordinator')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Directives' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Coordinator')
  
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Cancel Standing Orders' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Coordinator')

INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Edit Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Coordinator')
    
INSERT INTO RolePermission (RoleId,RoleElementId,CreatedByRoleId) 
  (select editrole.Id, dbo.RoleElement.Id, [Role].Id from role as editrole, roleelementtemplate
    inner join dbo.[Role] ON dbo.RoleElementTemplate.RoleId = dbo.[Role].Id
    INNER JOIN dbo.[RoleElement] ON dbo.RoleElementTemplate.RoleElementId = dbo.RoleElement.Id
    where roleelement.[name] = 'Delete Action Item Definition' and [role].siteid = 11
    and editrole.[SiteId] = 11 and editrole.[Name] = 'Coordinator')


GO

