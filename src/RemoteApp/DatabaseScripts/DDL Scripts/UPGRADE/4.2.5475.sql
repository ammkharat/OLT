---------------------------------------------------
-- Role for Configured Document Links
---------------------------------------------------
INSERT INTO RoleElement (Id, Name, FunctionalArea)
VALUES (195, 'Configure Configured Document Links', 'Admin - Work Permits');

GO

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id = 195
	and r.Name in ('Administrateur des Permis')
)

go




GO

