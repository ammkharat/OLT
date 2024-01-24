alter table DeviationAlert add Comments varchar(2048) null;

GO

insert into roleelement
values (128, 'Edit Deviation Alert Comment')

GO

insert into roleelementtemplate (roleelementid, roleid, siteid)
select 128, r.id, 3
from role r where r.name = 'Operating Engineer'

GO

GO
