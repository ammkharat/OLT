-- Remove all Role Permissions for Work Permits in Firebag
DELETE ret 
FROM RoleElementTemplate ret
INNER JOIN dbo.[Role] r ON ret.RoleId = r.Id
INNER JOIN dbo.RoleElement re ON ret.RoleElementId = re.Id
WHERE re.FunctionalArea = 'Work Permits'
AND r.SiteId = 5


GO

