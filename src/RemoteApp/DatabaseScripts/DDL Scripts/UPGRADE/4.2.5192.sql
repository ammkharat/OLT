
-- #1619 (Navigate confined space data using a grid)


-- Let Firebag see the work permits section of the app

INSERT INTO dbo.SiteFunctionalArea (SiteId, FunctionalArea) VALUES (5, 6)   -- Firebag, Work Permits

GO

-- Give everyone in Firebag permission to view confined space documents (role element 192)

INSERT INTO dbo.RoleElementTemplate ([RoleElementId], [RoleId])
(
	SELECT re.Id, r.Id
	FROM Role r, RoleElement re
	WHERE r.SiteId = 5 AND
	      re.Id = 192
)

GO



GO

