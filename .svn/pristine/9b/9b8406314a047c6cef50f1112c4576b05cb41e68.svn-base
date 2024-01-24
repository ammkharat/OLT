

delete from RoleElementTemplate 
where RoleElementId in (select Id from RoleElement where Name = 'View Permit Requests') and
      RoleId in (select Id from Role where Name = 'Operator' and SiteId = 10)



GO

