update roleelement
set FunctionalArea = 'Admin - Site Configuration'
where id = 179 and name = 'Configure Priorities Page';

go

insert into roleelement(id, name, functionalarea)
values (181, 'View Permit Requests', 'Work Permits');

insert into roleelement(id, name, functionalarea)
values (182, 'Create Permit Request', 'Work Permits');

insert into roleelement(id, name, functionalarea)
values (183, 'Edit Permit Request', 'Work Permits');

insert into roleelement(id, name, functionalarea)
values (184, 'Delete Permit Request', 'Work Permits');

insert into roleelement(id, name, functionalarea)
values (185, 'Convert Permit Request to Work Permit', 'Work Permits');

go



GO
