insert into roleelement
values (126, 'Edit DOR Comments')

go

insert into roleelementtemplate
(roleelementid, roleid, siteid)
select 126, r.id, s.id
from site s,
role r
where 
r.name = 'Area Manager'
and exists
(
	select *
	from roleelementtemplate
	where roleid = r.id
	and siteid = s.id
)

go


GO
