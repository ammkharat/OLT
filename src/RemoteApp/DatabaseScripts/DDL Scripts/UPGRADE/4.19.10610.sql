INSERT INTO RoleElement(Id,Name,FunctionalArea) VALUES (272,'Set Operational Modes','Action Items & Targets')

GO

INSERT INTO RoleElementTemplate (RoleElementId, RoleId) 
SELECT re.Id, r.Id
FROM Role r, RoleElement re WHERE
      re.Name = 'Set Operational Modes'




GO

