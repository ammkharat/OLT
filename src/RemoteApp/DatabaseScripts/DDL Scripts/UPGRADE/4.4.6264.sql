
-- #1942
-- Make it so that people in Montreal who can create directives can also delete them (across roles)

insert into RolePermission (RoleId, RoleElementId, CreatedByRoleId)
select r.Id, re.Id, r2.Id
from Role r, RoleElement re, Role r2
where r.SiteId = 9 and r.Name in ('Superviseur', 'Leader de  Secteur', 'Coordonnateur des Opérations', 'Ingénieur', 'Coordonnateur de l''Entretien') and      
      re.Name in ('Delete Directives') and
      r2.Name in ('Superviseur', 'Leader de  Secteur', 'Coordonnateur des Opérations', 'Ingénieur', 'Coordonnateur de l''Entretien')

go





GO

