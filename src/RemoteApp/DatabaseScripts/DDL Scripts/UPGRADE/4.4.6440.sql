INSERT INTO RoleElement (Id, Name, FunctionalArea) VALUES (198, 'Delete Form', 'Forms');

GO

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id from Role r, RoleElement re
  where r.siteid = 8
        and re.Id in (198)
	    and r.Name in ('Supervisor', 'Operator', 'Operating / Chief Engineer', 'Coordinator / Area Team Lead', 'Unit Leader', 'Contractor / Tradesperson', 'Scheduler')
)
