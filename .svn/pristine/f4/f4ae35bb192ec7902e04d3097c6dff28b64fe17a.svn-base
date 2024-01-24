update RoleDisplayConfiguration
set PrimaryDefaultPageID = 17,
SecondaryDefaultPageId = null
where RoleId in (select id from Role where siteid = 9 and name = 'Opérateur')
and SectionId = 6;

delete from RoleDisplayConfiguration
where RoleId in (select id from Role where siteid = 9 and name in ('Administrateur des Permis', 'Coordonnateur des Opérations'))
and SectionId = 8;

go



GO

