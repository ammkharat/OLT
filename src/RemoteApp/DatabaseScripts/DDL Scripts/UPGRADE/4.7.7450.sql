

delete from RoleElementTemplate
where RoleElementId = 10  -- Comment Action Item Definition
and RoleId in (select Id from Role where SiteId = 8 and Name in ('TA Tech', 'Operator'))



GO

