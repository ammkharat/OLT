
-- #1979

DELETE FROM RoleElementTemplate
WHERE RoleId in (select r.Id from Role r where r.SiteId = 8) and
      RoleElementId in (select re.Id from RoleElement re where re.Name in ('Configure Work Permit Dropdowns'))

go

DELETE FROM DropdownValue
WHERE [Key] = 'work_permit_groups'

go





GO

