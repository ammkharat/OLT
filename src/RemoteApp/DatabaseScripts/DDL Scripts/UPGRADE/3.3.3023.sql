insert into roleelement values
(136, 'Configure Default Tabs');


insert into roleelementtemplate
select distinct 136,  roleid, siteid
from roleelementtemplate
where roleid = 37;


go

GO
