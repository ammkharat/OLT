insert into roleelement
values (127, 'Configure DOR Cutoff Time')

go

insert into roleelementtemplate
(roleelementid, roleid, siteid)
select 127, r.id, s.id
from site s,
role r
where 
r.name = 'Administrator'
and exists
(
	select *
	from roleelementtemplate
	where roleid = r.id
	and siteid = s.id
)

go


GO

GO
