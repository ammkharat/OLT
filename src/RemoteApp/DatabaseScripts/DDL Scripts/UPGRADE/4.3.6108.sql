-- removing roleelementtemplate date for Edmonton that was included in the following scripts
-- 4.3.5575
-- 4.3.5715
-- 4.3.5776
-- 4.3.6062

-- because we don't want edmonton permits to show up in release 4.3
delete ret from RoleElementTemplate ret
inner join dbo.[Role] ON ret.RoleId = dbo.[Role].Id
inner join dbo.RoleElement ON ret.RoleElementId = dbo.RoleElement.Id
where 
functionalarea = 'Work Permits'
and
[role].siteid = 8

-- remove the work permits for Edmonton
delete from SiteFunctionalArea where SiteId = 8 and FunctionalArea = 6
GO

