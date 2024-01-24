
-- Delete confined space ossa table

DROP TABLE dbo.ConfinedSpaceOssa
GO

-- Give everyone in Firebag permission to view work permits (role element 24)

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
	SELECT re.Id, r.Id
	FROM Role r, RoleElement re
	WHERE r.SiteId = 5 AND
	      re.Id = 24
)

GO

-- Revoke access to view confined space documents in Firebag

DELETE FROM dbo.RoleElementTemplate
WHERE RoleElementId = 192 AND
	RoleId IN (SELECT r.Id FROM Role r WHERE r.SiteId = 5)
	
GO



GO

