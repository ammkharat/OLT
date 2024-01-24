-- #2309
DELETE FROM RoleElementTemplate
WHERE RoleId in (select r.Id from Role r where r.SiteId = 8 and r.[Name] = 'Operator') and
      RoleElementId in (select re.Id from RoleElement re where re.Name in ('View Permit Requests'))



GO

