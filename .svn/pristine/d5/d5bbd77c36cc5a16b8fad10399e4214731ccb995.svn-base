---------------------------------------------------
-- Role for Work Permit Dropdowns
---------------------------------------------------
INSERT INTO RoleElement (Id, Name, FunctionalArea)
VALUES (194, 'Configure Work Permit Dropdowns', 'Admin - Work Permits');

GO


INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 9 
    and re.Id in 
	(
		194
	)
	and r.Name in ('Administrateur des Permis')
)

go



GO

