INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
	SELECT re.Id, r.Id from Role r,	RoleElement re
	where r.siteid = 9 and 
	re.Id in (2, 3, 4, 6, 8, 11)
	and r.Name in ('Superviseur')
)


GO

