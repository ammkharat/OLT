-- User Story #791
-- Created February 23, 2011
-- To remove permissions for a Unit Leader in Oilsands so that they cannot create, approve, reject, edit, and un-approve Action Item -- Definitions.

-- To verify the selection
/* select * from RoleElementTemplate where 
siteId = (select Id from Site where name = 'Oilsands')
and roleId = (select Id from Role where name = 'Unit Leader')
and RoleElementId in
(select Id from RoleElement where name in
	('Approve Action Item Definition', 
	'Reject Action Item Definition', 
	'Create Action Item Definition',
	'Edit Action Item Definition',
	'Delete Action Item Definition',
	'Toggle Approval Required for Action Item Definition')) */
	
	
	
Delete from RoleElementTemplate 
where siteId = (select Id from Site where name = 'Oilsands')
and roleId = (select Id from Role where name = 'Unit Leader')
and RoleElementId in
	(select Id from RoleElement where name in
		('Approve Action Item Definition', 
		'Reject Action Item Definition', 
		'Create Action Item Definition',
		'Edit Action Item Definition',
		'Delete Action Item Definition',
		'Toggle Approval Required for Action Item Definition'));

go		
GO
