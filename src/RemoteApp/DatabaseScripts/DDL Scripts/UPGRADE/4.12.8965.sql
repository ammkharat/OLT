

delete from RoleElementTemplate
where RoleId in (select Id from Role where SiteId = 5) and
      RoleElementId in (select Id from RoleElement where Name in ('Configure Work Permit Contractor', 'Configure Craft Or Trade'))
go

update CraftOrTrade set Deleted = 1 where SiteId = 5;






GO

