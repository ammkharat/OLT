INSERT INTO RoleElement (Id, Name, FunctionalArea)
VALUES (197, 'Clone Permit Request', 'Work Permits');

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id
  from Role r,
	   RoleElement re
  where r.siteid = 8
        and re.Id in (197)
	    and r.Name in ('Supervisor', 'Scheduler')
)
GO