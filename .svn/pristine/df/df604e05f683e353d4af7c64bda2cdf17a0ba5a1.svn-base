
INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
  SELECT 
    re.Id, 
    r.Id
    from Role r,
	RoleElement re
    where r.siteid = 5
    and re.Id in 
	(
	23,  -- Create Permit
    27,  -- Delete Permit
    29,  -- Update Permit at any time
    31,  -- Print permit
    46,  -- Clone with no restriction
    52  -- Close permit
	)
	and r.Name in ('Operator', 'Supervisor')
)

go



GO

