update Role
set Name = 'Ops Coordinator / Area Team Lead'
where siteid in (8)
and Name = 'Area Manager'
;

update Role
set Name = 'Operating / Chief Engineer'
where siteid in (3, 5, 8)
and Name = 'Operating Engineer'
;

-- delete op eng directive role elements from sarnia
delete from RoleElementTemplate
from RoleElementTemplate
where RoleElementId in (137, 138, 140)
and RoleId in (select Id from Role where SiteId = 1)
;

-- delete op eng directive role elements from mackay
delete from RoleElementTemplate
where RoleElementId in (137, 138, 140)
and RoleId in (select Id from Role where SiteId = 7)
;

-- remove deviation alert roleelements for TA roles
delete from RoleElementTemplate
where RoleElementId in (104, 105, 106, 110, 128)
and RoleId in 
(
	select Id from Role where SiteId = 3 and name in
	(
		'TA Coordinator',
		'TA Director',
		'TA Engineer',
		'TA Execution Manager',
		'TA Manager'
	)
)
;


go


GO
