delete from RoleElementTemplate
where RoleElementId in 
(
	66, 67, 68, 
	69, 70, 71, 
	123, 124, 125, 
	143, 144, 145, 
	155, 156, 157,
	158, 159, 160,
	161, 162, 163,
	164, 165, 166,
	167, 168, 169,
	170, 171, 172,
	173, 174, 175
);

go

delete from RoleElement
where Id in 
(
	66, 67, 68, 
	69, 70, 71,  
	123, 124, 125, 
	143, 144, 145, 
	155, 156, 157,
	158, 159, 160,
	161, 162, 163,
	164, 165, 166,
	167, 168, 169,
	170, 171, 172,
	173, 174, 175
);

go

delete from RoleElementTemplate
where RoleElementId in 
(
	137, 138, 140,
	146, 147, 148
);

go

delete from RoleElement
where Id in 
(
	137, 138, 140,
	146, 147, 148
);

go

update RoleElement
set name = 'Create Directives'
where id = 97 and name = 'Create (Area Manager) Directives';

update RoleElement
set name = 'Edit Directives'
where id = 98 and name = 'Edit (Area Manager) Directives';

update RoleElement
set name = 'Delete (Directives'
where id = 99 and name = 'Delete (Area Manager) Directives';

update RoleElement
set FunctionalArea = 'Logs'
where id = 54 and name = 'View/Edit Log Definitions'

go


GO
