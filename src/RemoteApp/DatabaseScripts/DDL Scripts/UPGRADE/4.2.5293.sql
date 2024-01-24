-- 181, "View Permit Requests
-- 182, "Create Permit Request
-- 83, "Edit Permit Request
-- 184, "Delete Permit Request
-- 185, "Submit Permit Request
-- 186, "Import Permit Requests

-- Read permission for everyone in FB
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id
  from Role r, RoleElement re
  where r.siteid = 5
  and re.Id = 181
);

-- operators and supervisors
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT re.Id, r.Id
  from Role r,RoleElement re
  where r.siteid = 5 
  and re.Id in (182, 183, 184, 185, 186)
  and r.Name in ('Operator', 'Supervisor')
);


	
	



GO

