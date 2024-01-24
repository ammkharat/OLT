insert into roleelementtemplate
select e.id, r.id, 8
from role r,
roleelement e
where r.name = 'Area Manager'
and e.id in (2, 3, 73)

go

insert into roleelementtemplate
select e.id, r.id, 8
from role r,
roleelement e
where r.name in ('Unit Leader', 'Operator')
and e.id in (121)

go




GO
