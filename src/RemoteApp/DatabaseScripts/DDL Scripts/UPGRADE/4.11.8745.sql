
insert into RoleElement (Id, Name, FunctionalArea) values (230, 'No approval required for GN-6 End Date Change', 'Forms');
go  
  
INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Coordinator / Area Team Lead' and re.[Name] = 'No approval required for GN-6 End Date Change';  
go  


GO

