DECLARE @role as bigint;

insert into role values ('Unit Leader', 3, 0, 'UnitLeader');
set @role = @@IDENTITY

-- operator role elements
insert into roleelementtemplate
select roleelementid, @role, siteid
from roleelementtemplate
where roleid = 2
and siteid = 3

-- supervisor action item role elements
insert into roleelementtemplate values(2, @role, 3);
insert into roleelementtemplate values(3, @role, 3);
insert into roleelementtemplate values(4, @role, 3);
insert into roleelementtemplate values(6, @role, 3);
insert into roleelementtemplate values(8, @role, 3);
insert into roleelementtemplate values(11, @role, 3);

-- have to add the new unit leader role into the shift handover config role table
insert into shifthandoverconfigurationrole
select s.id, r.id
from shifthandoverconfiguration s,
role r
where s.name = 'Daily Shift Handover'
and r.id = @role

GO
