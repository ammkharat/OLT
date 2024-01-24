

INSERT INTO RoleElement (Id, Name, FunctionalArea) VALUES (199, 'Edit Form', 'Forms');

GO

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id from Role r, RoleElement re
  where r.siteid = 8
        and re.Id in (199)
)



GO

