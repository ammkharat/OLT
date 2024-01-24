
insert into roleelement values
(130, 'View Lab Alert Definitions and Lab Alerts');

insert into roleelement values
(131, 'Create Lab Alert Definition');

insert into roleelement values
(132, 'Edit Lab Alert Definition');

insert into roleelement values
(133, 'Delete Lab Alert Definition');

insert into roleelement values
(134, 'Respond To Lab Alert');


go

insert into roleelementtemplate
select distinct 130,  roleid, siteid
from roleelementtemplate
where siteid = 3;

insert into roleelementtemplate
select distinct 131,  roleid, siteid
from roleelementtemplate
where siteid = 3
and roleid in (38, 39);

insert into roleelementtemplate
select distinct 132,  roleid, siteid
from roleelementtemplate
where siteid = 3
and roleid in (38, 39);

insert into roleelementtemplate
select distinct 133,  roleid, siteid
from roleelementtemplate
where siteid = 3
and roleid in (38, 39);

insert into roleelementtemplate
select distinct 134,  roleid, siteid
from roleelementtemplate
where siteid = 3
and roleid in (1, 39);


go

GO
